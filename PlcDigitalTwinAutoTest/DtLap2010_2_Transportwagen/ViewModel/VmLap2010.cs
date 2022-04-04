using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Contracts;
using DtLap2010_2_Transportwagen.Model;
using LibDatenstruktur;

namespace DtLap2010_2_Transportwagen.ViewModel;

public partial class VmLap2010 : BasePlcDtAt.BaseViewModel.VmBase
{
    private readonly ModelLap2010 _modelLap2010;
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
    }
    protected override void ViewModelAufrufThread()
    {
        FensterTitel = PlcDaemon.PlcState.PlcBezeichnung + ": " + _datenstruktur.VersionsStringLokal;

        BrushF1 = SetBrush(_modelLap2010!.F1, Brushes.LawnGreen, Brushes.Red);
        BrushP1 = SetBrush(_modelLap2010!.P1, Brushes.Red, Brushes.White);
        BrushQ1 = SetBrush(_modelLap2010!.Q1, Brushes.LawnGreen, Brushes.White);
        BrushQ2 = SetBrush(_modelLap2010!.Q2, Brushes.LawnGreen, Brushes.White);
        BrushS2 = SetBrush(_modelLap2010!.S2, Brushes.White, Brushes.Red);

        (VisibilityEinB1, VisibilityAusB1) = SetVisibility(_modelLap2010!.B1);
        (VisibilityEinB2, VisibilityAusB2) = SetVisibility(_modelLap2010!.B2);
        (VisibilityFuellen, _) = SetVisibility(_modelLap2010!.Fuellen);
        (VisibilityKurzschluss, _) = SetVisibility(_modelLap2010!.Q1 && _modelLap2010!.Q2);

        var posWagenkastenLinks = _modelLap2010!.Position * (BreiteZeichenbereich - BreiteWagenkasten);

        PositionWagenkasten = new Thickness(posWagenkastenLinks, 0, BreiteZeichenbereich - posWagenkastenLinks - BreiteWagenkasten, 0);
        PositionRadLinks = new Thickness(posWagenkastenLinks, 0, BreiteZeichenbereich - posWagenkastenLinks - BreíteRad, 0);
        PositionRadRechts = new Thickness(posWagenkastenLinks + BreiteWagenkasten - BreíteRad, 0, BreiteZeichenbereich - posWagenkastenLinks - BreiteWagenkasten, 0);
    }
    protected override void ViewModelAufrufTaster(Enum tasterId, bool gedrueckt) { }
    protected override void ViewModelAufrufSchalter(Enum schalterId) { }
    public override void PlotterButtonClick(object sender, RoutedEventArgs e) { }
    public override void BeschreibungZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabBeschreibungZeichnen(this, tabItem, "#eeeeee");
    public override void LaborPlatteZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabLaborPlatteZeichnen(this, tabItem, "#eeeeee");
    public override void SimulationZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabSimulationZeichnen(this, tabItem, "#eeeeee");
}