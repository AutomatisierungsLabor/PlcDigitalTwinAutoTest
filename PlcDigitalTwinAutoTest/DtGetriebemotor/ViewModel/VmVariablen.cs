using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace DtGetriebemotor.ViewModel;

public partial class VmGetriebemotor
{


    [ObservableProperty] private Brush _brushP1;
    [ObservableProperty] private Brush _brushP2;
    [ObservableProperty] private Brush _brushP3;

    [ObservableProperty] private double _winkelGetriebemotor;

    [ObservableProperty] private ClickMode _clickModeS1;
    [ObservableProperty] private ClickMode _clickModeS2;
    [ObservableProperty] private ClickMode _clickModeS3;
    [ObservableProperty] private ClickMode _clickModeS4;
    [ObservableProperty] private ClickMode _clickModeS5;
    [ObservableProperty] private ClickMode _clickModeS6;
    [ObservableProperty] private ClickMode _clickModeS7;
    [ObservableProperty] private ClickMode _clickModeS8;
    [ObservableProperty] private ClickMode _clickModeS9;

    [ObservableProperty] private Visibility _visibilityEinB1;
    [ObservableProperty] private Visibility _visibilityEinB2;
    [ObservableProperty] private Visibility _visibilityEinS91;

    [ObservableProperty] private Visibility _visibilityAusB1;
    [ObservableProperty] private Visibility _visibilityAusB2;
    [ObservableProperty] private Visibility _visibilityAusS91;

    [ObservableProperty] private Point _pointTransformOrigin;
}