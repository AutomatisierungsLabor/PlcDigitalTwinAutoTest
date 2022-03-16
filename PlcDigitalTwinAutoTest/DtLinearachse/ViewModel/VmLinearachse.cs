using Contracts;
using DtLinearachse.Model;
using LibDatenstruktur;
using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DtLinearachse.ViewModel;
public enum WpfObjects
{
    // ReSharper disable once UnusedMember.Global
    ReserveFuerBasisViewModel = 20,// // enum WpfBase

    B1 = 21,
    B2 = 22,
    P1 = 31,
    P2 = 32,
    P3 = 33,
    P4 = 34,

    S1 = 41,
    S2 = 42,
    S3 = 43,
    S4 = 44,
    S5 = 45,
    S6 = 46,
    S7 = 47,
    S8 = 48,
    S9 = 49,
    S10 = 50,
    S11 = 51,

    PositionSchlitten = 60
}
public class VmLinearachse : BasePlcDtAt.BaseViewModel.VmBase
{
    private readonly ModelLinearachse _modelLinearachse;
    private readonly Datenstruktur _datenstruktur;

    public VmLinearachse(BasePlcDtAt.BaseModel.BaseModel model, Datenstruktur datenstruktur, CancellationTokenSource cancellationTokenSource) : base(model, datenstruktur, cancellationTokenSource)
    {
        _datenstruktur= datenstruktur;

        SichtbarEin[(int)WpfBase.TabBeschreibung] = Visibility.Collapsed;
        SichtbarEin[(int)WpfBase.TabLaborplatte] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.TabSimulation] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.TabAutoTest] = Visibility.Visible;

        SichtbarEin[(int)WpfBase.BtnPlcAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.BtnPlottAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.BtnLinkHomepageAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.BtnAlwarmVerwaltungAnzeigen] = Visibility.Visible;

        Text[(int)WpfObjects.S1] = "①";
        Text[(int)WpfObjects.S2] = "⓪";
        Text[(int)WpfObjects.S3] = "I";
        Text[(int)WpfObjects.S4] = "II";
        Text[(int)WpfObjects.S5] = "↑";
        Text[(int)WpfObjects.S6] = "↓";
        Text[(int)WpfObjects.S7] = "+";
        Text[(int)WpfObjects.S8] = "-";
        Text[(int)WpfObjects.S9] = "STOP";

        _modelLinearachse = model as ModelLinearachse;
    }
    protected override void ViewModelAufrufThread()
    {
        if (_modelLinearachse == null) return;

        FensterTitel = PlcDaemon.PlcState.PlcBezeichnung + ": " + _datenstruktur.VersionsStringLokal;

        SichtbarkeitUmschalten(_modelLinearachse.B1, (int)WpfObjects.B1);
        SichtbarkeitUmschalten(_modelLinearachse.B2, (int)WpfObjects.B2);
        SichtbarkeitUmschalten(_modelLinearachse.S10, (int)WpfObjects.S10);

        FarbeUmschalten(_modelLinearachse.P1, (int)WpfObjects.P1, Brushes.LawnGreen, Brushes.White);
        FarbeUmschalten(_modelLinearachse.P2, (int)WpfObjects.P2, Brushes.LawnGreen, Brushes.White);
        FarbeUmschalten(_modelLinearachse.P3, (int)WpfObjects.P3, Brushes.LawnGreen, Brushes.White);
        FarbeUmschalten(_modelLinearachse.P4, (int)WpfObjects.P4, Brushes.LawnGreen, Brushes.White);

        var links = _modelLinearachse.PositionSchlitten;
        var rechts = 525 - _modelLinearachse.PositionSchlitten;
        Margin[(int)WpfObjects.PositionSchlitten] = new Thickness(links, 0, rechts, 0);
    }
    protected override void ViewModelAufrufTaster(Enum tasterId, bool gedrueckt)
    {
        switch (tasterId)
        {
            case WpfObjects.S1: _modelLinearachse.S1 = gedrueckt; break;
            case WpfObjects.S2: _modelLinearachse.S2 = !gedrueckt; break;
            case WpfObjects.S3: _modelLinearachse.S3 = gedrueckt; break;
            case WpfObjects.S4: _modelLinearachse.S4 = gedrueckt; break;
            case WpfObjects.S5: _modelLinearachse.S5 = gedrueckt; break;
            case WpfObjects.S6: _modelLinearachse.S6 = gedrueckt; break;
            case WpfObjects.S7: _modelLinearachse.S7 = gedrueckt; break;
            case WpfObjects.S8: _modelLinearachse.S8 = gedrueckt; break;
            case WpfObjects.S9: _modelLinearachse.S9 = !gedrueckt; break;

            default: throw new ArgumentOutOfRangeException(nameof(tasterId));
        }
    }
    protected override void ViewModelAufrufSchalter(Enum schalterId)
    {
        switch (schalterId)
        {
            case WpfObjects.S10: _modelLinearachse.S10 = !_modelLinearachse.S10; break;
            case WpfObjects.S11: _modelLinearachse.S11 = !_modelLinearachse.S11; break;
            default: throw new ArgumentOutOfRangeException(nameof(schalterId));
        }
    }
    public override void PlotterButtonClick(object sender, RoutedEventArgs e) { }
    public override void BeschreibungZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabBeschreibungZeichnen(this, tabItem, "#eeeeee");
    public override void LaborPlatteZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabLaborPlatteZeichnen(this, tabItem, "#eeeeee");
    public override void SimulationZeichnen(TabItem tabItem) => TabZeichnen.TabZeichnen.TabSimulationZeichnen(this, tabItem, "#eeeeee");
}