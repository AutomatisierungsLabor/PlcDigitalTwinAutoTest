using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace LibAutoTest.ViewModel;

public partial class ViewModel
{



    internal void Taster(object id)
    {
        if (id is not Enum enumValue) return;

        var value = Convert.ToInt16(enumValue);
        var gedrueckt = ClickModeButton(value);

        switch (enumValue)
        {
            case WpfObjects.TasterStart: _autoTest.TestStarten(); break;

            default: throw new ArgumentOutOfRangeException(nameof(id));
        }
    }
    internal void Schalter(object id)
    {
        if (id is not Enum enumValue) return;

        switch (id)
        {
            case 20:
                break;
            default: throw new ArgumentOutOfRangeException(nameof(id));
        }
    }


    #region Taster/Schalter
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
    #endregion Taster/Schalter

}