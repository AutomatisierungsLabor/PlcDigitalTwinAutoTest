using System;
using BasePlcDtAt.BaseCommands;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using LibDatenstruktur;

namespace BasePlcDtAt.BaseViewModel;

public abstract partial class ViewModel
{
    public enum WpfBase
    {
        TabBeschreibung = 0,
        TabLaborplatte = 1,
        TabSimulation = 2,
        TabAutoTest = 3,
        BtnPlcAnzeigen = 4,
        BtnPlottAnzeigen = 5,
        ErrorAnzeige = 6,
        ErrorVersionLokal = 7,
        ErrorVersionPlc = 8
    }

    private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);

    protected abstract void ViewModelAufrufThread();
    protected abstract void ViewModelAufrufTaster(Enum tasterId, bool gedrueckt);
    protected abstract void ViewModelAufrufSchalter(Enum schalterId);
    
    public abstract void PlcButtonClick(object sender, RoutedEventArgs e);
    public abstract void PlotterButtonClick(object sender, RoutedEventArgs e);

    public Datenstruktur Datenstruktur { get; set; }
    public BaseModel.Model Model { get; set; }

    protected bool GridSichtbar;
    protected ViewModel(BaseModel.Model model, Datenstruktur datenstruktur)
    {
        Log.Debug("Konstruktor - startet");
        Model = model;
        Datenstruktur = datenstruktur;

        FensterTitel = "Unbekannter Titel";

        SpsSichtbar = Visibility.Hidden;
        SpsVersionLokal = "fehlt";
        SpsVersionEntfernt = "fehlt";
        SpsStatus = "x";
        SpsColor = Brushes.LightBlue;

        for (var i = 0; i < 500; i++)
        {
            ClkMode.Add(ClickMode.Press);
            SichtbarEin.Add(Visibility.Hidden);
            SichtbarAus.Add(Visibility.Visible);
            Farbe.Add(Brushes.White);
            Text.Add("");
        }

        System.Threading.Tasks.Task.Run(ViewModelTask);
    }

    public event PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    private ICommand _btnTaster;
    // ReSharper disable once UnusedMember.Global
    public ICommand BtnTaster => _btnTaster ??= new RelayCommand(Taster);

    private ICommand _btnSchalter;
    // ReSharper disable once UnusedMember.Global
    public ICommand BtnSchalter => _btnSchalter ??= new RelayCommand(Schalter);
    public abstract void BeschreibungZeichnen(Grid grid);
    public abstract void LaborPlatteZeichnen(Grid grid);
    public abstract void SimulationZeichnen(Grid grid);
}