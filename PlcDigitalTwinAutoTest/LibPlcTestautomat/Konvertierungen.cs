using LibPlcTools;
using SoftCircuits.Silk;

namespace LibPlcTestautomat;

public partial class TestAutomat
{
    public void PlcToDec(FunctionEventArgs functionEventArgs)
    {
        var zahl = functionEventArgs.Parameters[0].ToString();
        var plcZahl = new Uint(zahl);
        functionEventArgs.ReturnValue.SetValue((int)plcZahl.GetDec());
    }
}