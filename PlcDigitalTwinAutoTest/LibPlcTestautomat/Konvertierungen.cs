using LibPlcTools;
using SoftCircuits.Silk;

namespace LibPlcTestautomat;

public partial class TestAutomat
{
#pragma warning disable CA1822 // Mark members as static
    public void FuncPlcToDec(FunctionEventArgs args)
    {
        var zahl = args.Parameters[0].ToString();
        var plcZahl = new Uint(zahl);
        args.ReturnValue.SetValue((int)plcZahl.GetDec());
    }
#pragma warning restore CA1822 // Mark members as static
}