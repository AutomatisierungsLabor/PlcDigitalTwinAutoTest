using Contracts;
using Microsoft.Toolkit.Mvvm.Input;

namespace DtLap2010_1_Kompressoranlage.ViewModel;

public partial class VmLap2010
{
    [ICommand]
    private void ButtonTaster(string taster)
    {
        switch (taster)
        {
            case "S1": (_modelLap2010.S1, ClickModeS1) = BaseFunctions.ButtonClickModeInvertiert(ClickModeS1); break;
            case "S2": (_modelLap2010.S2, ClickModeS2) = BaseFunctions.ButtonClickMode(ClickModeS2); break;
        }
    }

    [ICommand]
    private void ButtonSchalter(string schalter)
    {
        switch (schalter)
        {
            case "B2": _modelLap2010!.B2 = !_modelLap2010.B2; break;
            case "F1": _modelLap2010!.F1 = !_modelLap2010.F1; break;
        }
    }
}
