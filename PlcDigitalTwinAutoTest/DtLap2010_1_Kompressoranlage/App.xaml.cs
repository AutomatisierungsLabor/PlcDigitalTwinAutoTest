using System.Threading;
using BasePlcDtAt;
using DtLap2010_1_Kompressoranlage.Model;
using LibDatenstruktur;

namespace DtLap2010_1_Kompressoranlage;

public partial class App
{
    private readonly CancellationTokenSource _cancellationTokenSource = new();
    public App()
    {
        var datenstruktur = new Datenstruktur();
        datenstruktur.SetVersionLokal("LAP 2010/1 Kompressoranlage V3.0");

        var modelKata = new ModelLap2010(datenstruktur, _cancellationTokenSource);
        var vmLap2010 = new ViewModel.VmLap2010(modelKata, datenstruktur, _cancellationTokenSource);
        var baseWindow = new BaseWindow(vmLap2010, datenstruktur, (int)Contracts.WpfBase.TabSimulation, _cancellationTokenSource);

        baseWindow.Show();
    }
}