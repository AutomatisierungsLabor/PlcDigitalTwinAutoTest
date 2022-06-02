using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DtLap2010_2_Transportwagen.ViewModel;

public partial class VmLap2010
{
    [ObservableProperty] private Brush _brushF1;
    [ObservableProperty] private Brush _brushP1;
    [ObservableProperty] private Brush _brushQ1;
    [ObservableProperty] private Brush _brushQ2;
    [ObservableProperty] private Brush _brushS2;

    [ObservableProperty] private ClickMode _clickModeF1;
    [ObservableProperty] private ClickMode _clickModeS1;
    [ObservableProperty] private ClickMode _clickModeS2;
    [ObservableProperty] private ClickMode _clickModeS3;

    [ObservableProperty] private Visibility _visibilityEinB1;
    [ObservableProperty] private Visibility _visibilityEinB2;
    [ObservableProperty] private Visibility _visibilityFuellen;
    [ObservableProperty] private Visibility _visibilityKurzschluss;

    [ObservableProperty] private Visibility _visibilityAusB1;
    [ObservableProperty] private Visibility _visibilityAusB2;

    [ObservableProperty] private Thickness _positionWagenkasten;
    [ObservableProperty] private Thickness _positionRadLinks;
    [ObservableProperty] private Thickness _positionRadRechts;
}