using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Contracts;
using DtLap2018_2_Abfuellanlage.Model;
using LibDatenstruktur;
using LibUtil;

namespace DtLap2018_2_Abfuellanlage.ViewModel;
public enum WpfObjects
{
    // ReSharper disable once UnusedMember.Global
    ReserveFuerBasisViewModel = 20, // enum WpfBase

    K1 = 21,
    K2 = 22,
    P1 = 23,
    P2 = 24,
    Q1 = 25,


    B1 = 30,
    F1 = 31,
    S1 = 32,
    S2 = 33,
    S3 = 34,
    S4 = 35,

    TankNachfuellen = 40,
    AllesReset = 41,
    Ableitung = 42,
    Zuleitung = 43,
    Pegel = 44,
    FuellstandProzent = 45,

    Flasche1 = 51,
    Flasche2 = 52,
    Flasche3 = 53,
    Flasche4 = 54,
    Flasche5 = 55,
    Flasche6 = 56,


    Fohrenburger0 = 60,
    // ReSharper disable UnusedMember.Global
    Fohrenburger1 = 61,
    Fohrenburger2 = 62,
    Fohrenburger3 = 63,
    Fohrenburger4 = 64,
    Fohrenburger5 = 65,
    Fohrenburger6 = 66,
    // ReSharper restore UnusedMember.Global

    Mohren0 = 70,
    // ReSharper disable UnusedMember.Global
    Mohren1 = 71,
    Mohren2 = 72,
    Mohren3 = 73,
    Mohren4 = 74,
    Mohren5 = 75,
    Mohren6 = 76
    // ReSharper restore UnusedMember.Global

}
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

        Text[(int)WpfObjects.AllesReset] = "RESET";
        Text[(int)WpfObjects.TankNachfuellen] = "Nachfüllen";
        
        Text[(int)WpfObjects.F1] = "Motorschutz";

        Text[(int)WpfObjects.S1] = "Start";
        Text[(int)WpfObjects.S2] = "Stop";
        Text[(int)WpfObjects.S3] = "Vereinzeln";
        Text[(int)WpfObjects.S4] = "Quittieren";


        PositionSetzen(new Punkt(10, 10), (int)WpfObjects.Flasche1);
        PositionSetzen(new Punkt(20, 20), (int)WpfObjects.Flasche2);
        PositionSetzen(new Punkt(30, 30), (int)WpfObjects.Flasche3);
        PositionSetzen(new Punkt(40, 40), (int)WpfObjects.Flasche4);
        PositionSetzen(new Punkt(50, 50), (int)WpfObjects.Flasche5);
    }
    protected override void ViewModelAufrufThread()
    {
        if (_modelLap2018 == null) return;
        FensterTitel = PlcDaemon.PlcState.PlcBezeichnung + ": " + _datenstruktur.VersionsStringLokal;

        Margin[(int)WpfObjects.Flasche1] = new Thickness(50, 50, 50, 20);

        SichtbarEin[(int)WpfObjects.Flasche1] = Visibility.Visible;

        FlaschePositionieren(_modelLap2018.AlleFlaschen[0], WpfObjects.Flasche1);
        FlaschePositionieren(_modelLap2018.AlleFlaschen[1], WpfObjects.Flasche2);
        FlaschePositionieren(_modelLap2018.AlleFlaschen[2], WpfObjects.Flasche3);
        FlaschePositionieren(_modelLap2018.AlleFlaschen[3], WpfObjects.Flasche4);
        FlaschePositionieren(_modelLap2018.AlleFlaschen[4], WpfObjects.Flasche5);
        FlaschePositionieren(_modelLap2018.AlleFlaschen[5], WpfObjects.Flasche6);
        /*
    PositionSetzen(.Flasche.GetPosition(), );
    PositionSetzen(_modelLap2018.AlleFlaschen[1].Flasche.GetPosition(), (int)WpfObjects.Flasche2);
    PositionSetzen(_modelLap2018.AlleFlaschen[2].Flasche.GetPosition(), (int)WpfObjects.Flasche3);
    PositionSetzen(_modelLap2018.AlleFlaschen[3].Flasche.GetPosition(), (int)WpfObjects.Flasche4);
    PositionSetzen(_modelLap2018.AlleFlaschen[4].Flasche.GetPosition(), (int)WpfObjects.Flasche5);
    PositionSetzen(_modelLap2018.AlleFlaschen[5].Flasche.GetPosition(), (int)WpfObjects.Flasche6);
        */

        RipSichtbarkeitUmschalten(_modelLap2018.B1, (int)WpfObjects.B1);
        RipSichtbarkeitUmschalten(_modelLap2018.K1, (int)WpfObjects.K1);
        RipSichtbarkeitUmschalten(_modelLap2018.K2, (int)WpfObjects.K2);

        KisteAnzeigen(_modelLap2018.FlaschenInDerKiste);

        FarbeUmschalten(_modelLap2018.F1, (int)WpfObjects.F1, Brushes.LawnGreen, Brushes.Red);
        FarbeUmschalten(_modelLap2018.P1, (int)WpfObjects.P1, Brushes.LawnGreen, Brushes.LightGray);
        FarbeUmschalten(_modelLap2018.P2, (int)WpfObjects.P2, Brushes.Red, Brushes.LightGray);
        FarbeUmschalten(_modelLap2018.Q1, (int)WpfObjects.Q1, Brushes.LawnGreen, Brushes.LightGray);
        FarbeUmschalten(_modelLap2018.Pegel > 0.01, (int)WpfObjects.Zuleitung, Brushes.Blue, Brushes.LightBlue);
        FarbeUmschalten(_modelLap2018.K1 && _modelLap2018.Pegel > 0.01, (int)WpfObjects.Ableitung, Brushes.Blue, Brushes.LightGray);

        Margin[(int)WpfObjects.Pegel] = new Thickness(0, HoeheFuellBalken * (1 - _modelLap2018.Pegel), 0, 0);
        Text[(int)WpfObjects.FuellstandProzent] = (100 * _modelLap2018.Pegel).ToString("F0") + "%";
    }

    private void FlaschePositionieren(Flaschen allflaschen, WpfObjects wpfId)
    {
        const double breiteZeichenfeld = 20 * 30;
        const double hoeheZeichenfeld = 20 * 30;

        RipSichtbarkeitUmschalten(allflaschen.Sichtbar, (int)wpfId);
        Margin[(int)wpfId] = new Thickness(allflaschen.Flasche.GetLinks(), allflaschen.Flasche.GetOben(), breiteZeichenfeld - allflaschen.Flasche.GetRechts(), hoeheZeichenfeld - allflaschen.Flasche.GetUnten());
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

        for (var i = 0; i < 8; i++)
        {
            RipSichtbarkeitUmschalten(alleFohrenburgerKisten[i], (int)WpfObjects.Fohrenburger0 + i);
            RipSichtbarkeitUmschalten(alleMohrenKisten[i], (int)WpfObjects.Mohren0 + i);
        }
    }

    protected override void ViewModelAufrufTaster(Enum tasterId, bool gedrueckt)
    {
        switch (tasterId)
        {
            case WpfObjects.S1: _modelLap2018.S1 = gedrueckt; break;
            case WpfObjects.S2: _modelLap2018.S2 = !gedrueckt; break;
            case WpfObjects.S3: _modelLap2018.S3 = gedrueckt; break;
            case WpfObjects.S4: _modelLap2018.S4 = gedrueckt; break;
            case WpfObjects.TankNachfuellen: _modelLap2018.TankNachfuellen(); break;
            case WpfObjects.AllesReset: _modelLap2018.AllesReset(); break;
            default: throw new ArgumentOutOfRangeException(nameof(tasterId));
        }
    }

    protected override void ViewModelAufrufSchalter(Enum schalterId)
    {
        _modelLap2018.F1 = schalterId switch
        {
            WpfObjects.F1 => !_modelLap2018.F1,
            _ => throw new ArgumentOutOfRangeException(nameof(schalterId))
        };
    }
    public override void PlotterButtonClick(object sender, RoutedEventArgs e) { }
    public override void BeschreibungZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabBeschreibungZeichnen(this, tabItem, "#eeeeee");
    public override void LaborPlatteZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabLaborPlatteZeichnen(this, tabItem, "#eeeeee");
    public override void SimulationZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabSimulationZeichnen(this, tabItem, "#eeeeee");
}