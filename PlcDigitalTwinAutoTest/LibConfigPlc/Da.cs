using System.Collections.ObjectModel;

namespace LibConfigPlc;

public class Da : EaConfig<DaEinstellungen>
{
    public Da(ObservableCollection<DaEinstellungen> zeilen) : base(zeilen)
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
                case Config.EaTypen.Bit: break;
                case Config.EaTypen.Byte: break;
                case Config.EaTypen.Word: break;
                case Config.EaTypen.Ascii: break;
                case Config.EaTypen.BitmusterByte: break;
                default: ConfigOk = false; break;
            }
        }
    }
}

public class DaEinstellungen
{
    public int StartByte { get; set; }
    public int StartBit { get; set; }
    public Config.EaTypen Type { get; set; }
    public string Bezeichnung { get; set; }
    public string Kommentar { get; set; }


    public DaEinstellungen()
    {
        StartByte = 0;
        StartBit = 0;
        Type = Config.EaTypen.NichtBelegt;
        Bezeichnung = "";
        Kommentar = "";
    }
}