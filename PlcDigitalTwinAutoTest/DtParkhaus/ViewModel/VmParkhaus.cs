using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Contracts;
using DtParkhaus.Model;
using LibDatenstruktur;

namespace DtParkhaus.ViewModel;

public partial class VmParkhaus : BasePlcDtAt.BaseViewModel.VmBase
{
    private readonly ModelParkhaus _modelParkhaus;
    private readonly Datenstruktur _datenstruktur;

    public VmParkhaus(BasePlcDtAt.BaseModel.BaseModel model, Datenstruktur datenstruktur, CancellationTokenSource cancellationTokenSource) : base(model, datenstruktur, cancellationTokenSource)
    {
        _datenstruktur = datenstruktur;

        VisibilityTabBeschreibung = Visibility.Collapsed;
        VisibilityTabLaborplatte = Visibility.Collapsed;
        VisibilityTabSimulation = Visibility.Visible;
        VisibilityTabSoftwareTest = Visibility.Visible;

        VisibilityBtnPlcAnzeigen = Visibility.Visible;
        VisibilityBtnPlottAnzeigen = Visibility.Visible;
        VisibilityBtnLinkHomepageAnzeigen = Visibility.Visible;
        VisibilityBtnAlarmVerwaltungAnzeigen = Visibility.Visible;

        _modelParkhaus = model as ModelParkhaus;
    }

    protected override void ViewModelAufrufThread()
    {
        if (_modelParkhaus == null) return;

        StringFensterTitel = PlcDaemon.PlcState.PlcBezeichnung + ": " + _datenstruktur.VersionsStringLokal;

        StringFreieParkplaetze = _modelParkhaus.FreieParkplaetze.ToString();
        StringFreieParkplaetzeSoll = $"( {_modelParkhaus.FreieParkplaetzeSoll} )";

        BrushB00 = Brushes.LawnGreen;

        (BrushB00, BrushB01, BrushB02, BrushB03, BrushB04, BrushB05, BrushB06, BrushB07) = GetAlleFarben(_modelParkhaus.BesetzteParkPlaetze[0]);
        (BrushB10, BrushB11, BrushB12, BrushB13, BrushB14, BrushB15, BrushB16, BrushB17) = GetAlleFarben(_modelParkhaus.BesetzteParkPlaetze[1]);
        (BrushB20, BrushB21, BrushB22, BrushB23, BrushB24, BrushB25, BrushB26, BrushB27) = GetAlleFarben(_modelParkhaus.BesetzteParkPlaetze[2]);
        (BrushB30, BrushB31, BrushB32, BrushB33, BrushB34, BrushB35, BrushB36, BrushB37) = GetAlleFarben(_modelParkhaus.BesetzteParkPlaetze[3]);

        (VisibilityPkw00, VisibilityPkw01, VisibilityPkw02, VisibilityPkw03, VisibilityPkw04, VisibilityPkw05, VisibilityPkw06, VisibilityPkw07) = GetAlleSichtbarkeiten(_modelParkhaus.BesetzteParkPlaetze[0]);
        (VisibilityPkw10, VisibilityPkw11, VisibilityPkw12, VisibilityPkw13, VisibilityPkw14, VisibilityPkw15, VisibilityPkw16, VisibilityPkw17) = GetAlleSichtbarkeiten(_modelParkhaus.BesetzteParkPlaetze[1]);
        (VisibilityPkw20, VisibilityPkw21, VisibilityPkw22, VisibilityPkw23, VisibilityPkw24, VisibilityPkw25, VisibilityPkw26, VisibilityPkw27) = GetAlleSichtbarkeiten(_modelParkhaus.BesetzteParkPlaetze[2]);
        (VisibilityPkw30, VisibilityPkw31, VisibilityPkw32, VisibilityPkw33, VisibilityPkw34, VisibilityPkw35, VisibilityPkw36, VisibilityPkw37) = GetAlleSichtbarkeiten(_modelParkhaus.BesetzteParkPlaetze[3]);
    }
    private static (Brush BrushB00, Brush BrushB01, Brush BrushB02, Brush BrushB03, Brush BrushB04, Brush BrushB05, Brush BrushB06, Brush BrushB07) GetAlleFarben(byte b)
    {
        var (b0, b1, b2, b3, b4, b5, b6, b7) = LibPlcTools.Bytes.AlleBitLesen(b);

        return (
                BaseFunctions.SetBrush(b0, Brushes.Red, Brushes.LawnGreen),
                BaseFunctions.SetBrush(b1, Brushes.Red, Brushes.LawnGreen),
                BaseFunctions.SetBrush(b2, Brushes.Red, Brushes.LawnGreen),
                BaseFunctions.SetBrush(b3, Brushes.Red, Brushes.LawnGreen),
                BaseFunctions.SetBrush(b4, Brushes.Red, Brushes.LawnGreen),
                BaseFunctions.SetBrush(b5, Brushes.Red, Brushes.LawnGreen),
                BaseFunctions.SetBrush(b6, Brushes.Red, Brushes.LawnGreen),
                BaseFunctions.SetBrush(b7, Brushes.Red, Brushes.LawnGreen)
        );
    }
    private static (Visibility VisibilityPkw00, Visibility VisibilityPkw01, Visibility VisibilityPkw02, Visibility VisibilityPkw03, Visibility VisibilityPkw04, Visibility VisibilityPkw05, Visibility VisibilityPkw06, Visibility VisibilityPkw07) GetAlleSichtbarkeiten(byte b)
    {
        var (b0, b1, b2, b3, b4, b5, b6, b7) = LibPlcTools.Bytes.AlleBitLesen(b);

        return (
                BaseFunctions.SetVisibilityEin(b0),
                BaseFunctions.SetVisibilityEin(b1),
                BaseFunctions.SetVisibilityEin(b2),
                BaseFunctions.SetVisibilityEin(b3),
                BaseFunctions.SetVisibilityEin(b4),
                BaseFunctions.SetVisibilityEin(b5),
                BaseFunctions.SetVisibilityEin(b6),
                BaseFunctions.SetVisibilityEin(b7)
        );
    }

    public override void PlotterButtonClick(object sender, RoutedEventArgs e) { }
    public override void BeschreibungZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabBeschreibungZeichnen(this, tabItem, "#eeeeee");
    public override void LaborPlatteZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabLaborPlatteZeichnen(this, tabItem, "#eeeeee");
    public override void SimulationZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabSimulationZeichnen(this, tabItem, "#eeeeee");
}