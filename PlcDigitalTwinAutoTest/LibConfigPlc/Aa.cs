using System.Collections.ObjectModel;

namespace LibConfigPlc;

public class Aa
{
    public bool ConfigOk { get; set; }
    public int AnzZeilen { get; set; }
    public int AnzByte { get; set; }
    public ObservableCollection<AaEinstellungen> Zeilen { get; set; }

    public Aa(ObservableCollection<AaEinstellungen> zeilen)
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

public class AaEinstellungen
{
    public int StartByte { get; set; }
    public int StartBit { get; set; }
    public double MinimalWert { get; set; }
    public double MaximalWert { get; set; }
    public double Schrittweite { get; set; }
    public Config.EaTypen Type { get; set; }
    public string Bezeichnung { get; set; }
    public string Kommentar { get; set; }

    public AaEinstellungen()
    {
        StartByte = 0;
        StartBit = 0;
        MinimalWert = 0;
        MaximalWert = 0;
        Schrittweite = 0;
        Type = Config.EaTypen.NichtBelegt;
        Bezeichnung = "";
        Kommentar = "";
    }
}