using DtBlinker.Model;
using LibDatenstruktur;

namespace DtBlinker;

public partial class App
{
    public Blinker Blinker { get; set; }

    public App()
    {
        var datenstruktur = new Datenstruktur();

        Blinker = new Blinker(datenstruktur);
        Blinker.SetVersionLokal("Blinker" + " " + "V3.0");

        var viewModel = new ViewModel.ViewModel(Blinker, datenstruktur);

        var baseWindow = new BasePlcDtAt.BaseWindow(viewModel, datenstruktur);
        baseWindow.Show();
    }
}