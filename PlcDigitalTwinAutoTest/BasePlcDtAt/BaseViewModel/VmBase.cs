using System;
using BasePlcDtAt.BaseCommands;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using LibDatenstruktur;
using LibPlcKommunikation;

namespace BasePlcDtAt.BaseViewModel;

public abstract partial class VmBase
{
    public enum WpfBase
    {
        TabBeschreibung = 0,
        TabLaborplatte = 1,
        TabSimulation = 2,
        TabAutoTest = 3,
        BtnPlcAnzeigen = 4,
        BtnPlottAnzeigen = 5,
        // ReSharper disable UnusedMember.Global
        ErrorAnzeige = 6,
        ErrorVersionLokal = 7,
        ErrorVersionPlc = 8
        // ReSharper restore UnusedMember.Global
    }

    private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);

    protected abstract void ViewModelAufrufThread();
    protected abstract void ViewModelAufrufTaster(Enum tasterId, bool gedrueckt);
    protected abstract void ViewModelAufrufSchalter(Enum schalterId);

    public abstract void PlotterButtonClick(object sender, RoutedEventArgs e);

    public Datenstruktur Datenstruktur { get; set; }
    public BaseModel.BaseModel Model { get; set; }
    
    public PlcDaemon PlcDaemon { get; set; }
    protected VmBase(BaseModel.BaseModel model, Datenstruktur datenstruktur)
    {
        Log.Debug("Konstruktor - startet");

        PlcDaemon = new PlcDaemon(datenstruktur);
        Model = model;
        Datenstruktur = datenstruktur;

        FensterTitel = "Unbekannter Titel";

        SpsSichtbar = Visibility.Hidden;
        SpsVersionLokal = "fehlt";
        SpsVersionEntfernt = "fehlt";
        SpsStatus = "x";
        SpsColor = Brushes.LightBlue;

        for (var i = 0; i < 100; i++)
        {
            ButtonIsEnabled.Add(false);
            ClkMode.Add(ClickMode.Press);
            SichtbarEin.Add(Visibility.Hidden);
            SichtbarAus.Add(Visibility.Visible);
            Farbe.Add(Brushes.White);
            Text.Add("");
            Margin.Add(new Thickness(0,0,0,0));
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
    public abstract void BeschreibungZeichnen(TabItem tabItem);
    public abstract void LaborPlatteZeichnen(TabItem tabItem);
    public abstract void SimulationZeichnen(TabItem tabItem);
}