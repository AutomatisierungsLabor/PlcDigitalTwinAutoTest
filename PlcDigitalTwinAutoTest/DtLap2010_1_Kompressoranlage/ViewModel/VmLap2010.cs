using DtLap2010_1_Kompressoranlage.Model;
using LibDatenstruktur;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DtLap2010_1_Kompressoranlage.ViewModel;

public partial class VmLap2010 : BasePlcDtAt.BaseViewModel.VmBase
{
    private readonly ModelLap2010 _modelLap2010;
    private readonly Datenstruktur _datenstruktur;

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

        BrushB2 = SetBrush(_modelLap2010!.B2, Brushes.LawnGreen, Brushes.Red);
        BrushF1 = SetBrush(_modelLap2010!.F1, Brushes.LawnGreen, Brushes.Red);
        BrushP1 = SetBrush(_modelLap2010!.P1, Brushes.Red, Brushes.White);
        BrushP2 = SetBrush(_modelLap2010!.P2, Brushes.LawnGreen, Brushes.White);
        BrushQ1 = SetBrush(_modelLap2010!.Q1, Brushes.LawnGreen, Brushes.White);
        BrushQ2 = SetBrush(_modelLap2010!.Q2, Brushes.LawnGreen, Brushes.White);
        BrushQ3 = SetBrush(_modelLap2010!.Q3, Brushes.LawnGreen, Brushes.White);

        (VisibilityEinB1, VisibilityAusB1) = SetVisibility(_modelLap2010.B1);
        (VisibilityKurzschluss, _) = SetVisibility(_modelLap2010.Q2 && _modelLap2010.Q3);

        AktuellerDruck = _modelLap2010.Druck;
    }
    public override void PlotterButtonClick(object sender, RoutedEventArgs e) { }
    public override void BeschreibungZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabBeschreibungZeichnen(this, tabItem, "#eeeeee");
    public override void LaborPlatteZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabLaborPlatteZeichnen(this, tabItem, "#eeeeee");
    public override void SimulationZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabSimulationZeichnen(this, tabItem, "#eeeeee");
}