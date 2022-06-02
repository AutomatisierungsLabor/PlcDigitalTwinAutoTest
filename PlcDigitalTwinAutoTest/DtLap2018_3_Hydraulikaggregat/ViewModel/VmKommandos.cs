using System.Windows;
using Microsoft.Toolkit.Mvvm.Input;

namespace DtLap2018_3_Hydraulikaggregat.ViewModel;

public partial class VmLap2018
{
    [ICommand]
    private void ButtonTaster(string taster)
    {
        switch (taster)
        {
            case "S1": (_modelLap2018.S1, ClickModeS1) = ButtonClickMode(ClickModeS1); break;
            case "S2": (_modelLap2018.S2, ClickModeS2) = ButtonClickModeInvertiert(ClickModeS2); break;
            case "S3":
                (_modelLap2018.S3, ClickModeS3) = ButtonClickMode(ClickModeS3);
                _modelLap2018.Stopwatch.Restart();
                break;
            case "S4": (_modelLap2018.S4, ClickModeS4) = ButtonClickMode(ClickModeS4); break;
            case "Nachfuellen": _modelLap2018.Pegel = 1; break;
        }
    }

    [ICommand]
    private void ButtonSchalter(string schalter)
    {
        switch (schalter)
        {
            case "B3": _modelLap2018.B3 = !_modelLap2018.B3; break;
            case "B4": _modelLap2018.B4 = !_modelLap2018.B4; break;
            case "B5": _modelLap2018.B5 = !_modelLap2018.B5; break;
            case "F1": _modelLap2018.F1 = !_modelLap2018.F1; break;
            case "ErweiterungOelKuehler": VisibilityErweiterungOelkuehler = VisibilityErweiterungOelkuehler == Visibility.Visible ? Visibility.Hidden : Visibility.Visible; break;
            case "ErweiterungZylinder": VisibilityErweiterungZylinder = VisibilityErweiterungZylinder == Visibility.Visible ? Visibility.Hidden : Visibility.Visible; break;
            case "ErweiterungOelFilter": VisibilityErweiterungOelfilter = VisibilityErweiterungOelfilter == Visibility.Visible ? Visibility.Hidden : Visibility.Visible; break;
        }
    }
}