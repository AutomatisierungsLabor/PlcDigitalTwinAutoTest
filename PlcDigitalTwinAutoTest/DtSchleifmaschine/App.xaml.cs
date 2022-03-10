using BasePlcDtAt;
using DtSchleifmaschine.Model;
using DtSchleifmaschine.ViewModel;
using LibDatenstruktur;
using System.Threading;

namespace DtSchleifmaschine;

public partial class App 
{
    private readonly CancellationTokenSource _cancellationTokenSource = new();

    public App()
    {
        var datenstruktur = new Datenstruktur();
        datenstruktur.SetVersionLokal("Schleifmaschine V3.0");
        datenstruktur.SetVorbeitungId("418");

        var modelSchleifmaschine = new ModelSchleifmaschine(datenstruktur, _cancellationTokenSource);
        var vmSchleifmaschine = new VmSchleifmaschine(modelSchleifmaschine, datenstruktur, _cancellationTokenSource);
        var baseWindow = new BaseWindow(vmSchleifmaschine, datenstruktur, (int)Contracts.WpfBase.TabSimulation, _cancellationTokenSource);

        baseWindow.Show();
    }
}