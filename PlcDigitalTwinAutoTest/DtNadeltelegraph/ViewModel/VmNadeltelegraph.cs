using System.Threading;
using System.Windows;
using System.Windows.Controls;
using DtNadeltelegraph.Model;
using LibDatenstruktur;

namespace DtNadeltelegraph.ViewModel;

public partial class VmNadeltelegraph : BasePlcDtAt.BaseViewModel.VmBase
{
    private readonly ModelNadeltelegraph _modelNadeltelegraph;
    private readonly Datenstruktur _datenstruktur;

    public VmNadeltelegraph(BasePlcDtAt.BaseModel.BaseModel model, Datenstruktur datenstruktur, CancellationTokenSource cancellationTokenSource) : base(model, datenstruktur, cancellationTokenSource)
    {
        _modelNadeltelegraph = model as ModelNadeltelegraph;
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
        if (_modelNadeltelegraph == null) return;
        StringFensterTitel = PlcDaemon.PlcState.PlcBezeichnung + ": " + _datenstruktur.VersionsStringLokal;

        AsciiCode = $"ASCII Code: {_modelNadeltelegraph.Zeichen} (16#{_modelNadeltelegraph.Zeichen:X2})";

        _modelNadeltelegraph.AlleZeiger[0].SetPosition(_modelNadeltelegraph.P1R, _modelNadeltelegraph.P1L);
        _modelNadeltelegraph.AlleZeiger[1].SetPosition(_modelNadeltelegraph.P2R, _modelNadeltelegraph.P2L);
        _modelNadeltelegraph.AlleZeiger[2].SetPosition(_modelNadeltelegraph.P3R, _modelNadeltelegraph.P3L);
        _modelNadeltelegraph.AlleZeiger[3].SetPosition(_modelNadeltelegraph.P4R, _modelNadeltelegraph.P4L);
        _modelNadeltelegraph.AlleZeiger[4].SetPosition(_modelNadeltelegraph.P5R, _modelNadeltelegraph.P5L);

        WinkelZeiger1 = _modelNadeltelegraph.AlleZeiger[0].GetWinkel();
        WinkelZeiger2 = _modelNadeltelegraph.AlleZeiger[1].GetWinkel();
        WinkelZeiger3 = _modelNadeltelegraph.AlleZeiger[2].GetWinkel();
        WinkelZeiger4 = _modelNadeltelegraph.AlleZeiger[3].GetWinkel();
        WinkelZeiger5 = _modelNadeltelegraph.AlleZeiger[4].GetWinkel();
        
        VisibilityLinieLinksOben1 = _modelNadeltelegraph.AlleZeiger[0].GetVisibilityUpLeft();
        VisibilityLinieRechtsOben1 = _modelNadeltelegraph.AlleZeiger[0].GetVisibilityUpRight();
        VisibilityLinieLinksUnten1 = _modelNadeltelegraph.AlleZeiger[0].GetVisibilityDownLeft();
        VisibilityLinieRechtsUnten1 = _modelNadeltelegraph.AlleZeiger[0].GetVisibilityDownRight();

        VisibilityLinieLinksOben2 = _modelNadeltelegraph.AlleZeiger[1].GetVisibilityUpLeft();
        VisibilityLinieRechtsOben2 = _modelNadeltelegraph.AlleZeiger[1].GetVisibilityUpRight();
        VisibilityLinieLinksUnten2 = _modelNadeltelegraph.AlleZeiger[1].GetVisibilityDownLeft();
        VisibilityLinieRechtsUnten2 = _modelNadeltelegraph.AlleZeiger[1].GetVisibilityDownRight();

        VisibilityLinieLinksOben3 = _modelNadeltelegraph.AlleZeiger[2].GetVisibilityUpLeft();
        VisibilityLinieRechtsOben3 = _modelNadeltelegraph.AlleZeiger[2].GetVisibilityUpRight();
        VisibilityLinieLinksUnten3 = _modelNadeltelegraph.AlleZeiger[2].GetVisibilityDownLeft();
        VisibilityLinieRechtsUnten3 = _modelNadeltelegraph.AlleZeiger[2].GetVisibilityDownRight();

        VisibilityLinieLinksOben4 = _modelNadeltelegraph.AlleZeiger[3].GetVisibilityUpLeft();
        VisibilityLinieRechtsOben4 = _modelNadeltelegraph.AlleZeiger[3].GetVisibilityUpRight();
        VisibilityLinieLinksUnten4 = _modelNadeltelegraph.AlleZeiger[3].GetVisibilityDownLeft();
        VisibilityLinieRechtsUnten4 = _modelNadeltelegraph.AlleZeiger[3].GetVisibilityDownRight();
    }
    public override void PlotterButtonClick(object sender, RoutedEventArgs e) { }
    public override void BeschreibungZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabBeschreibungZeichnen(this, tabItem, "#eeeeee");
    public override void LaborPlatteZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabLaborPlatteZeichnen(this, tabItem, "#eeeeee");
    public override void SimulationZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabSimulationZeichnen(this, tabItem, "#eeeeee");
}