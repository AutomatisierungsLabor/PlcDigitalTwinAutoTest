using TwinCAT.Ads;

namespace LibPlcKommunikation;

public class PlcBeckhoff : IPlc
{
    private enum BeckhoffStatus
    {
        Initialisieren = 0,
        Verbinden = 1,
        Kommunizieren = 2
    }

    private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);

    private readonly AdsClient _adsClient;
    private readonly IpAdressenBeckhoff _ipAdressenBeckhoff;
    private readonly byte[] _pcToPlc;
    // ReSharper disable once NotAccessedField.Local
    private byte[] _plcToPc;
    private BeckhoffStatus _beckhoffStatus;
    private uint _handlePcToPlc;
    private uint _handlePlcToPc;

    public PlcBeckhoff(IpAdressenBeckhoff ipAdressenBeckhoff, byte[] pcToPlc, byte[] plcToPc)
    {
        Log.Debug("gestartet!");

        _ipAdressenBeckhoff = ipAdressenBeckhoff;
        _pcToPlc = pcToPlc;
        _plcToPc = plcToPc;

        _adsClient = new AdsClient();
        _beckhoffStatus = BeckhoffStatus.Initialisieren;
    }
    public PlcState State => new()
    {
        PlcBezeichnung = "CX 9020",
        PlcError = false,
        PlcErrorMessage = "-"
    };
    public void PlcTask()
    {
        switch (_beckhoffStatus)
        {
            case BeckhoffStatus.Initialisieren:
                Log.Debug("ADS initialisieren");
                try
                {
                    _adsClient.Connect(_ipAdressenBeckhoff.AmsNetId, _ipAdressenBeckhoff.Port);
                    _handlePcToPlc = _adsClient.CreateVariableHandle("_PcToPlc.PcToPlc");
                    _handlePlcToPc = _adsClient.CreateVariableHandle("_PlcToPc.PlcToPc");
                    _beckhoffStatus = BeckhoffStatus.Verbinden;
                }
                catch (Exception e)
                {
                    Log.Debug("Beckhoff Initialisieren: " + e);
                    throw;
                }
                break;

            case BeckhoffStatus.Verbinden:
                if (_adsClient.IsConnected)
                {
                    Log.Debug("ADS verbunden");
                    _beckhoffStatus = BeckhoffStatus.Kommunizieren;
                }
                break;

            case BeckhoffStatus.Kommunizieren:
                try
                {
                    _plcToPc = (byte[])_adsClient.ReadAny(_handlePlcToPc, typeof(byte[]), new[] { 256 });
                    _adsClient.WriteAny(_handlePcToPlc, _pcToPlc);
                }
                catch (Exception e)
                {
                    Log.Debug("Beckhoff Kommunizieren: " + e);
                    throw;
                }
                break;

            default:
                throw new ArgumentOutOfRangeException();
        }

        State.PlcError = false;
    }
}