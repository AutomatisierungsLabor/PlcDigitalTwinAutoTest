using Microsoft.Toolkit.Mvvm.Input;

namespace DtLinearachse.ViewModel;

public partial class VmLinearachse
{
    [ICommand]
    private void ButtonTaster(string taster)
    {
        switch (taster)
        {
            case "S1": (_modelLinearachse.S1, ClickModeS1) = ButtonClickMode(ClickModeS1); break;
            case "S2": (_modelLinearachse.S2, ClickModeS2) = ButtonClickModeInvertiert(ClickModeS2); break;
            case "S3": (_modelLinearachse.S3, ClickModeS3) = ButtonClickMode(ClickModeS3); break;
            case "S4": (_modelLinearachse.S4, ClickModeS4) = ButtonClickMode(ClickModeS4); break;
            case "S5": (_modelLinearachse.S5, ClickModeS5) = ButtonClickMode(ClickModeS5); break;
            case "S6": (_modelLinearachse.S6, ClickModeS6) = ButtonClickMode(ClickModeS6); break;
            case "S7": (_modelLinearachse.S7, ClickModeS7) = ButtonClickMode(ClickModeS7); break;
            case "S8": (_modelLinearachse.S8, ClickModeS8) = ButtonClickMode(ClickModeS8); break;
            case "S9": (_modelLinearachse.S9, ClickModeS9) = ButtonClickModeInvertiert(ClickModeS9); break;
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
