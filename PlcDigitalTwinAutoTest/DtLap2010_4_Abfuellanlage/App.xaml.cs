using System.Threading;
using BasePlcDtAt;
using DtLap2010_4_Abfuellanlage.Model;
using LibDatenstruktur;

namespace DtLap2010_4_Abfuellanlage;

public partial class App
{
    private readonly CancellationTokenSource _cancellationTokenSource = new();

    public App()
    {
        var datenstruktur = new Datenstruktur();
        datenstruktur.SetVersionLokal("LAP 2010/4 Abfüllanlage V3.0");
        datenstruktur.SetVorbeitungId(580);

        var modelLap2010 = new ModelLap2010(datenstruktur, _cancellationTokenSource);
        var vmLap2010 = new ViewModel.VmLap2010(modelLap2010, datenstruktur, _cancellationTokenSource);
        var baseWindow = new BaseWindow(vmLap2010, datenstruktur, (int)Contracts.WpfBase.TabSimulation,
            _cancellationTokenSource);

        baseWindow.Show();
    }
}