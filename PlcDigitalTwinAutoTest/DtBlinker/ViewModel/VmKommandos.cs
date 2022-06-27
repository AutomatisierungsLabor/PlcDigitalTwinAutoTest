using Contracts;
using Microsoft.Toolkit.Mvvm.Input;

namespace DtBlinker.ViewModel;

public partial class VmBlinker
{
    [ICommand]
    private void ButtonTaster(string taster)
    {
        switch (taster)
        {
            case "S1": (_modelBlinker.S1, ClickModeS1) = BaseFunctions.ButtonClickMode(ClickModeS1); break;
            case "S2": (_modelBlinker.S2, ClickModeS2) = BaseFunctions.ButtonClickMode(ClickModeS2); break;
            case "S3": (_modelBlinker.S3, ClickModeS3) = BaseFunctions.ButtonClickMode(ClickModeS3); break;
            case "S4": (_modelBlinker.S4, ClickModeS4) = BaseFunctions.ButtonClickMode(ClickModeS4); break;
            case "S5": (_modelBlinker.S5, ClickModeS5) = BaseFunctions.ButtonClickMode(ClickModeS5); break;
        }
    }
}