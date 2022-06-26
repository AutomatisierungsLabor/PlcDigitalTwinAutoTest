using Contracts;
using Microsoft.Toolkit.Mvvm.Input;

namespace DtAmpelVerbania.ViewModel;

public partial class VmAmpelVerbania
{
    [ICommand]
    private void ButtonTaster(string taster)
    {
        if (taster == "S1") (_modelAmpelVarbania.S1, ClickModeS1) = BaseFunctions.ButtonClickMode(ClickModeS1);
    }

    [ICommand]
    private void ButtonSchalter(string schalter)
    {
        if (schalter == "S2") _modelAmpelVarbania.S2 = !_modelAmpelVarbania.S2;
    }
}