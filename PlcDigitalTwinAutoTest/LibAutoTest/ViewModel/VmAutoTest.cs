using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using LibAutoTest.Commands;

namespace LibAutoTest.ViewModel;

public class VmAutoTest
{
    public enum WpfObjects
    {
        TasterStart = 10
    }

    private readonly AutoTest _autoTest;

    public VmAutoTest(AutoTest autoTest)
    {
        _autoTest = autoTest;

        for (var i = 0; i < 100; i++)
        {
            ClkMode.Add(ClickMode.Press);
            SichtbarEin.Add(Visibility.Hidden);
            Text.Add("");
        }

        SichtbarEin[3] = Visibility.Visible;
        Text[(int)WpfObjects.TasterStart] = "Test Starten";

        System.Threading.Tasks.Task.Run(VisuAnzeigenTask);
    }

    private static void VisuAnzeigenTask()
    {
        while (true)
        {


            Thread.Sleep(10);
        }
        // ReSharper disable once FunctionNeverReturns
    }

    internal void Taster(object id)
    {
        if (id is not Enum enumValue) return;

        if (enumValue is WpfObjects.TasterStart) _autoTest.TestStarten();
        else throw new ArgumentOutOfRangeException(nameof(id));
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