using System.Windows;
using System.Windows.Controls;
using LibDatenstruktur;

namespace DtKata.ViewModel;

public class ViewModel : BasePlcDtAt.BaseViewModel.ViewModel
{
    private DtKata.TabZeichnen.TabZeichnen _tabZeichnen;

    public ViewModel()
    {
        
 SichtbarEin[(int)WpfObjects.TabLaborplatte] = Visibility.Collapsed;
        SichtbarEin[(int)WpfObjects.TabSimulation] = Visibility.Visible;
        SichtbarEin[(int)WpfObjects.TabAutoTest] = Visibility.Visible;
        SichtbarEin[(int)WpfObjects.BtnPlcAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfObjects.BtnPlottAnzeigen] = Visibility.Visible;
        SichtbarEin[(int)WpfObjects.ErrorAnzeige] = Visibility.Visible;

        FensterTitel = "ölsadkjf";

        
        /*
        TabZeichnen.TabZeichnen.TabBeschreibungZeichnen(GridBeschreibung, GridSichtbar);
        TabZeichnen.TabZeichnen.TabLaborPlatteZeichnen(GridLaborPlatte, GridSichtbar);
        TabZeichnen.TabZeichnen.TabSimulationZeichnen(GridSimulation, GridSichtbar);
        TabZeichnen.TabZeichnen.TabAutoTestZeichnen(GridAutoTest, GridSichtbar);
        */
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
}