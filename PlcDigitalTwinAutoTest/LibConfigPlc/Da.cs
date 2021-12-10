using System.Collections.ObjectModel;

namespace LibConfigPlc;

public class Da
{
    public bool ConfigOk { get; set; }
    public int AnzZeilen { get; set; }
    public int AnzByte { get; set; }
    public ObservableCollection<DaEinstellungen> Zeilen { get; set; }

    public Da(ObservableCollection<DaEinstellungen> zeilen)
    {
        ConfigOk = true;
        Zeilen = zeilen;
        AnzZeilen = zeilen.Count;
        ConfigTesten();
    }
    private void ConfigTesten()
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