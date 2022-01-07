using LibDatenstruktur;
using Sharp7;

namespace LibPlcKommunikation;

public class PlcSiemens : IPlc
{
    private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);

    private readonly IpAdressenSiemens _ipAdressenSiemens;
    private readonly byte[] _pc2Plc;
    private byte[] _plc2Pc;
    private readonly Sharp7.S7Client _s7Client;

    public PlcSiemens(IpAdressenSiemens ipAdressenSiemens, byte[] pc2Plc, byte[] plc2Pc)
    {
        Log.Debug("gestartet!");

        _ipAdressenSiemens = ipAdressenSiemens;
        _pc2Plc = pc2Plc;
        _plc2Pc = plc2Pc;
        _s7Client = new S7Client();

    }
    public PlcState State => new()
    {
        PlcStatus = "Keine SPS vorhanden",
        PlcError = false,
        PlcVersion = "-??-",
        PlcModus = "-?-",
        PlcBezeichnung = "S7-1200"
    };
    public bool PlcTask() => false;
}