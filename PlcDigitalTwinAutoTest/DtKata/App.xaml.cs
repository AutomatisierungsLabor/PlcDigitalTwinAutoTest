using DtKata.Model;
using LibDatenstruktur;

namespace DtKata;
public partial class App
{
    public ModelKata ModelKata { get; set; }
    public App()
    {
        var datenstruktur = new Datenstruktur();

        ModelKata = new ModelKata(datenstruktur);
        ModelKata.SetVersionLokal("Kata" + " " + "V3.0");

        var vmKata = new ViewModel.VmKata(ModelKata, datenstruktur);

        var baseWindow = new BasePlcDtAt.BaseWindow(vmKata, datenstruktur, (int)BasePlcDtAt.BaseViewModel.VmBase.WpfBase.TabSimulation);
        baseWindow.Show();
    }
}