using System.Windows;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace BasePlcDtAt.BaseViewModel;

public abstract partial class VmBase
{
    [ObservableProperty]
    private Visibility _visibilityTabBeschreibung;

    [ObservableProperty]
    private Visibility _visibilityTabLaborplatte;

    [ObservableProperty]
    private Visibility _visibilityTabSimulation;

    [ObservableProperty]
    private Visibility _visibilityTabSoftwareTest;
}