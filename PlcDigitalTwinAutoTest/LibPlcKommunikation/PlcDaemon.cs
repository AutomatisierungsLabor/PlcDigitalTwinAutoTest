using System.Net.NetworkInformation;
using LibDatenstruktur;
using Newtonsoft.Json;

namespace LibPlcKommunikation;

public class PlcDaemon
{
    private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);

    public IPlc Plc { get; set; }

    private readonly Datenstruktur _datenstruktur;

    private readonly IpAdressenSiemens _ipAdressenSiemens;
    private readonly IpAdressenBeckhoff _ipAdressenBeckhoff;
    private PlcDaemonStatus _plcDaemonStatus;


    private enum PlcDaemonStatus
    {
        SpsPingen = 0,
        SpsBeckhoff = 1,
        SpsSiemens = 2,
        SpsAktiv = 3
    }


    public PlcDaemon(Datenstruktur datenstruktur)
    {
        Log.Debug("gestartet!");

        Plc = new PlcKeine(datenstruktur);

        _datenstruktur = datenstruktur;

        try
        {
            _ipAdressenSiemens = JsonConvert.DeserializeObject<IpAdressenSiemens>(File.ReadAllText("IpAdressenSiemens.json"));
        }
        catch (Exception ex)
        {
            Log.Debug("Datei nicht gefunden: IpAdressenSiemens.json" + ex);
        }

        try
        {
            _ipAdressenBeckhoff = JsonConvert.DeserializeObject<IpAdressenBeckhoff>(File.ReadAllText("IpAdressenBeckhoff.json"));
        }
        catch (Exception ex)
        {
            Log.Debug("Datei nicht gefunden: IpAdressenBeckhoff.json" + ex);
        }

        Task.Run(PlcDaemonTask);
    }



    private void PlcDaemonTask()
    {

        var pingBeckhoff = new Ping();
        var pingSiemens = new Ping();

        while (true)
        {
            switch (_plcDaemonStatus)
            {
                case PlcDaemonStatus.SpsPingen:
                    try
                    {
                        var replyBeckhoff = pingBeckhoff.Send(_ipAdressenBeckhoff.IpAdresse);
                        var replySiemens = pingSiemens.Send(_ipAdressenSiemens.Adress);

                        if (replyBeckhoff is { Status: IPStatus.Success }) _plcDaemonStatus = PlcDaemonStatus.SpsBeckhoff;
                        if (replySiemens is { Status: IPStatus.Success }) _plcDaemonStatus = PlcDaemonStatus.SpsSiemens;
                    }
                    catch (Exception ex)
                    {
                        Log.Debug("Problem beim pingen:" + ex);
                    }
                    break;

                case PlcDaemonStatus.SpsBeckhoff:
                    Plc = new PlcBeckhoff(_ipAdressenBeckhoff, _datenstruktur);
                    _plcDaemonStatus = PlcDaemonStatus.SpsAktiv;
                    break;

                case PlcDaemonStatus.SpsSiemens:
                    Plc = new PlcSiemens(_ipAdressenSiemens, _datenstruktur);
                    _plcDaemonStatus = PlcDaemonStatus.SpsAktiv;
                    break;

                case PlcDaemonStatus.SpsAktiv:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            Thread.Sleep(10);
        }
        // ReSharper disable once FunctionNeverReturns
    }
}