using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DtLap2010_4_Abfuellanlage.Model;
using LibDatenstruktur;

namespace DtLap2010_4_Abfuellanlage.ViewModel;

public partial class VmLap2010 : BasePlcDtAt.BaseViewModel.VmBase
{
    private readonly ModelLap2010 _modelLap2010;
    private readonly Datenstruktur _datenstruktur;

    private const double HoeheFuellBalken = 9 * 35;

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
    protected override void ViewModelAufrufThread()
    {
        StringFensterTitel = PlcDaemon.PlcState.PlcBezeichnung + ": " + _datenstruktur.VersionsStringLokal;

        BrushP1 = SetBrush(_modelLap2010.P1, Brushes.Red, Brushes.White);
        BrushQ1 = SetBrush(_modelLap2010.Q1, Brushes.LawnGreen, Brushes.LightGray);
        BrushZuleitung = SetBrush(_modelLap2010!.Pegel > 0.01, Brushes.Coral, Brushes.LightCoral);

        (VisibilityEinB1, VisibilityAusB1) = SetVisibility(_modelLap2010.B1);
        (VisibilityEinB2, VisibilityAusB2) = SetVisibility(_modelLap2010.B2);
        (VisibilityEinK1, VisibilityAusK1) = SetVisibility(_modelLap2010.K1);
        (VisibilityEinK2, VisibilityAusK2) = SetVisibility(_modelLap2010.K2);
        (VisibilityAbleitung, _) = SetVisibility(_modelLap2010.K2 && _modelLap2010.Pegel > 0.01);

       Fuellstand = new Thickness(0, HoeheFuellBalken * (1 - _modelLap2010.Pegel), 0, 0);
    }
    public override void PlotterButtonClick(object sender, RoutedEventArgs e) { }
    public override void BeschreibungZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabBeschreibungZeichnen(this, tabItem, "#eeeeee");
    public override void LaborPlatteZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabLaborPlatteZeichnen(this, tabItem, "#eeeeee");
    public override void SimulationZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabSimulationZeichnen(this, tabItem, "#eeeeee");
}