using Contracts;
using LibAutoTest.Commands;
using LibAutoTestSilk;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using LibDatenstruktur;
using LibPlcKommunikation;

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
    private readonly PlcDaemon _plcDaemon;

    public VmAutoTest(AutoTest autoTest, AutoTesterSilk autoTesterSilk, Datenstruktur datenstruktur, PlcDaemon plcDaemon, CancellationTokenSource cancellationTokenSource)
    {
        _autoTest = autoTest;
        _autoTesterSilk = autoTesterSilk;
        _plcDaemon = plcDaemon;

        for (var i = 0; i < 100; i++)
        {
            ButtonIsEnabled.Add(new bool());
            ClkMode.Add(ClickMode.Press);
            SichtbarEin.Add(Visibility.Hidden);
            Text.Add("");
            Farbe.Add(Brushes.Yellow);
        }

        SichtbarEin[(int)WpfBase.TabAutoTest] = Visibility.Visible;

        SichtbarEin[(int)WpfObjects.TasterStart] = Visibility.Visible;
        Text[(int)WpfObjects.TasterStart] = "Test Starten";

        ButtonIsEnabled[(int)WpfObjects.TasterEinzelSchritt] = true;
        Text[(int)WpfObjects.TasterEinzelSchritt] = "Schritt!";

        System.Threading.Tasks.Task.Run(() => ViewModelTask(datenstruktur, cancellationTokenSource));
    }
    private void ViewModelTask(Datenstruktur datenstruktur, CancellationTokenSource cancellationTokenSource)
    {
        while (!cancellationTokenSource.IsCancellationRequested)
        {
            var errorVersion = !string.Equals(datenstruktur.VersionsStringLokal, datenstruktur.VersionsStringPlc);

            if (errorVersion || _plcDaemon.PlcState.PlcError)
            {
                SichtbarEin[(int)WpfBase.ErrorAnzeige] = Visibility.Visible;
                Farbe[(int)WpfBase.ErrorAnzeige] = Brushes.Red;
            }
            else
            {
                SichtbarEin[(int)WpfBase.ErrorAnzeige] = Visibility.Hidden;
                SichtbarEin[(int)WpfBase.ErrorMeldung] = Visibility.Hidden;
                SichtbarEin[(int)WpfBase.ErrorVersionLokal] = Visibility.Hidden;
                SichtbarEin[(int)WpfBase.ErrorVersionPlc] = Visibility.Hidden;
            }

            if (_plcDaemon.PlcState.PlcError)
            {
                SichtbarEin[(int)WpfBase.ErrorMeldung] = Visibility.Visible;
                Text[(int)WpfBase.ErrorMeldung] = _plcDaemon.PlcState.PlcErrorMessage;
            }

            if (errorVersion)
            {
                SichtbarEin[(int)WpfBase.ErrorVersionLokal] = Visibility.Visible;
                SichtbarEin[(int)WpfBase.ErrorVersionPlc] = Visibility.Visible;

                Text[(int)WpfBase.ErrorVersionLokal] = datenstruktur.VersionsStringLokal;
                Text[(int)WpfBase.ErrorVersionPlc] = datenstruktur.VersionsStringPlc;
            }

            Thread.Sleep(10);
        }
    }
    internal void Taster(object id)
    {
        if (id is not Enum enumValue) return;

        switch (enumValue)
        {
            case WpfObjects.TasterStart:
                _autoTest.AutoTesterSilk.AutoTestStarten();
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