using System.Threading;
using BasePlcDtAt;
using DtParkhaus.Model;
using DtParkhaus.ViewModel;
using LibDatenstruktur;

namespace DtParkhaus;

public partial class App
{
    private readonly CancellationTokenSource _cancellationTokenSource = new();

    public App()
    {
        var datenstruktur = new Datenstruktur();
        datenstruktur.SetVersionLokal("Parkhaus V3.0");
        datenstruktur.SetVorbeitungId("596");

        var modelParkhaus = new ModelParkhaus(datenstruktur, _cancellationTokenSource);
        var vmParkhaus = new VmParkhaus(modelParkhaus, datenstruktur, _cancellationTokenSource);
        var baseWindow = new BaseWindow(vmParkhaus, datenstruktur, (int)Contracts.WpfBase.TabSimulation, _cancellationTokenSource);

        baseWindow.Show();
    }
}