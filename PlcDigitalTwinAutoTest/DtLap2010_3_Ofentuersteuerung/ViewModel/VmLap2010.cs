using System;
using System.Threading;
using System.Windows;
using Contracts;
using DtLap2010_3_Ofentuersteuerung.Model;
using LibDatenstruktur;
using System.Windows.Controls;
using System.Windows.Media;

namespace DtLap2010_3_Ofentuersteuerung.ViewModel;

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

        SichtbarEin[(int)WpfBase.BtnPlcAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.BtnPlottAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.BtnLinkHomepageAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.BtnAlwarmVerwaltungAnzeigen] = Visibility.Visible;
    }
    protected override void ViewModelAufrufThread()
    {
        FensterTitel = PlcDaemon.PlcState.PlcBezeichnung + ": " + _datenstruktur.VersionsStringLokal;

        OfentuerePosition = new Thickness(0, 0, 0, 0); //_modelLap2010!.PositionOfentuere;
        ZahnstangePosition = new Thickness(0, 0, 0, 0); //_modelLap2010!.PositionZahnstange;
        ZahnradWinkel = _modelLap2010.WinkelZahnrad;

        (VisibilityEinB1, VisibilityAusB1) = SetVisibility(_modelLap2010.B1);
        (VisibilityEinB2, VisibilityAusB2) = SetVisibility(_modelLap2010.B2);
        (VisibilityEinB3, VisibilityAusB3) = SetVisibility(_modelLap2010.B3);
        (VisibilityKurzschluss, _) = SetVisibility(_modelLap2010.Q1 && _modelLap2010.Q2);

        BrushP1 = SetBrush(_modelLap2010.P1, Brushes.LawnGreen, Brushes.White);
        BrushQ1 = SetBrush(_modelLap2010.Q1, Brushes.LawnGreen, Brushes.White);
        BrushQ2 = SetBrush(_modelLap2010.Q2, Brushes.LawnGreen, Brushes.White);
    }
    protected override void ViewModelAufrufTaster(Enum tasterId, bool gedrueckt) { }
    protected override void ViewModelAufrufSchalter(Enum schalterId) { }
    public override void PlotterButtonClick(object sender, RoutedEventArgs e) { }
    public override void BeschreibungZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabBeschreibungZeichnen(this, tabItem, "#eeeeee");
    public override void LaborPlatteZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabLaborPlatteZeichnen(this, tabItem, "#eeeeee");
    public override void SimulationZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabSimulationZeichnen(this, tabItem, "#eeeeee");
}