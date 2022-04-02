using Microsoft.Toolkit.Mvvm.Input;

namespace DtGetriebemotor.ViewModel;

public partial class VmGetriebemotor
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
