using Newtonsoft.Json;

namespace LibConfigDt;

public class ConfigDt
{
    private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);

    public DtConfig DtConfig { get; set; }
    private string _path;

    public ConfigDt(string path)
    {
        Log.Debug("Konstruktor");

        _path = path;


        DtConfig = new DtConfig();

        var pfadName = Path.Combine(_path, "DigitalTwin.json");
        JsonEinlesen(pfadName);
    }
    public void JsonEinlesen(string pathName)
    {
        try
        {
            DtConfig = JsonConvert.DeserializeObject<DtConfig>(File.ReadAllText(pathName));
        }
        catch (Exception e)
        {
            Log.Debug(e);
            throw;
        }
    }
    public int GetAnzahlAa() => DtConfig.AnalogeAusgaenge.Length;
    public int GetAnzahlAi() => DtConfig.AnalogeEingaenge.Length;
    public int GetAnzahlDa() => DtConfig.DigitaleAusgaenge.Length;
    public int GetAnzahlDi() => DtConfig.DigitaleEingaenge.Length;
    public void SetPathRelativ(string pfad) => SetPath(new string(Path.Combine(Environment.CurrentDirectory, pfad)));
    public void SetPath(string path)
    {
        _path = path;
        var pfadName = Path.Combine(_path, "DigitalTwin.json");
        JsonEinlesen(pfadName);
    }
}