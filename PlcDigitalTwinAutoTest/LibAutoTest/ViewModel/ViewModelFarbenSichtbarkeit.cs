using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;

namespace LibAutoTest.ViewModel;

public partial class ViewModel
{
    internal void FarbeUmschalten(bool val, int i, Brush farbe1, Brush farbe2) => Farbe[i] = val ? farbe1 : farbe2;
    internal void SichtbarkeitUmschalten(bool val, int i)
    {
        SichtbarEin[i] = val ? Visibility.Visible : Visibility.Collapsed;
        SichtbarAus[i] = val ? Visibility.Collapsed : Visibility.Visible;
    }

    
    private ObservableCollection<Visibility> _sichtbarEin = new();
    public ObservableCollection<Visibility> SichtbarEin
    {
        get => _sichtbarEin;
        set
        {
            _sichtbarEin = value;
            OnPropertyChanged(nameof(SichtbarEin));
        }
    }

    private ObservableCollection<Visibility> _sichtbarAus = new();
    public ObservableCollection<Visibility> SichtbarAus
    {
        get => _sichtbarAus;
        set
        {
            _sichtbarAus = value;
            OnPropertyChanged(nameof(SichtbarAus));
        }
    }

    private ObservableCollection<Brush> _farbe = new();
    public ObservableCollection<Brush> Farbe
    {
        get => _farbe;
        set
        {
            _farbe = value;
            OnPropertyChanged(nameof(Farbe));
        }
    }

    private ObservableCollection<string> _text = new();
    public ObservableCollection<string> Text
    {
        get => _text;
        set
        {
            _text = value;
            OnPropertyChanged(nameof(Text));
        }
    }

}