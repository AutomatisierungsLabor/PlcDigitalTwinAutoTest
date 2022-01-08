using Sharp7;

namespace LibPlcKommunikation;

public enum SiemensDatenbausteine
{
    // ReSharper disable UnusedMember.Global
    VersionIn = 1,
    DigIn = 2,
    DigOut = 3,
    AnIn = 4,
    AnOut = 5,
    // ReSharper restore UnusedMember.Global
    Pc2Plc = 6,
    Plc2Pc = 7
}

public class PlcSiemens : IPlc
{
    public short AnzBytePc2Plc = 222;
    public short AnzBytePlc2Pc = 222;

    private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);

    private readonly IpAdressenSiemens _ipAdressenSiemens;
    private readonly byte[] _pc2Plc;
    private readonly byte[] _plc2Pc;
    private readonly S7Client _s7Client;

    private SiemensStatus _siemensStatus;

    public enum SiemensStatus
    {
        Verbinden = 0,
        Kommunizieren = 1
    }

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
        PlcBezeichnung = "S7-1200",
        PlcError = false,
        PlcErrorMessage = "-"
    };
    public void PlcTask()
    {
        var error = false;

        switch (_siemensStatus)
        {
            case SiemensStatus.Verbinden:
                var connect = _s7Client?.ConnectTo(_ipAdressenSiemens.Adress, 0, 1);

                if (connect == 0)
                {
                    State.PlcErrorMessage = "-";
                    _siemensStatus = SiemensStatus.Kommunizieren;
                }
                else
                {
                    FehlerAktiv(connect);
                }
                break;

            case SiemensStatus.Kommunizieren:
                error |= FehlerAktiv(_s7Client.DBWrite((int)SiemensDatenbausteine.Pc2Plc, 0, AnzBytePc2Plc, _pc2Plc));
                error |= FehlerAktiv(_s7Client.DBRead((int)SiemensDatenbausteine.Plc2Pc, 0, AnzBytePlc2Pc, _plc2Pc));
                break;

            default:
                throw new ArgumentOutOfRangeException();
        }

        if (error) _siemensStatus = SiemensStatus.Verbinden;
        State.PlcError = error;
    }
    private bool FehlerAktiv(int? error)
    {
        if (error == 0) return false;

        var errorNr = error.GetValueOrDefault();
        var errorText = _s7Client?.ErrorText(errorNr);
        State.PlcErrorMessage = "#" + errorNr + " --> " + errorText;
        return true;
    }
}