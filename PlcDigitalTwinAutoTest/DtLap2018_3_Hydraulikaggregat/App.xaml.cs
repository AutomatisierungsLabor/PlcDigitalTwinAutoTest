using BasePlcDtAt;
using DtLap2018_3_Hydraulikaggregat.Model;
using DtLap2018_3_Hydraulikaggregat.ViewModel;
using LibDatenstruktur;
using System.Threading;

namespace DtLap2018_3_Hydraulikaggregat;

public partial class App
{
    private readonly CancellationTokenSource _cancellationTokenSource = new();
    public App()
    {
        var datenstruktur = new Datenstruktur();
        datenstruktur.SetVersionLokal("LAP 2018/3 Hydrauliaggregat V3.0");
        datenstruktur.SetVorbeitungId("567");

        var modelLap2018 = new ModelLap2018(datenstruktur, _cancellationTokenSource);
        var vmLap2018 = new VmLap2018(modelLap2018, datenstruktur, _cancellationTokenSource);
        var baseWindow = new BaseWindow(vmLap2018, datenstruktur, (int)Contracts.WpfBase.TabSimulation, _cancellationTokenSource)
        {
            Height = 1100
        };

        baseWindow.Show();
    }
}
