using System.Threading;
using BasePlcDtAt;
using DtLap2010_5_Pumpensteuerung.Model;
using LibDatenstruktur;

namespace DtLap2010_5_Pumpensteuerung;

public partial class App
{
    private readonly CancellationTokenSource _cancellationTokenSource = new();

    public App()
    {
        var datenstruktur = new Datenstruktur();
        datenstruktur.SetVersionLokal("LAP 2010/5 Pumpensteuerung V3.0");
        datenstruktur.SetVorbeitungId(581);

        var modelLap2010 = new ModelLap2010(datenstruktur, _cancellationTokenSource);
        var vmLap2010 = new ViewModel.VmLap2010(modelLap2010, datenstruktur, _cancellationTokenSource);
        var baseWindow = new BaseWindow(vmLap2010, datenstruktur, (int)Contracts.WpfBase.TabSimulation,
            _cancellationTokenSource);

        baseWindow.Show();
    }
}