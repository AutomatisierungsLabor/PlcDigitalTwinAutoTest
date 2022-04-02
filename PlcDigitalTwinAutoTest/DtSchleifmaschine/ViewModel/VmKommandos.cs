using Microsoft.Toolkit.Mvvm.Input;

namespace DtSchleifmaschine.ViewModel;

public partial class VmSchleifmaschine
{
    [ICommand]
    private void ButtonTaster(string taster)
    {
        switch (taster)
        {}
    }

    [ICommand]
    private void ButtonSchalter(string schalter)
    {
        switch (schalter)
        { }
    }
}
