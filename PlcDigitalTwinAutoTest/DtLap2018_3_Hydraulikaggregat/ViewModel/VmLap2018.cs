using DtLap2018_3_Hydraulikaggregat.Model;
using LibDatenstruktur;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Contracts;

namespace DtLap2018_3_Hydraulikaggregat.ViewModel;

public partial class VmLap2018 : BasePlcDtAt.BaseViewModel.VmBase
{
    private readonly ModelLap2018 _modelLap2018;
    private readonly Datenstruktur _datenstruktur;

    private const double FuellBalkenHoehe = 580;    // oben und unten je 10 Pixel für den Radius
    private const double FuellBalkenOben = 10;
    public VmLap2018(BasePlcDtAt.BaseModel.BaseModel model, Datenstruktur datenstruktur, CancellationTokenSource cancellationTokenSource) : base(model, datenstruktur, cancellationTokenSource)
    {
        _modelLap2018 = model as ModelLap2018;
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
        if (_modelLap2018 == null) return;
        StringFensterTitel = PlcDaemon.PlcState.PlcBezeichnung + ": " + _datenstruktur.VersionsStringLokal;

        StringFuellstand = $"{_modelLap2018.Pegel * 100:F1}%";
        DoubleAktuellerDruck = _modelLap2018.Druck;

        BrushB3 = BaseFunctions.SetBrush(_modelLap2018.B3, Brushes.LawnGreen, Brushes.Red);
        BrushB4 = BaseFunctions.SetBrush(_modelLap2018.B4, Brushes.LawnGreen, Brushes.Red);
        BrushB5 = BaseFunctions.SetBrush(_modelLap2018.B5, Brushes.LawnGreen, Brushes.Red);

        BrushF1 = BaseFunctions.SetBrush(_modelLap2018.F1, Brushes.LawnGreen, Brushes.Red);

        BrushK1 = BaseFunctions.SetBrush(_modelLap2018.K1, Brushes.Red, Brushes.White);
        BrushK2 = BaseFunctions.SetBrush(_modelLap2018.K2, Brushes.Red, Brushes.White);

        BrushP1 = BaseFunctions.SetBrush(_modelLap2018.P1, Brushes.LawnGreen, Brushes.White);
        BrushP2 = BaseFunctions.SetBrush(_modelLap2018.P2, Brushes.Red, Brushes.White);
        BrushP3 = BaseFunctions.SetBrush(_modelLap2018.P3, Brushes.Red, Brushes.White);
        BrushP4 = BaseFunctions.SetBrush(_modelLap2018.P4, Brushes.Red, Brushes.White);
        BrushP5 = BaseFunctions.SetBrush(_modelLap2018.P5, Brushes.LawnGreen, Brushes.White);
        BrushP6 = BaseFunctions.SetBrush(_modelLap2018.P6, Brushes.Red, Brushes.White);
        BrushP7 = BaseFunctions.SetBrush(_modelLap2018.P7, Brushes.LawnGreen, Brushes.White);
        BrushP8 = BaseFunctions.SetBrush(_modelLap2018.P8, Brushes.Red, Brushes.White);

        BrushQ1 = BaseFunctions.SetBrush(_modelLap2018.Q1, Brushes.LawnGreen, Brushes.White);
        BrushQ2 = BaseFunctions.SetBrush(_modelLap2018.Q2, Brushes.LawnGreen, Brushes.White);
        BrushQ3 = BaseFunctions.SetBrush(_modelLap2018.Q3, Brushes.LawnGreen, Brushes.White);
        BrushQ4 = BaseFunctions.SetBrush(_modelLap2018.Q4, Brushes.LawnGreen, Brushes.White);

        BrushS4 = BaseFunctions.SetBrush(_modelLap2018.S4, Brushes.LawnGreen, Brushes.White);
        

        (VisibilityEinB1, VisibilityAusB1) = BaseFunctions.SetVisibility(_modelLap2018.B1);
        (VisibilityEinB2, VisibilityAusB2) = BaseFunctions.SetVisibility(_modelLap2018.B2);
        (VisibilityEinB3, VisibilityAusB3) = BaseFunctions.SetVisibility(_modelLap2018.B3);

        (VisibilityEinKurzschluss, _) = BaseFunctions.SetVisibility(_modelLap2018.Q2 && _modelLap2018.Q3);

        ThicknessFuellstand = new Thickness(21, FuellBalkenOben + FuellBalkenHoehe * (1 - _modelLap2018.Pegel), 41, 10);

        ErweiterungOelkuehler();
        ErweiterungZylinder();
        ErweiterungOelfilter();

        CheckErweiterungOelfilter();
        CheckErweiterungOelkuehler();
        CheckErweiterungZylinder();
    }
    internal void ErweiterungOelkuehler()
    {
        if (VisibilityErweiterungOelkuehler == Visibility.Visible) return;

        _modelLap2018.P7 = false;
    }
    internal void ErweiterungZylinder()
    {
        if (VisibilityErweiterungZylinder == Visibility.Visible) return;

        _modelLap2018.K1 = false;
        _modelLap2018.K2 = false;
    }
    internal void ErweiterungOelfilter()
    {
        if (VisibilityErweiterungOelfilter == Visibility.Visible) return;

        _modelLap2018.P8 = false;
    }


    internal void CheckErweiterungOelkuehler()
    {
        // (VisibilityErweiterungOelkuehler,_)=SetVisibility(_mainWindow.ChkOelkuehler.IsChecked != null && (bool)_mainWindow.ChkOelkuehler.IsChecked);
    }
    internal void CheckErweiterungZylinder()
    {
        //  (_visibilityZylinderAbgedeckt,_)=SetVisibility(_mainWindow.ChZylinder.IsChecked != null && (bool)_mainWindow.ChZylinder.IsChecked, 42);
    }
    internal void CheckErweiterungOelfilter()
    {
        //(_visibilityOelfilterAbgedeckt,_)=SetVisibility(_mainWindow.ChkOelfilter.IsChecked != null && (bool)_mainWindow.ChkOelfilter.IsChecked, 43);
    }

    public override void PlotterButtonClick(object sender, RoutedEventArgs e) { }
    public override void BeschreibungZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabBeschreibungZeichnen(this, tabItem, "#eeeeee");
    public override void LaborPlatteZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabLaborPlatteZeichnen(this, tabItem, "#eeeeee");
    public override void SimulationZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabSimulationZeichnen(this, tabItem, "#eeeeee");
}