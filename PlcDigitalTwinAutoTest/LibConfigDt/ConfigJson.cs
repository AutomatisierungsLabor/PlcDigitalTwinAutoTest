namespace LibConfigDt;

public enum TextbausteineAnzeigen
{
    NurInhalt = 0,
    H1Inhalt = 1,
    H1H2Inhalt = 2,
    H2Inhalt = 3,
    H1H2TestInhalt = 4
}
public enum EaTypen
{
    // ReSharper disable UnusedMember.Global
    NichtBelegt,
    Bit,
    Byte,
    Word,
    DWord,
    Ascii,
    BitmusterByte,
    SiemensAnalogwertProzent,
    SiemensAnalogwertPromille,
    SiemensAnalogwertSchieberegler
    // ReSharper restore UnusedMember.Global
}
public class DtConfig
{
    public EAConfig[] AnalogeAusgaenge { get; set; }
    public EAConfig[] AnalogeEingaenge { get; set; }
    public EAConfig[] DigitaleAusgaenge { get; set; }
    public EAConfig[] DigitaleEingaenge { get; set; }
    public Textbausteine[] Textbausteine { get; set; }
}
public class EAConfig
{
    public int StartByte { get; set; }
    public int StartBit { get; set; }
    public EaTypen Type { get; set; }
    public string Bezeichnung { get; set; }
    public string Kommentar { get; set; }
}
public class Textbausteine
{
    public int BausteinId { get; set; }
    public string PrefixH1 { get; set; }
    public string PrefixH2 { get; set; }
    public int VorbereitungId { get; set; }
    public string Test { get; set; }
    public string Kommentar { get; set; }
    public TextbausteineAnzeigen WasAnzeigen { get; set; }
}