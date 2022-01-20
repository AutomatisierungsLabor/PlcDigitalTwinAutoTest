using DtFibonacci.Model;
using LibDatenstruktur;

namespace DtFibonacci;

public partial class App
{
    public ModelFibonacci ModelFibonacci { get; set; }

    public App()
    {
        var datenstruktur = new Datenstruktur();

        ModelFibonacci = new ModelFibonacci(datenstruktur);
        ModelFibonacci.SetVersionLokal("Fibonacci" + " " + "V3.0");

        var vmFibonacci = new ViewModel.VmFibonacci(ModelFibonacci, datenstruktur);

        var baseWindow = new BasePlcDtAt.BaseWindow(vmFibonacci, datenstruktur, (int)BasePlcDtAt.BaseViewModel.VmBase.WpfBase.TabSimulation);
        baseWindow.Show();
    }
}