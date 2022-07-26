using DtNadeltelegraph.Model;
using LibDatenstruktur;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

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
    protected override void ViewModelAufrufThread(double dT)
    {
        if (_modelNadeltelegraph == null) return;
        StringFensterTitel = PlcDaemon.PlcState.PlcBezeichnung + ": " + _datenstruktur.VersionsStringLokal;

        StringAsciiCode = $"ASCII Code: {_modelNadeltelegraph.AsciiCode} (16#{_modelNadeltelegraph.AsciiCode:X2})";

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

        var ersterWinkel = 0;
        var zweiterWinkel = 0;

        foreach (var zeiger in _modelNadeltelegraph.AlleZeiger)
        {
            if (zeiger.GetWinkel() == 0) continue;

            if (ersterWinkel == 0) ersterWinkel = zeiger.GetWinkel();
            else if (zweiterWinkel == 0) zweiterWinkel = zeiger.GetWinkel();
        }

        var zeigerNachOben = ersterWinkel > 0 && zweiterWinkel < 0;
        var zeigerNachUnten = ersterWinkel < 0 && zweiterWinkel > 0;

        VisibilityLinieRechtsOben1 = _modelNadeltelegraph.AlleZeiger[0].GetVisibilityUpRight(zeigerNachOben);
        VisibilityLinieRechtsOben2 = _modelNadeltelegraph.AlleZeiger[1].GetVisibilityUpRight(zeigerNachOben);
        VisibilityLinieRechtsOben3 = _modelNadeltelegraph.AlleZeiger[2].GetVisibilityUpRight(zeigerNachOben);
        VisibilityLinieRechtsOben4 = _modelNadeltelegraph.AlleZeiger[3].GetVisibilityUpRight(zeigerNachOben);
        VisibilityLinieLinksOben1 = _modelNadeltelegraph.AlleZeiger[1].GetVisibilityUpLeft(zeigerNachOben);
        VisibilityLinieLinksOben2 = _modelNadeltelegraph.AlleZeiger[2].GetVisibilityUpLeft(zeigerNachOben);
        VisibilityLinieLinksOben3 = _modelNadeltelegraph.AlleZeiger[3].GetVisibilityUpLeft(zeigerNachOben);
        VisibilityLinieLinksOben4 = _modelNadeltelegraph.AlleZeiger[4].GetVisibilityUpLeft(zeigerNachOben);


        VisibilityLinieRechtsUnten1 = _modelNadeltelegraph.AlleZeiger[0].GetVisibilityDownRight(zeigerNachUnten);
        VisibilityLinieRechtsUnten2 = _modelNadeltelegraph.AlleZeiger[1].GetVisibilityDownRight(zeigerNachUnten);
        VisibilityLinieRechtsUnten3 = _modelNadeltelegraph.AlleZeiger[2].GetVisibilityDownRight(zeigerNachUnten);
        VisibilityLinieRechtsUnten4 = _modelNadeltelegraph.AlleZeiger[3].GetVisibilityDownRight(zeigerNachUnten);
        VisibilityLinieLinksUnten1 = _modelNadeltelegraph.AlleZeiger[1].GetVisibilityDownLeft(zeigerNachUnten);
        VisibilityLinieLinksUnten2 = _modelNadeltelegraph.AlleZeiger[2].GetVisibilityDownLeft(zeigerNachUnten);
        VisibilityLinieLinksUnten3 = _modelNadeltelegraph.AlleZeiger[3].GetVisibilityDownLeft(zeigerNachUnten);
        VisibilityLinieLinksUnten4 = _modelNadeltelegraph.AlleZeiger[4].GetVisibilityDownLeft(zeigerNachUnten);
    }
    public override void PlotterButtonClick(object sender, RoutedEventArgs e) { }
    public override void BeschreibungZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabBeschreibungZeichnen(this, tabItem, "#eeeeee");
    public override void LaborPlatteZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabLaborPlatteZeichnen(this, tabItem, "#eeeeee");
    public override void SimulationZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabSimulationZeichnen(this, tabItem, "#eeeeee");
}