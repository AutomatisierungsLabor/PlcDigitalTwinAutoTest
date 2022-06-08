using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DtSchleifmaschine.ViewModel;

public partial class VmSchleifmaschine
{
    [ObservableProperty] private Brush _brushF1;
    [ObservableProperty] private Brush _brushF2;
    [ObservableProperty] private Brush _brushP1;
    [ObservableProperty] private Brush _brushP2;
    [ObservableProperty] private Brush _brushP3;
    [ObservableProperty] private Brush _brushQ1;
    [ObservableProperty] private Brush _brushQ2;
    [ObservableProperty] private Brush _brushS3;

    [ObservableProperty] private ClickMode _clickModeF1;
    [ObservableProperty] private ClickMode _clickModeF2;
    [ObservableProperty] private ClickMode _clickModeS0;
    [ObservableProperty] private ClickMode _clickModeS1;
    [ObservableProperty] private ClickMode _clickModeS2;
    [ObservableProperty] private ClickMode _clickModeS3;
    [ObservableProperty] private ClickMode _clickModeS4;

    [ObservableProperty] private double _winkel;
    [ObservableProperty] private double _aktuelleDrehzahl;

    [ObservableProperty] private string _stringSchleifmaschineDrehzahl;

    [ObservableProperty] private Visibility _visibilityEinB1;
    [ObservableProperty] private Visibility _visibilityEinS3;

    [ObservableProperty] private Visibility _visibilityAusB1;
    [ObservableProperty] private Visibility _visibilityAusS3;

    [ObservableProperty] private Visibility _visibilityUebersynchron;

    [ObservableProperty] private Point _pointTransformOrigin;

}