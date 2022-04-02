using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;
using LibUtil;

namespace BasePlcDtAt.BaseViewModel;

public abstract partial class VmBase
{
    protected (Visibility Ein, Visibility Aus) SetVisibility(bool val) => val ? (Visibility.Visible, Visibility.Hidden) : (Visibility.Hidden, Visibility.Visible);
    protected Brush SetBrush(bool val, Brush farbeTrue, Brush farbeFalse) => val ? farbeTrue : farbeFalse;






    protected void RipFarbeUmschalten(bool val, int i, Brush farbeTrue, Brush farbeFalse) => Farbe[i] = val ? farbeTrue : farbeFalse;


    protected void RipSichtbarkeitUmschalten(bool val, int i) => SichtbarEin[i] = val ? Visibility.Visible : Visibility.Hidden;
    protected void PositionSetzen(Punkt punkt, Index i)
    {
        PosLinks[i] = punkt.X;
        PositionOben[i] = punkt.Y;
    }

    private ObservableCollection<double> _positonOben = new();
    public ObservableCollection<double> PositionOben
    {
        get => _positonOben;
        set
        {
            _positonOben = value;
            OnPropertyChanged(nameof(PositionOben));
        }
    }

    private ObservableCollection<double> _positionLinks = new();
    public ObservableCollection<double> PosLinks
    {
        get => _positionLinks;
        set
        {
            _positionLinks = value;
            OnPropertyChanged(nameof(PosLinks));
        }
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
        get => _margin;
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