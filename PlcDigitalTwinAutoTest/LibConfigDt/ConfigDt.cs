using Newtonsoft.Json;

namespace LibConfigDt;

public partial class ConfigDt
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
        if (File.Exists(pathName))
        {
            try
            {
                DtConfig = JsonConvert.DeserializeObject<DtConfig>(File.ReadAllText(pathName));
                var a = JsonConvert.DeserializeObject<Rootobject>(File.ReadAllText(pathName));
                JsonAufFehlerTesten();
            }
            catch (Exception e)
            {
                Log.Debug(e);
                throw;
            }
        }
        else
        {
            Log.Debug("json Datei fehlt:" + pathName);
        }
    }
    public int GetAnzahlAa() => DtConfig.AnalogeAusgaenge.EaConfigs == null ? 0 : DtConfig.AnalogeAusgaenge.EaConfigs.Length;
    public int GetAnzahlAi() => DtConfig.AnalogeEingaenge.EaConfigs == null ? 0 : DtConfig.AnalogeEingaenge.EaConfigs.Length;
    public int GetAnzahlDa() => DtConfig.DigitaleAusgaenge.EaConfigs == null ? 0 : DtConfig.DigitaleAusgaenge.EaConfigs.Length;
    public int GetAnzahlDi() => DtConfig.DigitaleEingaenge.EaConfigs == null ? 0 : DtConfig.DigitaleEingaenge.EaConfigs.Length;
    public int GetAnzahlTextbausteine() => DtConfig.Textbausteine == null ? 0 : DtConfig.Textbausteine.Length;
    public void SetPathRelativ(string pfad) => SetPath(new string(Path.Combine(Environment.CurrentDirectory, pfad)));
    public void SetPath(string path)
    {
        _path = path;
        var pfadName = Path.Combine(_path, "DigitalTwin.json");
        JsonEinlesen(pfadName);
    }
}