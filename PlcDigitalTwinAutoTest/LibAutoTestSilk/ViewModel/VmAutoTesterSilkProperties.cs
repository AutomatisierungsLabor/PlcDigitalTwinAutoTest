using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using LibTestDatensammlung;

namespace LibAutoTestSilk.ViewModel;

public partial class VmAutoTesterSilk
{
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

    private ObservableCollection<DataGridZeile> _dataGridZeilen = new();
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

    private void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}