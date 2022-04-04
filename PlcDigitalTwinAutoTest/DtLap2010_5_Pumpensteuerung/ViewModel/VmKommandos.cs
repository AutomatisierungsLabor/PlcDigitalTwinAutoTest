using Microsoft.Toolkit.Mvvm.Input;

namespace DtLap2010_5_Pumpensteuerung.ViewModel;

public partial class VmLap2010
{
    [ICommand]
    private void ButtonTaster(string taster)
    {
        switch (taster)
        {
            case "S3":
                _modelLap2010.S3 = !_modelLap2010.S3;
                break;
            case "Hand":
                _modelLap2010!.S1 = true;
                _modelLap2010!.S2 = false;
                break;
            case "Aus":
                _modelLap2010!.S1 = false;
                _modelLap2010!.S2 = false;
                break;
            case "Automatik":
                _modelLap2010!.S1 = false;
                _modelLap2010!.S2 = true;
                break;
        }
    }
    [ICommand]
    private void ButtonSchalter(string schalter)
    {
        switch (schalter)
        {
            case "F1": _modelLap2010.F1 = !_modelLap2010.F1; break;
            case "Y1": _modelLap2010.Y1 = !_modelLap2010.Y1; break;
        }
    }
}