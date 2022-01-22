using System.Threading;
using BasePlcDtAt;
using DtLinearachse.Model;
using DtLinearachse.ViewModel;
using LibDatenstruktur;

namespace DtLinearachse;

public partial class App
{
    public ModelLinearachse ModelLinearachse { get; set; }
    private readonly CancellationTokenSource _cancellationTokenSource = new();
    public App()
    {
        var datenstruktur = new Datenstruktur();

        ModelLinearachse = new ModelLinearachse(datenstruktur, _cancellationTokenSource);
        ModelLinearachse.SetVersionLokal("Linearachse" + " " + "V3.0");

        var vmLinearachse = new VmLinearachse(ModelLinearachse, datenstruktur, _cancellationTokenSource);

        var baseWindow = new BaseWindow(vmLinearachse, datenstruktur, (int)BasePlcDtAt.BaseViewModel.VmBase.WpfBase.TabLaborplatte, _cancellationTokenSource);
        baseWindow.Show();
    }
}