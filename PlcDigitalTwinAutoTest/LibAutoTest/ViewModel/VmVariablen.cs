using System.Windows;
using System.Windows.Controls;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace LibAutoTest.ViewModel;

public partial class VmAutoTest
{
    [ObservableProperty] private bool _enableTasterStart;

    [ObservableProperty] private ClickMode _clickModeStart;
    [ObservableProperty] private ClickMode _clickModeEinzelSchritt;

    [ObservableProperty] private Visibility _visibilityTabAutoTest;
    [ObservableProperty] private Visibility _visibilityTasterStart;
    [ObservableProperty] private Visibility _visibilityTasterEinzelschritt;

   [ObservableProperty] private string _stringTasterStart;
}
