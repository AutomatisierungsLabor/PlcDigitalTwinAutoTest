namespace LibConfigDt;

public enum TextbausteineAnzeigen
{
    NurInhalt = 0,
    H1H2Inhalt = 1,
    H1H2TestInhalt = 2
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
    public AaConfig[] AnalogeAusgaenge { get; set; }
    public AiConfig[] AnalogeEingaenge { get; set; }
    public DaConfig[] DigitaleAusgaenge { get; set; }
    public DiConfig[] DigitaleEingaenge { get; set; }
    public Textbausteine[] Textbausteine { get; set; }
}
public class AaConfig
{
    public int StartByte { get; set; }
    public int StartBit { get; set; }
    public EaTypen Type { get; set; }
    public string Bezeichnung { get; set; }
    public string Kommentar { get; set; }
}
public class AiConfig
{
    public int StartByte { get; set; }
    public int StartBit { get; set; }
    public EaTypen Type { get; set; }
    public string Bezeichnung { get; set; }
    public string Kommentar { get; set; }
}
public class DaConfig
{
    public int StartByte { get; set; }
    public int StartBit { get; set; }
    public EaTypen Type { get; set; }
    public string Bezeichnung { get; set; }
    public string Kommentar { get; set; }
}
public class DiConfig
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
    public int VorbereitungId { get; set; }
    public string Test { get; set; }
    public string Kommentar { get; set; }
    public TextbausteineAnzeigen WasAnzeigen { get; set; }
}