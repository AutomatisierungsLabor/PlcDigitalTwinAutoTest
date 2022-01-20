using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DtLinearachse.Model;
using LibDatenstruktur;

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
    S11 = 51
}
public class VmLinearachse : BasePlcDtAt.BaseViewModel.VmBase
{
    private readonly ModelLinearachse _modelLinearachse;
    private LibWpf.LibWpf _libWpfTabBeschreibung;
    private LibWpf.LibWpf _libWpfLaborPlatte;
    private LibWpf.LibWpf _libWpfSimulation;

    public VmLinearachse(BasePlcDtAt.BaseModel.BaseModel model, Datenstruktur datenstruktur) : base(model, datenstruktur)
    {

        SichtbarEin[(int)WpfBase.TabBeschreibung] = Visibility.Collapsed;
        SichtbarEin[(int)WpfBase.TabLaborplatte] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.TabSimulation] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.TabAutoTest] = Visibility.Visible;

        SichtbarEin[(int)WpfBase.BtnPlcAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.BtnPlottAnzeigen] = Visibility.Visible;

        Text[(int)WpfObjects.S1] = "Start";

        _modelLinearachse = model as ModelLinearachse;
    }

    protected override void ViewModelAufrufThread()
    {
        if (_modelLinearachse == null) return;

        FensterTitel = PlcDaemon.PlcState.PlcBezeichnung + ": " + Datenstruktur.VersionsStringLokal;

        SichtbarkeitUmschalten(_modelLinearachse.S1, (int)WpfObjects.S1);

        FarbeUmschalten(_modelLinearachse.P1, 1, Brushes.LawnGreen, Brushes.White);

        ErrorAnzeigen();
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
            case WpfObjects.S9: _modelLinearachse.S9 = gedrueckt; break;

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
    public override void BeschreibungZeichnen(TabItem tabItem) => _libWpfTabBeschreibung = TabZeichnen.TabZeichnen.TabBeschreibungZeichnen(this, tabItem, "#eeeeee");
    public override void LaborPlatteZeichnen(TabItem tabItem) => _libWpfLaborPlatte = TabZeichnen.TabZeichnen.TabLaborPlatteZeichnen(this, tabItem, "#eeeeee");
    public override void SimulationZeichnen(TabItem tabItem)
    {
        _libWpfSimulation = TabZeichnen.TabZeichnen.TabSimulationZeichnen(this, tabItem, "#eeeeee");

    }
    private void ErrorAnzeigen()
    {
        _libWpfTabBeschreibung?.PlcError(PlcDaemon, Datenstruktur);
        _libWpfLaborPlatte?.PlcError(PlcDaemon, Datenstruktur);
        _libWpfSimulation?.PlcError(PlcDaemon, Datenstruktur);
    }

}