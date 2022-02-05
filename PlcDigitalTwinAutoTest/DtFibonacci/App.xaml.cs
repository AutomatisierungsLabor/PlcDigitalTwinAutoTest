using BasePlcDtAt;
using DtFibonacci.Model;
using DtFibonacci.ViewModel;
using LibDatenstruktur;
using System.Threading;

namespace DtFibonacci;

public partial class App
{
    private readonly CancellationTokenSource _cancellationTokenSource = new();

    public App()
    {
        var datenstruktur = new Datenstruktur();
        datenstruktur.SetVersionLokal("Fibonacci V3.0");

        var modelFibonacci = new ModelFibonacci(datenstruktur, _cancellationTokenSource);
        var vmFibonacci = new VmFibonacci(modelFibonacci, datenstruktur, _cancellationTokenSource);
        var baseWindow = new BaseWindow(vmFibonacci, datenstruktur, (int)Contracts.WpfBase.TabSimulation, _cancellationTokenSource);

        baseWindow.Show();
    }
}