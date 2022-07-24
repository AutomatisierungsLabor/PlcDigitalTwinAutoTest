using BasePlcDtAt;
using DtLap2010_2_Transportwagen.Model;
using LibDatenstruktur;
using System.Threading;

namespace DtLap2010_2_Transportwagen;

public partial class App
{
    private readonly CancellationTokenSource _cancellationTokenSource = new();
    public App()
    {
        var datenstruktur = new Datenstruktur();
        datenstruktur.SetVersionLokal("LAP 2010/2 Transportwagen V3.0");
        datenstruktur.SetVorbeitungId("578");

        var modelLap2010 = new ModelLap2010(datenstruktur, _cancellationTokenSource);
        var vmLap2010 = new ViewModel.VmLap2010(modelLap2010, datenstruktur, _cancellationTokenSource);
        var baseWindow = new BaseWindow(vmLap2010, datenstruktur, (int)Contracts.WpfBase.TabSimulation, _cancellationTokenSource)
        {  
            Height = 730,
            Width = 1100
        };

        baseWindow.Show();
    }
}