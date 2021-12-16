using System.Collections.ObjectModel;

namespace LibConfigPlc;

public class Aa : EaConfig<AaEinstellungen>
{
    private readonly SharedFunctions _sharedFunctions = new();
    
    public Aa(ObservableCollection<AaEinstellungen> zeilen) : base(zeilen)
    {
    }
    protected override void ConfigTesten(byte[] speicherAbbild)
    {
        ConfigOk = true;
        AnzByte = 0;

        foreach (var zeile in Zeilen)
        {
            // ReSharper disable once SwitchStatementHandlesSomeKnownEnumValuesWithDefault
            switch (zeile.Type)
            {
                case Config.EaTypen.Byte:
                    if (zeile.StartBit > 0) ConfigOk = false;
                    if (_sharedFunctions.BitMusterAufKollissionTesten(speicherAbbild, zeile.StartByte, 0xFF)) ConfigOk = false;
                    break;
                case Config.EaTypen.Word:
                case Config.EaTypen.SiemensAnalogwertPromille:
                case Config.EaTypen.SiemensAnalogwertProzent:
                case Config.EaTypen.SiemensAnalogwertSchieberegler:
                    if (zeile.StartBit > 0) ConfigOk = false;
                    if (_sharedFunctions.BitMusterAufKollissionTesten(speicherAbbild, zeile.StartByte, 0xFF)) ConfigOk = false;
                    if (_sharedFunctions.BitMusterAufKollissionTesten(speicherAbbild, zeile.StartByte + 1, 0xFF)) ConfigOk = false;
                    break;
                default: ConfigOk = false; break;
            }
        }

        AnzByte = _sharedFunctions.AnzByteEinlesen(speicherAbbild);
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