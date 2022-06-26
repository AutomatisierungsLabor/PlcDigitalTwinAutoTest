using Contracts;
using Microsoft.Toolkit.Mvvm.Input;

namespace DtLap2018_1_Silosteuerung.ViewModel;

public partial class VmLap2018
{
    [ICommand]
    private void ButtonTaster(string taster)
    {
        switch (taster)
        {
            case "S0": (_modelLap2018.S0, ClickModeS0) = BaseFunctions.ButtonClickModeInvertiert(ClickModeS0); break;
            case "S1": (_modelLap2018.S1, ClickModeS1) = BaseFunctions.ButtonClickMode(ClickModeS1); break;
            case "S3": (_modelLap2018.S3, ClickModeS3) = BaseFunctions.ButtonClickMode(ClickModeS3); break;
            case "WagenNachLinks": _modelLap2018.WagenNachLinks(); break;
            case "WagenNachRechts": _modelLap2018.WagenNachRechts(); break;
        }
    }

    [ICommand]
    private void ButtonSchalter(string schalter)
    {
        switch (schalter)
        {
            case "F1": _modelLap2018.F1 = !_modelLap2018.F1; break;
            case "F2": _modelLap2018.F2 = !_modelLap2018.F2; break;
            case "S2": _modelLap2018.S2 = !_modelLap2018.S2; break;
            case "RutscheVoll": _modelLap2018.RutscheVoll = !_modelLap2018.RutscheVoll; break;
        }
    }
}