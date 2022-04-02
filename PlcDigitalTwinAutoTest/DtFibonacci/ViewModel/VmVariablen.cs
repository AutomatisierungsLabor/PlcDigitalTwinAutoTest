using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace DtFibonacci.ViewModel;

public partial class VmFibonacci
{
    [ObservableProperty] private Brush _brushP1;

    [ObservableProperty] private ClickMode _clickModeS1;

    [ObservableProperty] private string _stringS1;
}