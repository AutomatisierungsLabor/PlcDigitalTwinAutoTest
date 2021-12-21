using DtKata.Model;

namespace DtKata;

public partial class App
{
    public LibDatenstruktur.Datenstruktur Datenstruktur { get; set; }

    public App()
    {
        Datenstruktur = new LibDatenstruktur.Datenstruktur(1, 1, 0, 0);
       
        var kata = new Kata { VersionLokal = "Kata" + " " + "V2.0" };
        var viewModel = new ViewModel.ViewModel(kata, Datenstruktur);
        
        viewModel.SetGridSichtbar(true);

        kata.SetRefDatenstuktur(Datenstruktur);
        kata.ConfigPlc.SetPath("/ConfigPlc");

        var baseWindow = new BasePlcDtAt.BaseWindow(viewModel);
        baseWindow.Show();

        viewModel.AlleTabZeichnen(baseWindow);
    }
}