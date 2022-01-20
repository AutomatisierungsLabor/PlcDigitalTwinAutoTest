using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DtFibonacci.Model;
using LibDatenstruktur;
using ScottPlot;

namespace DtFibonacci.ViewModel;
public enum WpfObjects
{
    // ReSharper disable once UnusedMember.Global
    ReserveFuerBasisViewModel = 20,// // enum WpfBase

    P1 = 21,

    S1 = 31
}
public class VmFibonacci : BasePlcDtAt.BaseViewModel.VmBase
{
    private readonly ModelFibonacci _modelFibonacci;
    private LibWpf.LibWpf _libWpfTabBeschreibung;
    private LibWpf.LibWpf _libWpfLaborPlatte;
    private LibWpf.LibWpf _libWpfSimulation;
    private WpfPlot _scottPlot;
    private readonly double[] _zeitachse;
    private short _nextDataIndex = 1;
    public double[] WertLeuchtMelder { get; set; } = new double[5_000];

    public VmFibonacci(BasePlcDtAt.BaseModel.BaseModel model, Datenstruktur datenstruktur) : base(model, datenstruktur)
    {
        _zeitachse = DataGen.Consecutive(5000);

        SichtbarEin[(int)WpfBase.TabBeschreibung] = Visibility.Collapsed;
        SichtbarEin[(int)WpfBase.TabLaborplatte] = Visibility.Collapsed;
        SichtbarEin[(int)WpfBase.TabSimulation] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.TabAutoTest] = Visibility.Visible;

        SichtbarEin[(int)WpfBase.BtnPlcAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.BtnPlottAnzeigen] = Visibility.Visible;

        Text[(int)WpfObjects.S1] = "Start";

        _modelFibonacci = model as ModelFibonacci;
    }

    protected override void ViewModelAufrufThread()
    {
        if (_modelFibonacci == null) return;

        FensterTitel = PlcDaemon.PlcState.PlcBezeichnung + ": " + Datenstruktur.VersionsStringLokal;

        SichtbarkeitUmschalten(_modelFibonacci.S1, (int)WpfObjects.S1);

        FarbeUmschalten(_modelFibonacci.P1, 1, Brushes.LawnGreen, Brushes.White);

        ScottPlotAktualisieren();
        ErrorAnzeigen();
    }
    protected override void ViewModelAufrufTaster(Enum tasterId, bool gedrueckt)
    {
        if (tasterId is WpfObjects.S1) _modelFibonacci.S1 = gedrueckt;
        else throw new ArgumentOutOfRangeException(nameof(tasterId));
    }
    protected override void ViewModelAufrufSchalter(Enum schalterId) { }
    public override void PlotterButtonClick(object sender, RoutedEventArgs e) { }
    public override void BeschreibungZeichnen(TabItem tabItem) => _libWpfTabBeschreibung = TabZeichnen.TabZeichnen.TabBeschreibungZeichnen(this, tabItem, "#eeeeee");
    public override void LaborPlatteZeichnen(TabItem tabItem) => _libWpfLaborPlatte = TabZeichnen.TabZeichnen.TabLaborPlatteZeichnen(this, tabItem, "#eeeeee");
    public override void SimulationZeichnen(TabItem tabItem)
    {
        (_libWpfSimulation, _scottPlot) = TabZeichnen.TabZeichnen.TabSimulationZeichnen(this, tabItem, "#eeeeee");

        _scottPlot.Plot.YLabel("Leuchtmelder");
        _scottPlot.Plot.XLabel("Zeit [ms]");

        _scottPlot.Plot.AddScatter(_zeitachse, WertLeuchtMelder, label: "LED");
    }
    private void ErrorAnzeigen()
    {
        _libWpfTabBeschreibung?.PlcError(PlcDaemon, Datenstruktur);
        _libWpfLaborPlatte?.PlcError(PlcDaemon, Datenstruktur);
        _libWpfSimulation?.PlcError(PlcDaemon, Datenstruktur);
    }
    private void ScottPlotAktualisieren()
    {
        if (_nextDataIndex >= 4_990) _nextDataIndex = 0;

        for (var i = 0; i < 10; i++)
        {
            WertLeuchtMelder[_nextDataIndex + i] = _modelFibonacci.P1 ? 1 : 0;
        }

        _nextDataIndex += 10;

        if (_scottPlot != null)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                _scottPlot.Plot.AxisAuto(0);
                _scottPlot.Render();
            });
        }
    }
}