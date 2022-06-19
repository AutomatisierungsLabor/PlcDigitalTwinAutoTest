using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DtParkhaus.Model;
using LibDatenstruktur;
using ScottPlot;

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

    }
    public override void PlotterButtonClick(object sender, RoutedEventArgs e) { }
    public override void BeschreibungZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabBeschreibungZeichnen(this, tabItem, "#eeeeee");
    public override void LaborPlatteZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabLaborPlatteZeichnen(this, tabItem, "#eeeeee");
    public override void SimulationZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabSimulationZeichnen(this, tabItem, "#eeeeee");
}