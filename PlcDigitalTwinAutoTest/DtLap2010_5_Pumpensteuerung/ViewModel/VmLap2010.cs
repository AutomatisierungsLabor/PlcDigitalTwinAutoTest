using DtLap2010_5_Pumpensteuerung.Model;
using LibDatenstruktur;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DtLap2010_5_Pumpensteuerung.ViewModel;

public partial class VmLap2010 : BasePlcDtAt.BaseViewModel.VmBase
{
    private readonly ModelLap2010 _modelLap2010;
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

        VisibilityBtnPlcAnzeigen = Visibility.Visible;
        VisibilityBtnPlottAnzeigen = Visibility.Visible;
        VisibilityBtnLinkHomepageAnzeigen = Visibility.Visible;
        VisibilityBtnAlarmVerwaltungAnzeigen = Visibility.Visible;
    }

    protected override void ViewModelAufrufThread()
    {
        StringFensterTitel = PlcDaemon.PlcState.PlcBezeichnung + ": " + _datenstruktur.VersionsStringLokal;

        BrushF1 = SetBrush(_modelLap2010.F1, Brushes.LawnGreen, Brushes.Red);
        BrushP1 = SetBrush(_modelLap2010.P1, Brushes.LawnGreen, Brushes.LightGray);
        BrushP2 = SetBrush(_modelLap2010.P2, Brushes.Red, Brushes.LightGray);

        BrushZuleitungWaagrecht = SetBrush(_modelLap2010.Q1, Brushes.Blue, Brushes.LightBlue);
        BrushZuleitungSenkrecht = SetBrush(_modelLap2010.Q1, Brushes.Blue, Brushes.LightBlue);
        BrushAbleitungOben = SetBrush(_modelLap2010.Pegel > 0.01, Brushes.Blue, Brushes.LightBlue);
        BrushAbleitungUnten = SetBrush(_modelLap2010.Pegel > 0.01 && _modelLap2010!.Y1, Brushes.Blue, Brushes.LightBlue);

        (VisibilityEinB1, VisibilityAusB1) = SetVisibility(_modelLap2010.B1);
        (VisibilityEinB2, VisibilityAusB2) = SetVisibility(_modelLap2010.B2);
        (VisibilityEinQ1, VisibilityAusQ1) = SetVisibility(_modelLap2010.Q1);
        (VisibilityEinY1, VisibilityAusY1) = SetVisibility(_modelLap2010.Y1);

        MarginPegel = new Thickness(0, HoeheFuellBalken * (1 - _modelLap2010.Pegel), 0, 0);

        WinkelSchalter = SchalterWinkel(_modelLap2010.S1, _modelLap2010.S2);

    }
    private static double SchalterWinkel(bool s1, bool s2)
    {
        if (s1) return -45;
        return s2 ? 45 : 0;
    }
    public override void PlotterButtonClick(object sender, RoutedEventArgs e) { }
    public override void BeschreibungZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabBeschreibungZeichnen(this, tabItem, "#eeeeee");
    public override void LaborPlatteZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabLaborPlatteZeichnen(this, tabItem, "#eeeeee");
    public override void SimulationZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabSimulationZeichnen(this, tabItem, "#eeeeee");
}