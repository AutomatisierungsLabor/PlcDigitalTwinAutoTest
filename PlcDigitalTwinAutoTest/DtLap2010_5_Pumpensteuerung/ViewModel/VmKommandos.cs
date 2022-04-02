using Microsoft.Toolkit.Mvvm.Input;

namespace DtLap2010_5_Pumpensteuerung.ViewModel;

public partial class VmLap2010
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
        { }
    }
}
