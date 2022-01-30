using LibTestDatensammlung;
using SoftCircuits.Silk;

namespace LibAutoTestSilk.Silk;

public partial class Silk
{
    public void RunProgram(CompiledProgram program)
    {
        var runtime = new Runtime(program);
        runtime.Begin += Runtime_Begin;
        runtime.Function += Runtime_Function;
        runtime.End += Runtime_End;

        runtime.Execute();
    }
    public void Runtime_Begin(object sender, BeginEventArgs e) => VmAutoTesterSilk.DataGridKommentarAnzeigen(VmAutoTesterSilk.ZeilenNummerDataGrid++, $"{SilkStopwatch.ElapsedMilliseconds}ms", TestAnzeige.TestStart, " ");
    private void Runtime_End(object sender, EndEventArgs e) => VmAutoTesterSilk.DataGridKommentarAnzeigen(VmAutoTesterSilk.ZeilenNummerDataGrid++, $"{SilkStopwatch.ElapsedMilliseconds}ms", TestAnzeige.TestEnde, " ");
}