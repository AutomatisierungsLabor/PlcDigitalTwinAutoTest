using BasePlcDtAt;
using DtLinearachse.Model;
using DtLinearachse.ViewModel;
using LibDatenstruktur;
using System.Threading;

namespace DtLinearachse;

public partial class App
{
    private readonly CancellationTokenSource _cancellationTokenSource = new();
    public App()
    {
        var datenstruktur = new Datenstruktur();
        datenstruktur.SetVersionLokal("Linearachse V3.0");

        var modelLinearachse = new ModelLinearachse(datenstruktur, _cancellationTokenSource);
        var vmLinearachse = new VmLinearachse(modelLinearachse, datenstruktur, _cancellationTokenSource);
        var baseWindow = new BaseWindow(vmLinearachse, datenstruktur, (int)Contracts.WpfBase.TabLaborplatte, _cancellationTokenSource);

        baseWindow.Show();
    }
}