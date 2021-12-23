using DtKata.Model;
using LibConfigPlc;
using LibDatenstruktur;
using LibDisplayPlc;

namespace DtKata;

public partial class App
{
    public Datenstruktur Datenstruktur { get; set; }
    public ConfigPlc ConfigPlc { get; set; }
    public Kata Kata { get; set; }
    public LibDisplayPlc.DisplayPlc DisplayPlc { get; set; }
    public App()
    {
        Datenstruktur = new Datenstruktur();

        ConfigPlc = new ConfigPlc("/ConfigPlc");
        
        Kata = new Kata(Datenstruktur);
        Kata.SetVersionLokal("Kata" + " " + "V3.0");

        DisplayPlc = new DisplayPlc(Datenstruktur, ConfigPlc);

        var viewModel = new ViewModel.ViewModel(Kata, Datenstruktur);

        var baseWindow = new BasePlcDtAt.BaseWindow(viewModel);
        baseWindow.Show();

        viewModel.AlleTabZeichnen(baseWindow);

        DisplayPlc.Oeffnen();
    }
}