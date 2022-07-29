using BasePlcDtAt;
using DtLap2010_3_Ofentuersteuerung.Model;
using LibDatenstruktur;
using System.Threading;

namespace DtLap2010_3_Ofentuersteuerung;

public partial class App
{
    private readonly CancellationTokenSource _cancellationTokenSource = new();

    public App()
    {
        var datenstruktur = new Datenstruktur();
        datenstruktur.SetVersionLokal("LAP 2010/3 Ofentuersteuerung V3.0");
        datenstruktur.SetVorbeitungId("579");

        var modelLap2010 = new ModelLap2010(datenstruktur, _cancellationTokenSource);
        var vmLap2010 = new ViewModel.VmLap2010(modelLap2010, datenstruktur, _cancellationTokenSource);
        var baseWindow = new BaseWindow(vmLap2010, datenstruktur, (int)Contracts.WpfBase.TabSimulation, _cancellationTokenSource)
        {
            Height = 630,
            Width = 1120
        };

        baseWindow.Show();
    }
}