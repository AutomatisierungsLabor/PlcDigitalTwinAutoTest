using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using LibAutoTest.Commands;

namespace LibAutoTest.ViewModel;

public partial class VmAutoTest
{
    internal void ToggleSichtbarkeit(WpfObjects id) => SichtbarEin[(int)id] = SichtbarEin[(int)id] == Visibility.Visible ? Visibility.Hidden : Visibility.Visible;

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

    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    private ICommand _btnTaster;
    public ICommand BtnTaster => _btnTaster ??= new RelayCommand(Taster);
}