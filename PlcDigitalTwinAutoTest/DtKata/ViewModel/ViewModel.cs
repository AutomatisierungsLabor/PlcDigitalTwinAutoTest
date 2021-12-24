using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DtKata.Model;
using LibDatenstruktur;

namespace DtKata.ViewModel;
public enum WpfObjects
{
    P1 = 1,
    P2 = 2,
    P3 = 3,
    P4 = 4,
    P5 = 5,
    P6 = 6,
    P7 = 7,
    P8 = 8,

    S1 = 11,
    S2 = 12,
    S3 = 13,
    S4 = 14,
    S5 = 15,
    S6 = 16,
    S7 = 17,
    S8 = 18

}
public class ViewModel : BasePlcDtAt.BaseViewModel.ViewModel
{


    public ViewModel(BasePlcDtAt.BaseModel.Model model, Datenstruktur datenstruktur) : base(model, datenstruktur)
    {
        SichtbarEin[(int)WpfBase.TabLaborplatte] = Visibility.Collapsed;
        SichtbarEin[(int)WpfBase.TabSimulation] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.TabAutoTest] = Visibility.Visible;

        SichtbarEin[(int)WpfBase.BtnPlcAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.BtnPlottAnzeigen] = Visibility.Visible;

        _kata = model as Kata;
        /*

          SichtbarEin[(int)WpfBase.ErrorAnzeige] = Visibility.Visible;
          SichtbarEin[(int)WpfBase.ErrorVersionLokal] = Visibility.Visible;
          SichtbarEin[(int)WpfBase.ErrorVersionPlc] = Visibility.Visible;


          Text[(int)WpfObjects.ErrorVersionLokal] = "Lokale Projektversion";
          Text[(int)WpfObjects.ErrorVersionPlc] = "PLC Projektversion";
        */

        FensterTitel = "Nicht bekannt";
    }

    private readonly Kata _kata;
    protected override void ViewModelAufrufThread()
    {
        if (_kata == null) return;

        SichtbarkeitUmschalten(_kata.S1, (int)WpfObjects.S1);
        SichtbarkeitUmschalten(_kata.S2, (int)WpfObjects.S2);
        SichtbarkeitUmschalten(_kata.S3, (int)WpfObjects.S3);
        SichtbarkeitUmschalten(_kata.S4, (int)WpfObjects.S4);
        SichtbarkeitUmschalten(_kata.S5, (int)WpfObjects.S5);
        SichtbarkeitUmschalten(_kata.S6, (int)WpfObjects.S6);
        SichtbarkeitUmschalten(_kata.S7, (int)WpfObjects.S7);
        SichtbarkeitUmschalten(_kata.S8, (int)WpfObjects.S8);

        FarbeUmschalten(_kata.P1, 1, Brushes.LawnGreen, Brushes.White);
        FarbeUmschalten(_kata.P2, 2, Brushes.LawnGreen, Brushes.White);
        FarbeUmschalten(_kata.P3, 3, Brushes.LawnGreen, Brushes.White);
        FarbeUmschalten(_kata.P4, 4, Brushes.LawnGreen, Brushes.White);
        FarbeUmschalten(_kata.P5, 5, Brushes.Yellow, Brushes.White);
        FarbeUmschalten(_kata.P6, 6, Brushes.Yellow, Brushes.White);
        FarbeUmschalten(_kata.P7, 7, Brushes.Red, Brushes.White);
        FarbeUmschalten(_kata.P8, 8, Brushes.Red, Brushes.White);

        FensterTitel = Model.VersionLokal;
    }
    protected override void ViewModelAufrufTaster(Enum tasterId, bool gedrueckt)
    {
        switch (tasterId)
        {
            case WpfObjects.S1: _kata.S1 = gedrueckt; break;
            case WpfObjects.S2: _kata.S2 = gedrueckt; break;
            case WpfObjects.S3: _kata.S3 = !gedrueckt; break;
            case WpfObjects.S4: _kata.S4 = !gedrueckt; break;
            default: throw new ArgumentOutOfRangeException(nameof(tasterId));
        }
    }
    protected override void ViewModelAufrufSchalter(Enum schalterId)
    {
        switch (schalterId)
        {
            case WpfObjects.S5: _kata.S5 = !_kata.S5; break;
            case WpfObjects.S6: _kata.S6 = !_kata.S6; break;
            case WpfObjects.S7: _kata.S7 = !_kata.S7; break;
            case WpfObjects.S8: _kata.S8 = !_kata.S8; break;
            default: throw new ArgumentOutOfRangeException(nameof(schalterId));
        }
    }
    public override void BetriebsartProjektChanged(object sender, SelectionChangedEventArgs e)
    {
        if (sender is not TabControl tc) return;

        Datenstruktur.BetriebsartProjekt = tc.SelectedIndex switch
        {
            0 => BetriebsartProjekt.BeschreibungAnzeigen,
            1 => BetriebsartProjekt.LaborPlatte,
            2 => BetriebsartProjekt.Simulation,
            3 => BetriebsartProjekt.AutomatischerSoftwareTest,
            _ => Datenstruktur.BetriebsartProjekt
        };
    }
    public override void PlcButtonClick(object sender, RoutedEventArgs e)
    {
        //throw new System.NotImplementedException();
    }
    public override void PlotterButtonClick(object sender, RoutedEventArgs e)
    {
        //throw new System.NotImplementedException();
    }

    public override void BeschreibungZeichnen(Grid grid) => TabZeichnen.TabZeichnen.TabBeschreibungZeichnen(grid, GridSichtbar, "#eeeeee");

    public override void LaborPlatteZeichnen(Grid grid) => TabZeichnen.TabZeichnen.TabLaborPlatteZeichnen(grid, GridSichtbar, "#eeeeee");

    public override void SimulationZeichnen(Grid grid) => TabZeichnen.TabZeichnen.TabSimulationZeichnen(grid, GridSichtbar, "#eeeeee");

    public override void AutotestZeichnen(Grid grid) => TabZeichnen.TabZeichnen.TabAutoTestZeichnen(grid, GridSichtbar, "#eeeeee");


    // ReSharper disable once UnusedMember.Global
    public void SetGridSichtbar() => GridSichtbar = true;

}