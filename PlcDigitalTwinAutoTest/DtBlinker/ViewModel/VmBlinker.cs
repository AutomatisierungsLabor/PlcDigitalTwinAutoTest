using System;
using System.Net.Mime;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DtBlinker.Model;
using LibDatenstruktur;

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
    private LibWpf.LibWpf _libWpfTabBeschreibung;
    private LibWpf.LibWpf _libWpfLaborPlatte;
    private LibWpf.LibWpf _libWpfSimulation;


    public VmBlinker(BasePlcDtAt.BaseModel.BaseModel model, Datenstruktur datenstruktur) : base(model, datenstruktur)
    {
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

        FarbeUmschalten(_modelBlinker.P1, 1, Brushes.LawnGreen, Brushes.White);

        _libWpfTabBeschreibung?.PlcError(PlcDaemon, Datenstruktur);
        _libWpfLaborPlatte?.PlcError(PlcDaemon, Datenstruktur);
        _libWpfSimulation?.PlcError(PlcDaemon, Datenstruktur);
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
    public override void BeschreibungZeichnen(TabItem tabItem) => _libWpfTabBeschreibung = TabZeichnen.TabZeichnen.TabBeschreibungZeichnen(this, tabItem, "#eeeeee");
    public override void LaborPlatteZeichnen(TabItem tabItem) => _libWpfLaborPlatte = TabZeichnen.TabZeichnen.TabLaborPlatteZeichnen(this, tabItem, "#eeeeee");
    public override void SimulationZeichnen(TabItem tabItem) => _libWpfSimulation = TabZeichnen.TabZeichnen.TabSimulationZeichnen(this, tabItem, "#eeeeee");
}