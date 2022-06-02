using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Windows.Controls;
using System.Windows.Media;

namespace DtFibonacci.ViewModel;

public partial class VmFibonacci
{
    [ObservableProperty] private Brush _brushP1;

    [ObservableProperty] private ClickMode _clickModeS1;
}