using BasePlcDtAt;
using LibDatenstruktur;
using System.Threading;
using DtLap2018_4_Niveauregelung.Model;
using DtLap2018_4_Niveauregelung.ViewModel;

namespace DtLap2018_4_Niveauregelung;
public partial class App
{
    private readonly CancellationTokenSource _cancellationTokenSource = new();
    public App()
    {
        var datenstruktur = new Datenstruktur();
        datenstruktur.SetVersionLokal("LAP 2018/4 V3.0");
        datenstruktur.SetVorbeitungId("570");

        var modelLap2018 = new ModelLap2018(datenstruktur, _cancellationTokenSource);
        var vmLap2018 = new VmLap2018(modelLap2018, datenstruktur, _cancellationTokenSource);
        var baseWindow = new BaseWindow(vmLap2018, datenstruktur, (int)Contracts.WpfBase.TabSimulation, _cancellationTokenSource);

        baseWindow.Show();
    }
}