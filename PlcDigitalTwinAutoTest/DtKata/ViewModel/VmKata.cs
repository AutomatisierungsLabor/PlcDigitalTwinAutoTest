using DtKata.Model;
using LibDatenstruktur;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DtKata.ViewModel;

public partial class VmKata : BasePlcDtAt.BaseViewModel.VmBase
{
    private readonly ModelKata _modelKata;
    private readonly Datenstruktur _datenstruktur;

    public VmKata(BasePlcDtAt.BaseModel.BaseModel model, Datenstruktur datenstruktur, CancellationTokenSource cancellationTokenSource) : base(model, datenstruktur, cancellationTokenSource)
    {
        _modelKata = model as ModelKata;
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
        if (_modelKata == null) return;
        StringFensterTitel = PlcDaemon.PlcState.PlcBezeichnung + ": " + _datenstruktur.VersionsStringLokal;

        (VisibilityEinS1, VisibilityAusS1) = SetVisibility(_modelKata.S1);
        (VisibilityEinS2, VisibilityAusS2) = SetVisibility(_modelKata.S2);
        (VisibilityEinS3, VisibilityAusS3) = SetVisibility(_modelKata.S3);
        (VisibilityEinS4, VisibilityAusS4) = SetVisibility(_modelKata.S4);
        (VisibilityEinS5, VisibilityAusS5) = SetVisibility(_modelKata.S5);
        (VisibilityEinS6, VisibilityAusS6) = SetVisibility(_modelKata.S6);
        (VisibilityEinS7, VisibilityAusS7) = SetVisibility(_modelKata.S7);
        (VisibilityEinS8, VisibilityAusS8) = SetVisibility(_modelKata.S8);
        
        BrushP1 = SetBrush(_modelKata.P1, Brushes.LawnGreen, Brushes.White);
        BrushP2 = SetBrush(_modelKata.P2, Brushes.LawnGreen, Brushes.White);
        BrushP3 = SetBrush(_modelKata.P3, Brushes.LawnGreen, Brushes.White);
        BrushP4 = SetBrush(_modelKata.P4, Brushes.LawnGreen, Brushes.White);
        BrushP5 = SetBrush(_modelKata.P5, Brushes.Yellow, Brushes.White);
        BrushP6 = SetBrush(_modelKata.P6, Brushes.Yellow, Brushes.White);
        BrushP7 = SetBrush(_modelKata.P7, Brushes.Red, Brushes.White);
        BrushP8 = SetBrush(_modelKata.P8, Brushes.Red, Brushes.White);
    }
    public override void PlotterButtonClick(object sender, RoutedEventArgs e) { }
    public override void BeschreibungZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabBeschreibungZeichnen(this, tabItem, "#eeeeee");
    public override void LaborPlatteZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabLaborPlatteZeichnen(this, tabItem, "#eeeeee");
    public override void SimulationZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabSimulationZeichnen(this, tabItem, "#eeeeee");
}