using System.Collections.ObjectModel;
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

    public Di Di { get; set; }
    public Da Da { get; set; }
    public Ai Ai { get; set; }
    public Aa Aa { get; set; }


    public Config()
    {
        Di = new Di(new ObservableCollection<DiEinstellungen>());
        Da = new Da(new ObservableCollection<DaEinstellungen>());
        Ai = new Ai(new ObservableCollection<AiEinstellungen>());
        Aa = new Aa(new ObservableCollection<AaEinstellungen>());
    }
    public void SetPath(string pfad)
    {
        if (!Directory.Exists(pfad)) return;

        var pfadDi = $"{pfad}/DI.json";
        var pfadDa = $"{pfad}/DA.json";
        var pfadAi = $"{pfad}/AI.json";
        var pfadAa = $"{pfad}/AA.json";

        if (File.Exists(pfadDi))
        {
            try
            {
                Di = JsonConvert.DeserializeObject<Di>(File.ReadAllText(pfadDi));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Datei nicht gefunden:" + pfad + " --> " + ex);
            }
        }
        else Di.ConfigOk=false;


        if (File.Exists(pfadDa))
        {
            try
            {
                Da = JsonConvert.DeserializeObject<Da>(File.ReadAllText(pfadDa));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Datei nicht gefunden:" + pfad + " --> " + ex);
            }
        }
        else Da.ConfigOk = false;

        if (File.Exists(pfadAi))
        {
            try
            {
                Ai = JsonConvert.DeserializeObject<Ai>(File.ReadAllText(pfadAi));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Datei nicht gefunden:" + pfad + " --> " + ex);
            }
        }
        else Ai.ConfigOk = false;

        if (File.Exists(pfadAa))
        {
            try
            {
                Aa = JsonConvert.DeserializeObject<Aa>(File.ReadAllText(pfadAa));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Datei nicht gefunden:" + pfad + " --> " + ex);
            }
        }
        else Aa.ConfigOk = false;
    }
}