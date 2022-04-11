using Microsoft.Toolkit.Mvvm.Input;

namespace DtFibonacci.ViewModel;

public partial class VmFibonacci
{
    [ICommand]
    private void ButtonTaster(string taster)
    {
        if (taster == "S1") (_modelFibonacci.S1, ClickModeS1) = ButtonClickMode(ClickModeS1);
    }
}
