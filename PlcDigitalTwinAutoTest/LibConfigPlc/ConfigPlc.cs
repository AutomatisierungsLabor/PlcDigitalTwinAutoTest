using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace LibConfigPlc;

public class ConfigPlc
{
    private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);

    public ConfigPlc(string pfad)
    {
        Log.Debug("ConfigPlc einlesen: " + pfad);
        SetPathRelativ(pfad);
    }

    public enum EaTypen
    {
        NichtBelegt,
        // ReSharper disable UnusedMember.Global
        Bit,
        Byte,
        Word,
        Ascii,
        BitmusterByte,
        SiemensAnalogwertProzent,
        SiemensAnalogwertPromille,
        SiemensAnalogwertSchieberegler
        // ReSharper restore UnusedMember.Global
    }

    public string PfadAbsolut { get; set; }

    public Di Di { get; set; } = new(new ObservableCollection<DiEinstellungen>());
    public Da Da { get; set; } = new(new ObservableCollection<DaEinstellungen>());
    public Ai Ai { get; set; } = new(new ObservableCollection<AiEinstellungen>());
    public Aa Aa { get; set; } = new(new ObservableCollection<AaEinstellungen>());
    public T SetPath<T, TEinstellungen>(string pfad, EaConfig<TEinstellungen> ioConfig) where T : EaConfig<TEinstellungen>
    {
        ioConfig.ConfigOk = false;
        var dateiPfad = $"{pfad}/{typeof(T).Name.ToUpper()}.json";
        if (!File.Exists(dateiPfad))
        {
            Log.Debug("ConfigPlc Datei nicht gefunden: " + dateiPfad);
            return ioConfig as T;
        }
        try
        {
            ioConfig = JsonConvert.DeserializeObject<T>(File.ReadAllText(dateiPfad));
        }
        catch (Exception ex)
        {
            Log.Debug("ConfigPlc Datei nicht gefunden: " + dateiPfad + ex);
        }
        return ioConfig as T;
    }

    public void SetPathRelativ(string pfad) => SetPath(new string(Path.Combine(Environment.CurrentDirectory, pfad)));
    public void SetPath(string pfad)
    {
        PfadAbsolut = pfad;
        Di = SetPath<Di, DiEinstellungen>(pfad, Di);
        Da = SetPath<Da, DaEinstellungen>(pfad, Da);
        Ai = SetPath<Ai, AiEinstellungen>(pfad, Ai);
        Aa = SetPath<Aa, AaEinstellungen>(pfad, Aa);
    }
}