using DtBlinker.Model;
using LibConfigPlc;
using LibDatenstruktur;

namespace DtBlinker;

public partial class App
{
    public Datenstruktur Datenstruktur { get; set; }
    public ConfigPlc ConfigPlc { get; set; }
    public Blinker Blinker { get; set; }
    public App()
    {

        Blinker = new Blinker(Datenstruktur);
        Blinker.SetVersionLokal("Blinker" + " " + "V3.0");


        var viewModel = new ViewModel.ViewModel(Blinker, Datenstruktur);

        var baseWindow = new BasePlcDtAt.BaseWindow(viewModel);
        baseWindow.Show();
    }
}