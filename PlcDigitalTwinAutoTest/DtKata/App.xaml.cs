using DtKata.Model;
using LibConfigPlc;
using LibDatenstruktur;

namespace DtKata;

public partial class App
{
    public Datenstruktur Datenstruktur { get; set; }
    public Config ConfigPlc { get; set; }
    public Kata Kata { get; set; }

    public App()
    {
        Datenstruktur = new Datenstruktur();

        ConfigPlc = new Config("/ConfigPlc");
        
        Kata = new Kata(Datenstruktur);
        Kata.SetVersionLokal("Kata" + " " + "V3.0");

        var viewModel = new ViewModel.ViewModel(Kata, Datenstruktur);

        var baseWindow = new BasePlcDtAt.BaseWindow(viewModel);
        baseWindow.Show();

        viewModel.AlleTabZeichnen(baseWindow);
    }
}