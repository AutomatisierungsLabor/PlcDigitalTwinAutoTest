using Microsoft.Toolkit.Mvvm.Input;

namespace DtLeitungszuordnungsTester.ViewModel;

public partial class VmLeitungszuordnungsTester
{
    [ICommand]
    private void ButtonTaster(string taster)
    {
        switch (taster)
        { }
    }

    [ICommand]
    private void ButtonSchalter(string schalter)
    {
        switch (schalter)
        { }
    }
}
