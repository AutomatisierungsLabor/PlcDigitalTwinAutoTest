using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using LibSilkAutoTester.Model;
using LibSilkAutoTester.TestAutomat;

namespace LibSilkAutoTester.ViewModel;

public class VmSilkAutoTester
{
    public enum WpfIndex
    {
        Di01 = 0,
        Da01 = 16,
        SoureCode = 32
    }

    private Model.ModelSilkAutoTester _modelSilkAutoTester;
    private string _pfadAlt = "-";

    public VmSilkAutoTester(ModelSilkAutoTester modelSilkAutoTester)
    {
        _modelSilkAutoTester = modelSilkAutoTester;

        

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

            if (_pfadAlt != _modelSilkAutoTester.ConfigPlc.PfadAbsolut)
            {
                _pfadAlt = _modelSilkAutoTester.ConfigPlc.PfadAbsolut;

                Text[(int)WpfIndex.SoureCode] = _modelSilkAutoTester.TestSource;

                for (var i = 0; i < 100; i++) SichtbarEin[i] = Visibility.Hidden;

                foreach (var zeile in _modelSilkAutoTester.ConfigPlc.Di.Zeilen)
                {
                    var bitPos = (int)WpfIndex.Di01 + 8 * zeile.StartByte + zeile.StartBit;
                    SichtbarEin[bitPos] = Visibility.Visible;
                    Text[bitPos] = zeile.Bezeichnung;
                }

                foreach (var zeile in _modelSilkAutoTester.ConfigPlc.Da.Zeilen)
                {
                    var bitPos = (int)WpfIndex.Da01 + 8 * zeile.StartByte + zeile.StartBit;
                    SichtbarEin[bitPos] = Visibility.Visible;
                    Text[bitPos] = zeile.Bezeichnung;
                }

            }

            Thread.Sleep(10);
        }
        // ReSharper disable once FunctionNeverReturns
    }





    private ObservableCollection<DataGridZeile> _dataGridZeiles;
    public ObservableCollection<DataGridZeile> DataGridZeiles
    {
        get => _dataGridZeiles;
        set
        {
            _dataGridZeiles = value;
            OnPropertyChanged(nameof(DataGridZeiles));
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