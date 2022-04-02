using Microsoft.Toolkit.Mvvm.Input;

namespace DtFibonacci.ViewModel;

public partial class VmFibonacci
{
    [ICommand]
    private void ButtonTaster(string taster)
    {
        switch (taster)
        {  }
    }

    [ICommand]
    private void ButtonSchalter(string schalter)
    {
        switch (schalter)
        { }
    }
}
