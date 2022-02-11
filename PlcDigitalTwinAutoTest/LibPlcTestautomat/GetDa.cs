using LibPlcTools;
using SoftCircuits.Silk;

namespace LibPlcTestautomat;

public partial class TestAutomat
{
    public uint GetDigitalOutputWord() => Simatic.Digital_CombineTwoByte(_datenstruktur.Da[0], _datenstruktur.Da[1]);
    public void FuncGetDigitaleAusgaenge(FunctionEventArgs args) => args.ReturnValue.SetValue((int)GetDigitalOutputWord());
}