using System;
using System.Threading;
using System.Windows;
using Contracts;
using DtLap2010_3_Ofentuersteuerung.Model;
using LibDatenstruktur;
using System.Windows.Controls;
using System.Windows.Media;

namespace DtLap2010_3_Ofentuersteuerung.ViewModel;
public enum WpfObjects
{
    // ReSharper disable once UnusedMember.Global
    ReserveFuerBasisViewModel = 20, // enum WpfBase

    P1 = 21,

    Q1 = 23,
    Q2 = 24,

    B1 = 31,
    B2 = 32,
    B3 = 33,
    S1 = 34,
    S2 = 35,
    S3 = 36,

    Kurzschluss = 40,

    ZahnradWinkel = 50,
    ZahnstangePosition = 51,
    OfentuerePosition = 52
}
public class VmLap2010 : BasePlcDtAt.BaseViewModel.VmBase
{
    private readonly ModelLap2010? _modelLap2010;
    private readonly Datenstruktur _datenstruktur;

    public VmLap2010(BasePlcDtAt.BaseModel.BaseModel model, Datenstruktur datenstruktur, CancellationTokenSource cancellationTokenSource) : base(model, datenstruktur, cancellationTokenSource)
    {
        _modelLap2010 = model as ModelLap2010;
        _datenstruktur = datenstruktur;

        SichtbarEin[(int)WpfBase.TabBeschreibung] = Visibility.Collapsed;
        SichtbarEin[(int)WpfBase.TabLaborplatte] = Visibility.Collapsed;
        SichtbarEin[(int)WpfBase.TabSimulation] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.TabAutoTest] = Visibility.Visible;

        SichtbarEin[(int)WpfBase.BtnPlcAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.BtnPlottAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.BtnLinkHomepageAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.BtnAlwarmVerwaltungAnzeigen] = Visibility.Visible;

        Text[(int)WpfObjects.B2] = "Lichtschranke";

        Text[(int)WpfObjects.S1] = "Halt";
        Text[(int)WpfObjects.S2] = "Öffnen";
        Text[(int)WpfObjects.S3] = "Schliessen";
        Text[(int)WpfObjects.P1] = "Schliessen";
        Text[(int)WpfObjects.Q1] = "Q1 (LL)";
        Text[(int)WpfObjects.Q2] = "Q2 (RL)";

        Text[(int)WpfObjects.Kurzschluss] = "Kurzschluss";
    }
    protected override void ViewModelAufrufThread()
    {
        FensterTitel = PlcDaemon.PlcState.PlcBezeichnung + ": " + _datenstruktur.VersionsStringLokal;

        Margin[(int)WpfObjects.OfentuerePosition] = new Thickness(0, 0, 0, 0); //_modelLap2010!.PositionOfentuere;
        Margin[(int)WpfObjects.ZahnstangePosition] = new Thickness(0, 0, 0, 0); //_modelLap2010!.PositionZahnstange;
        Winkel[(int)WpfObjects.ZahnradWinkel] = _modelLap2010!.WinkelZahnrad;

        SichtbarkeitUmschalten(_modelLap2010.B1, 1);
        SichtbarkeitUmschalten(_modelLap2010.B2, 2);
        SichtbarkeitUmschalten(_modelLap2010.B3, 3);
        SichtbarkeitUmschalten(_modelLap2010.Q1 && _modelLap2010.Q2, 20);

        FarbeUmschalten(_modelLap2010.P1, (int)WpfObjects.P1, Brushes.LawnGreen, Brushes.White);
        FarbeUmschalten(_modelLap2010.Q1, (int)WpfObjects.Q1, Brushes.LawnGreen, Brushes.White);
        FarbeUmschalten(_modelLap2010.Q2, (int)WpfObjects.Q2, Brushes.LawnGreen, Brushes.White);
    }
    protected override void ViewModelAufrufTaster(Enum tasterId, bool gedrueckt)
    {
        switch (tasterId)
        {

            case WpfObjects.B3: _modelLap2010!.B3 = !gedrueckt; break;
            case WpfObjects.S1: _modelLap2010!.S1 = !gedrueckt; break;
            case WpfObjects.S2: _modelLap2010!.S2 = gedrueckt; break;
            case WpfObjects.S3: _modelLap2010!.S3 = gedrueckt; break;
            default: throw new ArgumentOutOfRangeException(nameof(tasterId));
        }
    }
    protected override void ViewModelAufrufSchalter(Enum schalterId) { }

    private double _aktuellerDruck;
    public double AktuellerDruck
    {
        get => _aktuellerDruck;
        set
        {
            _aktuellerDruck = value;
            OnPropertyChanged(nameof(AktuellerDruck));
        }
    }

    public override void PlotterButtonClick(object sender, RoutedEventArgs e) { }
    public override void BeschreibungZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabBeschreibungZeichnen(this, tabItem, "#eeeeee");
    public override void LaborPlatteZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabLaborPlatteZeichnen(this, tabItem, "#eeeeee");
    public override void SimulationZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabSimulationZeichnen(this, tabItem, "#eeeeee");
}