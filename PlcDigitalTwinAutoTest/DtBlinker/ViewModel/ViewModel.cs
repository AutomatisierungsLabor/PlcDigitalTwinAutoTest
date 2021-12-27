using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DtBlinker.Model;
using LibDatenstruktur;

namespace DtBlinker.ViewModel;
public enum WpfObjects
{
    P1 = 11,

    S1 = 21,
    S2 = 22,
    S3 = 23,
    S4 = 24,
    S5 = 25
}
public class ViewModel : BasePlcDtAt.BaseViewModel.ViewModel
{
    public ViewModel(BasePlcDtAt.BaseModel.Model model, Datenstruktur datenstruktur) : base(model, datenstruktur)
    {
        SichtbarEin[(int)WpfBase.TabBeschreibung] = Visibility.Collapsed;
        SichtbarEin[(int)WpfBase.TabLaborplatte] = Visibility.Collapsed;
        SichtbarEin[(int)WpfBase.TabSimulation] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.TabAutoTest] = Visibility.Visible;

        SichtbarEin[(int)WpfBase.BtnPlcAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.BtnPlottAnzeigen] = Visibility.Visible;

        _blinker = model as Blinker;
        /*

          SichtbarEin[(int)WpfBase.ErrorAnzeige] = Visibility.Visible;
          SichtbarEin[(int)WpfBase.ErrorVersionLokal] = Visibility.Visible;
          SichtbarEin[(int)WpfBase.ErrorVersionPlc] = Visibility.Visible;


          Text[(int)WpfObjects.ErrorVersionLokal] = "Lokale Projektversion";
          Text[(int)WpfObjects.ErrorVersionPlc] = "PLC Projektversion";
        */

        FensterTitel = "Nicht bekannt";
    }
    private readonly Blinker _blinker;
    protected override void ViewModelAufrufThread()
    {
        if (_blinker == null) return;


        FensterTitel = Datenstruktur.LokaleVersion;

        SichtbarkeitUmschalten(_blinker.S1, (int)WpfObjects.S1);
        SichtbarkeitUmschalten(_blinker.S2, (int)WpfObjects.S2);
        SichtbarkeitUmschalten(_blinker.S3, (int)WpfObjects.S3);
        SichtbarkeitUmschalten(_blinker.S4, (int)WpfObjects.S4);
        SichtbarkeitUmschalten(_blinker.S5, (int)WpfObjects.S5);

        FarbeUmschalten(_blinker.P1, 1, Brushes.LawnGreen, Brushes.White);
    }
    protected override void ViewModelAufrufTaster(Enum tasterId, bool gedrueckt)
    {
        switch (tasterId)
        {
            case WpfObjects.S1: _blinker.S1 = gedrueckt; break;
            case WpfObjects.S2: _blinker.S2 = gedrueckt; break;
            case WpfObjects.S3: _blinker.S3 = !gedrueckt; break;
            case WpfObjects.S4: _blinker.S4 = !gedrueckt; break;
            case WpfObjects.S5: _blinker.S5 = !gedrueckt; break;

            default: throw new ArgumentOutOfRangeException(nameof(tasterId));
        }
    }
    protected override void ViewModelAufrufSchalter(Enum schalterId) { }
    public override void PlotterButtonClick(object sender, RoutedEventArgs e) { }
    public override void BeschreibungZeichnen(Grid grid) => TabZeichnen.TabZeichnen.TabBeschreibungZeichnen(grid, GridSichtbar, "#eeeeee");
    public override void LaborPlatteZeichnen(Grid grid) => TabZeichnen.TabZeichnen.TabLaborPlatteZeichnen(grid, GridSichtbar, "#eeeeee");
    public override void SimulationZeichnen(Grid grid) => TabZeichnen.TabZeichnen.TabSimulationZeichnen(grid, GridSichtbar, "#eeeeee");
}