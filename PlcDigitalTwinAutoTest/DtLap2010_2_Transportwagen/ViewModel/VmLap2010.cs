using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Contracts;
using DtLap2010_2_Transportwagen.Model;
using LibDatenstruktur;

namespace DtLap2010_2_Transportwagen.ViewModel;
public enum WpfObjects
{
    // ReSharper disable once UnusedMember.Global
    ReserveFuerBasisViewModel = 20, // enum WpfBase

    P1 = 21,
    Q1 = 22,
    Q2 = 23,

    B1 = 31,
    B2 = 32,
    F1 = 33,
    S1 = 34,
    S2 = 35,
    S3 = 36,

    Fuellen = 40,
    Kurzschluss = 41,

    PositionWagenkasten = 50,
    PositionRadLinks = 51,
    PositionRadRechts = 52
}
public partial class VmLap2010 : BasePlcDtAt.BaseViewModel.VmBase
{
    private readonly ModelLap2010? _modelLap2010;
    private readonly Datenstruktur _datenstruktur;
    
    private const double BreiteZeichenbereich = 20 * 30;
    private const double BreiteWagenkasten = 180;
    private const double BreíteRad = 30;

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

        Text[(int)WpfObjects.S1] = "Start";
        Text[(int)WpfObjects.S2] = "Not Halt";
        Text[(int)WpfObjects.S3] = "Reset";
        Text[(int)WpfObjects.P1] = "Störung";
    }
    protected override void ViewModelAufrufThread()
    {
        FensterTitel = PlcDaemon.PlcState.PlcBezeichnung + ": " + _datenstruktur.VersionsStringLokal;

        RipFarbeUmschalten(_modelLap2010!.F1, (int)WpfObjects.F1, Brushes.LawnGreen, Brushes.Red);
        RipFarbeUmschalten(_modelLap2010!.P1, (int)WpfObjects.P1, Brushes.Red, Brushes.White);
        RipFarbeUmschalten(_modelLap2010!.Q1, (int)WpfObjects.Q1, Brushes.LawnGreen, Brushes.White);
        RipFarbeUmschalten(_modelLap2010!.Q2, (int)WpfObjects.Q2, Brushes.LawnGreen, Brushes.White);
        RipFarbeUmschalten(_modelLap2010!.S2, (int)WpfObjects.S2, Brushes.White, Brushes.Red);

        RipSichtbarkeitUmschalten(_modelLap2010!.B1, (int)WpfObjects.B1);
        RipSichtbarkeitUmschalten(_modelLap2010!.B2, (int)WpfObjects.B2);
        RipSichtbarkeitUmschalten(_modelLap2010!.Fuellen, (int)WpfObjects.Fuellen);
        RipSichtbarkeitUmschalten(_modelLap2010!.Q1 && _modelLap2010!.Q2, (int)WpfObjects.Kurzschluss);

        var posWagenkastenLinks = _modelLap2010!.Position * (BreiteZeichenbereich - BreiteWagenkasten);

        Margin[(int)WpfObjects.PositionWagenkasten] = new Thickness(posWagenkastenLinks, 0, BreiteZeichenbereich - posWagenkastenLinks - BreiteWagenkasten, 0);
        Margin[(int)WpfObjects.PositionRadLinks] = new Thickness(posWagenkastenLinks, 0, BreiteZeichenbereich - posWagenkastenLinks - BreíteRad, 0);
        Margin[(int)WpfObjects.PositionRadRechts] = new Thickness(posWagenkastenLinks + BreiteWagenkasten - BreíteRad, 0, BreiteZeichenbereich - posWagenkastenLinks - BreiteWagenkasten, 0);
    }
    protected override void ViewModelAufrufTaster(Enum tasterId, bool gedrueckt)
    {
        switch (tasterId)
        {
            case WpfObjects.S1: _modelLap2010!.S1 = gedrueckt; break;
            case WpfObjects.S3: _modelLap2010!.S3 = gedrueckt; break;
            default: throw new ArgumentOutOfRangeException(nameof(tasterId));
        }
    }
    protected override void ViewModelAufrufSchalter(Enum schalterId)
    {
        switch (schalterId)
        {
            case WpfObjects.F1: _modelLap2010!.F1 = !_modelLap2010.F1; break;
            case WpfObjects.S2: _modelLap2010!.B2 = !_modelLap2010.S2; break;
            default: throw new ArgumentOutOfRangeException(nameof(schalterId));
        }
    }

    public override void PlotterButtonClick(object sender, RoutedEventArgs e) { }
    public override void BeschreibungZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabBeschreibungZeichnen(this, tabItem, "#eeeeee");
    public override void LaborPlatteZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabLaborPlatteZeichnen(this, tabItem, "#eeeeee");
    public override void SimulationZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabSimulationZeichnen(this, tabItem, "#eeeeee");
}