using System;
using LibAutoTestSilk.TestAutomat;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Media;
using LibConfigPlc;

namespace LibAutoTestSilk.ViewModel;

public class VmAutoTesterSilk
{
    private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);

    public enum WpfIndex
    {
        Di01 = 0,
        Di17 = 15,
        Da01 = 16,
        Da17 = 31,
        SoureCode = 32
    }
    public VmAutoTesterSilk()
    {
        DataGridZeilen = new ObservableCollection<DataGridZeile>();

        for (var i = 0; i < 100; i++)
        {
            SichtbarEin.Add(Visibility.Hidden);
            Farbe.Add(Brushes.White);
            Text.Add("");
        }
    }
    internal void SetNeuesTestProjekt(DirectoryInfo ordnerAktuellesProjekt, ConfigPlc configPlc)
    {
        try
        {
            var pfad = Path.Combine(ordnerAktuellesProjekt.ToString(), "test.ssc");
            Log.Debug("TestSource: " + pfad);
            Text[(int)WpfIndex.SoureCode] = File.ReadAllText(pfad);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        for (var i = 0; i < 100; i++) SichtbarEin[i] = Visibility.Hidden;

        foreach (var zeile in configPlc.Di.Zeilen)
        {
            var bitPos = (int)WpfIndex.Di01 + 8 * zeile.StartByte + zeile.StartBit;
            if (bitPos > (int)WpfIndex.Di17) throw new ArgumentOutOfRangeException(bitPos.ToString());

            SichtbarEin[bitPos] = Visibility.Visible;
            Text[bitPos] = zeile.Bezeichnung;
        }

        foreach (var zeile in configPlc.Da.Zeilen)
        {
            var bitPos = (int)WpfIndex.Da01 + 8 * zeile.StartByte + zeile.StartBit;
            if (bitPos > (int)WpfIndex.Da17) throw new ArgumentOutOfRangeException(bitPos.ToString());

            SichtbarEin[bitPos] = Visibility.Visible;
            Text[bitPos] = zeile.Bezeichnung;
        }
    }

    public void UpdateDataGrid(DataGridZeile zeile)
    {
        Application.Current.Dispatcher.Invoke(() =>
        {
            var zeilenNr = zeile.ZeilenNr;
            if (DataGridZeilen.Count <= zeilenNr) DataGridZeilen.Add(zeile);
            else DataGridZeilen[zeilenNr] = zeile;
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