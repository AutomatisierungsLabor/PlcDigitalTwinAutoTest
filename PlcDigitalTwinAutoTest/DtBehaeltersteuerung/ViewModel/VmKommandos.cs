using Microsoft.Toolkit.Mvvm.Input;

namespace DtBehaeltersteuerung.ViewModel;

public partial class VmBehaeltersteuerung
{
    [ICommand]
    private void ButtonTaster(string taster)
    {
        switch (taster)
        {
          
        }
    }

    [ICommand]
    private void ButtonSchalter(string schalter)
    {
        switch (schalter)
        {
            case "Q2": _modelBehaeltersteuerung.AlleMeineBehaelter[0].VentilUnten = !_modelBehaeltersteuerung.AlleMeineBehaelter[0].VentilUnten; break;
            case "Q4": _modelBehaeltersteuerung.AlleMeineBehaelter[1].VentilUnten = !_modelBehaeltersteuerung.AlleMeineBehaelter[1].VentilUnten; break;
            case "Q6": _modelBehaeltersteuerung.AlleMeineBehaelter[2].VentilUnten = !_modelBehaeltersteuerung.AlleMeineBehaelter[2].VentilUnten; break;
            case "Q8": _modelBehaeltersteuerung.AlleMeineBehaelter[3].VentilUnten = !_modelBehaeltersteuerung.AlleMeineBehaelter[3].VentilUnten; break;
        }
    }
}
