using Microsoft.Toolkit.Mvvm.Input;

namespace DtParkhaus.ViewModel;

public partial class VmParkhaus
{
    [ICommand]
    private void ButtonTaster(string taster)
    {
        switch (taster)
        {
           // case "S1": (_modelBlinker.S1, ClickModeS1) = ButtonClickMode(ClickModeS1); break;

        }
    }
}