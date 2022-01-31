using LibPlcTools;

namespace LibAutoTestSilk.Silk;

public partial class Silk
{
    internal void SetDigitaleEingaengeWord(Uint eingaenge)
    {
        Datenstruktur.Di[0] = Simatic.Digital_GetLowByte((uint)eingaenge.GetDec());
        Datenstruktur.Di[1] = Simatic.Digital_GetHighByte((uint)eingaenge.GetDec());
    }
}