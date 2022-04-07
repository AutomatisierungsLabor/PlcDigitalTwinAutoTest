using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace DtLap2018_1_Silosteuerung.ViewModel;

public partial class VmLap2018
{
    [ObservableProperty] private Brush _brushF1;
    [ObservableProperty] private Brush _brushF2;
    [ObservableProperty] private Brush _brushP1;
    [ObservableProperty] private Brush _brushP2;
    [ObservableProperty] private Brush _brushQ1;
    [ObservableProperty] private Brush _brushQ2;
    [ObservableProperty] private Brush _brushS2;
    [ObservableProperty] private Brush _brushRutscheVoll;
    [ObservableProperty] private Brush _brushMaterialUnten;
    [ObservableProperty] private Brush _brushMaterialOben;


    [ObservableProperty] private ClickMode _clickModeS0;
    [ObservableProperty] private ClickMode _clickModeS1;
    [ObservableProperty] private ClickMode _clickModeS2;
    [ObservableProperty] private ClickMode _clickModeS3;
    [ObservableProperty] private ClickMode _clickModeF1;
    [ObservableProperty] private ClickMode _clickModeF2;
    [ObservableProperty] private ClickMode _clickModeWagenNachLinks;
    [ObservableProperty] private ClickMode _clickModeWagenNachRechts;
    [ObservableProperty] private ClickMode _clickRutscheVoll;


    [ObservableProperty] private Visibility _visibilityEinB1;
    [ObservableProperty] private Visibility _visibilityEinB2;
    [ObservableProperty] private Visibility _visibilityEinQ1;
    [ObservableProperty] private Visibility _visibilityEinQ2;
    [ObservableProperty] private Visibility _visibilityEinS1;
    [ObservableProperty] private Visibility _visibilityEinY1;
    [ObservableProperty] private Visibility _visibilityEinMaterialOben;
    [ObservableProperty] private Visibility _visibilityEinMaterialUnten;

    [ObservableProperty] private Visibility _visibilityAusB1;
    [ObservableProperty] private Visibility _visibilityAusB2;
    [ObservableProperty] private Visibility _visibilityAusQ1;
    [ObservableProperty] private Visibility _visibilityAusQ2;
    [ObservableProperty] private Visibility _visibilityAusS1;
    [ObservableProperty] private Visibility _visibilityAusY1;
    [ObservableProperty] private Visibility _visibilityAusMaterialOben;
    [ObservableProperty] private Visibility _visibilityAusMaterialUnten;


    [ObservableProperty] private string _stringMaterialSiloFuellstand;
    [ObservableProperty] private string _stringRutscheVoll;

    [ObservableProperty] private Thickness _marginPositionWagen;
    [ObservableProperty] private Thickness _marginPostionWagenInhalt;
    [ObservableProperty] private Thickness _marginSilo;

}