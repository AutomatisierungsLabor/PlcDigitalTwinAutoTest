using LibPlcTools;

namespace LibAutoTestSilk.Silk;

public partial class Silk
{
    internal void SetDigitaleEingaengeWord(Uint eingaenge)
    {
        _datenstruktur.Di[0] = Simatic.Digital_GetLowByte((uint)eingaenge.GetDec());
        _datenstruktur.Di[1] = Simatic.Digital_GetHighByte((uint)eingaenge.GetDec());
    }
}