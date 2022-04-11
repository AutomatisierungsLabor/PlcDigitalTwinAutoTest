using LibAutoTestSilk;
using System.Windows;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace LibAutoTest.ViewModel;

public partial class VmAutoTest : ObservableObject
{
    private readonly AutoTest _autoTest;
    private readonly AutoTesterSilk _autoTesterSilk;

    public VmAutoTest(AutoTest autoTest, AutoTesterSilk autoTesterSilk)
    {
        _autoTest = autoTest;
        _autoTesterSilk = autoTesterSilk;

        VisibilityTabAutoTest = Visibility.Visible;
        VisibilityTasterStart = Visibility.Visible;
        StringTasterStart = "Test Starten";

        VisibilityTasterEinzelschritt = Visibility.Hidden;
        EnableTasterStart = false;
    }
}