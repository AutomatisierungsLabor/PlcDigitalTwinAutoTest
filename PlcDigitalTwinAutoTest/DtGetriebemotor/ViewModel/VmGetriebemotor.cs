using Contracts;
using DtGetriebemotor.Model;
using LibDatenstruktur;
using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DtGetriebemotor.ViewModel;
public enum WpfObjects
{
    // ReSharper disable once UnusedMember.Global
    ReserveFuerBasisViewModel = 20,// // enum WpfBase

    B1 = 21,
    B2 = 22,

    P1 = 30,
    P2 = 31,
    P3 = 32,

    S1 = 40,
    S2 = 41,
    S4 = 42,
    S3 = 43,
    S5 = 44,
    S7 = 45,
    S6 = 46,
    S8 = 47,
    S91 = 48,
    // ReSharper disable once UnusedMember.Global
    S92 = 49,

    WinkelGetriebemotor = 50

}
public class VmGetriebemotor : BasePlcDtAt.BaseViewModel.VmBase
{
    private readonly ModelGetriebemotor _modelGetriebemotor;
    private readonly Datenstruktur _datenstruktur;
    public VmGetriebemotor(BasePlcDtAt.BaseModel.BaseModel model, Datenstruktur datenstruktur, CancellationTokenSource cancellationTokenSource) : base(model, datenstruktur, cancellationTokenSource)
    {
        _datenstruktur= datenstruktur;

        SichtbarEin[(int)WpfBase.TabBeschreibung] = Visibility.Collapsed;
        SichtbarEin[(int)WpfBase.TabLaborplatte] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.TabSimulation] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.TabAutoTest] = Visibility.Visible;

        SichtbarEin[(int)WpfBase.BtnPlcAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.BtnPlottAnzeigen] = Visibility.Visible;

        Text[(int)WpfObjects.S1] = "①";
        Text[(int)WpfObjects.S2] = "⓪";
        Text[(int)WpfObjects.S3] = "I";
        Text[(int)WpfObjects.S4] = "STOP";
        Text[(int)WpfObjects.S5] = "II";
        Text[(int)WpfObjects.S6] = "←";
        Text[(int)WpfObjects.S7] = "STOP";
        Text[(int)WpfObjects.S8] = "→";

        TransformOrigin[(int)WpfObjects.WinkelGetriebemotor] = new Point(5, 5);

        _modelGetriebemotor = model as ModelGetriebemotor;
    }

    protected override void ViewModelAufrufThread()
    {
        if (_modelGetriebemotor == null) return;

        FensterTitel = PlcDaemon.PlcState.PlcBezeichnung + ": " + _datenstruktur.VersionsStringLokal;

        SichtbarkeitUmschalten(_modelGetriebemotor.B1, (int)WpfObjects.B1);
        SichtbarkeitUmschalten(_modelGetriebemotor.B2, (int)WpfObjects.B1);

        FarbeUmschalten(_modelGetriebemotor.P1, (int)WpfObjects.P1, Brushes.White, Brushes.LightGray);
        FarbeUmschalten(_modelGetriebemotor.P2, (int)WpfObjects.P2, Brushes.LawnGreen, Brushes.LightGray);
        FarbeUmschalten(_modelGetriebemotor.P3, (int)WpfObjects.P3, Brushes.Red, Brushes.LightGray);

        Winkel[(int)WpfObjects.WinkelGetriebemotor] = _modelGetriebemotor.WinkelGetriebemotor;
    }
    protected override void ViewModelAufrufTaster(Enum tasterId, bool gedrueckt)
    {
        switch (tasterId)
        {
            case WpfObjects.S1: _modelGetriebemotor.S1 = gedrueckt; break;
            case WpfObjects.S2: _modelGetriebemotor.S2 = !gedrueckt; break;
            case WpfObjects.S3: _modelGetriebemotor.S3 = gedrueckt; break;
            case WpfObjects.S4: _modelGetriebemotor.S4 = !gedrueckt; break;
            case WpfObjects.S5: _modelGetriebemotor.S5 = gedrueckt; break;
            case WpfObjects.S6: _modelGetriebemotor.S6 = gedrueckt; break;
            case WpfObjects.S7: _modelGetriebemotor.S7 = !gedrueckt; break;
            case WpfObjects.S8: _modelGetriebemotor.S8 = gedrueckt; break;

            default: throw new ArgumentOutOfRangeException(nameof(tasterId));
        }
    }
    protected override void ViewModelAufrufSchalter(Enum schalterId)
    {
        switch (schalterId)
        {
            case WpfObjects.S91:
                _modelGetriebemotor.S91 = !_modelGetriebemotor.S91;
                _modelGetriebemotor.S92 = !_modelGetriebemotor.S91;
                break;
            default: throw new ArgumentOutOfRangeException(nameof(schalterId));
        }
    }
    public override void PlotterButtonClick(object sender, RoutedEventArgs e) { }
    public override void BeschreibungZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabBeschreibungZeichnen(this, tabItem, "#eeeeee");
    public override void LaborPlatteZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabLaborPlatteZeichnen(this, tabItem, "#eeeeee");
    public override void SimulationZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabSimulationZeichnen(this, tabItem, "#eeeeee");
}