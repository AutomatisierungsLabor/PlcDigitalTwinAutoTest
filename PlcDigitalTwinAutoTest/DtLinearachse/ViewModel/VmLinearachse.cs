using Contracts;
using DtLinearachse.Model;
using LibDatenstruktur;
using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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

        SichtbarEin[(int)WpfBase.BtnPlcAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.BtnPlottAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.BtnLinkHomepageAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.BtnAlwarmVerwaltungAnzeigen] = Visibility.Visible;

        _modelLinearachse = model as ModelLinearachse;
    }
    protected override void ViewModelAufrufThread()
    {
        if (_modelLinearachse == null) return;

        FensterTitel = PlcDaemon.PlcState.PlcBezeichnung + ": " + _datenstruktur.VersionsStringLokal;

        (VisibilityEinB1, VisibilityAusB1) = SetVisibility(_modelLinearachse.B1);
        (VisibilityEinB2, VisibilityAusB2) = SetVisibility(_modelLinearachse.B2);
        (VisibilityEinS10, VisibilityAusS10) = SetVisibility(_modelLinearachse.S10);
        
        BrushP1 = SetBrush(_modelLinearachse.P1, Brushes.LawnGreen, Brushes.White);
        BrushP2 = SetBrush(_modelLinearachse.P2, Brushes.LawnGreen, Brushes.White);
        BrushP3 = SetBrush(_modelLinearachse.P3, Brushes.LawnGreen, Brushes.White);
        BrushP4 = SetBrush(_modelLinearachse.P4, Brushes.LawnGreen, Brushes.White);

        var links = _modelLinearachse.PositionSchlitten;
        var rechts = 525 - _modelLinearachse.PositionSchlitten;
        MarginPositionSchlitten = new Thickness(links, 0, rechts, 0);
    }
    protected override void ViewModelAufrufTaster(Enum tasterId, bool gedrueckt) { }
    protected override void ViewModelAufrufSchalter(Enum schalterId) { }
    public override void PlotterButtonClick(object sender, RoutedEventArgs e) { }
    public override void BeschreibungZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabBeschreibungZeichnen(this, tabItem, "#eeeeee");
    public override void LaborPlatteZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabLaborPlatteZeichnen(this, tabItem, "#eeeeee");
    public override void SimulationZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabSimulationZeichnen(this, tabItem, "#eeeeee");
}