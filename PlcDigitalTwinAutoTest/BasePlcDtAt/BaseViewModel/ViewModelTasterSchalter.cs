using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace BasePlcDtAt.BaseViewModel;

public abstract partial class ViewModel
{
    internal void Taster(object id)
    {
        if (id is not string ascii) return;

        var tasterId = short.Parse(ascii);
        var gedrueckt = ClickModeButton(tasterId);

        ViewModelAufrufTaster(tasterId);
        switch (tasterId)
        {


            default: throw new ArgumentOutOfRangeException(nameof(id));
        }
    }

    internal void Schalter(object id)
    {
        if (id is not string ascii) return;

        var schalterId = short.Parse(ascii);

        ViewModelAufrufSchalter(schalterId);
        switch (schalterId)
        {


            default: throw new ArgumentOutOfRangeException(nameof(id));
        }
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