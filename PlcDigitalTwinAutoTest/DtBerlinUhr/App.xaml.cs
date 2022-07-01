using System.Threading;
using BasePlcDtAt;
using DtBerlinUhr.Model;
using DtBerlinUhr.ViewModel;
using LibDatenstruktur;

namespace DtBerlinUhr;

public partial class App
{
    private readonly CancellationTokenSource _cancellationTokenSource = new();

    public App()
    {
        var datenstruktur = new Datenstruktur();
        datenstruktur.SetVersionLokal("BerlinUhr V3.0");
        datenstruktur.SetVorbeitungId("625");

        var modelWordclock = new ModelBerlinUhr(datenstruktur, _cancellationTokenSource);
        var vmWordclock = new VmBerlinUhr(modelWordclock, datenstruktur, _cancellationTokenSource);
        var baseWindow = new BaseWindow(vmWordclock, datenstruktur, (int)Contracts.WpfBase.TabSimulation, _cancellationTokenSource)
        {
            Height = 750,
            Width = 1170
        };

        baseWindow.Show();
    }
}