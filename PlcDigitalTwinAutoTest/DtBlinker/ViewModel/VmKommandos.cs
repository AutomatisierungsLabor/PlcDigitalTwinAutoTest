using Microsoft.Toolkit.Mvvm.Input;

namespace DtBlinker.ViewModel;

public partial class VmBlinker
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
               }
    }
}
