using DtLap2010_3_Ofentuersteuerung.Model;
using LibDatenstruktur;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Contracts;

namespace DtLap2010_3_Ofentuersteuerung.ViewModel;

public partial class VmLap2010 : BasePlcDtAt.BaseViewModel.VmBase
{
    private readonly ModelLap2010 _modelLap2010;
    private readonly Datenstruktur _datenstruktur;

    private const double BreiteOfentuere = 7 * WpfData.RasterX;
    private const double BreiteFahrweg = 20 * WpfData.RasterX;

    public VmLap2010(BasePlcDtAt.BaseModel.BaseModel model, Datenstruktur datenstruktur, CancellationTokenSource cancellationTokenSource) : base(model, datenstruktur, cancellationTokenSource)
    {
        _modelLap2010 = model as ModelLap2010;
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
        StringFensterTitel = PlcDaemon.PlcState.PlcBezeichnung + ": " + _datenstruktur.VersionsStringLokal;

        var rechterRand = BreiteOfentuere * _modelLap2010.PositionOfentuere;
        ThicknessOfentuerePosition = new Thickness(BreiteFahrweg - BreiteOfentuere * (1 + _modelLap2010.PositionOfentuere), 0, rechterRand, 0);
        ThicknessZahnstangePosition = new Thickness(-rechterRand, 0, rechterRand, 0);

        const double winkelFaktor = -184;
        const double winkelOffset = -1.5;
        DoubleZahnradWinkel = winkelOffset + winkelFaktor * _modelLap2010.PositionOfentuere;

        (VisibilityEinB1, VisibilityAusB1) = BaseFunctions.SetVisibility(_modelLap2010.B1);
        (VisibilityEinB2, VisibilityAusB2) = BaseFunctions.SetVisibility(_modelLap2010.B2);
        (VisibilityEinB3, VisibilityAusB3) = BaseFunctions.SetVisibility(_modelLap2010.B3);
        (VisibilityKurzschluss, _) = BaseFunctions.SetVisibility(_modelLap2010.Q1 && _modelLap2010.Q2);

        BrushP1 = BaseFunctions.SetBrush(_modelLap2010.P1, Brushes.LawnGreen, Brushes.White);
        BrushQ1 = BaseFunctions.SetBrush(_modelLap2010.Q1, Brushes.LawnGreen, Brushes.White);
        BrushQ2 = BaseFunctions.SetBrush(_modelLap2010.Q2, Brushes.LawnGreen, Brushes.White);
    }
    public override void PlotterButtonClick(object sender, RoutedEventArgs e) { }
    public override void BeschreibungZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabBeschreibungZeichnen(this, tabItem, "#eeeeee");
    public override void LaborPlatteZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabLaborPlatteZeichnen(this, tabItem, "#eeeeee");
    public override void SimulationZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabSimulationZeichnen(this, tabItem, "#eeeeee");
}