using TwinCAT.Ads;

namespace LibPlcKommunikation;

public class PlcBeckhoff : IPlc
{
    public enum BeckhoffStatus
    {
        Initialisieren = 0,
        Verbinden = 1,
        Kommunizieren = 2
    }

    private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);

    private readonly AdsClient _adsClient;
    private readonly IpAdressenBeckhoff _ipAdressenBeckhoff;
    private readonly byte[] _pc2Plc;
    // ReSharper disable once NotAccessedField.Local
    private byte[] _plc2Pc;
    private BeckhoffStatus _beckhoffStatus;
    private uint _handlePc2Plc;
    private uint _handlePlc2Pc;

    public PlcBeckhoff(IpAdressenBeckhoff ipAdressenBeckhoff, byte[] pc2Plc, byte[] plc2Pc)
    {
        Log.Debug("gestartet!");

        _ipAdressenBeckhoff = ipAdressenBeckhoff;
        _pc2Plc = pc2Plc;
        _plc2Pc = plc2Pc;

        _adsClient = new AdsClient();
        _beckhoffStatus = BeckhoffStatus.Verbinden;
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
                _adsClient.Connect(_ipAdressenBeckhoff.AmsNetId, _ipAdressenBeckhoff.Port);
                _handlePc2Plc = _adsClient.CreateVariableHandle("Pc2Plc");
                _handlePlc2Pc = _adsClient.CreateVariableHandle("Plc2Pc");
                _beckhoffStatus = BeckhoffStatus.Verbinden;
                break;

            case BeckhoffStatus.Verbinden:
                if (_adsClient.IsConnected)
                {
                    Log.Debug("ADS verbunden");
                    _beckhoffStatus = BeckhoffStatus.Kommunizieren;
                }
                break;

            case BeckhoffStatus.Kommunizieren:
                _plc2Pc = (byte[])_adsClient.ReadAny(_handlePlc2Pc, typeof(byte[]), new[] { 256 });
                _adsClient.WriteAny(_handlePc2Plc, _pc2Plc);
                break;

            default:
                throw new ArgumentOutOfRangeException();
        }

        State.PlcError = false;
    }
}