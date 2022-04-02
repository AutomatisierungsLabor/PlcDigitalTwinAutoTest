using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace BasePlcDtAt.BaseViewModel;

public abstract partial class VmBase
{
    public (bool ergebnis, ClickMode clickModeTaster) ButtonClickMode(ClickMode clickMode) => clickMode == ClickMode.Press ? (true, ClickMode.Release) : (false, ClickMode.Press);
    public (bool ergebnis, ClickMode clickModeTaster) ButtonClickModeInvertiert(ClickMode clickMode) => clickMode == ClickMode.Press ? (false, ClickMode.Release) : (true, ClickMode.Press);





    internal void Taster(object id)
    {
        if (id is not Enum enumValue) return;

        var value = Convert.ToInt16(enumValue);
        var gedrueckt = ClickModeButton(value);

        ViewModelAufrufTaster(enumValue, gedrueckt);
    }

    internal void Schalter(object id)
    {
        if (id is not Enum enumValue) return;

        ViewModelAufrufSchalter(enumValue);
    }

    public bool ClickModeButton(int tasterId)
    {
        if (ClkMode[tasterId] == ClickMode.Press)
        {
            ClkMode[tasterId] = ClickMode.Release;
            return true;
        }

        ClkMode[tasterId] = ClickMode.Press;
        return false;
    }

    private ObservableCollection<ClickMode> _clkMode = new();
    public ObservableCollection<ClickMode> ClkMode
    {
        get => _clkMode;
        set
        {
            _clkMode = value;
            OnPropertyChanged(nameof(ClkMode));
        }
    }
}