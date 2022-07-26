using System.Threading;
using System.Windows;
using System.Windows.Controls;
using DtVoltmeter.Model;
using LibDatenstruktur;

namespace DtVoltmeter.ViewModel;

public partial class VmVoltmeter : BasePlcDtAt.BaseViewModel.VmBase
{
    private readonly ModelVoltmeter _modelVoltmeter;
    private readonly Datenstruktur _datenstruktur;


    public VmVoltmeter(BasePlcDtAt.BaseModel.BaseModel model, Datenstruktur datenstruktur, CancellationTokenSource cancellationTokenSource) : base(model, datenstruktur, cancellationTokenSource)
    {
        _datenstruktur = datenstruktur;

        VisibilityTabBeschreibung = Visibility.Collapsed;
        VisibilityTabLaborplatte = Visibility.Collapsed;
        VisibilityTabSimulation = Visibility.Visible;
        VisibilityTabSoftwareTest = Visibility.Visible;

        VisibilityBtnPlcAnzeigen = Visibility.Visible;
        VisibilityBtnPlottAnzeigen = Visibility.Visible;
        VisibilityBtnLinkHomepageAnzeigen = Visibility.Visible;
        VisibilityBtnAlarmVerwaltungAnzeigen = Visibility.Visible;

        _modelVoltmeter = model as ModelVoltmeter;
    }

    protected override void ViewModelAufrufThread(double dT)
    {
        if (_modelVoltmeter == null) return;

        StringFensterTitel = PlcDaemon.PlcState.PlcBezeichnung + ": " + _datenstruktur.VersionsStringLokal;

        if (_modelVoltmeter.HintergrundGruen) BrushHintergrundFarbe = System.Windows.Media.Brushes.LawnGreen;
        else
        {
            BrushHintergrundFarbe = _modelVoltmeter.HintergrundGelb ? System.Windows.Media.Brushes.Yellow : System.Windows.Media.Brushes.Red;
        }

        _modelVoltmeter.AnalogSignal = (int)DoubleAnalogsignal;
        StringAnalogsignal = $"AI 0: {_modelVoltmeter.AnalogSignal}";
        StringAnalogInVolt = $"AI 0: {_modelVoltmeter.AnalogSignal / 2746.8:F2}V";
    }
    public override void PlotterButtonClick(object sender, RoutedEventArgs e) { }
    public override void BeschreibungZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabBeschreibungZeichnen(this, tabItem, "#eeeeee");
    public override void LaborPlatteZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabLaborPlatteZeichnen(this, tabItem, "#eeeeee");
    public override void SimulationZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabSimulationZeichnen(this, tabItem, "#eeeeee");
}