namespace Contracts;

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
    SiemensAnalogwertSchieberegler,
    TestErrorAusgeben
}
public enum EaConfigError
{
    None,
    UngueltigesStartByte,
    UngueltigesStartBit,
    BezeichnungFehlt,
    KommentarFehlt,
    BitKollision,
    ByteKollision,
    NichtBelegt,
    FalscheId,
    UnbekannterFehler
}