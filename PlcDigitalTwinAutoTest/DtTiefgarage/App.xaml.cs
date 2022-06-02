using System.Threading;
using BasePlcDtAt;
using DtTiefgarage.Model;
using DtTiefgarage.ViewModel;
using LibDatenstruktur;

namespace DtTiefgarage;

public partial class App
{
    private readonly CancellationTokenSource _cancellationTokenSource = new();

    public App()
    {
        var datenstruktur = new Datenstruktur();
        datenstruktur.SetVersionLokal("Tiefgarage V3.0");
        datenstruktur.SetVorbeitungId("566");

        var modelTiefgarage = new ModelTiefgarage(datenstruktur, _cancellationTokenSource);
        var vmTiefgarage = new VmTiefgarage(modelTiefgarage, datenstruktur, _cancellationTokenSource);
        var baseWindow = new BaseWindow(vmTiefgarage, datenstruktur, (int)Contracts.WpfBase.TabSimulation, _cancellationTokenSource);

        baseWindow.Show();
    }
}