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
}
public class DtConfig
{
    public AnalogeAusgaenge AnalogeAusgaenge { get; set; }
    public DtEaConfig AnalogeEingaenge { get; set; }
    public DtEaConfig DigitaleAusgaenge { get; set; }
    public DtEaConfig DigitaleEingaenge { get; set; }
    public Textbausteine[] Textbausteine { get; set; }
}
public class AnalogeAusgaenge
{
    public bool ConfigOk { get; set; }
    public int AnzByte { get; set; }
    public EaConfig[] EaConfigs { get; set; }
}

public class DtEaConfig
{
    public bool ConfigOk { get; set; }
    public int AnzByte { get; set; }
    public EaConfig[] EaConfigs { get; set; }   
}
public class EaConfig
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
    // ReSharper disable once UnusedMember.Global
    public int VorbereitungId { get; set; }
    public string Test { get; set; }
    public string Kommentar { get; set; }
    public TextbausteineAnzeigen WasAnzeigen { get; set; }
}