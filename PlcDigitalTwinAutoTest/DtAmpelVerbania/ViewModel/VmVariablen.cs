using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace DtAmpelVerbania.ViewModel;

public partial class VmAmpelVerbania
{
    [ObservableProperty] private short _shortSiebenSegmentAnzeige;
    
    [ObservableProperty] private Brush _brushAnzeige;
    [ObservableProperty] private Brush _brushP11;
    [ObservableProperty] private Brush _brushP12;
    [ObservableProperty] private Brush _brushP13;
    [ObservableProperty] private Brush _brushP21;
    [ObservableProperty] private Brush _brushP22;
    [ObservableProperty] private Brush _brushP23;
    [ObservableProperty] private Brush _brushP31;
    [ObservableProperty] private Brush _brushP32;
    [ObservableProperty] private Brush _brushP33;


    [ObservableProperty] private ClickMode _clickModeS1;
    [ObservableProperty] private ClickMode _clickModeS2;

    [ObservableProperty] private string _stringAnzeige;

    [ObservableProperty] private Visibility _visibilityAnzeige;
    [ObservableProperty] private Visibility _visibilitySiebenSegmentAnzeige;
}