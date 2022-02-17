using BasePlcDtAt.BaseCommands;
using Contracts;
using LibDatenstruktur;
using LibPlcKommunikation;
using System;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace BasePlcDtAt.BaseViewModel;

public abstract partial class VmBase
{
    private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);

    protected abstract void ViewModelAufrufThread();
    protected abstract void ViewModelAufrufTaster(Enum tasterId, bool gedrueckt);
    protected abstract void ViewModelAufrufSchalter(Enum schalterId);

    public abstract void PlotterButtonClick(object sender, RoutedEventArgs e);
    public BaseModel.BaseModel Model { get; set; }
    public PlcDaemon PlcDaemon { get; set; }


    private readonly Datenstruktur _datenstruktur;

    protected VmBase(BaseModel.BaseModel model, Datenstruktur datenstruktur, CancellationTokenSource cancellationTokenSource)
    {
        Log.Debug("Konstruktor - startet");

        PlcDaemon = new PlcDaemon(datenstruktur, cancellationTokenSource);
        Model = model;
        _datenstruktur = datenstruktur;

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
            Margin.Add(new Thickness(0, 0, 0, 0));
            TransformOrigin.Add(new Point(0, 0));
            Winkel.Add(0);
        }

        Farbe[(int)WpfBase.ErrorAnzeige] = Brushes.Red;

        System.Threading.Tasks.Task.Run(() => ViewModelTask(cancellationTokenSource));
    }

    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

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