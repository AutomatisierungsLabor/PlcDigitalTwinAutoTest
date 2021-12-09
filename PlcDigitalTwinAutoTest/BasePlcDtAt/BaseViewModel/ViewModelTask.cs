using System.Threading;

namespace BasePlcDtAt.BaseViewModel;

public partial class ViewModel
{
    private void ViewModelTask()
    {
        while (true)
        {

            Thread.Sleep(10);
        }
        // ReSharper disable once FunctionNeverReturns
    }
}