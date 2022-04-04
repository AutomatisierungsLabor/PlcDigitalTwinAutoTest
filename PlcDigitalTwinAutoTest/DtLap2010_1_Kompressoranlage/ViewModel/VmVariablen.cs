using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace DtLap2010_1_Kompressoranlage.ViewModel;

public partial class VmLap2010
{
    [ObservableProperty] private Brush _brushB2;
    [ObservableProperty] private Brush _brushF1;
    [ObservableProperty] private Brush _brushP1;
    [ObservableProperty] private Brush _brushP2;
    [ObservableProperty] private Brush _brushQ1;
    [ObservableProperty] private Brush _brushQ2;
    [ObservableProperty] private Brush _brushQ3;


    [ObservableProperty] private ClickMode _clickModeB2;
    [ObservableProperty] private ClickMode _clickModeF1;
    [ObservableProperty] private ClickMode _clickModeS1;
    [ObservableProperty] private ClickMode _clickModeS2;

    [ObservableProperty] private double _aktuellerDruck;

    [ObservableProperty] private string _stringF1;

    [ObservableProperty] private Visibility _visibilityEinB1;
    [ObservableProperty] private Visibility _visibilityEinB2;

    [ObservableProperty] private Visibility _visibilityAusB1;
    [ObservableProperty] private Visibility _visibilityAusB2;

    [ObservableProperty] private Visibility _visibilityFuellen;

    [ObservableProperty] private Visibility _visibilityKurzschluss;
}