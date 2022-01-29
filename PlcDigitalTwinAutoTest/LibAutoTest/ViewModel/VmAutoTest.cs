using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using LibAutoTest.Commands;
using LibAutoTestSilk;

namespace LibAutoTest.ViewModel;

public class VmAutoTest
{
    public enum WpfObjects
    {
        TasterStart = 10,
        CheckBoxEinzelSchritt = 11,
        TasterEinzelSchritt = 12
    }

    private readonly AutoTest _autoTest;
    private readonly AutoTesterSilk _autoTesterSilk;

    public VmAutoTest(AutoTest autoTest, AutoTesterSilk autoTesterSilk)
    {
        _autoTest = autoTest;
        _autoTesterSilk = autoTesterSilk;

        for (var i = 0; i < 100; i++)
        {
            ButtonIsEnabled.Add(new bool());
            ClkMode.Add(ClickMode.Press);
            SichtbarEin.Add(Visibility.Hidden);
            Text.Add("");
        }

        SichtbarEin[3] = Visibility.Visible;

        SichtbarEin[(int)WpfObjects.TasterStart] = Visibility.Visible;
        Text[(int)WpfObjects.TasterStart] = "Test Starten";

        ButtonIsEnabled[(int)WpfObjects.TasterEinzelSchritt] = true;
        Text[(int)WpfObjects.TasterEinzelSchritt] = "Schritt!";
    }
    internal void Taster(object id)
    {
        if (id is not Enum enumValue) return;

        switch (enumValue)
        {
            case WpfObjects.TasterStart:
                _autoTest.AutoTesterSilk.TestStarten();
                break;
            case WpfObjects.CheckBoxEinzelSchritt:
                ToggleSichtbarkeit(WpfObjects.TasterEinzelSchritt);
                _autoTesterSilk.Silk.SetBetriebsart(SichtbarEin[(int)WpfObjects.TasterEinzelSchritt] == Visibility.Visible);
                break;
            case WpfObjects.TasterEinzelSchritt:
                _autoTesterSilk.Silk.EinzelnerSchrittAusfuehren();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(id));
        }
    }

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

    public event PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    private ICommand _btnTaster;
    public ICommand BtnTaster => _btnTaster ??= new RelayCommand(Taster);
}