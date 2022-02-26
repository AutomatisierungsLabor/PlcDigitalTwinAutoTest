using BasePlcDtAt;
using DtBlinker.Model;
using DtBlinker.ViewModel;
using LibDatenstruktur;
using System.Threading;

namespace DtBlinker;

public partial class App
{
    private readonly CancellationTokenSource _cancellationTokenSource = new();

    public App()
    {
        var datenstruktur = new Datenstruktur();
        datenstruktur.SetVersionLokal("Blinker V3.0");
        datenstruktur.SetVorbeitungId("594");

        var modelBlinker = new ModelBlinker(datenstruktur, _cancellationTokenSource);
        var vmBlinker = new VmBlinker(modelBlinker, datenstruktur, _cancellationTokenSource);
        var baseWindow = new BaseWindow(vmBlinker, datenstruktur, (int)Contracts.WpfBase.TabSimulation, _cancellationTokenSource);

        baseWindow.Show();
    }
}