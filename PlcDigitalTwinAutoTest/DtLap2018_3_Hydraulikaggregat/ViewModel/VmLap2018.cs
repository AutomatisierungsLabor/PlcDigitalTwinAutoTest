using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Contracts;
using DtLap2018_3_Hydraulikaggregat.Model;
using LibDatenstruktur;

namespace DtLap2018_3_Hydraulikaggregat.ViewModel;
public enum WpfObjects
{
    // ReSharper disable once UnusedMember.Global
    ReserveFuerBasisViewModel = 20, // enum WpfBase

    B1 = 21,
    B2 = 22,
    B3 = 23,
    B4 = 24,
    B5 = 25,

    F1 = 26,

    K1 = 30,
    K2 = 31,

    P1 = 40,
    P2 = 41,
    P3 = 42,
    P4 = 43,
    P5 = 44,
    P6 = 45,
    P7 = 46,
    P8 = 47,

    Q1 = 48,
    Q2 = 49,
    Q3 = 50,
    Q4 = 51,

    S1 = 55,
    S2 = 56,
    S3 = 57,
    S4 = 58,

    Nachfullen = 60,
    Kurzschluss = 61,
    OelkuehlerAbgedeckt = 62,
    ZylinderAbgedeckt = 63,
    OelfilterAbgedeckt = 64

}
public partial class VmLap2018 : BasePlcDtAt.BaseViewModel.VmBase
{
    private readonly ModelLap2018 _modelLap2018;
    private readonly Datenstruktur _datenstruktur;

    public VmLap2018(BasePlcDtAt.BaseModel.BaseModel model, Datenstruktur datenstruktur, CancellationTokenSource cancellationTokenSource) : base(model, datenstruktur, cancellationTokenSource)
    {
        _modelLap2018 = model as ModelLap2018;
        _datenstruktur = datenstruktur;

        VisibilityTabBeschreibung = Visibility.Collapsed;
        VisibilityTabLaborplatte = Visibility.Collapsed;
        VisibilityTabSimulation = Visibility.Visible;
        VisibilityTabSoftwareTest = Visibility.Visible;

        SichtbarEin[(int)WpfBase.BtnPlcAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.BtnPlottAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.BtnLinkHomepageAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.BtnAlwarmVerwaltungAnzeigen] = Visibility.Visible;

        Text[(int)WpfObjects.S1] = "S1";
        Text[(int)WpfObjects.S2] = "S2";
        Text[(int)WpfObjects.S3] = "S3";
        Text[(int)WpfObjects.S4] = "S4";
    }
    protected override void ViewModelAufrufThread()
    {
        if (_modelLap2018 == null) return;
        FensterTitel = PlcDaemon.PlcState.PlcBezeichnung + ": " + _datenstruktur.VersionsStringLokal;

        //Druck = _hydraulikaggregat.Druck;

        FarbeUmschalten(_modelLap2018.B3, (int)WpfObjects.B3, Brushes.LawnGreen, Brushes.Red);
        FarbeUmschalten(_modelLap2018.B4, (int)WpfObjects.B4, Brushes.LawnGreen, Brushes.Red);
        FarbeUmschalten(_modelLap2018.B5, (int)WpfObjects.B5, Brushes.LawnGreen, Brushes.Red);

        FarbeUmschalten(_modelLap2018.F1, (int)WpfObjects.F1, Brushes.LawnGreen, Brushes.Red);

        FarbeUmschalten(_modelLap2018.K1, (int)WpfObjects.K1, Brushes.Red, Brushes.White);
        FarbeUmschalten(_modelLap2018.K2, (int)WpfObjects.K2, Brushes.Red, Brushes.White);

        FarbeUmschalten(_modelLap2018.P1, (int)WpfObjects.P1, Brushes.LawnGreen, Brushes.White);
        FarbeUmschalten(_modelLap2018.P2, (int)WpfObjects.P2, Brushes.Red, Brushes.White);
        FarbeUmschalten(_modelLap2018.P3, (int)WpfObjects.P3, Brushes.Red, Brushes.White);
        FarbeUmschalten(_modelLap2018.P4, (int)WpfObjects.P4, Brushes.Red, Brushes.White);
        FarbeUmschalten(_modelLap2018.P5, (int)WpfObjects.P5, Brushes.LawnGreen, Brushes.White);
        FarbeUmschalten(_modelLap2018.P6, (int)WpfObjects.P6, Brushes.Red, Brushes.White);
        FarbeUmschalten(_modelLap2018.P7, (int)WpfObjects.P7, Brushes.LawnGreen, Brushes.White);
        FarbeUmschalten(_modelLap2018.P8, (int)WpfObjects.P8, Brushes.Red, Brushes.White);

        FarbeUmschalten(_modelLap2018.Q1, (int)WpfObjects.Q1, Brushes.LawnGreen, Brushes.White);
        FarbeUmschalten(_modelLap2018.Q2, (int)WpfObjects.Q2, Brushes.LawnGreen, Brushes.White);
        FarbeUmschalten(_modelLap2018.Q3, (int)WpfObjects.Q3, Brushes.LawnGreen, Brushes.White);
        FarbeUmschalten(_modelLap2018.Q4, (int)WpfObjects.Q4, Brushes.LawnGreen, Brushes.White);

        FarbeUmschalten(_modelLap2018.S4, (int)WpfObjects.S4, Brushes.LawnGreen, Brushes.White);

        RipSichtbarkeitUmschalten(_modelLap2018.B1, (int)WpfObjects.B1);
        RipSichtbarkeitUmschalten(_modelLap2018.B2, (int)WpfObjects.B2);
        RipSichtbarkeitUmschalten(_modelLap2018.B3, (int)WpfObjects.B3);

        RipSichtbarkeitUmschalten(_modelLap2018.Q2 && _modelLap2018.Q3, 40);

        // Margin_1(_modelLap2018.Pegel);
        
        ErweiterungOelkuehler();
        ErweiterungZylinder();
        ErweiterungOelfilter();

    }
    internal void ErweiterungOelkuehler()
    {
        if (SichtbarEin[(int)WpfObjects.OelkuehlerAbgedeckt] == Visibility.Visible) return;

        _modelLap2018.P7 = false;
    }
    internal void ErweiterungZylinder()
    {
        if (SichtbarEin[(int)WpfObjects.ZylinderAbgedeckt] == Visibility.Visible) return;

        _modelLap2018.K1 = false;
        _modelLap2018.K2 = false;
    }
    internal void ErweiterungOelfilter()
    {
        if (SichtbarEin[(int)WpfObjects.OelfilterAbgedeckt] == Visibility.Visible) return;

        _modelLap2018.P8 = false;
    }

    /*
    internal void CheckErweiterungOelkuehler()
    {
        _viewModel.ViAnz.RIPSichtbarkeitUmschalten(_mainWindow.ChkOelkuehler.IsChecked != null && (bool)_mainWindow.ChkOelkuehler.IsChecked, 41);
    }
    internal void CheckErweiterungZylinder()
    {
        _viewModel.ViAnz.RIPSichtbarkeitUmschalten(
            _mainWindow.ChZylinder.IsChecked != null && (bool)_mainWindow.ChZylinder.IsChecked, 42);
    }
    internal void CheckErweiterungOelfilter()
    {
        _viewModel.ViAnz.RIPSichtbarkeitUmschalten(
            _mainWindow.ChkOelfilter.IsChecked != null && (bool)_mainWindow.ChkOelfilter.IsChecked, 43);
    }
    */

    protected override void ViewModelAufrufTaster(Enum tasterId, bool gedrueckt)
    {
        switch (tasterId)
        {
            case WpfObjects.S1: _modelLap2018.S1 = gedrueckt; break;
            case WpfObjects.S2: _modelLap2018.S2 = !gedrueckt; break;
            case WpfObjects.S3:
                _modelLap2018.S3 = gedrueckt;
                _modelLap2018.Stopwatch.Restart(); break;
            case WpfObjects.S4: _modelLap2018.S4 = gedrueckt; break;
            case WpfObjects.Nachfullen: _modelLap2018.Pegel = 1; break;
            default: throw new ArgumentOutOfRangeException(nameof(tasterId));
        }
    }
    protected override void ViewModelAufrufSchalter(Enum schalterId)
    {
        switch (schalterId)
        {
            case WpfObjects.B3: _modelLap2018.B3 = !_modelLap2018.B3; break;
            case WpfObjects.B4: _modelLap2018.B4 = !_modelLap2018.B4; break;
            case WpfObjects.B5: _modelLap2018.B5 = !_modelLap2018.B5; break;
            case WpfObjects.F1: _modelLap2018.F1 = !_modelLap2018.F1; break;
            default: throw new ArgumentOutOfRangeException(nameof(schalterId));
        }
    }
    public override void PlotterButtonClick(object sender, RoutedEventArgs e) { }
    public override void BeschreibungZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabBeschreibungZeichnen(this, tabItem, "#eeeeee");
    public override void LaborPlatteZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabLaborPlatteZeichnen(this, tabItem, "#eeeeee");
    public override void SimulationZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabSimulationZeichnen(this, tabItem, "#eeeeee");
}