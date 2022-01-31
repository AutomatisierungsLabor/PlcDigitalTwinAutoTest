using LibDatenstruktur;
using LibPlcTools;
using SoftCircuits.Silk;

namespace LibPlcTestautomat;

public partial class TestAutomat
{
    private uint GetDigitalOutputWord() => Simatic.Digital_CombineTwoByte(_datenstruktur.Da[0], _datenstruktur.Da[1]);

    public void GetDigitaleAusgaenge(FunctionEventArgs functionEventArgs)
    {
        functionEventArgs.ReturnValue.SetValue((int)GetDigitalOutputWord());
    }
}