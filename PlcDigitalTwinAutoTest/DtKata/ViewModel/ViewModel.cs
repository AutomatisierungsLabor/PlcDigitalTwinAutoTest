using System.Net.Mime;
using System.Windows;
using System.Windows.Controls;
using BasePlcDtAt;
using LibDatenstruktur;

namespace DtKata.ViewModel;

public class ViewModel : BasePlcDtAt.BaseViewModel.ViewModel
{
    public ViewModel()
    {

        SichtbarEin[(int)WpfObjects.TabLaborplatte] = Visibility.Collapsed;
        SichtbarEin[(int)WpfObjects.TabSimulation] = Visibility.Visible;
        SichtbarEin[(int)WpfObjects.TabAutoTest] = Visibility.Visible;
        SichtbarEin[(int)WpfObjects.BtnPlcAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfObjects.BtnPlottAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfObjects.ErrorAnzeige] = Visibility.Visible;

        Text[(int)WpfObjects.ErrorVersionLokal] = "Lokale Projektversion";
        Text[(int)WpfObjects.ErrorVersionPlc] = "PLC Projektversion";


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
        var sdfs = baseWindow.FindName("Grid0");
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