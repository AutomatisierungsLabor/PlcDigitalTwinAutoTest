using System.Net.NetworkInformation;
using System.Text;
using LibDatenstruktur;
using Newtonsoft.Json;

namespace LibPlcKommunikation;



public class PlcDaemon
{
    private enum PlcDaemonStatus
    {
        SpsPingen = 0,
        SpsBeckhoff = 1,
        SpsSiemens = 2
    }

    private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);

    public PlcKeine PlcKeine { get; set; }
    public PlcBeckhoff PlcBeckhoff { get; set; }
    public PlcSiemens PlcSiemens { get; set; }
    public PlcState PlcState { get; set; }

    public byte[] Pc2Plc = new byte[1024];
    public byte[] Plc2Pc = new byte[1024];

    private readonly Datenstruktur _datenstruktur;
    private readonly IpAdressenSiemens _ipAdressenSiemens;
    private readonly IpAdressenBeckhoff _ipAdressenBeckhoff;
    private PlcDaemonStatus _plcDaemonStatus;

    public PlcDaemon(Datenstruktur datenstruktur)
    {
        Log.Debug("Daemon gestartet");

        _datenstruktur = datenstruktur;
        _plcDaemonStatus = PlcDaemonStatus.SpsPingen;
        Log.Debug("SPS pingen");

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

        PlcKeine = new PlcKeine(_datenstruktur);
        PlcBeckhoff = new PlcBeckhoff(_ipAdressenBeckhoff, Pc2Plc, Plc2Pc);
        PlcSiemens = new PlcSiemens(_ipAdressenSiemens, Pc2Plc, Plc2Pc);

        Task.Run(PlcDaemonTask);
    }
    private void PlcDaemonTask()
    {
        var pingBeckhoff = new Ping();
        var pingSiemens = new Ping();

        PlcKeine.PlcTask();
        PlcState = PlcKeine.State;

        while (true)
        {
            switch (_plcDaemonStatus)
            {
                case PlcDaemonStatus.SpsPingen:

                    try
                    {
                        var replyBeckhoff = pingBeckhoff.Send(_ipAdressenBeckhoff.IpAdresse);
                        var replySiemens = pingSiemens.Send(_ipAdressenSiemens.Adress);

                        if (replyBeckhoff is { Status: IPStatus.Success })
                        {
                            Log.Debug("Beckhoff SPS erkannt");
                            _plcDaemonStatus = PlcDaemonStatus.SpsBeckhoff;
                        }

                        if (replySiemens is { Status: IPStatus.Success })
                        {
                            Log.Debug("Siemens SPS erkannt");
                            _plcDaemonStatus = PlcDaemonStatus.SpsSiemens;
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.Debug("Problem beim pingen:" + ex);
                    }
                    break;

                case PlcDaemonStatus.SpsBeckhoff:
                    PlcBeckhoff.PlcTask();
                    PlcState = PlcBeckhoff.State;
                    if (PlcBeckhoff.State.PlcError) _plcDaemonStatus = PlcDaemonStatus.SpsPingen;
                    break;

                case PlcDaemonStatus.SpsSiemens:
                    PlcSiemens.PlcTask();
                    PlcState = PlcSiemens.State;
                    if (PlcSiemens.State.PlcError) _plcDaemonStatus = PlcDaemonStatus.SpsPingen;
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            DatenPc2PlcRangieren();

            Thread.Sleep(10);
        }
        // ReSharper disable once FunctionNeverReturns
    }
    private void DatenPc2PlcRangieren()
    {
        //https://support.industry.siemens.com/cs/ww/de/view/109747136
        // S7-1200: 240 Byte
        // 222 Byte maximal

        const int anzDi = 32;
        const int anzAi = 64;
        const int anzBefehle = 32;

        const int anzDa = 32;
        const int anzAa = 64;
        const int anzVersionsbez = 64;
        // ReSharper disable InlineTemporaryVariable
        const int anfangDi = 0;
        const int anfangAi = anzDi;
        const int anfangBefehle = anfangAi + anzAi;

        const int anfangDa = 0;
        const int anfangAa = anzDa;
        const int anfangVersion = anfangAa + anzDa;
        // ReSharper restore InlineTemporaryVariable

        var versionsStringPlc = new byte[256];

        if (anzDi + anzAi + anzBefehle > PlcSiemens.AnzBytePc2Plc) throw new ArgumentOutOfRangeException();
        if (anzDa + anzAa + anzVersionsbez > PlcSiemens.AnzBytePlc2Pc) throw new ArgumentOutOfRangeException();

        Buffer.BlockCopy(_datenstruktur.Di, 0, Pc2Plc, anfangDi, anzDi);
        Buffer.BlockCopy(_datenstruktur.Ai, 0, Pc2Plc, anfangAi, anzAi);
        Buffer.BlockCopy(_datenstruktur.BefehlePlc, 0, Pc2Plc, anfangBefehle, anzBefehle);

        Buffer.BlockCopy(Plc2Pc, anfangDa, _datenstruktur.Da, 0, anzDa);
        Buffer.BlockCopy(Plc2Pc, anfangAa, _datenstruktur.Aa, 0, anzAa);
        Buffer.BlockCopy(Plc2Pc, anfangVersion, versionsStringPlc, 0, anzVersionsbez);

        var textLaenge = 0;
        for (var i = 0; i < 255; i++)
        {
            if (versionsStringPlc[i] != 0) continue;
            textLaenge = i;
            break;
        }
        var enc = new ASCIIEncoding();
        _datenstruktur.VersionsStringPlc = enc.GetString(versionsStringPlc, 0, textLaenge);
    }
}