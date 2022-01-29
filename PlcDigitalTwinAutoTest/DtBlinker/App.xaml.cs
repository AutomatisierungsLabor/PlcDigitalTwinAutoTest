using System.Threading;
using BasePlcDtAt;
using DtBlinker.Model;
using DtBlinker.ViewModel;
using LibDatenstruktur;

namespace DtBlinker;

public partial class App
{
    public ModelBlinker ModelBlinker { get; set; }
    private readonly CancellationTokenSource _cancellationTokenSource = new();

    public App()
    {
        var datenstruktur = new Datenstruktur();

        ModelBlinker = new ModelBlinker(datenstruktur, _cancellationTokenSource);
        ModelBlinker.SetVersionLokal("Blinker" + " " + "V3.0");

        var vmBlinker = new VmBlinker(ModelBlinker, datenstruktur, _cancellationTokenSource);

        var baseWindow = new BaseWindow(vmBlinker, datenstruktur, (int)BasePlcDtAt.BaseViewModel.VmBase.WpfBase.TabSimulation, _cancellationTokenSource);
        baseWindow.Show();
    }
}