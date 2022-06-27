﻿using Contracts;
using Microsoft.Toolkit.Mvvm.Input;

namespace DtGetriebemotor.ViewModel;

public partial class VmGetriebemotor
{
    [ICommand]
    private void ButtonTaster(string taster)
    {
        switch (taster)
        {
            case "S1": (_modelGetriebemotor.S1, ClickModeS1) = BaseFunctions.ButtonClickMode(ClickModeS1); break;
            case "S2": (_modelGetriebemotor.S2, ClickModeS2) = BaseFunctions.ButtonClickModeInvertiert(ClickModeS2); break;
            case "S3": (_modelGetriebemotor.S3, ClickModeS3) = BaseFunctions.ButtonClickMode(ClickModeS3); break;
            case "S4": (_modelGetriebemotor.S4, ClickModeS4) = BaseFunctions.ButtonClickModeInvertiert(ClickModeS4); break;
            case "S5": (_modelGetriebemotor.S5, ClickModeS5) = BaseFunctions.ButtonClickMode(ClickModeS5); break;
            case "S6": (_modelGetriebemotor.S6, ClickModeS6) = BaseFunctions.ButtonClickMode(ClickModeS6); break;
            case "S7": (_modelGetriebemotor.S7, ClickModeS7) = BaseFunctions.ButtonClickModeInvertiert(ClickModeS7); break;
            case "S8": (_modelGetriebemotor.S8, ClickModeS8) = BaseFunctions.ButtonClickMode(ClickModeS8); break;
        }
    }

    [ICommand]
    private void ButtonSchalter(string schalter)
    {
        if (schalter != "S91") return;

        _modelGetriebemotor.S91 = !_modelGetriebemotor.S91;
        _modelGetriebemotor.S92 = !_modelGetriebemotor.S91;
    }
}
