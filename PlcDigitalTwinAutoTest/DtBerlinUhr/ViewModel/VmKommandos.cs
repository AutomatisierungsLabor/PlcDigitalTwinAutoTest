using Microsoft.Toolkit.Mvvm.Input;

namespace DtBerlinUhr.ViewModel;

public partial class VmBerlinUhr
{
    [ICommand]
    private void ButtonTaster(string taster)
    {
        switch (taster)
        {
            case "AktuelleZeitUebernehmen":
                _modelBerlinUhr.SetCurrentTime();
                DoubleGeschwindigkeit = 1;
                break;
        }
    }
}