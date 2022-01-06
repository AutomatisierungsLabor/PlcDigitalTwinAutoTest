using LibDatenstruktur;

namespace LibPlcKommunikation;

public class PlcKeine : IPlc
{
    private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);

    public PlcKeine(Datenstruktur datenstruktur)
    {
        Log.Debug("gestartet!");

        datenstruktur.PlcStatus = "Keine SPS vorhanden";
        datenstruktur.PlcError = false;
        datenstruktur.PlcVersion = "-??-";
        datenstruktur.PlcModus = "-?-";
        datenstruktur.PlcBezeichnung = "Keine SPS erkannt";
    }
}