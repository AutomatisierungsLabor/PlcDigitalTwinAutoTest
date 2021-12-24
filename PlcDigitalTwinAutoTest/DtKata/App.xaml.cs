using DtKata.Model;
using LibDatenstruktur;

namespace DtKata;

public partial class App
{
    public Kata Kata { get; set; }

    public App()
    {
        var datenstruktur = new Datenstruktur();
        Kata = new Kata(datenstruktur);
        Kata.SetVersionLokal("Kata" + " " + "V3.0");

        var viewModel = new ViewModel.ViewModel(Kata, datenstruktur);

        var baseWindow = new BasePlcDtAt.BaseWindow(viewModel, datenstruktur);
        baseWindow.Show();
    }
}