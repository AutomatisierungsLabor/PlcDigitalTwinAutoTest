using DtLinearachse.Model;
using LibDatenstruktur;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Contracts;

namespace DtLinearachse.ViewModel;

public partial class VmLinearachse : BasePlcDtAt.BaseViewModel.VmBase
{
    private readonly ModelLinearachse _modelLinearachse;
    private readonly Datenstruktur _datenstruktur;

    public VmLinearachse(BasePlcDtAt.BaseModel.BaseModel model, Datenstruktur datenstruktur, CancellationTokenSource cancellationTokenSource) : base(model, datenstruktur, cancellationTokenSource)
    {
        _datenstruktur = datenstruktur;

        VisibilityTabBeschreibung = Visibility.Collapsed;
        VisibilityTabLaborplatte = Visibility.Visible;
        VisibilityTabSimulation = Visibility.Visible;
        VisibilityTabSoftwareTest = Visibility.Visible;

        VisibilityBtnPlcAnzeigen = Visibility.Visible;
        VisibilityBtnPlottAnzeigen = Visibility.Visible;
        VisibilityBtnLinkHomepageAnzeigen = Visibility.Visible;
        VisibilityBtnAlarmVerwaltungAnzeigen = Visibility.Visible;

        _modelLinearachse = model as ModelLinearachse;
    }
    protected override void ViewModelAufrufThread(double dT)
    {
        if (_modelLinearachse == null) return;

        StringFensterTitel = PlcDaemon.PlcState.PlcBezeichnung + ": " + _datenstruktur.VersionsStringLokal;

        (VisibilityEinB1, VisibilityAusB1) = BaseFunctions.SetVisibility(_modelLinearachse.B1);
        (VisibilityEinB2, VisibilityAusB2) = BaseFunctions.SetVisibility(_modelLinearachse.B2);
        (VisibilityEinS10, VisibilityAusS10) = BaseFunctions.SetVisibility(_modelLinearachse.S10);

        BrushP1 = BaseFunctions.SetBrush(_modelLinearachse.P1, Brushes.White, Brushes.LightGray);
        BrushP2 = BaseFunctions.SetBrush(_modelLinearachse.P2, Brushes.White, Brushes.LightGray);
        BrushP3 = BaseFunctions.SetBrush(_modelLinearachse.P3, Brushes.Red, Brushes.LightGray);
        BrushP4 = BaseFunctions.SetBrush(_modelLinearachse.P4, Brushes.LawnGreen, Brushes.LightGray);

        var links = _modelLinearachse.PositionSchlitten;
        var rechts = 525 - _modelLinearachse.PositionSchlitten;
        MarginPositionSchlitten = new Thickness(links, 0, rechts, 0);
    }
    public override void PlotterButtonClick(object sender, RoutedEventArgs e) { }
    public override void BeschreibungZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabBeschreibungZeichnen(this, tabItem, "#eeeeee");
    public override void LaborPlatteZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabLaborPlatteZeichnen(this, tabItem, "#eeeeee");
    public override void SimulationZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabSimulationZeichnen(this, tabItem, "#eeeeee");
}