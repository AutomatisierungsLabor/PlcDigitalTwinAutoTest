using System.ComponentModel;
using System.Threading;

namespace BasePlcDtAt.BaseViewModel;

public abstract partial class ViewModel : INotifyPropertyChanged
{
    private void ViewModelTask()
    {
        while (true)
        {
            ViewModelAufrufThread();
            Thread.Sleep(10);
        }
        // ReSharper disable once FunctionNeverReturns
    }
}