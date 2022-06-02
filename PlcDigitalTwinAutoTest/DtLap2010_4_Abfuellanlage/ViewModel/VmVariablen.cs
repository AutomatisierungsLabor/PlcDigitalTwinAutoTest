using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DtLap2010_4_Abfuellanlage.ViewModel;

public partial class VmLap2010
{

    [ObservableProperty] private Brush _brushP1;
    [ObservableProperty] private Brush _brushQ1;
    [ObservableProperty] private Brush _brushZuleitung;

    [ObservableProperty] private ClickMode _clickModeS1;
    [ObservableProperty] private ClickMode _clickModeS2;
    [ObservableProperty] private ClickMode _clickModeReset;
    [ObservableProperty] private ClickMode _clickModeNachfuellen;



    [ObservableProperty] private Visibility _visibilityAbleitung;

    [ObservableProperty] private Visibility _visibilityEinB1;
    [ObservableProperty] private Visibility _visibilityEinB2;
    [ObservableProperty] private Visibility _visibilityEinK1;
    [ObservableProperty] private Visibility _visibilityEinK2;

    [ObservableProperty] private Visibility _visibilityAusB1;
    [ObservableProperty] private Visibility _visibilityAusB2;
    [ObservableProperty] private Visibility _visibilityAusK1;
    [ObservableProperty] private Visibility _visibilityAusK2;

    [ObservableProperty] private Thickness _fuellstand;
}