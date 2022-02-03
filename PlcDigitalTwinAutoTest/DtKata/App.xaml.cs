using BasePlcDtAt;
using DtKata.Model;
using DtKata.ViewModel;
using LibDatenstruktur;
using System.Threading;

namespace DtKata;
public partial class App
{
    public ModelKata ModelKata { get; set; }
    private readonly CancellationTokenSource _cancellationTokenSource = new();
    public App()
    {
        var datenstruktur = new Datenstruktur();

        ModelKata = new ModelKata(datenstruktur, _cancellationTokenSource);
        ModelKata.SetVersionLokal("Kata" + " " + "V3.0");

        var vmKata = new VmKata(ModelKata, datenstruktur, _cancellationTokenSource);

        var baseWindow = new BaseWindow(vmKata, datenstruktur, (int)Contracts.WpfBase.TabSimulation, _cancellationTokenSource);
        baseWindow.Show();
    }
}