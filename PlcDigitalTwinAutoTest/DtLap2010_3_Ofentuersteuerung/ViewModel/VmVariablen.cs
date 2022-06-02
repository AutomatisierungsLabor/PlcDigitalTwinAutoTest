using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DtLap2010_3_Ofentuersteuerung.ViewModel;

public partial class VmLap2010
{

    [ObservableProperty] private Brush _brushP1;
    [ObservableProperty] private Brush _brushQ1;
    [ObservableProperty] private Brush _brushQ2;

    [ObservableProperty] private ClickMode _clickModeB2;
    [ObservableProperty] private ClickMode _clickModeS1;
    [ObservableProperty] private ClickMode _clickModeS2;
    [ObservableProperty] private ClickMode _clickModeS3;

    [ObservableProperty] private double _aktuellerDruck;
    [ObservableProperty] private double _zahnradWinkel;

    [ObservableProperty] private Visibility _visibilityEinB1;
    [ObservableProperty] private Visibility _visibilityEinB2;
    [ObservableProperty] private Visibility _visibilityEinB3;

    [ObservableProperty] private Visibility _visibilityAusB1;
    [ObservableProperty] private Visibility _visibilityAusB2;
    [ObservableProperty] private Visibility _visibilityAusB3;

    [ObservableProperty] private Visibility _visibilityKurzschluss;

    [ObservableProperty] private Thickness _ofentuerePosition;
    [ObservableProperty] private Thickness _zahnstangePosition;
}