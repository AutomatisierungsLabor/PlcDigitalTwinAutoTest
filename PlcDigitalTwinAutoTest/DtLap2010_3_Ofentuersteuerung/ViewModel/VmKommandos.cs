using Microsoft.Toolkit.Mvvm.Input;

namespace DtLap2010_3_Ofentuersteuerung.ViewModel;

public partial class VmLap2010
{
    [ICommand]
    private void ButtonTaster(string taster)
    {
        switch (taster)
        {
            case "B2": (_modelLap2010.B2, ClickModeB2) = ButtonClickMode(ClickModeB2); break;
            case "S1": (_modelLap2010.S1, ClickModeS1) = ButtonClickMode(ClickModeS1); break;
            case "S2": (_modelLap2010.S2, ClickModeS2) = ButtonClickMode(ClickModeS2); break;
            case "S3": (_modelLap2010.S3, ClickModeS3) = ButtonClickMode(ClickModeS3); break;
        }
    }

}