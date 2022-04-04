using Microsoft.Toolkit.Mvvm.Input;

namespace DtLap2010_2_Transportwagen.ViewModel;

public partial class VmLap2010
{
    [ICommand]
    private void ButtonTaster(string taster)
    {
        switch (taster)
        {
            case "S1": (_modelLap2010.S1, ClickModeS1) = ButtonClickMode(ClickModeS1); break;
            case "S3": (_modelLap2010.S3, ClickModeS3) = ButtonClickMode(ClickModeS3); break;
        }
    }

    [ICommand]
    private void ButtonSchalter(string schalter)
    {
        switch (schalter)
        {
            case "F1": _modelLap2010.F1 = !_modelLap2010.F1; break;
            case "S2": _modelLap2010.S2 = !_modelLap2010.S2; break;
        }
    }
}
