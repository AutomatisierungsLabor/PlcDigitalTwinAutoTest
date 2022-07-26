using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Windows;
using System.Windows.Media;

namespace BasePlcDtAt.BaseViewModel;

public abstract partial class VmBase
{
    [ObservableProperty] private Brush _brushErrorAnzeige;
    [ObservableProperty] private Brush _brushSpsColor;

    [ObservableProperty] private Visibility _visibilityTabBeschreibung;
    [ObservableProperty] private Visibility _visibilityTabLaborplatte;
    [ObservableProperty] private Visibility _visibilityTabSimulation;
    [ObservableProperty] private Visibility _visibilityTabSoftwareTest;

    [ObservableProperty] private Visibility _visibilityBtnPlcAnzeigen;
    [ObservableProperty] private Visibility _visibilityBtnPlottAnzeigen;
    [ObservableProperty] private Visibility _visibilityBtnLinkHomepageAnzeigen;
    [ObservableProperty] private Visibility _visibilityBtnAlarmVerwaltungAnzeigen;
    [ObservableProperty] private Visibility _visibilityBtnInfoAnzeigen;

    [ObservableProperty] private Visibility _visibilityErrorAnzeige;
    [ObservableProperty] private Visibility _visibilityErrorMeldung;
    [ObservableProperty] private Visibility _visibilityErrorVersionLokal;
    [ObservableProperty] private Visibility _visibilityErrorVersionPlc;

    [ObservableProperty] private Visibility _visibilitySpsSichtbar;


    [ObservableProperty] private string _stringErrorMeldung;
    [ObservableProperty] private string _stringErrorVersionLokal;
    [ObservableProperty] private string _stringErrorVersionPlc;

    [ObservableProperty] private string _stringFensterTitel;
    [ObservableProperty] private string _stringSpsVersionLokal;
    [ObservableProperty] private string _stringSpsVersionEntfernt;
    [ObservableProperty] private string _stringSpsStatus;

}