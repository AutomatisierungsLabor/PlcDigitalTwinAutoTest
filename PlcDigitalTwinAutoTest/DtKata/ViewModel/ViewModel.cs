using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DtKata.Model;
using LibDatenstruktur;

namespace DtKata.ViewModel;
public enum WpfObjects
{
    P1 = 11,
    P2 = 12,
    P3 = 13,
    P4 = 14,
    P5 = 15,
    P6 = 16,
    P7 = 17,
    P8 = 18,

    S1 = 21,
    S2 = 22,
    S3 = 23,
    S4 = 24,
    S5 = 25,
    S6 = 26,
    S7 = 27,
    S8 = 28
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

        FensterTitel = Datenstruktur.LokaleVersion;

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
    public override void PlotterButtonClick(object sender, RoutedEventArgs e) { }
    public override void BeschreibungZeichnen(Grid grid) => TabZeichnen.TabZeichnen.TabBeschreibungZeichnen(grid, GridSichtbar, "#eeeeee");
    public override void LaborPlatteZeichnen(Grid grid) => TabZeichnen.TabZeichnen.TabLaborPlatteZeichnen(grid, GridSichtbar, "#eeeeee");
    public override void SimulationZeichnen(Grid grid) => TabZeichnen.TabZeichnen.TabSimulationZeichnen(grid, "#eeeeee");
}