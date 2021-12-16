using System.Windows;
using DtKata.Model;
using LibDatenstruktur;

namespace DtKata.ViewModel;

public class ViewModel : BasePlcDtAt.BaseViewModel.ViewModel
{

    protected override void ViewModelKonstuktorZusatz()
    {
        SichtbarEin[(int)WpfObjects.TabLaborplatte] = Visibility.Collapsed;
        SichtbarEin[(int)WpfObjects.TabSimulation] = Visibility.Visible;
        SichtbarEin[(int)WpfObjects.TabAutoTest] = Visibility.Visible;

        FensterTitel = "ölsadkjf";
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


}