using Contracts;
using DtBlinker.Model;
using LibDatenstruktur;
using ScottPlot;
using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DtBlinker.ViewModel;

public enum WpfObjects
{
    // ReSharper disable once UnusedMember.Global
    ReserveFuerBasisViewModel = 20,// // enum WpfBase

    P1 = 21,

    S1 = 31,
    S2 = 32,
    S3 = 33,
    S4 = 34,
    S5 = 35
}
public class VmBlinker : BasePlcDtAt.BaseViewModel.VmBase
{
    private readonly ModelBlinker _modelBlinker;
    private WpfPlot _scottPlot;
    private readonly double[] _zeitachse;
    private short _nextDataIndex = 1;
    private readonly double[] _wertLeuchtMelder;

    public VmBlinker(BasePlcDtAt.BaseModel.BaseModel model, Datenstruktur datenstruktur, CancellationTokenSource cancellationTokenSource) : base(model, datenstruktur, cancellationTokenSource)
    {
        _wertLeuchtMelder = new double[5_000];
        _zeitachse = DataGen.Consecutive(5_000);

        SichtbarEin[(int)WpfBase.TabBeschreibung] = Visibility.Collapsed;
        SichtbarEin[(int)WpfBase.TabLaborplatte] = Visibility.Collapsed;
        SichtbarEin[(int)WpfBase.TabSimulation] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.TabAutoTest] = Visibility.Visible;

        SichtbarEin[(int)WpfBase.BtnPlcAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.BtnPlottAnzeigen] = Visibility.Visible;

        Text[(int)WpfObjects.S1] = "Niedriger";
        Text[(int)WpfObjects.S2] = "Höher";
        Text[(int)WpfObjects.S3] = "Weniger";
        Text[(int)WpfObjects.S4] = "Mehr";
        Text[(int)WpfObjects.S5] = "RESET";

        _modelBlinker = model as ModelBlinker;
    }

    protected override void ViewModelAufrufThread()
    {
        if (_modelBlinker == null) return;

        FensterTitel = PlcDaemon.PlcState.PlcBezeichnung + ": " + Datenstruktur.VersionsStringLokal;

        SichtbarkeitUmschalten(_modelBlinker.S1, (int)WpfObjects.S1);
        SichtbarkeitUmschalten(_modelBlinker.S2, (int)WpfObjects.S2);
        SichtbarkeitUmschalten(_modelBlinker.S3, (int)WpfObjects.S3);
        SichtbarkeitUmschalten(_modelBlinker.S4, (int)WpfObjects.S4);
        SichtbarkeitUmschalten(_modelBlinker.S5, (int)WpfObjects.S5);

        FarbeUmschalten(_modelBlinker.P1, (int)WpfObjects.P1, Brushes.LawnGreen, Brushes.White);

        ScottPlotAktualisieren();
    }
    protected override void ViewModelAufrufTaster(Enum tasterId, bool gedrueckt)
    {
        switch (tasterId)
        {
            case WpfObjects.S1: _modelBlinker.S1 = gedrueckt; break;
            case WpfObjects.S2: _modelBlinker.S2 = gedrueckt; break;
            case WpfObjects.S3: _modelBlinker.S3 = gedrueckt; break;
            case WpfObjects.S4: _modelBlinker.S4 = gedrueckt; break;
            case WpfObjects.S5: _modelBlinker.S5 = gedrueckt; break;

            default: throw new ArgumentOutOfRangeException(nameof(tasterId));
        }
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
            _wertLeuchtMelder[_nextDataIndex + i] = _modelBlinker.P1 ? 1 : 0;
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