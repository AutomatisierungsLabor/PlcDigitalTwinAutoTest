using DtLap2018_2_Abfuellanlage.Model;
using LibDatenstruktur;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Contracts;

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

        VisibilityBtnPlcAnzeigen = Visibility.Visible;
        VisibilityBtnPlottAnzeigen = Visibility.Visible;
        VisibilityBtnLinkHomepageAnzeigen = Visibility.Visible;
        VisibilityBtnAlarmVerwaltungAnzeigen = Visibility.Visible;
    }
    protected override void ViewModelAufrufThread(double dT)
    {
        if (_modelLap2018 == null) return;
        StringFensterTitel = PlcDaemon.PlcState.PlcBezeichnung + ": " + _datenstruktur.VersionsStringLokal;

        (VisibilityFlasche1, MarginFlasche1) = FlaschePositionieren(_modelLap2018.AlleFlaschen[0]);
        (VisibilityFlasche2, MarginFlasche2) = FlaschePositionieren(_modelLap2018.AlleFlaschen[1]);
        (VisibilityFlasche3, MarginFlasche3) = FlaschePositionieren(_modelLap2018.AlleFlaschen[2]);
        (VisibilityFlasche4, MarginFlasche4) = FlaschePositionieren(_modelLap2018.AlleFlaschen[3]);
        (VisibilityFlasche5, MarginFlasche5) = FlaschePositionieren(_modelLap2018.AlleFlaschen[4]);
        (VisibilityFlasche6, MarginFlasche6) = FlaschePositionieren(_modelLap2018.AlleFlaschen[5]);

        (VisibilityEinB1, VisibilityAusB1) = BaseFunctions.SetVisibility(_modelLap2018.B1);
        (VisibilityEinK1, VisibilityAusK1) = BaseFunctions.SetVisibility(_modelLap2018.K1);
        (VisibilityEinK2, VisibilityAusK2) = BaseFunctions.SetVisibility(_modelLap2018.K2);

        KisteAnzeigen(_modelLap2018.FlaschenInDerKiste);

        BrushF1 = BaseFunctions.SetBrush(_modelLap2018.F1, Brushes.LawnGreen, Brushes.Red);
        BrushP1 = BaseFunctions.SetBrush(_modelLap2018.P1, Brushes.LawnGreen, Brushes.LightGray);
        BrushP2 = BaseFunctions.SetBrush(_modelLap2018.P2, Brushes.Red, Brushes.LightGray);
        BrushQ1 = BaseFunctions.SetBrush(_modelLap2018.Q1, Brushes.LawnGreen, Brushes.LightGray);
        BrushZuleitung = BaseFunctions.SetBrush(_modelLap2018.Pegel > 0.01, Brushes.Blue, Brushes.LightBlue);
        BrushAbleitung = BaseFunctions.SetBrush(_modelLap2018.K1 && _modelLap2018.Pegel > 0.01, Brushes.Blue, Brushes.LightGray);

        MarginPegel = new Thickness(0, HoeheFuellBalken * (1 - _modelLap2018.Pegel), 0, 0);
        StringFuellstandProzent = (100 * _modelLap2018.Pegel).ToString("F0") + "%";
    }

    private (Visibility vis, Thickness margin) FlaschePositionieren(Flaschen allflaschen)
    {
        const double breiteZeichenfeld = 20 * WpfData.RasterX;
        const double hoeheZeichenfeld = 20 * WpfData.RasterY;

        var (ein, _) = BaseFunctions.SetVisibility(allflaschen.Sichtbar);
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

        (VisibilityFohrenburger0, _) = BaseFunctions.SetVisibility(alleFohrenburgerKisten[0]);
        (VisibilityFohrenburger1, _) = BaseFunctions.SetVisibility(alleFohrenburgerKisten[1]);
        (VisibilityFohrenburger2, _) = BaseFunctions.SetVisibility(alleFohrenburgerKisten[2]);
        (VisibilityFohrenburger3, _) = BaseFunctions.SetVisibility(alleFohrenburgerKisten[3]);
        (VisibilityFohrenburger4, _) = BaseFunctions.SetVisibility(alleFohrenburgerKisten[4]);
        (VisibilityFohrenburger5, _) = BaseFunctions.SetVisibility(alleFohrenburgerKisten[5]);
        (VisibilityFohrenburger6, _) = BaseFunctions.SetVisibility(alleFohrenburgerKisten[6]);

        (VisibilityMohren0, _) = BaseFunctions.SetVisibility(alleMohrenKisten[0]);
        (VisibilityMohren1, _) = BaseFunctions.SetVisibility(alleMohrenKisten[1]);
        (VisibilityMohren2, _) = BaseFunctions.SetVisibility(alleMohrenKisten[2]);
        (VisibilityMohren3, _) = BaseFunctions.SetVisibility(alleMohrenKisten[3]);
        (VisibilityMohren4, _) = BaseFunctions.SetVisibility(alleMohrenKisten[4]);
        (VisibilityMohren5, _) = BaseFunctions.SetVisibility(alleMohrenKisten[5]);
        (VisibilityMohren6, _) = BaseFunctions.SetVisibility(alleMohrenKisten[6]);
    }
    public override void PlotterButtonClick(object sender, RoutedEventArgs e) { }
    public override void BeschreibungZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabBeschreibungZeichnen(this, tabItem, "#eeeeee");
    public override void LaborPlatteZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabLaborPlatteZeichnen(this, tabItem, "#eeeeee");
    public override void SimulationZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabSimulationZeichnen(this, tabItem, "#eeeeee");
}