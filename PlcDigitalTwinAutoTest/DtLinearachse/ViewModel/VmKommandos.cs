using Microsoft.Toolkit.Mvvm.Input;

namespace DtLinearachse.ViewModel;

public partial class VmLinearachse
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
