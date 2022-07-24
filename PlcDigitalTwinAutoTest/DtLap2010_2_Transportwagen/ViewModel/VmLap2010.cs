using System.Diagnostics;
using DtLap2010_2_Transportwagen.Model;
using LibDatenstruktur;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Contracts;

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

        VisibilityBtnPlcAnzeigen = Visibility.Visible;
        VisibilityBtnPlottAnzeigen = Visibility.Visible;
        VisibilityBtnLinkHomepageAnzeigen = Visibility.Visible;
        VisibilityBtnAlarmVerwaltungAnzeigen = Visibility.Visible;
    }
    protected override void ViewModelAufrufThread()
    {
        StringFensterTitel = PlcDaemon.PlcState.PlcBezeichnung + ": " + _datenstruktur.VersionsStringLokal;

        BrushF1 = BaseFunctions.SetBrush(_modelLap2010!.F1, Brushes.LawnGreen, Brushes.Red);
        BrushP1 = BaseFunctions.SetBrush(_modelLap2010!.P1, Brushes.Red, Brushes.LightGray);
        BrushQ1 = BaseFunctions.SetBrush(_modelLap2010!.Q1, Brushes.LawnGreen, Brushes.LightGray);
        BrushQ2 = BaseFunctions.SetBrush(_modelLap2010!.Q2, Brushes.LawnGreen, Brushes.LightGray);
        BrushS2 = BaseFunctions.SetBrush(_modelLap2010!.S2, Brushes.LawnGreen, Brushes.Red);

        (VisibilityEinB1, VisibilityAusB1) = BaseFunctions.SetVisibility(_modelLap2010!.B1);
        (VisibilityEinB2, VisibilityAusB2) = BaseFunctions.SetVisibility(_modelLap2010!.B2);
        (VisibilityFuellen, _) = BaseFunctions.SetVisibility(_modelLap2010!.Fuellen);
        (VisibilityKurzschluss, _) = BaseFunctions.SetVisibility(_modelLap2010!.Q1 && _modelLap2010!.Q2);

        var posWagenkastenLinks = _modelLap2010!.PositionWagen * (BreiteZeichenbereich - BreiteWagenkasten);

        ThicknessPositionWagenkasten = new Thickness(posWagenkastenLinks, 0, BreiteZeichenbereich - posWagenkastenLinks - BreiteWagenkasten, 0);
        ThicknessPositionRadLinks = new Thickness(posWagenkastenLinks, 0, BreiteZeichenbereich - posWagenkastenLinks - BreíteRad, 0);
        ThicknessPositionRadRechts = new Thickness(posWagenkastenLinks + BreiteWagenkasten - BreíteRad, 0, BreiteZeichenbereich - posWagenkastenLinks - BreiteWagenkasten, 0);
    }
    public override void PlotterButtonClick(object sender, RoutedEventArgs e) { }
    public override void BeschreibungZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabBeschreibungZeichnen(this, tabItem, "#eeeeee");
    public override void LaborPlatteZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabLaborPlatteZeichnen(this, tabItem, "#eeeeee");
    public override void SimulationZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabSimulationZeichnen(this, tabItem, "#eeeeee");
}