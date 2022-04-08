using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Contracts;
using DtLap2018_2_Abfuellanlage.Model;
using LibDatenstruktur;

namespace DtLap2018_2_Abfuellanlage.ViewModel;

public partial class VmLap2018 : BasePlcDtAt.BaseViewModel.VmBase
{
    private readonly ModelLap2018 _modelLap2018;
    private readonly Datenstruktur _datenstruktur;
    private const double HoeheFuellBalken = 9 * 35;

    public VmLap2018(BasePlcDtAt.BaseModel.BaseModel model, Datenstruktur datenstruktur, CancellationTokenSource cancellationTokenSource) : base(model, datenstruktur, cancellationTokenSource)
    {
        _modelLap2018 = model as ModelLap2018;
        _datenstruktur = datenstruktur;

        VisibilityTabBeschreibung = Visibility.Collapsed;
        VisibilityTabLaborplatte = Visibility.Collapsed;
        VisibilityTabSimulation = Visibility.Visible;
        VisibilityTabSoftwareTest = Visibility.Visible;

        SichtbarEin[(int)WpfBase.BtnPlcAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.BtnPlottAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.BtnLinkHomepageAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.BtnAlwarmVerwaltungAnzeigen] = Visibility.Visible;
    }
    protected override void ViewModelAufrufThread()
    {
        if (_modelLap2018 == null) return;
        FensterTitel = PlcDaemon.PlcState.PlcBezeichnung + ": " + _datenstruktur.VersionsStringLokal;

        (VisibilityFlasche1, MarginFlasche1) = FlaschePositionieren(_modelLap2018.AlleFlaschen[0]);
        (VisibilityFlasche2, MarginFlasche2) = FlaschePositionieren(_modelLap2018.AlleFlaschen[1]);
        (VisibilityFlasche3, MarginFlasche3) = FlaschePositionieren(_modelLap2018.AlleFlaschen[2]);
        (VisibilityFlasche4, MarginFlasche4) = FlaschePositionieren(_modelLap2018.AlleFlaschen[3]);
        (VisibilityFlasche5, MarginFlasche5) = FlaschePositionieren(_modelLap2018.AlleFlaschen[4]);
        (VisibilityFlasche6, MarginFlasche6) = FlaschePositionieren(_modelLap2018.AlleFlaschen[5]);
        
        (VisibilityEinB1, VisibilityAusB1) = SetVisibility(_modelLap2018.B1);
        (VisibilityEinK1, VisibilityAusK1) = SetVisibility(_modelLap2018.K1);
        (VisibilityEinK2, VisibilityAusK2) = SetVisibility(_modelLap2018.K2);

        KisteAnzeigen(_modelLap2018.FlaschenInDerKiste);

        BrushF1 = SetBrush(_modelLap2018.F1, Brushes.LawnGreen, Brushes.Red);
        BrushP1 = SetBrush(_modelLap2018.P1, Brushes.LawnGreen, Brushes.LightGray);
        BrushP2 = SetBrush(_modelLap2018.P2, Brushes.Red, Brushes.LightGray);
        BrushQ1 = SetBrush(_modelLap2018.Q1, Brushes.LawnGreen, Brushes.LightGray);
        BrushZuleitung = SetBrush(_modelLap2018.Pegel > 0.01, Brushes.Blue, Brushes.LightBlue);
        BrushAbleitung = SetBrush(_modelLap2018.K1 && _modelLap2018.Pegel > 0.01, Brushes.Blue, Brushes.LightGray);

        MarginPegel = new Thickness(0, HoeheFuellBalken * (1 - _modelLap2018.Pegel), 0, 0);
        StringFuellstandProzent= (100 * _modelLap2018.Pegel).ToString("F0") + "%";
    }

    private (Visibility vis, Thickness margin) FlaschePositionieren(Flaschen allflaschen)
    {
        const double breiteZeichenfeld = 20 * 30;
        const double hoeheZeichenfeld = 20 * 30;

        var (ein, _) = SetVisibility(allflaschen.Sichtbar);
        var margin = new Thickness(allflaschen.Flasche.GetLinks(), allflaschen.Flasche.GetOben(), breiteZeichenfeld - allflaschen.Flasche.GetRechts(), hoeheZeichenfeld - allflaschen.Flasche.GetUnten());
        return (ein, margin);
    }
    private void KisteAnzeigen(int anzahlFlaschen)
    {
        var alleFohrenburgerKisten = new bool[10];
        var alleMohrenKisten = new bool[10];

        for (var i = 0; i < 10; i++)
        {
            alleFohrenburgerKisten[i] = false;
            alleMohrenKisten[i] = false;
        }

        if (_modelLap2018.AktuellesBier == ModelLap2018.Bier.Fohrenburger) alleFohrenburgerKisten[anzahlFlaschen] = true; else alleMohrenKisten[anzahlFlaschen] = true;

        (VisibilityFohrenburger0, _) = SetVisibility(alleFohrenburgerKisten[0]);
        (VisibilityFohrenburger1, _) = SetVisibility(alleFohrenburgerKisten[1]);
        (VisibilityFohrenburger2, _) = SetVisibility(alleFohrenburgerKisten[2]);
        (VisibilityFohrenburger3, _) = SetVisibility(alleFohrenburgerKisten[3]);
        (VisibilityFohrenburger4, _) = SetVisibility(alleFohrenburgerKisten[4]);
        (VisibilityFohrenburger5, _) = SetVisibility(alleFohrenburgerKisten[5]);
        (VisibilityFohrenburger6, _) = SetVisibility(alleFohrenburgerKisten[6]);

        (VisibilityMohren0, _) = SetVisibility(alleMohrenKisten[0]);
        (VisibilityMohren1, _) = SetVisibility(alleMohrenKisten[1]);
        (VisibilityMohren2, _) = SetVisibility(alleMohrenKisten[2]);
        (VisibilityMohren3, _) = SetVisibility(alleMohrenKisten[3]);
        (VisibilityMohren4, _) = SetVisibility(alleMohrenKisten[4]);
        (VisibilityMohren5, _) = SetVisibility(alleMohrenKisten[5]);
        (VisibilityMohren6, _) = SetVisibility(alleMohrenKisten[6]);
    }
    protected override void ViewModelAufrufTaster(Enum tasterId, bool gedrueckt) { }
    protected override void ViewModelAufrufSchalter(Enum schalterId) { }
    public override void PlotterButtonClick(object sender, RoutedEventArgs e) { }
    public override void BeschreibungZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabBeschreibungZeichnen(this, tabItem, "#eeeeee");
    public override void LaborPlatteZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabLaborPlatteZeichnen(this, tabItem, "#eeeeee");
    public override void SimulationZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabSimulationZeichnen(this, tabItem, "#eeeeee");
}