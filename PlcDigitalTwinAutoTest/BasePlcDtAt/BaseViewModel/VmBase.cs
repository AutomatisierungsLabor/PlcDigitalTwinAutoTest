using LibDatenstruktur;
using LibPlcKommunikation;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BasePlcDtAt.BaseViewModel;

public abstract partial class VmBase : ObservableObject
{
    private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);

    protected abstract void ViewModelAufrufThread();

    public abstract void PlotterButtonClick(object sender, RoutedEventArgs e);
    //public abstract void HomepageButtonClick(object sender, RoutedEventArgs e);
    //public abstract void AlarmVerwaltungButtonClick(object sender, RoutedEventArgs e);



    public BaseModel.BaseModel Model { get; set; }
    public PlcDaemon PlcDaemon { get; set; }


    private readonly Datenstruktur _datenstruktur;

    protected VmBase(BaseModel.BaseModel model, Datenstruktur datenstruktur, CancellationTokenSource cancellationTokenSource)
    {
        Log.Debug("Konstruktor - startet");

        PlcDaemon = new PlcDaemon(datenstruktur, cancellationTokenSource);
        Model = model;
        _datenstruktur = datenstruktur;

        StringFensterTitel = "Unbekannter Titel";

        VisibilitySpsSichtbar = Visibility.Hidden;
        StringSpsVersionLokal = "fehlt";
        StringSpsVersionEntfernt = "fehlt";
        StringSpsStatus = "x";
        BrushSpsColor = Brushes.LightBlue;

        System.Threading.Tasks.Task.Run(() => ViewModelTask(cancellationTokenSource));
    }
    public abstract void BeschreibungZeichnen(TabItem tabItem);
    public abstract void LaborPlatteZeichnen(TabItem tabItem);
    public abstract void SimulationZeichnen(TabItem tabItem);
}