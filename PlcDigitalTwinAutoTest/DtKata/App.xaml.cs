using BasePlcDtAt;
using DtKata.Model;
using DtKata.ViewModel;
using LibDatenstruktur;
using System.Threading;

namespace DtKata;
public partial class App
{
    private readonly CancellationTokenSource _cancellationTokenSource = new();
    public App()
    {
        var datenstruktur = new Datenstruktur();
        datenstruktur.SetVersionLokal("Kata V3.0");

        var modelKata = new ModelKata(datenstruktur, _cancellationTokenSource);
        var vmKata = new VmKata(modelKata, datenstruktur, _cancellationTokenSource);
        var baseWindow = new BaseWindow(vmKata, datenstruktur, (int)Contracts.WpfBase.TabSimulation, _cancellationTokenSource);

        baseWindow.Show();
    }
}