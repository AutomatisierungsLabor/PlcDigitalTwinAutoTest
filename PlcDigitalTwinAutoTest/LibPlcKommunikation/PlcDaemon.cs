using LibDatenstruktur;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Text;

namespace LibPlcKommunikation;

public class PlcDaemon
{
    public enum PlcDaemonStatus
    {
        SpsPingStarten = 0,
        SpsPingErgebnis = 1,
        SpsBeckhoff = 2,
        SpsSiemens = 3
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
    private Action<PlcDaemonStatus, long, long, long> _cbSetPlcInfo;
    private long _zyklusZeitMin;
    private long _zyklusZeitMax;

    public PlcDaemon(Datenstruktur datenstruktur, CancellationTokenSource cancellationTokenSource)
    {
        Log.Debug("PLC Daemon gestartet");

        _datenstruktur = datenstruktur;
        _plcDaemonStatus = PlcDaemonStatus.SpsPingStarten;
        _cancellationTokenSource = cancellationTokenSource;

        _pcToPlc = new byte[1024];
        _plcToPc = new byte[1024];

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

        Log.Debug("SPS pingen");


        _plcKeine = new PlcKeine(_datenstruktur);
        _plcBeckhoff = new PlcBeckhoff(_ipAdressenBeckhoff, _pcToPlc, _plcToPc);
        _plcSiemens = new PlcSiemens(_ipAdressenSiemens, _pcToPlc, _plcToPc);

        Task.Run(PlcDaemonTask);
    }
    private void PlcDaemonTask()
    {
        ResetPlcInfo();
        var stopwatch = new Stopwatch();

        var pingBeckhoff = new Ping();
        pingBeckhoff.PingCompleted += (_, args) => _plcDaemonStatus = args.Reply is { Status: IPStatus.Success } ? PlcDaemonStatus.SpsBeckhoff : PlcDaemonStatus.SpsPingStarten;
       
        var pingSiemens = new Ping();
        pingSiemens.PingCompleted += (_, args) => _plcDaemonStatus = args.Reply is { Status: IPStatus.Success } ? PlcDaemonStatus.SpsSiemens : PlcDaemonStatus.SpsPingStarten;
        
        _plcKeine.PlcTask();
        PlcState = _plcKeine.State;

        while (!_cancellationTokenSource.IsCancellationRequested)
        {
            switch (_plcDaemonStatus)
            {
                case PlcDaemonStatus.SpsPingStarten:
                    Log.Debug("SpsPingStarten");
                    pingBeckhoff.SendAsync(_ipAdressenBeckhoff.IpAdresse, 1000, null);
                    pingSiemens.SendAsync(_ipAdressenSiemens.Adress, 1000, null);

                    _datenstruktur.VersionsStringPlc = PlcState.PlcBezeichnung;
                    _plcDaemonStatus = PlcDaemonStatus.SpsPingErgebnis;
                    break;

                case PlcDaemonStatus.SpsPingErgebnis:
                    // einfach nichts tun und auf das Ergebnis warten
                    break;

                case PlcDaemonStatus.SpsBeckhoff:
                    _plcBeckhoff.PlcTask();
                    PlcState = _plcBeckhoff.State;
                    DatenPcToPlcRangieren();
                    if (_plcBeckhoff.State.PlcError)
                    {
                        _plcDaemonStatus = PlcDaemonStatus.SpsPingStarten;
                    }
                    break;

                case PlcDaemonStatus.SpsSiemens:
                    _plcSiemens.PlcTask();
                    PlcState = _plcSiemens.State;
                    DatenPcToPlcRangieren();
                    if (_plcSiemens.State.PlcError)
                    {
                        _plcDaemonStatus = PlcDaemonStatus.SpsPingStarten;
                    }
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            _datenstruktur.BefehlePlc[0] = _datenstruktur.BetriebsartProjekt switch
            {
                BetriebsartProjekt.BeschreibungAnzeigen => 0,
                BetriebsartProjekt.LaborPlatte => 0,
                BetriebsartProjekt.Simulation => 1,
                BetriebsartProjekt.AutomatischerSoftwareTest => 1,
                _ => _datenstruktur.BefehlePlc[0]
            };

            if (stopwatch.ElapsedMilliseconds < _zyklusZeitMin) _zyklusZeitMin = stopwatch.ElapsedMilliseconds;
            if (stopwatch.ElapsedMilliseconds > _zyklusZeitMax) _zyklusZeitMax = stopwatch.ElapsedMilliseconds;

            _cbSetPlcInfo?.Invoke(_plcDaemonStatus, stopwatch.ElapsedMilliseconds, _zyklusZeitMin, _zyklusZeitMax);

            stopwatch.Restart();
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
    public void SetInfoCallback(Action<PlcDaemonStatus, long, long, long> setPlcValues) => _cbSetPlcInfo = setPlcValues;
    public void ResetPlcInfo()
    {
        _zyklusZeitMax = 0;
        _zyklusZeitMin = long.MaxValue;
    }
}