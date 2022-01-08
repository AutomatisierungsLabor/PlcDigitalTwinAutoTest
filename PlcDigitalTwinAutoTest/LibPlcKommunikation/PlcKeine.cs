namespace LibPlcKommunikation;

public class PlcKeine : IPlc
{
    private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);

    public PlcKeine()
    {
        Log.Debug("gestartet!");
    }
    public PlcState State => new()
    {
        PlcBezeichnung = "Keine SPS erkannt",
        PlcError = false,
        PlcErrorMessage = "-"
    };
    public void PlcTask() { }
}