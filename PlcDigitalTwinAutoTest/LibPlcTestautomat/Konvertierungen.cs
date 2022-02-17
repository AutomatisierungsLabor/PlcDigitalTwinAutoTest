using LibPlcTools;
using SoftCircuits.Silk;

namespace LibPlcTestautomat;

public partial class TestAutomat
{
    public void FuncPlcToDec(FunctionEventArgs args)
    {
        var zahl = args.Parameters[0].ToString();
        var plcZahl = new Uint(zahl);
        args.ReturnValue.SetValue((int)plcZahl.GetDec());
    }
}