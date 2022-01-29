using LibAutoTestSilk.TestAutomat;
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

    public void Runtime_Begin(object sender, BeginEventArgs e)
    {
        const string data = "";
        e.UserData = data;

        VmAutoTesterSilk.UpdateDataGrid(new DataGridZeile(
             VmAutoTesterSilk.ZeilenNummerDataGrid++,
             $"{SilkStopwatch.ElapsedMilliseconds}ms",
             TestAnzeige.TestStart,
             " ",        // DigInput 
             " ",        // DigOutput Soll
             " ",        // DigOutput Ist
             " "));
    }
    private void Runtime_End(object sender, EndEventArgs e)
    {
        VmAutoTesterSilk.UpdateDataGrid(new DataGridZeile(
            VmAutoTesterSilk.ZeilenNummerDataGrid++,
            $"{SilkStopwatch.ElapsedMilliseconds}ms",
            TestAnzeige.TestEnde,
            " ",        // DigInput 
            " ",        // DigOutput Soll
            " ",        // DigOutput Ist
            " "));
    }
}