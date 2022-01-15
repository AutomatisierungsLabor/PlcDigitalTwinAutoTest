using System.Threading;
using LibAutoTest;

namespace BasePlcDtAt.BaseViewModel;

public abstract partial class VmBase
{

    private AutoTest _autoTest;
    private void ViewModelTask()
    {
        while (true)
        {

            if (_autoTest != null) _autoTest.LibWpfAutoTest.PlcError(PlcDaemon);


            ViewModelAufrufThread();
            Thread.Sleep(10);
        }
        // ReSharper disable once FunctionNeverReturns
    }

    public void SetAutoTestRef(AutoTest autoTest ) => _autoTest = autoTest;
}