using Microsoft.Toolkit.Mvvm.Input;

namespace DtVoltmeter.ViewModel;

public partial class VmVoltmeter
{
    [ICommand]
    private void ButtonTaster(string taster)
    {
        switch (taster)
        {
            default:break;
        }
    }
}