using LibPlcTools;
using SoftCircuits.Silk;

namespace LibPlcTestautomat;

public partial class TestAutomat
{
    public void FuncSetDigitaleEingaenge(FunctionEventArgs args)
    {
        var di = new Uint((ulong)args.Parameters[0].ToInteger());
        _datenstruktur.Di[0] = Simatic.Digital_GetLowByte((uint)di.GetDec());
        _datenstruktur.Di[1] = Simatic.Digital_GetHighByte((uint)di.GetDec());
    }
}