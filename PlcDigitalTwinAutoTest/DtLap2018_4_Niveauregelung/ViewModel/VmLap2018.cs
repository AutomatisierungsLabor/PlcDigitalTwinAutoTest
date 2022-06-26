using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Contracts;
using DtLap2018_4_Niveauregelung.Model;
using LibDatenstruktur;

namespace DtLap2018_4_Niveauregelung.ViewModel;

public partial class VmLap2018 : BasePlcDtAt.BaseViewModel.VmBase
{
    private readonly ModelLap2018 _modelLap2018;
    private readonly Datenstruktur _datenstruktur;

    private const double HoeheFuellBalken = 12 * 30;

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
    protected override void ViewModelAufrufThread()
    {
        if (_modelLap2018 == null) return;
        StringFensterTitel = PlcDaemon.PlcState.PlcBezeichnung + ": " + _datenstruktur.VersionsStringLokal;
        
        StringFuellstand = $"Füllstand: {_modelLap2018.Pegel * 100:F1}%";

        BrushF1 = BaseFunctions.SetBrush(!_modelLap2018.F1, Brushes.Red, Brushes.LawnGreen);
        BrushF2 = BaseFunctions.SetBrush(!_modelLap2018.F2, Brushes.Red, Brushes.LawnGreen);

        BrushP1 = BaseFunctions.SetBrush(_modelLap2018.P1, Brushes.Red, Brushes.White);
        BrushP2 = BaseFunctions.SetBrush(_modelLap2018.P2, Brushes.LawnGreen, Brushes.White);
        BrushP3 = BaseFunctions.SetBrush(_modelLap2018.P3, Brushes.OrangeRed, Brushes.White);

        BrushAbleitungOben = BaseFunctions.SetBrush(_modelLap2018.Pegel > 0.01, Brushes.Blue, Brushes.LightBlue);
        BrushAbleitungUnten = BaseFunctions.SetBrush(_modelLap2018.Y1 && _modelLap2018.Pegel > 0.01, Brushes.Blue, Brushes.LightBlue);
        BrushZuleitungLinksWaagrecht = BaseFunctions.SetBrush(_modelLap2018.Q1, Brushes.Blue, Brushes.LightBlue);
        BrushZuleitungLinksSenkrecht = BaseFunctions.SetBrush(_modelLap2018.Q1, Brushes.Blue, Brushes.LightBlue);
        BrushZuleitungRechtsWaagrecht = BaseFunctions.SetBrush(_modelLap2018.Q2, Brushes.Blue, Brushes.LightBlue);
        BrushZuleitungRechtsSenkrecht = BaseFunctions.SetBrush(_modelLap2018.Q2, Brushes.Blue, Brushes.LightBlue);

        (VisibilityEinB1, VisibilityAusB1) = BaseFunctions.SetVisibility(_modelLap2018.B1);
        (VisibilityEinB2, VisibilityAusB2) = BaseFunctions.SetVisibility(_modelLap2018.B2);
        (VisibilityEinB3, VisibilityAusB3) = BaseFunctions.SetVisibility(_modelLap2018.B3);
        (VisibilityEinQ1, VisibilityAusQ1) = BaseFunctions.SetVisibility(_modelLap2018.Q1);
        (VisibilityEinQ2, VisibilityAusQ2) = BaseFunctions.SetVisibility(_modelLap2018.Q2);
        (VisibilityEinY1, VisibilityAusY1) = BaseFunctions.SetVisibility(_modelLap2018.Y1);

        ThicknessFuellstand = new Thickness(0, HoeheFuellBalken * (1 - _modelLap2018.Pegel), 0, 0);
    }
    public override void PlotterButtonClick(object sender, RoutedEventArgs e) { }
    public override void BeschreibungZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabBeschreibungZeichnen(this, tabItem, "#eeeeee");
    public override void LaborPlatteZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabLaborPlatteZeichnen(this, tabItem, "#eeeeee");
    public override void SimulationZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabSimulationZeichnen(this, tabItem, "#eeeeee");
}