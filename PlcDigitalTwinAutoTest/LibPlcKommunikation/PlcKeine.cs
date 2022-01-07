namespace LibPlcKommunikation;

public class PlcKeine : IPlc
{
    private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);

    public PlcKeine( )
    {
        Log.Debug("gestartet!");
    }
    public PlcState State => new()
    {
        PlcStatus = "Keine SPS vorhanden",
        PlcError = false,
        PlcVersion = "-??-",
        PlcModus = "-?-",
        PlcBezeichnung = "Keine SPS erkannt"
    };
    public bool PlcTask() => false;
}