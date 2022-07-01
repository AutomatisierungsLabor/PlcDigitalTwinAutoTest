using System.Threading;
using BasePlcDtAt;
using DtAmpelVerbania.Model;
using DtAmpelVerbania.ViewModel;
using LibDatenstruktur;

namespace DtAmpelVerbania;

public partial class App
{
    private readonly CancellationTokenSource _cancellationTokenSource = new();

    public App()
    {
        var datenstruktur = new Datenstruktur();
        datenstruktur.SetVersionLokal("AmpelVerbania V3.0");
        datenstruktur.SetVorbeitungId("614");

        var modelAmpelVarbania = new ModelAmpelVarbania(datenstruktur, _cancellationTokenSource);
        var vmAmpelVarbania = new VmAmpelVerbania(modelAmpelVarbania, datenstruktur, _cancellationTokenSource);
        var baseWindow = new BaseWindow(vmAmpelVarbania, datenstruktur, (int)Contracts.WpfBase.TabSimulation, _cancellationTokenSource)
        {
            Height = 750,
            Width = 900
        };

        baseWindow.Show();
    }
}