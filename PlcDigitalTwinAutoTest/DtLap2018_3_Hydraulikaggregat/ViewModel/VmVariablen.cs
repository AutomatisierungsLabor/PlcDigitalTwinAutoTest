using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DtLap2018_3_Hydraulikaggregat.ViewModel;

public partial class VmLap2018
{
    [ObservableProperty] private Brush _brushB3;
    [ObservableProperty] private Brush _brushB4;
    [ObservableProperty] private Brush _brushB5;
    [ObservableProperty] private Brush _brushF1;
    [ObservableProperty] private Brush _brushK1;
    [ObservableProperty] private Brush _brushK2;
    [ObservableProperty] private Brush _brushP1;
    [ObservableProperty] private Brush _brushP2;
    [ObservableProperty] private Brush _brushP3;
    [ObservableProperty] private Brush _brushP4;
    [ObservableProperty] private Brush _brushP5;
    [ObservableProperty] private Brush _brushP6;
    [ObservableProperty] private Brush _brushP7;
    [ObservableProperty] private Brush _brushP8;
    [ObservableProperty] private Brush _brushQ1;
    [ObservableProperty] private Brush _brushQ2;
    [ObservableProperty] private Brush _brushQ3;
    [ObservableProperty] private Brush _brushQ4;
    [ObservableProperty] private Brush _brushS4;
    [ObservableProperty] private Brush _brushUeberdruck;

    [ObservableProperty] private ClickMode _clickModeB3;
    [ObservableProperty] private ClickMode _clickModeB4;
    [ObservableProperty] private ClickMode _clickModeB5;
    [ObservableProperty] private ClickMode _clickModeF1;
    [ObservableProperty] private ClickMode _clickModeS1;
    [ObservableProperty] private ClickMode _clickModeS2;
    [ObservableProperty] private ClickMode _clickModeS3;
    [ObservableProperty] private ClickMode _clickModeS4;
    [ObservableProperty] private ClickMode _clickModeUeberdruck;
    [ObservableProperty] private ClickMode _clickModeNachfuellen;

    [ObservableProperty] private double _doubleAktuellerDruck;

    [ObservableProperty] private Visibility _visibilityEinB1;
    [ObservableProperty] private Visibility _visibilityEinB2;
    [ObservableProperty] private Visibility _visibilityEinB3;
    [ObservableProperty] private Visibility _visibilityEinKurzschluss;

    [ObservableProperty] private Visibility _visibilityAusB1;
    [ObservableProperty] private Visibility _visibilityAusB2;
    [ObservableProperty] private Visibility _visibilityAusB3;

    [ObservableProperty] private Visibility _visibilityErweiterungOelkuehler;
    [ObservableProperty] private Visibility _visibilityErweiterungZylinder;
    [ObservableProperty] private Visibility _visibilityErweiterungOelfilter;

    [ObservableProperty] private string _stringFuellstand;

    [ObservableProperty] private Thickness _thicknessFuellstand;
}