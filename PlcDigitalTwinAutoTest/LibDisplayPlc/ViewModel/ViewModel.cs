using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using LibConfigPlc;
using LibDatenstruktur;

namespace LibDisplayPlc.ViewModel;

public enum WpfObjects
{
    // ReSharper disable UnusedMember.Global
    Di00 = 0,
    Di01,
    Di02,
    Di03,
    Di04,
    Di05,
    Di06,
    Di07,
    Di10,
    Di11,
    Di12,
    Di13,
    Di14,
    Di15,
    Di16,
    Di17,

    DiBeschreibung00,
    DiBeschreibung01,
    DiBeschreibung02,
    DiBeschreibung03,
    DiBeschreibung04,
    DiBeschreibung05,
    DiBeschreibung06,
    DiBeschreibung07,
    DiBeschreibung10,
    DiBeschreibung11,
    DiBeschreibung12,
    DiBeschreibung13,
    DiBeschreibung14,
    DiBeschreibung15,
    DiBeschreibung16,
    DiBeschreibung17,

    Da00,
    Da01,
    Da02,
    Da03,
    Da04,
    Da05,
    Da06,
    Da07,
    Da10,
    Da11,
    Da12,
    Da13,
    Da14,
    Da15,
    Da16,
    Da17,

    DaBeschreibung00,
    DaBeschreibung01,
    DaBeschreibung02,
    DaBeschreibung03,
    DaBeschreibung04,
    DaBeschreibung05,
    DaBeschreibung06,
    DaBeschreibung07,
    DaBeschreibung10,
    DaBeschreibung11,
    DaBeschreibung12,
    DaBeschreibung13,
    DaBeschreibung14,
    DaBeschreibung15,
    DaBeschreibung16,
    DaBeschreibung17
    // ReSharper restore UnusedMember.Global
}

public class ViewModel
{

    private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);

    private ConfigPlc _configPlc;
    private Datenstruktur _datenstruktur;

    public ViewModel(Datenstruktur datenstruktur, ConfigPlc configPlc)
    {

        Log.Debug("Konstruktor - startet");


        _datenstruktur = datenstruktur;
        _configPlc = configPlc;


        for (var i = 0; i < 100; i++)
        {
            SichtbarEin.Add(Visibility.Hidden);
            SichtbarAus.Add(Visibility.Visible);
            Farbe.Add(Brushes.White);
            Text.Add("");
        }



        System.Threading.Tasks.Task.Run(ViewModelTask);

    }


    private void ViewModelTask()
    {
        while (true)
        {
            for (var i = 0; i < 100; i++)
            {
                SichtbarEin[i] = Visibility.Collapsed;
                SichtbarAus[i] = Visibility.Collapsed;
            }

            foreach (var zeile in _configPlc.Di.Zeilen)
            {
                var bitnummer = zeile.StartBit + 8 * zeile.StartByte;
                Text[(int)WpfObjects.Di00 + bitnummer] = zeile.Bezeichnung;
                Text[(int)WpfObjects.DiBeschreibung00 + bitnummer] = zeile.Kommentar;
                SichtbarEin[(int)WpfObjects.Di00 + bitnummer] = Visibility.Visible;
                SichtbarEin[(int)WpfObjects.DiBeschreibung00 + bitnummer] = Visibility.Visible;
            }

            foreach (var zeile in _configPlc.Da.Zeilen)
            {
                var bitnummer = zeile.StartBit + 8 * zeile.StartByte;
                Text[(int)WpfObjects.Da00 + bitnummer] = zeile.Bezeichnung;
                Text[(int)WpfObjects.DaBeschreibung00 + bitnummer] = zeile.Kommentar;
                SichtbarEin[(int)WpfObjects.Da00 + bitnummer] = Visibility.Visible;
                SichtbarEin[(int)WpfObjects.DaBeschreibung00 + bitnummer] = Visibility.Visible;
            }

            for (var i = 0; i < 16; i++)
            {
                FarbeUmschalten(BitTesten(_datenstruktur.Di, i), (int)WpfObjects.Di00 + i, Brushes.Yellow, Brushes.DarkGray);
                FarbeUmschalten(BitTesten(_datenstruktur.Da, i), (int)WpfObjects.Da00 + i, Brushes.LawnGreen, Brushes.DarkGray);
            }

            Thread.Sleep(10);
        }
        // ReSharper disable once FunctionNeverReturns
    }



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


    public event PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    private static bool BitTesten(IReadOnlyList<byte> datenArray, int i)
    {
        var ibyte = i / 8;
        var bitMuster = (byte)(1 << (i % 8));

        return (datenArray[ibyte] & bitMuster) == bitMuster;
    }
}