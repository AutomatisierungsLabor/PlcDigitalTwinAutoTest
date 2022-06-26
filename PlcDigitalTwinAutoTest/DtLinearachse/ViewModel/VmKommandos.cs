using Contracts;
using Microsoft.Toolkit.Mvvm.Input;

namespace DtLinearachse.ViewModel;

public partial class VmLinearachse
{
    [ICommand]
    private void ButtonTaster(string taster)
    {
        switch (taster)
        {
            case "S1": (_modelLinearachse.S1, ClickModeS1) = BaseFunctions.ButtonClickMode(ClickModeS1); break;
            case "S2": (_modelLinearachse.S2, ClickModeS2) = BaseFunctions.ButtonClickModeInvertiert(ClickModeS2); break;
            case "S3": (_modelLinearachse.S3, ClickModeS3) = BaseFunctions.ButtonClickMode(ClickModeS3); break;
            case "S4": (_modelLinearachse.S4, ClickModeS4) = BaseFunctions.ButtonClickMode(ClickModeS4); break;
            case "S5": (_modelLinearachse.S5, ClickModeS5) = BaseFunctions.ButtonClickMode(ClickModeS5); break;
            case "S6": (_modelLinearachse.S6, ClickModeS6) = BaseFunctions.ButtonClickMode(ClickModeS6); break;
            case "S7": (_modelLinearachse.S7, ClickModeS7) = BaseFunctions.ButtonClickMode(ClickModeS7); break;
            case "S8": (_modelLinearachse.S8, ClickModeS8) = BaseFunctions.ButtonClickMode(ClickModeS8); break;
            case "S9": (_modelLinearachse.S9, ClickModeS9) = BaseFunctions.ButtonClickModeInvertiert(ClickModeS9); break;
        }
    }


    [ICommand]
    private void ButtonSchalter(string schalter)
    {
        switch (schalter)
        {
            case "S10": _modelLinearachse.S10 = !_modelLinearachse.S10; break;
            case "S11": _modelLinearachse.S11 = !_modelLinearachse.S11; break;
        }
    }
}
