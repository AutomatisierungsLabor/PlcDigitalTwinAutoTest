using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Contracts;
using DtSchleifmaschine.Model;
using LibDatenstruktur;

namespace DtSchleifmaschine.ViewModel;

public enum WpfObjects
{
    // ReSharper disable once UnusedMember.Global
    ReserveFuerBasisViewModel = 20,// // enum WpfBase

    B1 = 21,

    F1 = 22,
    F2 = 23,

    P1 = 25,
    P2 = 26,
    P3 = 27,

    S0 = 30,
    S1 = 31,
    S2 = 32,
    S3 = 33,
    S4 = 34,
    S5 = 35,


    WinkelSchleifmaschine = 50,
    SchleifmaschineDrehzahl = 51
}
public partial class VmSchleifmaschine : BasePlcDtAt.BaseViewModel.VmBase
{
    private readonly ModelSchleifmaschine _modelSchleifmaschine;
    private readonly Datenstruktur _datenstruktur;

    public VmSchleifmaschine(BasePlcDtAt.BaseModel.BaseModel model, Datenstruktur datenstruktur, CancellationTokenSource cancellationTokenSource) : base(model, datenstruktur, cancellationTokenSource)
    {
        _datenstruktur = datenstruktur;

        VisibilityTabBeschreibung = Visibility.Collapsed;
        VisibilityTabLaborplatte = Visibility.Collapsed;
        VisibilityTabSimulation = Visibility.Visible;
        VisibilityTabSoftwareTest = Visibility.Visible;

        SichtbarEin[(int)WpfBase.BtnPlcAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.BtnPlottAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.BtnLinkHomepageAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.BtnAlwarmVerwaltungAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfObjects.SchleifmaschineDrehzahl] = Visibility.Visible;

        Text[(int)WpfObjects.S0] = "STOP";
        Text[(int)WpfObjects.S1] = "I";
        Text[(int)WpfObjects.S2] = "II";
        Text[(int)WpfObjects.S3] = "Not Halt";
        Text[(int)WpfObjects.S4] = "RESET";

        Text[(int)WpfObjects.B1] = "Schleifmaschine Übersynchron!";

        _modelSchleifmaschine = model as ModelSchleifmaschine;
    }

    protected override void ViewModelAufrufThread()
    {
        if (_modelSchleifmaschine == null) return;

        FensterTitel = PlcDaemon.PlcState.PlcBezeichnung + ": " + _datenstruktur.VersionsStringLokal;

        Winkel[(int)WpfObjects.WinkelSchleifmaschine] = _modelSchleifmaschine.WinkelSchleifmaschine;
        AktuelleDrehzahl = _modelSchleifmaschine.DrehzahlSchleifmaschine;
        Text[(int)WpfObjects.SchleifmaschineDrehzahl] = "n=" + _modelSchleifmaschine.DrehzahlSchleifmaschine;
        
        RipSichtbarkeitUmschalten(_modelSchleifmaschine.B1, (int)WpfObjects.B1);
        RipSichtbarkeitUmschalten(_modelSchleifmaschine.S3, (int)WpfObjects.S3);

        RipFarbeUmschalten(_modelSchleifmaschine.F1, (int)WpfObjects.F1, Brushes.LawnGreen, Brushes.Red);
        RipFarbeUmschalten(_modelSchleifmaschine.F2, (int)WpfObjects.F2, Brushes.LawnGreen, Brushes.Red);

        RipFarbeUmschalten(_modelSchleifmaschine.P1, (int)WpfObjects.P1, Brushes.White, Brushes.LightGray);
        RipFarbeUmschalten(_modelSchleifmaschine.P2, (int)WpfObjects.P2, Brushes.LawnGreen, Brushes.LightGray);
        RipFarbeUmschalten(_modelSchleifmaschine.P3, (int)WpfObjects.P3, Brushes.Red, Brushes.LightGray);
        RipFarbeUmschalten(_modelSchleifmaschine.S3, (int)WpfObjects.S3, Brushes.LawnGreen, Brushes.Red);
    }
    protected override void ViewModelAufrufTaster(Enum tasterId, bool gedrueckt)
    {
        switch (tasterId)
        {
            case WpfObjects.S0: _modelSchleifmaschine.S0 = !gedrueckt; break;
            case WpfObjects.S1: _modelSchleifmaschine.S1 = gedrueckt; break;
            case WpfObjects.S2: _modelSchleifmaschine.S2 = gedrueckt; break;
            case WpfObjects.S4:
                _modelSchleifmaschine.S4 = gedrueckt;
                _modelSchleifmaschine.B1 = false;
                break;

            default: throw new ArgumentOutOfRangeException(nameof(tasterId));
        }
    }

    protected override void ViewModelAufrufSchalter(Enum schalterId)
    {
        switch (schalterId)
        {
            case WpfObjects.F1: _modelSchleifmaschine.F1 = !_modelSchleifmaschine.F1; break;
            case WpfObjects.F2: _modelSchleifmaschine.F2 = !_modelSchleifmaschine.F2; break;
            case WpfObjects.S3: _modelSchleifmaschine.S3 = !_modelSchleifmaschine.S3; break;
            default: throw new ArgumentOutOfRangeException(nameof(schalterId));
        }
    }
    public override void PlotterButtonClick(object sender, RoutedEventArgs e) { }
    public override void BeschreibungZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabBeschreibungZeichnen(this, tabItem, "#eeeeee");
    public override void LaborPlatteZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabLaborPlatteZeichnen(this, tabItem, "#eeeeee");
    public override void SimulationZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabSimulationZeichnen(this, tabItem, "#eeeeee");

    private double _aktuelleDrehzahl;
    public double AktuelleDrehzahl
    {
        get => _aktuelleDrehzahl;
        set
        {
            _aktuelleDrehzahl = value;
            OnPropertyChanged(nameof(AktuelleDrehzahl));
        }
    }
}