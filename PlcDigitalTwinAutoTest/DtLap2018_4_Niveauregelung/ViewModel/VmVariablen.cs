using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace DtLap2018_4_Niveauregelung.ViewModel;

public partial class VmLap2018
{
    [ObservableProperty] private Brush _brushF1;
    [ObservableProperty] private Brush _brushF2;
    [ObservableProperty] private Brush _brushP1;
    [ObservableProperty] private Brush _brushP2;
    [ObservableProperty] private Brush _brushP3;

    [ObservableProperty] private Brush _brushAbleitungOben;
    [ObservableProperty] private Brush _brushAbleitungUnten;
    [ObservableProperty] private Brush _brushZuleitungLinksWaagrecht;
    [ObservableProperty] private Brush _brushZuleitungLinksSenkrecht;
    [ObservableProperty] private Brush _brushZuleitungRechtsWaagrecht;
    [ObservableProperty] private Brush _brushZuleitungRechtsSenkrecht;

    [ObservableProperty] private ClickMode _clickModeF1;
    [ObservableProperty] private ClickMode _clickModeF2;
    [ObservableProperty] private ClickMode _clickModeS1;
    [ObservableProperty] private ClickMode _clickModeS2;
    [ObservableProperty] private ClickMode _clickModeS3;
    [ObservableProperty] private ClickMode _clickModeY1;

    [ObservableProperty] private Visibility _visibilityEinB1;
    [ObservableProperty] private Visibility _visibilityEinB2;
    [ObservableProperty] private Visibility _visibilityEinB3;
    [ObservableProperty] private Visibility _visibilityEinQ1;
    [ObservableProperty] private Visibility _visibilityEinQ2;
    [ObservableProperty] private Visibility _visibilityEinY1;

    [ObservableProperty] private Visibility _visibilityAusB1;
    [ObservableProperty] private Visibility _visibilityAusB2;
    [ObservableProperty] private Visibility _visibilityAusB3;
    [ObservableProperty] private Visibility _visibilityAusQ1;
    [ObservableProperty] private Visibility _visibilityAusQ2;
    [ObservableProperty] private Visibility _visibilityAusY1;

    [ObservableProperty] private Thickness _thicknessFuellstand;
}