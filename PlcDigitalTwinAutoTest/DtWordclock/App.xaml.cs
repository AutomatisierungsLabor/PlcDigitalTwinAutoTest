using System.Threading;
using BasePlcDtAt;
using DtWordclock.Model;
using DtWordclock.ViewModel;
using LibDatenstruktur;

namespace DtWordclock;

public partial class App
{
    private readonly CancellationTokenSource _cancellationTokenSource = new();

    public App()
    {
        var datenstruktur = new Datenstruktur();
        datenstruktur.SetVersionLokal("Wordclock V3.0");
        datenstruktur.SetVorbeitungId("571");

        var modelWordclock = new ModelWordclock(datenstruktur, _cancellationTokenSource);
        var vmWordclock = new VmWordclock(modelWordclock, datenstruktur, _cancellationTokenSource);
        var baseWindow = new BaseWindow(vmWordclock, datenstruktur, (int)Contracts.WpfBase.TabSimulation, _cancellationTokenSource)
        {
            Height = 1130,
            Width = 1450
        };

        baseWindow.Show();
    }
}