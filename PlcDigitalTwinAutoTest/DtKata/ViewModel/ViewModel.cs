using System;
using System.Net.Mime;
using System.Windows;
using System.Windows.Controls;
using BasePlcDtAt;
using DtKata.Model;
using LibDatenstruktur;

namespace DtKata.ViewModel;

public class ViewModel : BasePlcDtAt.BaseViewModel.ViewModel
{

    public enum WpfObjects
    {
        Dummy1 = 0, // die ersten zehn
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
        S8 = 28,

    }

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

        FensterTitel = Model.VersionLokal;
    }

    protected override void ViewModelAufrufTaster(Enum tasterId, bool gedrueckt)
    {
        switch (tasterId)
            {
                case WpfObjects.S1: _kata.S1 = gedrueckt; break;
                case WpfObjects.S2:

                    break;




                default: throw new ArgumentOutOfRangeException(nameof(tasterId));
            }


    }
    protected override void ViewModelAufrufSchalter(short schalterId)
    {
        //
    }

    public override void BetriebsartProjektChanged(object sender, SelectionChangedEventArgs e)
    {
        //throw new System.NotImplementedException();
    }

    public override void PlcButtonClick(object sender, RoutedEventArgs e)
    {
        //throw new System.NotImplementedException();
    }

    public override void PlotterButtonClick(object sender, RoutedEventArgs e)
    {
        //throw new System.NotImplementedException();
    }

    public void SetGridSichtbar(bool b) => GridSichtbar = b;
    public void AlleTabZeichnen(BaseWindow baseWindow)
    {
        GridBeschreibung = baseWindow.FindName("Grid0") as Grid;
        GridLaborPlatte = baseWindow.FindName("Grid1") as Grid;
        GridSimulation = baseWindow.FindName("Grid2") as Grid;
        GridAutoTest = baseWindow.FindName("Grid3") as Grid;

        TabZeichnen.TabZeichnen.TabBeschreibungZeichnen(GridBeschreibung, GridSichtbar);
        TabZeichnen.TabZeichnen.TabLaborPlatteZeichnen(GridLaborPlatte, GridSichtbar);
        TabZeichnen.TabZeichnen.TabSimulationZeichnen(GridSimulation, GridSichtbar);
        TabZeichnen.TabZeichnen.TabAutoTestZeichnen(GridAutoTest, GridSichtbar);
    }
}