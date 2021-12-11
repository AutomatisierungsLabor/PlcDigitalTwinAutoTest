using System.Collections.ObjectModel;
using log4net.Repository.Hierarchy;
using Newtonsoft.Json;

namespace LibConfigPlc;

public class Config
{
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

    public Di Di { get; set; } = new Di(new ObservableCollection<DiEinstellungen>());
    public Da Da { get; set; } = new Da(new ObservableCollection<DaEinstellungen>());
    public Ai Ai { get; set; } = new Ai(new ObservableCollection<AiEinstellungen>());
    public Aa Aa { get; set; } = new Aa(new ObservableCollection<AaEinstellungen>());

    public T SetPath<T, TEinstellungen>(string pfad, EaConfig<TEinstellungen> ioConfig) where T : EaConfig<TEinstellungen>
    {
        ioConfig.ConfigOk = false;
        var dateiPfad = $"{pfad}/{typeof(T).Name}.json";

        if (!File.Exists(dateiPfad)) return ioConfig as T;
        try
        {
            ioConfig = JsonConvert.DeserializeObject<T>(File.ReadAllText(dateiPfad));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Datei nicht gefunden:" + pfad + " --> " + ex);
        }
        return ioConfig as T;
    }

    public void SetPath(string pfad)
    {
        Di = SetPath<Di, DiEinstellungen>(pfad, Di);
        Da = SetPath<Da, DaEinstellungen>(pfad, Da);
        Ai = SetPath<Ai, AiEinstellungen>(pfad, Ai);
        Aa = SetPath<Aa, AaEinstellungen>(pfad, Aa);
    }
}