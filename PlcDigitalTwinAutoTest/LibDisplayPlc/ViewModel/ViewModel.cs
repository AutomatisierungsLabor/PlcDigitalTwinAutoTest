using LibConfigPlc;
using LibDatenstruktur;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Media;

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

    private readonly ConfigPlc _configPlc;
    private readonly Datenstruktur _datenstruktur;
    private readonly CancellationTokenSource _cancellationTokenSource;

    private ObservableCollection<DaEinstellungen> _daZeilenAlt = new();
    private ObservableCollection<DiEinstellungen> _diZeilenAlt = new();

    public ViewModel(Datenstruktur datenstruktur, ConfigPlc configPlc, CancellationTokenSource cancellationTokenSource)
    {
        Log.Debug("Konstruktor - startet");

        _datenstruktur = datenstruktur;
        _configPlc = configPlc;
        _cancellationTokenSource = cancellationTokenSource;

        for (var i = 0; i < 100; i++)
        {
            SichtbarEin.Add(Visibility.Hidden);
            Farbe.Add(Brushes.White);
            Text.Add("");
        }

        System.Threading.Tasks.Task.Run(ViewModelTask);
    }
    private void ViewModelTask()
    {
        while (!_cancellationTokenSource.IsCancellationRequested)
        {
            DiZeilenBeschriften(_configPlc.Di.Zeilen);
            DaZeilenBeschriften(_configPlc.Da.Zeilen);

            for (var i = 0; i < 16; i++)
            {
                FarbeUmschalten(LibPlcTools.Bitmuster.BitInByteArrayTesten(_datenstruktur.Di, i), (int)WpfObjects.Di00 + i, Brushes.Yellow, Brushes.DarkGray);
                FarbeUmschalten(LibPlcTools.Bitmuster.BitInByteArrayTesten(_datenstruktur.Da, i), (int)WpfObjects.Da00 + i, Brushes.LawnGreen, Brushes.DarkGray);
            }

            Thread.Sleep(10);
        }
    }
    private void DaZeilenBeschriften(ObservableCollection<DaEinstellungen> daZeilen)
    {
        if (_daZeilenAlt == daZeilen) return;

        _daZeilenAlt = daZeilen;

        for (var i = (int)WpfObjects.Da00; i <= (int)WpfObjects.DaBeschreibung17; i++) SichtbarEin[i] = Visibility.Collapsed;
        
        foreach (var zeile in _configPlc.Da.Zeilen)
        {
            var bitnummer = zeile.StartBit + 8 * zeile.StartByte;
            Text[(int)WpfObjects.Da00 + bitnummer] = zeile.Bezeichnung;
            Text[(int)WpfObjects.DaBeschreibung00 + bitnummer] = zeile.Kommentar;
            SichtbarEin[(int)WpfObjects.Da00 + bitnummer] = Visibility.Visible;
            SichtbarEin[(int)WpfObjects.DaBeschreibung00 + bitnummer] = Visibility.Visible;
        }
    }
    private void DiZeilenBeschriften(ObservableCollection<DiEinstellungen> diZeilen)
    {
        if (_diZeilenAlt == diZeilen) return;

        _diZeilenAlt = diZeilen;

        for (var i = (int)WpfObjects.Di00; i <= (int)WpfObjects.DiBeschreibung17; i++) SichtbarEin[i] = Visibility.Collapsed;

        foreach (var zeile in _configPlc.Di.Zeilen)
        {
            var bitnummer = zeile.StartBit + 8 * zeile.StartByte;
            Text[(int)WpfObjects.Di00 + bitnummer] = zeile.Bezeichnung;
            Text[(int)WpfObjects.DiBeschreibung00 + bitnummer] = zeile.Kommentar;
            SichtbarEin[(int)WpfObjects.Di00 + bitnummer] = Visibility.Visible;
            SichtbarEin[(int)WpfObjects.DiBeschreibung00 + bitnummer] = Visibility.Visible;
        }
    }

    private void FarbeUmschalten(bool val, int i, Brush farbe1, Brush farbe2) => Farbe[i] = val ? farbe1 : farbe2;

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