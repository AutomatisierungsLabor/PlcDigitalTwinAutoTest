using System.Threading;

namespace LibAutoTest.ViewModel;

public partial class ViewModel
{
    private void VisuAnzeigenTask()
    {
        while (true)
        {

            Text[(int)WpfObjects.TasterStart] = "Test Starten";

            Thread.Sleep(10);
        }

        // ReSharper disable once FunctionNeverReturns
    }
}