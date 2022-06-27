using Contracts;
using Microsoft.Toolkit.Mvvm.Input;

namespace DtSchleifmaschine.ViewModel;

public partial class VmSchleifmaschine
{

    [ICommand]
    private void ButtonTaster(string taster)
    {
        switch (taster)
        {
            case "S0": (_modelSchleifmaschine.S0, ClickModeS0) = BaseFunctions.ButtonClickModeInvertiert(ClickModeS0); break;
            case "S1": (_modelSchleifmaschine.S1, ClickModeS1) = BaseFunctions.ButtonClickMode(ClickModeS1); break;
            case "S2": (_modelSchleifmaschine.S1, ClickModeS2) = BaseFunctions.ButtonClickMode(ClickModeS2); break;
            case "S3":
                (_modelSchleifmaschine.S3, ClickModeS3) = BaseFunctions.ButtonClickMode(ClickModeS3);
                _modelSchleifmaschine.B1 = false;
                break;
        }
    }

    [ICommand]
    private void ButtonSchalter(string schalter)
    {
        switch (schalter)
        {
            case "F1": _modelSchleifmaschine.F1 = !_modelSchleifmaschine.F1; break;
            case "F2": _modelSchleifmaschine.F2 = !_modelSchleifmaschine.F2; break;
            case "S3": _modelSchleifmaschine.S3 = !_modelSchleifmaschine.S3; break;
        }
    }
}
