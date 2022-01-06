using LibDatenstruktur;

namespace LibPlcKommunikation;

public class PlcBeckhoff : IPlc
{
    private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);

    private readonly Datenstruktur _datenstruktur;

    public PlcBeckhoff(IpAdressenBeckhoff ipAdressenBeckhoff, Datenstruktur datenstruktur)
    {
        Log.Debug("gestartet!");

_datenstruktur = datenstruktur;
    }

    public string GetSpsStatus()
    {
        throw new NotImplementedException();
    }

    public bool GetSpsError()
    {
        throw new NotImplementedException();
    }

    public string GetVersion()
    {
        throw new NotImplementedException();
    }

    public string GetPlcModus()
    {
        throw new NotImplementedException();
    }

    public string GetPlcBezeichnung()
    {
        throw new NotImplementedException();
    }
}