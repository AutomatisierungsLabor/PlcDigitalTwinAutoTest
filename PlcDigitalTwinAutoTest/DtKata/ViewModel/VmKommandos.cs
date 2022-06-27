using Contracts;
using Microsoft.Toolkit.Mvvm.Input;

namespace DtKata.ViewModel;

public partial class VmKata
{
    [ICommand]
    private void ButtonTaster(string taster)
    {
        switch (taster)
        {
            case "S1": (_modelKata.S1, ClickModeS1) = BaseFunctions.ButtonClickMode(ClickModeS1); break;
            case "S2": (_modelKata.S2, ClickModeS2) = BaseFunctions.ButtonClickMode(ClickModeS2); break;
            case "S3": (_modelKata.S3, ClickModeS3) = BaseFunctions.ButtonClickModeInvertiert(ClickModeS3); break;
            case "S4": (_modelKata.S4, ClickModeS4) = BaseFunctions.ButtonClickModeInvertiert(ClickModeS4); break;
        }
    }

    [ICommand]
    private void ButtonSchalter(string schalter)
    {
        switch (schalter)
        {
            case "S5": _modelKata.S5 = !_modelKata.S5; break;
            case "S6": _modelKata.S6 = !_modelKata.S6; break;
            case "S7": _modelKata.S7 = !_modelKata.S7; break;
            case "S8": _modelKata.S8 = !_modelKata.S8; break;
        }
    }
}
