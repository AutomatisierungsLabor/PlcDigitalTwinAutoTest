using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using Contracts;
using DtLap2010_2_Transportwagen.Model;
using LibDatenstruktur;

namespace DtLap2010_2_Transportwagen.ViewModel;
public enum WpfObjects
{
    // ReSharper disable once UnusedMember.Global
    ReserveFuerBasisViewModel = 20, // enum WpfBase

    P1 = 21,
    P2 = 22,
    Q1 = 23,
    Q2 = 24,
    Q3 = 25,

    B1 = 31,
    B2 = 32,
    F1 = 33,
    S1 = 34,
    S2 = 35,

    Kurzschluss = 40
}
public class VmLap2010 : BasePlcDtAt.BaseViewModel.VmBase
{
    private readonly ModelLap2010? _modelLap2010;
    private readonly Datenstruktur _datenstruktur;

    public VmLap2010(BasePlcDtAt.BaseModel.BaseModel model, Datenstruktur datenstruktur, CancellationTokenSource cancellationTokenSource) : base(model, datenstruktur, cancellationTokenSource)
    {
        _modelLap2010 = model as ModelLap2010;
        _datenstruktur = datenstruktur;

        SichtbarEin[(int)WpfBase.TabBeschreibung] = Visibility.Collapsed;
        SichtbarEin[(int)WpfBase.TabLaborplatte] = Visibility.Collapsed;
        SichtbarEin[(int)WpfBase.TabSimulation] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.TabAutoTest] = Visibility.Visible;

        SichtbarEin[(int)WpfBase.BtnPlcAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.BtnPlottAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.BtnLinkHomepageAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.BtnAlwarmVerwaltungAnzeigen] = Visibility.Visible;

        Text[(int)WpfObjects.B1] = "B1";
        Text[(int)WpfObjects.B2] = "B2";
        Text[(int)WpfObjects.F1] = "F1";

        Text[(int)WpfObjects.S1] = "Aus";
        Text[(int)WpfObjects.S2] = "Ein";
        Text[(int)WpfObjects.P1] = "Störung";
        Text[(int)WpfObjects.P2] = "Betriebsbereit";
        Text[(int)WpfObjects.Kurzschluss] = "Kurzschluss";
    }
    protected override void ViewModelAufrufThread()
    {
        FensterTitel = PlcDaemon.PlcState.PlcBezeichnung + ": " + _datenstruktur.VersionsStringLokal;

    
    }
    protected override void ViewModelAufrufTaster(Enum tasterId, bool gedrueckt)
    {
        switch (tasterId)
        {
            case WpfObjects.S1: _modelLap2010!.S1 = !gedrueckt; break;
            case WpfObjects.S2: _modelLap2010!.S2 = gedrueckt; break;
            default: throw new ArgumentOutOfRangeException(nameof(tasterId));
        }
    }
    protected override void ViewModelAufrufSchalter(Enum schalterId)
    {
        switch (schalterId)
        {
            case WpfObjects.B2: _modelLap2010!.B2 = !_modelLap2010.B2; break;
            case WpfObjects.F1: _modelLap2010!.F1 = !_modelLap2010.F1; break;
            default: throw new ArgumentOutOfRangeException(nameof(schalterId));
        }
    }
    private double _aktuellerDruck;
    public double AktuellerDruck
    {
        get => _aktuellerDruck;
        set
        {
            _aktuellerDruck = value;
            OnPropertyChanged(nameof(AktuellerDruck));
        }
    }

    public override void PlotterButtonClick(object sender, RoutedEventArgs e) { }
    public override void BeschreibungZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabBeschreibungZeichnen(this, tabItem, "#eeeeee");
    public override void LaborPlatteZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabLaborPlatteZeichnen(this, tabItem, "#eeeeee");
    public override void SimulationZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabSimulationZeichnen(this, tabItem, "#eeeeee");
}