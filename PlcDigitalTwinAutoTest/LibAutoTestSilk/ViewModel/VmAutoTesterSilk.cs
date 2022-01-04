using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using LibAutoTestSilk.Model;
using LibAutoTestSilk.TestAutomat;

namespace LibAutoTestSilk.ViewModel;

public class VmAutoTesterSilk
{
    public enum WpfIndex
    {
        Di01 = 0,
        Di17 = 15,
        Da01 = 16,
        Da17 = 31,
        SoureCode = 32
    }


    public VmAutoTesterSilk(ModelAutoTesterSilk modelSilkAutoTester)
    {

        DataGridZeilen = new ObservableCollection<DataGridZeile> {
            new(
                0,
                "0",
                TestAnzeige.Version,
                " ",
                " ",
                " ",
                " ")
        };

        for (var i = 0; i < 100; i++)
        {
            SichtbarEin.Add(Visibility.Hidden);
            Farbe.Add(Brushes.White);
            Text.Add("");
        }

        System.Threading.Tasks.Task.Run(VmAnzeigenTask);
    }

    internal void VmAnzeigenTask()
    {
        while (true)
        {

            Thread.Sleep(10);
        }
        // ReSharper disable once FunctionNeverReturns
    }


    public void UpdateDataGrid(DataGridZeile zeile)
    {
        Application.Current.Dispatcher.Invoke(() =>
        {
            DataGridZeilen.Add(zeile);
        });
    }

    private short _zeilenNummerDataGrid;

    public short ZeilenNummerDataGrid
    {
        get => _zeilenNummerDataGrid;
        set
        {
            _zeilenNummerDataGrid = value;
            OnPropertyChanged(nameof(ZeilenNummerDataGrid));
        }
    }

    private ObservableCollection<DataGridZeile> _dataGridZeilen;
    public ObservableCollection<DataGridZeile> DataGridZeilen
    {
        get => _dataGridZeilen;
        set
        {
            _dataGridZeilen = value;
            OnPropertyChanged(nameof(DataGridZeilen));
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


    public event PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


}