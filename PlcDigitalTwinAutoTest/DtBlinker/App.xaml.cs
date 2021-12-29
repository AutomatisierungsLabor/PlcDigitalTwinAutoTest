using DtBlinker.Model;
using LibDatenstruktur;

namespace DtBlinker;

public partial class App
{
    public ModelBlinker ModelBlinker { get; set; }

    public App()
    {
        var datenstruktur = new Datenstruktur();

        ModelBlinker = new ModelBlinker(datenstruktur);
        ModelBlinker.SetVersionLokal("Blinker" + " " + "V3.0");

        var vmBlinker = new ViewModel.VmBlinker(ModelBlinker, datenstruktur);

        var baseWindow = new BasePlcDtAt.BaseWindow(vmBlinker, datenstruktur, (int)BasePlcDtAt.BaseViewModel.VmBase.WpfBase.TabSimulation);
        baseWindow.Show();
    }
}