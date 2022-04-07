using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Contracts;
using DtSchleifmaschine.Model;
using LibDatenstruktur;

namespace DtSchleifmaschine.ViewModel;

public partial class VmSchleifmaschine : BasePlcDtAt.BaseViewModel.VmBase
{
    private readonly ModelSchleifmaschine _modelSchleifmaschine;
    private readonly Datenstruktur _datenstruktur;

    public VmSchleifmaschine(BasePlcDtAt.BaseModel.BaseModel model, Datenstruktur datenstruktur, CancellationTokenSource cancellationTokenSource) : base(model, datenstruktur, cancellationTokenSource)
    {
        _datenstruktur = datenstruktur;

        VisibilityTabBeschreibung = Visibility.Collapsed;
        VisibilityTabLaborplatte = Visibility.Collapsed;
        VisibilityTabSimulation = Visibility.Visible;
        VisibilityTabSoftwareTest = Visibility.Visible;

        SichtbarEin[(int)WpfBase.BtnPlcAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.BtnPlottAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.BtnLinkHomepageAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.BtnAlwarmVerwaltungAnzeigen] = Visibility.Visible;

        _modelSchleifmaschine = model as ModelSchleifmaschine;

        PointTransformOrigin = new Point(5, 5);
    }

    protected override void ViewModelAufrufThread()
    {
        if (_modelSchleifmaschine == null) return;

        FensterTitel = PlcDaemon.PlcState.PlcBezeichnung + ": " + _datenstruktur.VersionsStringLokal;

        Winkel = _modelSchleifmaschine.WinkelSchleifmaschine;
        AktuelleDrehzahl = _modelSchleifmaschine.DrehzahlSchleifmaschine;
        StringSchleifmaschineDrehzahl = "n=" + _modelSchleifmaschine.DrehzahlSchleifmaschine;

        (VisibilityEinB1, VisibilityAusB1) = SetVisibility(_modelSchleifmaschine.B1);
        (VisibilityEinS3, VisibilityAusS3) = SetVisibility(_modelSchleifmaschine.S3);

        BrushF1 = SetBrush(_modelSchleifmaschine.F1, Brushes.LawnGreen, Brushes.Red);
        BrushF2 = SetBrush(_modelSchleifmaschine.F2, Brushes.LawnGreen, Brushes.Red);

        BrushP1 = SetBrush(_modelSchleifmaschine.P1, Brushes.White, Brushes.LightGray);
        BrushP2 = SetBrush(_modelSchleifmaschine.P2, Brushes.LawnGreen, Brushes.LightGray);
        BrushP3 = SetBrush(_modelSchleifmaschine.P3, Brushes.Red, Brushes.LightGray);
        BrushS3 = SetBrush(_modelSchleifmaschine.S3, Brushes.LawnGreen, Brushes.Red);
    }
    protected override void ViewModelAufrufTaster(Enum tasterId, bool gedrueckt) { }
    protected override void ViewModelAufrufSchalter(Enum schalterId) { }
    public override void PlotterButtonClick(object sender, RoutedEventArgs e) { }
    public override void BeschreibungZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabBeschreibungZeichnen(this, tabItem, "#eeeeee");
    public override void LaborPlatteZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabLaborPlatteZeichnen(this, tabItem, "#eeeeee");
    public override void SimulationZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabSimulationZeichnen(this, tabItem, "#eeeeee");
}