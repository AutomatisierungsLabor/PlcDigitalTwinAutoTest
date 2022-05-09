using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DtLap2010_5_Pumpensteuerung.ViewModel;

public partial class VmLap2010
{
    [ObservableProperty] private Brush _brushF1;
    [ObservableProperty] private Brush _brushP1;
    [ObservableProperty] private Brush _brushP2;

    [ObservableProperty] private Brush _brushZuleitungWaagrecht;
    [ObservableProperty] private Brush _brushZuleitungSenkrecht;
    [ObservableProperty] private Brush _brushAbleitungOben;
    [ObservableProperty] private Brush _brushAbleitungUnten;

    [ObservableProperty] private ClickMode _clickModeF1;
    [ObservableProperty] private ClickMode _clickModeS3;
    [ObservableProperty] private ClickMode _clickModeY1;
    [ObservableProperty] private ClickMode _clickModeHand;
    [ObservableProperty] private ClickMode _clickModeAus;
    [ObservableProperty] private ClickMode _clickModeAutomatik;

    [ObservableProperty] private double _winkelSchalter;

    [ObservableProperty] private Thickness _marginPegel;



    [ObservableProperty] private Visibility _visibilityEinB1;
    [ObservableProperty] private Visibility _visibilityEinB2;
    [ObservableProperty] private Visibility _visibilityEinQ1;
    [ObservableProperty] private Visibility _visibilityEinY1;

    [ObservableProperty] private Visibility _visibilityAusB1;
    [ObservableProperty] private Visibility _visibilityAusB2;
    [ObservableProperty] private Visibility _visibilityAusQ1;
    [ObservableProperty] private Visibility _visibilityAusY1;
}