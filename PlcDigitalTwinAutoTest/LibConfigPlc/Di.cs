using System.Collections.ObjectModel;

namespace LibConfigPlc;

public class Di : EaConfig<DiEinstellungen>
{
    public Di(ObservableCollection<DiEinstellungen> zeilen) : base(zeilen)
    {
    }
    protected override void ConfigTesten()
    {
        ConfigOk = true;
        AnzByte = 0;

        var speicherAbbild = new byte[256];

        foreach (var zeile in Zeilen)
        {
            if (zeile.StartByte > 256) ConfigOk = false;
            if (zeile.StartBit > 7) ConfigOk = false;

            // ReSharper disable once SwitchStatementHandlesSomeKnownEnumValuesWithDefault
            switch (zeile.Type)
            {
                case Config.EaTypen.Bit:
                    var bitMuster = BitmusterErzeugen(zeile.StartBit);
                    if (BitMusterAufKollissionTesten(speicherAbbild, zeile.StartByte, bitMuster)) ConfigOk = false;
                    break;
                case Config.EaTypen.Byte:
                    if (zeile.StartBit > 0) ConfigOk = false;
                    if (BitMusterAufKollissionTesten(speicherAbbild, zeile.StartByte, 0xFF)) ConfigOk = false;
                    break;
                case Config.EaTypen.Word:
                    if (zeile.StartBit > 0) ConfigOk = false;
                    if (BitMusterAufKollissionTesten(speicherAbbild, zeile.StartByte, 0xFF)) ConfigOk = false;
                    if (BitMusterAufKollissionTesten(speicherAbbild, zeile.StartByte + 1, 0xFF)) ConfigOk = false;
                    break;
                case Config.EaTypen.Ascii:
                    if (zeile.StartBit > 0) ConfigOk = false;
                    if (BitMusterAufKollissionTesten(speicherAbbild, zeile.StartByte, 0xFF)) ConfigOk = false;
                    break;
                case Config.EaTypen.BitmusterByte:
                    if (zeile.StartBit > 0) ConfigOk = false;
                    if (BitMusterAufKollissionTesten(speicherAbbild, zeile.StartByte, 0xFF)) ConfigOk = false;
                    break; 
                default: ConfigOk = false; break;
            }
        }
    }

    private static byte BitmusterErzeugen(int bitPos) => (byte)(1 << bitPos);
    private static bool BitMusterAufKollissionTesten(IList<byte> speicherAbbild, int posByte, byte bitMuster)
    {
        if (posByte > 256) return true;
        if ((speicherAbbild[posByte] & bitMuster) > 0) return true;

        speicherAbbild[posByte] |= bitMuster;
        return false;
    }



}

public class DiEinstellungen
{
    public int LaufendeNr { get; set; }
    public int StartByte { get; set; }
    public int StartBit { get; set; }
    public int AnzahlBit { get; set; }
    public Config.EaTypen Type { get; set; }
    public string Bezeichnung { get; set; }
    public string Kommentar { get; set; }

    public DiEinstellungen()
    {
        LaufendeNr = 0;
        StartByte = 0;
        StartBit = 0;
        AnzahlBit = 0;
        Type = Config.EaTypen.NichtBelegt;
        Bezeichnung = "";
        Kommentar = "";
    }
}