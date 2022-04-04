using Microsoft.Toolkit.Mvvm.Input;

namespace DtLap2010_4_Abfuellanlage.ViewModel;

public partial class VmLap2010
{

    [ICommand]
    private void ButtonTaster(string taster)
    {
        switch (taster)
        {
            case "S1": (_modelLap2010.S1, ClickModeS1) = ButtonClickModeInvertiert(ClickModeS1); break;
            case "S2": (_modelLap2010.S2, ClickModeS2) = ButtonClickMode(ClickModeS2); break;
            case "Reset": _modelLap2010.Reset(); break;
            case "Nachfuellen": _modelLap2010.Nachfuellen(); break;
        }
    }

    [ICommand]
    private void ButtonSchalter(string schalter)
    {
        if (schalter == "B2") _modelLap2010.B2 = !_modelLap2010.B2;
    }
}