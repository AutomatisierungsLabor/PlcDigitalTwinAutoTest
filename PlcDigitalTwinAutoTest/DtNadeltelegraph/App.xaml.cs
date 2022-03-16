using BasePlcDtAt;
using DtNadeltelegraph.Model;
using DtNadeltelegraph.ViewModel;
using LibDatenstruktur;
using System.Threading;

namespace DtNadeltelegraph;
public partial class App
{
    private readonly CancellationTokenSource _cancellationTokenSource = new();
    public App()
    {
        var datenstruktur = new Datenstruktur();
        datenstruktur.SetVersionLokal("Nadeltelegraph V3.0");
        datenstruktur.SetVorbeitungId("575");

        var modelNadeltelegraph = new ModelNadeltelegraph(datenstruktur, _cancellationTokenSource);
        var vmNadeltelegraph = new VmNadeltelegraph(modelNadeltelegraph, datenstruktur, _cancellationTokenSource);
        var baseWindow = new BaseWindow(vmNadeltelegraph, datenstruktur, (int)Contracts.WpfBase.TabSimulation, _cancellationTokenSource);

        MainWindow!.Height = 1100;
        baseWindow.Show();
    }
}
