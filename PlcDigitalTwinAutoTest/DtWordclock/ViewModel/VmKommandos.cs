using Microsoft.Toolkit.Mvvm.Input;

namespace DtWordclock.ViewModel;

public partial class VmWordclock
{
    [ICommand]
    private void ButtonTaster(string taster)
    {
        switch (taster)
        {
            case "AktuelleZeitUebernehmen":
                _modelWordclock.SetCurrentTime();
                DoubleGeschwindigkeit = 1;
                break;
        }
    }
}