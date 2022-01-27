using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;

namespace BasePlcDtAt.BaseViewModel;

public abstract partial class VmBase
{
    protected void FarbeUmschalten(bool val, int i, Brush farbe1, Brush farbe2) => Farbe[i] = val ? farbe1 : farbe2;
    protected void SichtbarkeitUmschalten(bool val, int i)
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

    private ObservableCollection<bool> _buttonIsEnabled = new();
    public ObservableCollection<bool> ButtonIsEnabled
    {
        get => _buttonIsEnabled;
        set
        {
            _buttonIsEnabled = value;
            OnPropertyChanged(nameof(ButtonIsEnabled));
        }
    }

    private ObservableCollection<Thickness> _margin = new();
    public ObservableCollection<Thickness> Margin
    {
        get=> _margin;
        set
        {
            _margin = value;
            OnPropertyChanged(nameof(Margin));
        }
    }
    
    private ObservableCollection<Point> _transformOrigin = new();
    public ObservableCollection<Point> TransformOrigin
    {
        get => _transformOrigin;
        set
        {
            _transformOrigin = value;
            OnPropertyChanged(nameof(TransformOrigin));
        }
    }

    private ObservableCollection<double> _winkel = new();
    public ObservableCollection<double> Winkel
    {
        get => _winkel;
        set
        {
            _winkel = value;
            OnPropertyChanged(nameof(Winkel));
        }
    }
}