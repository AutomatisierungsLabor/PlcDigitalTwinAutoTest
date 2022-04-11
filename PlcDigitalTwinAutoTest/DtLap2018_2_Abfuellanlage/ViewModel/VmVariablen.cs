using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace DtLap2018_2_Abfuellanlage.ViewModel;

public partial class VmLap2018
{


    [ObservableProperty] private Brush _brushF1;
    [ObservableProperty] private Brush _brushP1;
    [ObservableProperty] private Brush _brushP2;
    [ObservableProperty] private Brush _brushQ1;
    [ObservableProperty] private Brush _brushZuleitung;
    [ObservableProperty] private Brush _brushAbleitung;

    [ObservableProperty] private ClickMode _clickModeF1;
    [ObservableProperty] private ClickMode _clickModeS1;
    [ObservableProperty] private ClickMode _clickModeS2;
    [ObservableProperty] private ClickMode _clickModeS3;
    [ObservableProperty] private ClickMode _clickModeS4;
    [ObservableProperty] private ClickMode _clickModeTankNachfuellen;
    [ObservableProperty] private ClickMode _clickModeAllesReset;

    [ObservableProperty] private Thickness _marginFlasche1;
    [ObservableProperty] private Thickness _marginFlasche2;
    [ObservableProperty] private Thickness _marginFlasche3;
    [ObservableProperty] private Thickness _marginFlasche4;
    [ObservableProperty] private Thickness _marginFlasche5;
    [ObservableProperty] private Thickness _marginFlasche6;
    [ObservableProperty] private Thickness _marginPegel;

    [ObservableProperty] private string _stringFuellstandProzent;

    [ObservableProperty] private Visibility _visibilityEinB1;
    [ObservableProperty] private Visibility _visibilityEinK1;
    [ObservableProperty] private Visibility _visibilityEinK2;

    [ObservableProperty] private Visibility _visibilityAusB1;
    [ObservableProperty] private Visibility _visibilityAusK1;
    [ObservableProperty] private Visibility _visibilityAusK2;
    
    [ObservableProperty] private Visibility _visibilityFlasche1;
    [ObservableProperty] private Visibility _visibilityFlasche2;
    [ObservableProperty] private Visibility _visibilityFlasche3;
    [ObservableProperty] private Visibility _visibilityFlasche4;
    [ObservableProperty] private Visibility _visibilityFlasche5;
    [ObservableProperty] private Visibility _visibilityFlasche6;

    [ObservableProperty] private Visibility _visibilityFohrenburger0;
    [ObservableProperty] private Visibility _visibilityFohrenburger1;
    [ObservableProperty] private Visibility _visibilityFohrenburger2;
    [ObservableProperty] private Visibility _visibilityFohrenburger3;
    [ObservableProperty] private Visibility _visibilityFohrenburger4;
    [ObservableProperty] private Visibility _visibilityFohrenburger5;
    [ObservableProperty] private Visibility _visibilityFohrenburger6;

    [ObservableProperty] private Visibility _visibilityMohren0;
    [ObservableProperty] private Visibility _visibilityMohren1;
    [ObservableProperty] private Visibility _visibilityMohren2;
    [ObservableProperty] private Visibility _visibilityMohren3;
    [ObservableProperty] private Visibility _visibilityMohren4;
    [ObservableProperty] private Visibility _visibilityMohren5;
    [ObservableProperty] private Visibility _visibilityMohren6;
}