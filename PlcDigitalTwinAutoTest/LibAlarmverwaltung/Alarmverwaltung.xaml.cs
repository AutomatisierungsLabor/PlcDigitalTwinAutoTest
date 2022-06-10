using System.Threading;
using System.Windows.Controls;
using LibAlarmverwaltung.Model;
using LibAlarmverwaltung.ViewModel;
using LibConfigDt;
using LibDatenstruktur;

namespace LibAlarmverwaltung;

public partial class Alarmverwaltung
{

    private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);


    public AlarmZeichnen.AlarmZeichnen AlarmZeichnen { get; set; }
    public ModelAlarmverwaltung ModelAlarmverwaltung { get; set; }
  

    public bool FensterAktiv { get; set; }

    private readonly Datenstruktur _datenstruktur;
    private readonly ConfigDt _configDt;
    private readonly CancellationTokenSource _cancellationTokenSource;

    public Alarmverwaltung(Datenstruktur datenstruktur, ConfigDt configDt, CancellationTokenSource cancellationTokenSource)
    {
        Log.Debug("Konstruktor");

        _datenstruktur = datenstruktur;
        _configDt = configDt;
        _cancellationTokenSource = cancellationTokenSource;

        var grid = new Grid();
        Content = grid;

        AlarmZeichnen = new AlarmZeichnen.AlarmZeichnen(_configDt, grid, this);
        ModelAlarmverwaltung = new ModelAlarmverwaltung();
        var viewModel = new VmAlarmverwaltung(_datenstruktur, _configDt, _cancellationTokenSource);

        DataContext = viewModel;

        Closing += (_, e) =>
        {
            e.Cancel = true;
            FensterAusblenden();
        };
    }
    public void FensterAusblenden()
    {
        FensterAktiv = false;
        Hide();
    }
    public void FensterAnzeigen()
    {
        FensterAktiv = true;
        Show();
    }

    public void ConfigNeuLaden() => AlarmZeichnen.UpdateConfig();

    public void WindowSetSize(double w, double h)
    {
        Width = w;
        Height = h;
    }
}