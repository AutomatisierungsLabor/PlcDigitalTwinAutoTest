using System.Threading;
using BasePlcDtAt;
using DtVoltmeter.Model;
using DtVoltmeter.ViewModel;
using LibDatenstruktur;

namespace DtVoltmeter;

public partial class App
{
    private readonly CancellationTokenSource _cancellationTokenSource = new();

    public App()
    {
        var datenstruktur = new Datenstruktur();
        datenstruktur.SetVersionLokal("Voltmeter V3.0");
        datenstruktur.SetVorbeitungId("594");

        var modelBlinker = new ModelVoltmeter(datenstruktur, _cancellationTokenSource);
        var vmBlinker = new VmVoltmeter(modelBlinker, datenstruktur, _cancellationTokenSource);
        var baseWindow = new BaseWindow(vmBlinker, datenstruktur, (int)Contracts.WpfBase.TabSimulation, _cancellationTokenSource);

        baseWindow.Show();
    }
}