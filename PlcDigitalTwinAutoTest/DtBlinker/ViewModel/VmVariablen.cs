using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Windows.Controls;
using System.Windows.Media;

namespace DtBlinker.ViewModel;

public partial class VmBlinker
{
    [ObservableProperty] private Brush _brushP1;

    [ObservableProperty] private ClickMode _clickModeS1;
    [ObservableProperty] private ClickMode _clickModeS2;
    [ObservableProperty] private ClickMode _clickModeS3;
    [ObservableProperty] private ClickMode _clickModeS4;
    [ObservableProperty] private ClickMode _clickModeS5;
}