using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Contracts;
using DtLap2010_4_Abfuellanlage.Model;
using LibDatenstruktur;

namespace DtLap2010_4_Abfuellanlage.ViewModel;
public enum WpfObjects
{
    // ReSharper disable once UnusedMember.Global
    ReserveFuerBasisViewModel = 20, // enum WpfBase

    K1 = 21,
    K2 = 22,
    P1 = 23,
    Q1 = 24,

    B1 = 31,
    B2 = 32,
    F1 = 33,
    S1 = 34,
    S2 = 35,

    Fuellstand = 40,
    Reset = 41,
    Nachfuellen = 42,

    Zuleitung=50,
    Ableitung=51
}
public partial class VmLap2010 : BasePlcDtAt.BaseViewModel.VmBase
{
    private readonly ModelLap2010? _modelLap2010;
    private readonly Datenstruktur _datenstruktur;

    private const double HoeheFuellBalken = 9 * 35;

    public VmLap2010(BasePlcDtAt.BaseModel.BaseModel model, Datenstruktur datenstruktur, CancellationTokenSource cancellationTokenSource) : base(model, datenstruktur, cancellationTokenSource)
    {
        _modelLap2010 = model as ModelLap2010;
        _datenstruktur = datenstruktur;

        VisibilityTabBeschreibung = Visibility.Collapsed;
        VisibilityTabLaborplatte = Visibility.Collapsed;
        VisibilityTabSimulation = Visibility.Visible;
        VisibilityTabSoftwareTest = Visibility.Visible;

        SichtbarEin[(int)WpfBase.BtnPlcAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.BtnPlottAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.BtnLinkHomepageAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.BtnAlwarmVerwaltungAnzeigen] = Visibility.Visible;

        Text[(int)WpfObjects.B1] = "B1";
        Text[(int)WpfObjects.B2] = "B2";
        Text[(int)WpfObjects.F1] = "F1";

        Text[(int)WpfObjects.S1] = "Aus";
        Text[(int)WpfObjects.S2] = "Ein";
        Text[(int)WpfObjects.P1] = "Störung";
        Text[(int)WpfObjects.Q1] = "Betriebsbereit";
    }
    protected override void ViewModelAufrufThread()
    {
        FensterTitel = PlcDaemon.PlcState.PlcBezeichnung + ": " + _datenstruktur.VersionsStringLokal;

        RipFarbeUmschalten(_modelLap2010!.P1, 5, Brushes.Red, Brushes.White);
        RipFarbeUmschalten(_modelLap2010!.Q1, 6, Brushes.LawnGreen, Brushes.LightGray);
        RipFarbeUmschalten(_modelLap2010!.Pegel > 0.01, 21, Brushes.Coral, Brushes.LightCoral);

        RipSichtbarkeitUmschalten(_modelLap2010!.B1, 1);
        RipSichtbarkeitUmschalten(_modelLap2010!.B2, 2);
        RipSichtbarkeitUmschalten(_modelLap2010!.K1, 3);
        RipSichtbarkeitUmschalten(_modelLap2010!.K2, 4);
        RipSichtbarkeitUmschalten(_modelLap2010!.K2 && _modelLap2010!.Pegel > 0.01, 20);

        Margin[(int)WpfObjects.Fuellstand] = new Thickness(0, HoeheFuellBalken * (1 - _modelLap2010!.Pegel), 0, 0);
    }
    protected override void ViewModelAufrufTaster(Enum tasterId, bool gedrueckt)
    {
        switch (tasterId)
        {
            case WpfObjects.S1: _modelLap2010!.S1 = !gedrueckt; break;
            case WpfObjects.S2: _modelLap2010!.S2 = gedrueckt; break;
            case WpfObjects.Reset: _modelLap2010!.AllesReset(); break;
            case WpfObjects.Nachfuellen: _modelLap2010!.Nachfuellen(); break;
            default: throw new ArgumentOutOfRangeException(nameof(tasterId));
        }
    }
    protected override void ViewModelAufrufSchalter(Enum schalterId)
    {
        switch (schalterId)
        {
            case WpfObjects.B2: _modelLap2010!.B2 = !_modelLap2010.B2; break;

            default: throw new ArgumentOutOfRangeException(nameof(schalterId));
        }
    }
 
    public override void PlotterButtonClick(object sender, RoutedEventArgs e) { }
    public override void BeschreibungZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabBeschreibungZeichnen(this, tabItem, "#eeeeee");
    public override void LaborPlatteZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabLaborPlatteZeichnen(this, tabItem, "#eeeeee");
    public override void SimulationZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabSimulationZeichnen(this, tabItem, "#eeeeee");
}