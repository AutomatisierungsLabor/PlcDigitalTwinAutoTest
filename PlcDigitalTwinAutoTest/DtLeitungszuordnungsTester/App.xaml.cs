using BasePlcDtAt;
using LibDatenstruktur;
using System.Threading;

namespace DtLeitungszuordnungsTester;

public partial class App
{
    private readonly CancellationTokenSource _cancellationTokenSource = new();

    public App()
    {
        var datenstruktur = new Datenstruktur();
        datenstruktur.SetVersionLokal("LeitungszuordnungsTester V3.0");
        datenstruktur.SetVorbeitungId("545");

        var modelLeitungszuordnungsTester = new Model.ModelLeitungszuordnungsTester(datenstruktur, _cancellationTokenSource);
        var vmLeitungszuordnungsTester = new ViewModel.VmLeitungszuordnungsTester(modelLeitungszuordnungsTester, datenstruktur, _cancellationTokenSource);
        var baseWindow = new BaseWindow(vmLeitungszuordnungsTester, datenstruktur, (int)Contracts.WpfBase.TabSimulation, _cancellationTokenSource);

        baseWindow.Show();
    }
}