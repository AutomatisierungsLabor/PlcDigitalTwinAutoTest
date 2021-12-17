using DtKata.Model;
using LibDatenstruktur;

namespace DtKata;

public partial class App
{
    public LibDatenstruktur.Datenstruktur Datenstruktur { get; set; }
    private BasePlcDtAt.BaseWindow _baseWindow;
    public App()
    {
        Datenstruktur = new LibDatenstruktur.Datenstruktur();
        var viewModel = new ViewModel.ViewModel();
        var kata = new Kata { VersionLokal = "Kata" + " " + "V2.0" };


        viewModel.SetRefModel(kata);
        viewModel.SetRefDatenstruktur(Datenstruktur);
        viewModel.SetGridSichtbar(true);


        kata.SetRefDatenstuktur(Datenstruktur);
        kata.ConfigPlc.SetPath("/ConfigPlc");

        _baseWindow = new BasePlcDtAt.BaseWindow(viewModel);
        _baseWindow.Show();

        viewModel.AlleTabZeichnen(_baseWindow);
    }
}