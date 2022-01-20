using DtLinearachse.Model;
using DtLinearachse.ViewModel;
using LibDatenstruktur;

namespace DtLinearachse;

public partial class App
{
    public ModelLinearachse ModelLinearachse { get; set; }
    public App()
    {
        var datenstruktur = new Datenstruktur();

        ModelLinearachse = new ModelLinearachse(datenstruktur);
        ModelLinearachse.SetVersionLokal("Linearachse" + " " + "V3.0");

        var vmLinearachse = new VmLinearachse(ModelLinearachse, datenstruktur);

        var baseWindow = new BasePlcDtAt.BaseWindow(vmLinearachse, datenstruktur, (int)BasePlcDtAt.BaseViewModel.VmBase.WpfBase.TabLaborplatte);
        baseWindow.Show();
    }
}