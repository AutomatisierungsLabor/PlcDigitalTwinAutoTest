using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Contracts;
using DtAmpelVerbania.Model;
using LibDatenstruktur;

namespace DtAmpelVerbania.ViewModel;

public partial class VmAmpelVerbania : BasePlcDtAt.BaseViewModel.VmBase
{
    private readonly ModelAmpelVarbania _modelAmpelVarbania;
    private readonly Datenstruktur _datenstruktur;

    public VmAmpelVerbania(BasePlcDtAt.BaseModel.BaseModel model, Datenstruktur datenstruktur, CancellationTokenSource cancellationTokenSource) : base(model, datenstruktur, cancellationTokenSource)
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

        _modelAmpelVarbania = model as ModelAmpelVarbania;
    }
    protected override void ViewModelAufrufThread(double dT)
    {
        if (_modelAmpelVarbania == null) return;

        StringFensterTitel = PlcDaemon.PlcState.PlcBezeichnung + ": " + _datenstruktur.VersionsStringLokal;

        BrushP11 = BaseFunctions.SetBrush(_modelAmpelVarbania.P11, Brushes.Red, Brushes.LightGray);
        BrushP12 = BaseFunctions.SetBrush(_modelAmpelVarbania.P12, Brushes.Yellow, Brushes.LightGray);
        BrushP13 = BaseFunctions.SetBrush(_modelAmpelVarbania.P13, Brushes.LawnGreen, Brushes.LightGray);

        BrushP21 = BaseFunctions.SetBrush(_modelAmpelVarbania.P21, Brushes.Red, Brushes.LightGray);
        BrushP22 = BaseFunctions.SetBrush(_modelAmpelVarbania.P22, Brushes.Yellow, Brushes.LightGray);
        BrushP23 = BaseFunctions.SetBrush(_modelAmpelVarbania.P23, Brushes.LawnGreen, Brushes.LightGray);

        BrushP31 = BaseFunctions.SetBrush(_modelAmpelVarbania.P31, Brushes.Red, Brushes.LightGray);
        BrushP32 = BaseFunctions.SetBrush(_modelAmpelVarbania.P32, Brushes.Yellow, Brushes.LightGray);
        BrushP33 = BaseFunctions.SetBrush(_modelAmpelVarbania.P33, Brushes.LawnGreen, Brushes.LightGray);

        StringAnzeige = _modelAmpelVarbania.Anzeige == 0 ? "--" : _modelAmpelVarbania.Anzeige.ToString();

        ShortSiebenSegmentAnzeige = _modelAmpelVarbania.AlleSegmente;

        VisibilityAnzeige = _modelAmpelVarbania.S2 ? Visibility.Visible : Visibility.Collapsed;
        VisibilitySiebenSegmentAnzeige = _modelAmpelVarbania.S2 ? Visibility.Collapsed : Visibility.Visible;
    }
    public override void PlotterButtonClick(object sender, RoutedEventArgs e) { }
    public override void BeschreibungZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabBeschreibungZeichnen(this, tabItem, "#eeeeee");
    public override void LaborPlatteZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabLaborPlatteZeichnen(this, tabItem, "#eeeeee");
    public override void SimulationZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabSimulationZeichnen(this, tabItem, "#eeeeee");
}