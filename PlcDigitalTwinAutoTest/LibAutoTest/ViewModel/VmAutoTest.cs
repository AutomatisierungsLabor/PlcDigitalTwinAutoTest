using LibAutoTestSilk;
using System.Threading;
using System.Windows;
using LibDatenstruktur;
using LibPlcKommunikation;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace LibAutoTest.ViewModel;

public partial class VmAutoTest : ObservableObject
{
    private readonly AutoTest _autoTest;
    private readonly AutoTesterSilk _autoTesterSilk;
    private readonly PlcDaemon _plcDaemon;

    public VmAutoTest(AutoTest autoTest, AutoTesterSilk autoTesterSilk, Datenstruktur datenstruktur, PlcDaemon plcDaemon, CancellationTokenSource cancellationTokenSource)
    {
        _autoTest = autoTest;
        _autoTesterSilk = autoTesterSilk;
        _plcDaemon = plcDaemon;

        VisibilityTabAutoTest = Visibility.Visible;
        VisibilityTasterStart = Visibility.Visible;
        StringTasterStart = "Test Starten";

        VisibilityTasterEinzelschritt = Visibility.Hidden;
        EnableTasterStart = false;

        System.Threading.Tasks.Task.Run(() => ViewModelTask(datenstruktur, cancellationTokenSource));
    }
    private void ViewModelTask(Datenstruktur datenstruktur, CancellationTokenSource cancellationTokenSource)
    {
        while (!cancellationTokenSource.IsCancellationRequested)
        {
            Thread.Sleep(10);
        }
    }
}