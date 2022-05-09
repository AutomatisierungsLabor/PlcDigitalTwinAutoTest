using Microsoft.Toolkit.Mvvm.Input;
using System.Windows;

namespace LibAutoTest.ViewModel;

public partial class VmAutoTest
{
    [ICommand]
    private void ButtonTaster(string taster)
    {
        switch (taster)
        {
            case "TasterStart": _autoTest.AutoTesterSilk.AutoTestStarten(); break;
            case "CheckboxEinzelschritt":
                CheckboxTasterEinzelschritt = !CheckboxTasterEinzelschritt;
                VisibilityTasterEinzelschritt = CheckboxTasterEinzelschritt ? Visibility.Visible : Visibility.Hidden;
                _autoTesterSilk.Silk.SetBetriebsart(CheckboxTasterEinzelschritt); break;
            case "TasterEinzelSchritt": _autoTesterSilk.Silk.EinzelnerSchrittAusfuehren(); break;
        }
    }
}