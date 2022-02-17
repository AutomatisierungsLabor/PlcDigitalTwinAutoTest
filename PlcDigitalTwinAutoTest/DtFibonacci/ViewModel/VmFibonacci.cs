using Contracts;
using DtFibonacci.Model;
using LibDatenstruktur;
using ScottPlot;
using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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
    private readonly Datenstruktur _datenstruktur;
    private WpfPlot _scottPlot;
    private readonly double[] _zeitachse;
    private short _nextDataIndex = 1;
    private readonly double[] _wertLeuchtMelder;

    public VmFibonacci(BasePlcDtAt.BaseModel.BaseModel model, Datenstruktur datenstruktur, CancellationTokenSource cancellationTokenSource) : base(model, datenstruktur, cancellationTokenSource)
    {
        _datenstruktur= datenstruktur;
        _wertLeuchtMelder = new double[5_000];
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

        FensterTitel = PlcDaemon.PlcState.PlcBezeichnung + ": " + _datenstruktur.VersionsStringLokal;

        SichtbarkeitUmschalten(_modelFibonacci.S1, (int)WpfObjects.S1);

        FarbeUmschalten(_modelFibonacci.P1, (int)WpfObjects.P1, Brushes.LawnGreen, Brushes.White);

        ScottPlotAktualisieren();
    }
    protected override void ViewModelAufrufTaster(Enum tasterId, bool gedrueckt)
    {
        if (tasterId is WpfObjects.S1) _modelFibonacci.S1 = gedrueckt;
        else throw new ArgumentOutOfRangeException(nameof(tasterId));
    }
    protected override void ViewModelAufrufSchalter(Enum schalterId) { }
    public override void PlotterButtonClick(object sender, RoutedEventArgs e) { }
    public override void BeschreibungZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabBeschreibungZeichnen(this, tabItem, "#eeeeee");
    public override void LaborPlatteZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabLaborPlatteZeichnen(this, tabItem, "#eeeeee");
    public override void SimulationZeichnen(TabItem tabItem)
    {
        _scottPlot = TabZeichnen.TabZeichnen.TabSimulationZeichnen(this, tabItem, "#eeeeee");

        _scottPlot.Plot.YLabel("Leuchtmelder");
        _scottPlot.Plot.XLabel("Zeit [ms]");

        _scottPlot.Plot.AddScatter(_zeitachse, _wertLeuchtMelder, label: "LED");
    }
    private void ScottPlotAktualisieren()
    {
        if (_nextDataIndex >= 4_990) _nextDataIndex = 0;

        for (var i = 0; i < 10; i++)
        {
            _wertLeuchtMelder[_nextDataIndex + i] = _modelFibonacci.P1 ? 1 : 0;
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