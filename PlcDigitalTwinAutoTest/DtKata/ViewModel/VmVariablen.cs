using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace DtKata.ViewModel;

public partial class VmKata
{

    [ObservableProperty] private Brush _brushP1;
    [ObservableProperty] private Brush _brushP2;
    [ObservableProperty] private Brush _brushP3;
    [ObservableProperty] private Brush _brushP4;
    [ObservableProperty] private Brush _brushP5;
    [ObservableProperty] private Brush _brushP6;
    [ObservableProperty] private Brush _brushP7;
    [ObservableProperty] private Brush _brushP8;

    [ObservableProperty] private ClickMode _clickModeS1;
    [ObservableProperty] private ClickMode _clickModeS2;
    [ObservableProperty] private ClickMode _clickModeS3;
    [ObservableProperty] private ClickMode _clickModeS4;

    [ObservableProperty] private string _stringS1;
    [ObservableProperty] private string _stringS2;
    [ObservableProperty] private string _stringS3;
    [ObservableProperty] private string _stringS4;

    [ObservableProperty] private Visibility _visibilityEinS1;
    [ObservableProperty] private Visibility _visibilityEinS2;
    [ObservableProperty] private Visibility _visibilityEinS3;
    [ObservableProperty] private Visibility _visibilityEinS4;
    [ObservableProperty] private Visibility _visibilityEinS5;
    [ObservableProperty] private Visibility _visibilityEinS6;
    [ObservableProperty] private Visibility _visibilityEinS7;
    [ObservableProperty] private Visibility _visibilityEinS8;

    [ObservableProperty] private Visibility _visibilityAusS1;
    [ObservableProperty] private Visibility _visibilityAusS2;
    [ObservableProperty] private Visibility _visibilityAusS3;
    [ObservableProperty] private Visibility _visibilityAusS4;
    [ObservableProperty] private Visibility _visibilityAusS5;
    [ObservableProperty] private Visibility _visibilityAusS6;
    [ObservableProperty] private Visibility _visibilityAusS7;
    [ObservableProperty] private Visibility _visibilityAusS8;
}