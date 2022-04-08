using System.Windows;
using Microsoft.Toolkit.Mvvm.Input;

namespace LibAutoTest.ViewModel;

public partial class VmAutoTest
{
    [ICommand]
    private void ButtonTaster(string taster)
    {
        switch (taster)
        {
            case "TasterStart": _autoTest.AutoTesterSilk.AutoTestStarten(); break;
            case "CheckBoxEinzelSchritt":
                // todo ToggleSichtbarkeit(WpfObjects.TasterEinzelSchritt);
                _autoTesterSilk.Silk.SetBetriebsart(VisibilityTasterEinzelschritt == Visibility.Visible); break;
            case "TasterEinzelSchritt": _autoTesterSilk.Silk.EinzelnerSchrittAusfuehren(); break;

        }
    }
}