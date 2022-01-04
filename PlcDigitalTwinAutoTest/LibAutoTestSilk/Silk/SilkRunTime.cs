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
}