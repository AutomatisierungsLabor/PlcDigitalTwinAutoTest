using Contracts;
using Microsoft.Toolkit.Mvvm.Input;

namespace DtLap2018_2_Abfuellanlage.ViewModel;

public partial class VmLap2018
{
    [ICommand]
    private void ButtonTaster(string taster)
    {
        switch (taster)
        {
            case "S1": (_modelLap2018.S1, ClickModeS1) = BaseFunctions.ButtonClickMode(ClickModeS1); break;
            case "S2": (_modelLap2018.S2, ClickModeS2) = BaseFunctions.ButtonClickModeInvertiert(ClickModeS2); break;
            case "S3": (_modelLap2018.S3, ClickModeS3) = BaseFunctions.ButtonClickMode(ClickModeS3); break;
            case "S4": (_modelLap2018.S4, ClickModeS4) = BaseFunctions.ButtonClickMode(ClickModeS4); break;
            case "TankNachfuellen": _modelLap2018.TankNachfuellen(); break;
            case "AllesReset": _modelLap2018.AllesReset(); break;
        }
    }

    [ICommand]
    private void ButtonSchalter(string schalter)
    {
        if (schalter == "F1") _modelLap2018.F1 = !_modelLap2018.F1;
    }
}