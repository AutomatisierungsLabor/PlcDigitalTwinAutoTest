using LibDatenstruktur;
using Newtonsoft.Json;
using System.Net.NetworkInformation;
using System.Text;

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


    public PlcState PlcState { get; set; }

    private readonly byte[] _pcToPlc;
    private readonly byte[] _plcToPc;

    private readonly PlcKeine _plcKeine;
    private readonly PlcBeckhoff _plcBeckhoff;
    private readonly PlcSiemens _plcSiemens;
    private readonly Datenstruktur _datenstruktur;
    private readonly IpAdressenSiemens _ipAdressenSiemens;
    private readonly IpAdressenBeckhoff _ipAdressenBeckhoff;
    private PlcDaemonStatus _plcDaemonStatus;
    private readonly CancellationTokenSource _cancellationTokenSource;

    public PlcDaemon(Datenstruktur datenstruktur, CancellationTokenSource cancellationTokenSource)
    {
        Log.Debug("Daemon gestartet");

        _datenstruktur = datenstruktur;
        _plcDaemonStatus = PlcDaemonStatus.SpsPingen;
        _cancellationTokenSource = cancellationTokenSource;

        _pcToPlc = new byte[1024];
        _plcToPc = new byte[1024];

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

        _plcKeine = new PlcKeine(_datenstruktur);
        _plcBeckhoff = new PlcBeckhoff(_ipAdressenBeckhoff, _pcToPlc, _plcToPc);
        _plcSiemens = new PlcSiemens(_ipAdressenSiemens, _pcToPlc, _plcToPc);

        Task.Run(PlcDaemonTask);
    }
    private void PlcDaemonTask()
    {
        var pingBeckhoff = new Ping();
        var pingSiemens = new Ping();

        _plcKeine.PlcTask();
        PlcState = _plcKeine.State;

        while (!_cancellationTokenSource.IsCancellationRequested)
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
                    _datenstruktur.VersionsStringPlc = PlcState.PlcBezeichnung;
                    break;

                case PlcDaemonStatus.SpsBeckhoff:
                    _plcBeckhoff.PlcTask();
                    PlcState = _plcBeckhoff.State;
                    DatenPcToPlcRangieren();
                    if (_plcBeckhoff.State.PlcError) _plcDaemonStatus = PlcDaemonStatus.SpsPingen;
                    break;

                case PlcDaemonStatus.SpsSiemens:
                    _plcSiemens.PlcTask();
                    PlcState = _plcSiemens.State;
                    DatenPcToPlcRangieren();
                    if (_plcSiemens.State.PlcError) _plcDaemonStatus = PlcDaemonStatus.SpsPingen;
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (_datenstruktur.SimulationAktiv()) _datenstruktur.BefehlePlc[0] = 1;
            else _datenstruktur.BefehlePlc[0] = 0;

            Thread.Sleep(10);
        }
        // ReSharper disable once FunctionNeverReturns
    }
    private void DatenPcToPlcRangieren()
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
        const int anfangBefehle = anzDi + anzAi;

        const int anfangDa = 0;
        const int anfangAa = anzDa;
        const int anfangVersion = anzDa + anzAa;
        // ReSharper restore InlineTemporaryVariable

        var versionsStringPlc = new byte[256];

        if (anzDi + anzAi + anzBefehle > _plcSiemens.AnzBytePcToPlc) throw new ArgumentOutOfRangeException();
        if (anzDa + anzAa + anzVersionsbez > _plcSiemens.AnzBytePlcToPc) throw new ArgumentOutOfRangeException();

        Buffer.BlockCopy(_datenstruktur.Di, 0, _pcToPlc, anfangDi, anzDi);
        Buffer.BlockCopy(_datenstruktur.Ai, 0, _pcToPlc, anfangAi, anzAi);
        Buffer.BlockCopy(_datenstruktur.BefehlePlc, 0, _pcToPlc, anfangBefehle, anzBefehle);

        Buffer.BlockCopy(_plcToPc, anfangDa, _datenstruktur.Da, 0, anzDa);
        Buffer.BlockCopy(_plcToPc, anfangAa, _datenstruktur.Aa, 0, anzAa);
        Buffer.BlockCopy(_plcToPc, anfangVersion, versionsStringPlc, 0, anzVersionsbez);

        var textLaenge = 0;
        for (var i = 0; i < 255; i++)
        {
            if (versionsStringPlc[i] != 0)
            {
                textLaenge = i + 1;
            }
        }
        var enc = new ASCIIEncoding();
        _datenstruktur.VersionsStringPlc = enc.GetString(versionsStringPlc, 0, textLaenge);
    }
}