using System.Collections.ObjectModel;

namespace LibConfigPlc;

public class Ai : EaConfig<AiEinstellungen>
{
    public Ai(ObservableCollection<AiEinstellungen> zeilen) : base(zeilen)
    {
    }
    protected override void ConfigTesten()
    {
        ConfigOk = true;
        AnzByte = 0;

        foreach (var zeile in Zeilen)
        {
            // ReSharper disable once SwitchStatementHandlesSomeKnownEnumValuesWithDefault
            switch (zeile.Type)
            {
                case Config.EaTypen.Byte: break;
                case Config.EaTypen.Word: break;
                case Config.EaTypen.SiemensAnalogwertPromille: break;
                case Config.EaTypen.SiemensAnalogwertProzent: break;
                case Config.EaTypen.SiemensAnalogwertSchieberegler: break;
                default: ConfigOk = false; break;
            }
        }
    }
}

public class AiEinstellungen
{
    public int StartByte { get; set; }
    public int StartBit { get; set; }
    public Config.EaTypen Type { get; set; }
    public string Bezeichnung { get; set; }
    public string Kommentar { get; set; }

    public AiEinstellungen()
    {
        StartByte = 0;
        StartBit = 0;
        Type = Config.EaTypen.NichtBelegt;
        Bezeichnung = "";
        Kommentar = "";
    }
}