using Contracts;
using LibDatenstruktur;
using Newtonsoft.Json;

namespace LibConfigDt;

public partial class ConfigDt
{
    private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);

    public DtConfig DtConfig { get; set; }
    private string _path;

    private Action _cbNeuerTest;

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
        else Log.Debug("json Datei fehlt:" + pathName);
    }
    public int GetAnzahlAa() => DtConfig.AnalogeAusgaenge.EaConfig?.Length ?? 0;
    public int GetAnzahlAi() => DtConfig.AnalogeEingaenge.EaConfig?.Length ?? 0;
    public int GetAnzahlDa() => DtConfig.DigitaleAusgaenge.EaConfig?.Length ?? 0;
    public int GetAnzahlDi() => DtConfig.DigitaleEingaenge.EaConfig?.Length ?? 0;
    public int GetAnzahlTextbausteine() => DtConfig.Textbausteine?.Length ?? 0;
    public int GetAnzahlAlarme()=>DtConfig.Alarm?.Length ?? 0;
    public EaConfigError GetAlarmConfigError(int id) => DtConfig.Alarm[id].EaConfigError;
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
        if (dtEaConfig?.EaConfig == null) return EaTypen.TestErrorAusgeben;
        return dtEaConfig.EaConfig.Length < pos ? EaTypen.TestErrorAusgeben : dtEaConfig.EaConfig[pos].Type;
    }
    public void SetPathRelativ(string pfad) => SetPath(new string(Path.Combine(Environment.CurrentDirectory, pfad)));
    public void SetPath(string path)
    {
        _path = path;
        var pfadName = Path.Combine(_path, "DigitalTwin.json");
        JsonEinlesen(pfadName);

        _cbNeuerTest?.Invoke();
    }
    public EaConfigError GetEaConfigError(DatenBereich datenBereich, int pos)
    {
        var dtEaConfig = datenBereich switch
        {
            DatenBereich.Aa => DtConfig.AnalogeAusgaenge,
            DatenBereich.Ai => DtConfig.AnalogeEingaenge,
            DatenBereich.Da => DtConfig.DigitaleAusgaenge,
            DatenBereich.Di => DtConfig.DigitaleEingaenge,
            _ => null
        };
        if (dtEaConfig?.EaConfig == null) return EaConfigError.UnbekannterFehler;
        return dtEaConfig.EaConfig.Length < pos ? EaConfigError.UnbekannterFehler : dtEaConfig.EaConfig[pos].EaConfigError;
    }

    public void SetCallbackNeuerTest(Action callback) => _cbNeuerTest = callback;
}