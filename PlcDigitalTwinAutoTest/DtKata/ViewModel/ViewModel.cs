using System.Net.Mime;
using System.Windows;
using System.Windows.Controls;
using BasePlcDtAt;
using LibDatenstruktur;

namespace DtKata.ViewModel;

public class ViewModel : BasePlcDtAt.BaseViewModel.ViewModel
{

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
        S8 = 18,

    }

    public ViewModel()
    {

        SichtbarEin[(int)WpfBase.TabLaborplatte] = Visibility.Collapsed;
        SichtbarEin[(int)WpfBase.TabSimulation] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.TabAutoTest] = Visibility.Visible;

        SichtbarEin[(int)WpfBase.BtnPlcAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfBase.BtnPlottAnzeigen] = Visibility.Visible;
        /*

          SichtbarEin[(int)WpfBase.ErrorAnzeige] = Visibility.Visible;
          SichtbarEin[(int)WpfBase.ErrorVersionLokal] = Visibility.Visible;
          SichtbarEin[(int)WpfBase.ErrorVersionPlc] = Visibility.Visible;


          Text[(int)WpfObjects.ErrorVersionLokal] = "Lokale Projektversion";
          Text[(int)WpfObjects.ErrorVersionPlc] = "PLC Projektversion";
        */

        FensterTitel = "Nicht bekannt";
    }

    protected override void ViewModelAufrufThread()
    {
        if (Model == null) return;

        FensterTitel = Model.VersionLokal;
    }
    protected override void ViewModelAufrufTaster(short tasterId)
    {
        //
    }
    protected override void ViewModelAufrufSchalter(short schalterId)
    {
        //
    }
    public void SetRefDatenstruktur(Datenstruktur datenstruktur) => Datenstruktur = datenstruktur;
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