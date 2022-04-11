using Microsoft.Toolkit.Mvvm.Input;

namespace DtBlinker.ViewModel;

public partial class VmBlinker
{
    [ICommand]
    private void ButtonTaster(string taster)
    {
        switch (taster)
        {
            case "S1": (_modelBlinker.S1, ClickModeS1) = ButtonClickMode(ClickModeS1); break;
            case "S2": (_modelBlinker.S2, ClickModeS2) = ButtonClickMode(ClickModeS2); break;
            case "S3": (_modelBlinker.S3, ClickModeS3) = ButtonClickMode(ClickModeS3); break;
            case "S4": (_modelBlinker.S4, ClickModeS4) = ButtonClickMode(ClickModeS4); break;
            case "S5": (_modelBlinker.S5, ClickModeS5) = ButtonClickMode(ClickModeS5); break;
        }
    }
}