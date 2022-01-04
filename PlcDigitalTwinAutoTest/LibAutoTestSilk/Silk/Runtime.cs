using LibAutoTestSilk.TestAutomat;
using SoftCircuits.Silk;

namespace LibAutoTestSilk.Silk;

public partial class Silk
{
    public void Runtime_Begin(object sender, BeginEventArgs e)
    {
        const string data = "";
        e.UserData = data;

        VmSilkAutoTester.UpdateDataGrid(new DataGridZeile(
            VmSilkAutoTester.ZeilenNummerDataGrid++,
            $"{SilkStopwatch.ElapsedMilliseconds}ms",
            TestAnzeige.TestStart,
            " ",
            " ",
            " ",
            " "));
    }

    private void Runtime_End(object sender, EndEventArgs e)
    {
        VmSilkAutoTester.UpdateDataGrid(new DataGridZeile(
            VmSilkAutoTester.ZeilenNummerDataGrid++,
            $"{SilkStopwatch.ElapsedMilliseconds}ms",
            TestAnzeige.TestEnde,
            " ",
            " ",
            " ",
            " "));
    }

    public void RunProgram(CompiledProgram program)
    {
        var runtime = new Runtime(program);
        runtime.Begin += Runtime_Begin;
        runtime.Function += Runtime_Function;
        runtime.End += Runtime_End;

        runtime.Execute();
    }
}