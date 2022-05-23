using LibDatenstruktur;
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
    public int GetAnzahlAa() => DtConfig.AnalogeAusgaenge.EaConfig == null ? 0 : DtConfig.AnalogeAusgaenge.EaConfig.Length;
    public int GetAnzahlAi() => DtConfig.AnalogeEingaenge.EaConfig == null ? 0 : DtConfig.AnalogeEingaenge.EaConfig.Length;
    public int GetAnzahlDa() => DtConfig.DigitaleAusgaenge.EaConfig == null ? 0 : DtConfig.DigitaleAusgaenge.EaConfig.Length;
    public int GetAnzahlDi() => DtConfig.DigitaleEingaenge.EaConfig == null ? 0 : DtConfig.DigitaleEingaenge.EaConfig.Length;
    public int GetAnzahlTextbausteine() => DtConfig.Textbausteine == null ? 0 : DtConfig.Textbausteine.Length;

    public EaTypen GetEaType(DatenBereich datenBereich, int pos)
    {
        var dtEaConfig = datenBereich switch
        {
            DatenBereich.Aa => DtConfig.AnalogeAusgaenge,
            DatenBereich.Ai => DtConfig.AnalogeEingaenge,
            DatenBereich.Da => DtConfig.DigitaleAusgaenge,
            DatenBereich.Di => DtConfig.DigitaleEingaenge,
            _ => null
        };
        if (dtEaConfig == null) return EaTypen.TestErrorAusgeben;
        if (dtEaConfig.EaConfig == null) return EaTypen.TestErrorAusgeben;
        if (dtEaConfig.EaConfig.Length < pos) return EaTypen.TestErrorAusgeben;
        return dtEaConfig.EaConfig[pos].Type;
    }
    public void SetPathRelativ(string pfad) => SetPath(new string(Path.Combine(Environment.CurrentDirectory, pfad)));
    public void SetPath(string path)
    {
        _path = path;
        var pfadName = Path.Combine(_path, "DigitalTwin.json");
        JsonEinlesen(pfadName);
    }
}