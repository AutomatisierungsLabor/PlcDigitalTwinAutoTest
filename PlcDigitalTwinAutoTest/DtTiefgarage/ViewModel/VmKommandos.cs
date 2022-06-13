using Microsoft.Toolkit.Mvvm.Input;

namespace DtTiefgarage.ViewModel;

public partial class VmTiefgarage
{
    [ICommand]
    private void ButtonTaster(string taster)
    {
        switch (taster)
        {
            case "DraussenParken": _modelTiefgarage.DraussenParken(); break;
            case "DrinnenParken": _modelTiefgarage.DrinnenParken(); break;

            case "Pkw1": _modelTiefgarage.AllePkwPersonen[0].Losfahren();  break;
            case "Pkw2": _modelTiefgarage.AllePkwPersonen[1].Losfahren(); break;
            case "Pkw3": _modelTiefgarage.AllePkwPersonen[2].Losfahren(); break;
            case "Pkw4": _modelTiefgarage.AllePkwPersonen[3].Losfahren(); break;
            case "Mensch1": _modelTiefgarage.AllePkwPersonen[4].Losfahren(); break;
            case "Mensch2": _modelTiefgarage.AllePkwPersonen[5].Losfahren(); break;
            case "Mensch3": _modelTiefgarage.AllePkwPersonen[6].Losfahren(); break;
            case "Mensch4": _modelTiefgarage.AllePkwPersonen[7].Losfahren(); break;
        }
    }
}