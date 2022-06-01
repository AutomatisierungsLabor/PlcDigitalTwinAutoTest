using Microsoft.Toolkit.Mvvm.Input;

namespace DtLap2018_4_Niveauregelung.ViewModel;

public partial class VmLap2018
{
    [ICommand]
    private void ButtonTaster(string taster)
    {
        switch (taster)
        {
            case "S1": (_modelLap2018.S1, ClickModeS1) = ButtonClickMode(ClickModeS1); break;
            case "S2": (_modelLap2018.S2, ClickModeS2) = ButtonClickMode(ClickModeS2); break;
            case "S3": (_modelLap2018.S3, ClickModeS3) = ButtonClickModeInvertiert(ClickModeS3); break;

        }
    }

    [ICommand]
    private void ButtonSchalter(string schalter)
    {
        switch (schalter)
        {
            case "F1": _modelLap2018.F1 = !_modelLap2018.F1; break;
            case "F2": _modelLap2018.F2 = !_modelLap2018.F2; break;
            case "Y1": _modelLap2018.Y1 = !_modelLap2018.Y1; break;
        }
    }
}
