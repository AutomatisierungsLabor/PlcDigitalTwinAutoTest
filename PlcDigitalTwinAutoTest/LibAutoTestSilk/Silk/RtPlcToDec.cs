using LibPlcTools;
using SoftCircuits.Silk;

namespace LibAutoTestSilk.Silk;

public partial class Silk
{
    private static void PlcToDec(FunctionEventArgs e)
    {
        var zahl = e.Parameters[0].ToString();
        var plcZahl = new Uint(zahl);
        e.ReturnValue.SetValue((int)plcZahl.GetDec());
    }
}