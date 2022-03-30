using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Contracts;
using DtLap2018_2_Abfuellanlage.Model;
using LibDatenstruktur;

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
public class VmLap2018 : BasePlcDtAt.BaseViewModel.VmBase
{
    private readonly ModelLap2018 _modelLap2018;
    private readonly Datenstruktur _datenstruktur;
    private const double HoeheFuellBalken = 9 * 35;

    public VmLap2018(BasePlcDtAt.BaseModel.BaseModel model, Datenstruktur datenstruktur, CancellationTokenSource cancellationTokenSource) : base(model, datenstruktur, cancellationTokenSource)
    {
        _modelLap2018 = model as ModelLap2018;
        _datenstruktur = datenstruktur;

        SichtbarEin[(int)WpfBase.TabBeschreibung] = Visibility.Collapsed;
        SichtbarEin[(int)WpfBase.TabLaborplatte] = Visibility.Collapsed;
        SichtbarEin[(int)WpfBase.TabSimulation] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.TabAutoTest] = Visibility.Visible;

        SichtbarEin[(int)WpfBase.BtnPlcAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.BtnPlottAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.BtnLinkHomepageAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.BtnAlwarmVerwaltungAnzeigen] = Visibility.Visible;

        Text[(int)WpfObjects.S1] = "S1";
        Text[(int)WpfObjects.S2] = "S2";
        Text[(int)WpfObjects.S3] = "S3";
        Text[(int)WpfObjects.S4] = "S4";
    }
    protected override void ViewModelAufrufThread()
    {
        if (_modelLap2018 == null) return;
        FensterTitel = PlcDaemon.PlcState.PlcBezeichnung + ": " + _datenstruktur.VersionsStringLokal;

        SichtbarkeitUmschalten(_modelLap2018.AlleFlaschen[0].Sichtbar, (int)WpfObjects.Flasche1);
        SichtbarkeitUmschalten(_modelLap2018.AlleFlaschen[1].Sichtbar, (int)WpfObjects.Flasche2);
        SichtbarkeitUmschalten(_modelLap2018.AlleFlaschen[2].Sichtbar, (int)WpfObjects.Flasche3);
        SichtbarkeitUmschalten(_modelLap2018.AlleFlaschen[3].Sichtbar, (int)WpfObjects.Flasche4);
        SichtbarkeitUmschalten(_modelLap2018.AlleFlaschen[4].Sichtbar, (int)WpfObjects.Flasche5);
        SichtbarkeitUmschalten(_modelLap2018.AlleFlaschen[5].Sichtbar, (int)WpfObjects.Flasche6);

        SichtbarkeitUmschalten(_modelLap2018.B1, (int)WpfObjects.B1);
        SichtbarkeitUmschalten(_modelLap2018.K1, (int)WpfObjects.K1);
        SichtbarkeitUmschalten(_modelLap2018.K2, (int)WpfObjects.K2);
        SichtbarkeitUmschalten(_modelLap2018.K1 && _modelLap2018.Pegel > 0.01, (int)WpfObjects.Ableitung);

        KisteAnzeigen(_modelLap2018.FlaschenInDerKiste);

        FarbeUmschalten(_modelLap2018.F1, (int)WpfObjects.F1, Brushes.LawnGreen, Brushes.Red);
        FarbeUmschalten(_modelLap2018.P1, (int)WpfObjects.P1, Brushes.LawnGreen, Brushes.LightGray);
        FarbeUmschalten(_modelLap2018.P2, (int)WpfObjects.P2, Brushes.Red, Brushes.LightGray);
        FarbeUmschalten(_modelLap2018.Q1, (int)WpfObjects.Q1, Brushes.LawnGreen, Brushes.LightGray);
        FarbeUmschalten(_modelLap2018.Pegel > 0.01, (int)WpfObjects.Zuleitung, Brushes.Blue, Brushes.LightBlue); // Zuleitung

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

        if (_modelLap2018.AktuellesBier == ModelLap2018.Bier.Fohrenburger)
        {
            alleFohrenburgerKisten[anzahlFlaschen] = true;
        }
        else
        {
            alleMohrenKisten[anzahlFlaschen] = true;
        }

        for (var i = 0; i < 8; i++)
        {
            SichtbarkeitUmschalten(alleFohrenburgerKisten[i], (int)WpfObjects.Fohrenburger0 + i);
            SichtbarkeitUmschalten(alleMohrenKisten[i], (int)WpfObjects.Mohren0 + i);
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
    protected override void ViewModelAufrufSchalter(Enum schalterId) { }
    public override void PlotterButtonClick(object sender, RoutedEventArgs e) { }
    public override void BeschreibungZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabBeschreibungZeichnen(this, tabItem, "#eeeeee");
    public override void LaborPlatteZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabLaborPlatteZeichnen(this, tabItem, "#eeeeee");
    public override void SimulationZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabSimulationZeichnen(this, tabItem, "#eeeeee");
}