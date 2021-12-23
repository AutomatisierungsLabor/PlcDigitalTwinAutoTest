using DtBlinker.Model;
using LibConfigPlc;
using LibDatenstruktur;
using LibDisplayPlc;

namespace DtBlinker;

public partial class App
{
    public Datenstruktur Datenstruktur { get; set; }
    public ConfigPlc ConfigPlc { get; set; }
    public Blinker Blinker { get; set; }
    public DisplayPlc DisplayPlc { get; set; }
    public App()
    {
        Datenstruktur = new Datenstruktur();

        ConfigPlc = new ConfigPlc("/ConfigPlc");

        Blinker = new Blinker(Datenstruktur);
        Blinker.SetVersionLokal("Blinker" + " " + "V3.0");

        DisplayPlc = new DisplayPlc(Datenstruktur, ConfigPlc);

        var viewModel = new ViewModel.ViewModel(Blinker, Datenstruktur);

        var baseWindow = new BasePlcDtAt.BaseWindow(viewModel);
        baseWindow.Show();

        viewModel.AlleTabZeichnen(baseWindow);

        DisplayPlc.Oeffnen();
    }
}