using BasePlcDtAt;
using DtGetriebemotor.Model;
using DtGetriebemotor.ViewModel;
using LibDatenstruktur;
using System.Threading;

namespace DtGetriebemotor;

public partial class App
{
    private readonly CancellationTokenSource _cancellationTokenSource = new();

    public App()
    {
        var datenstruktur = new Datenstruktur();
        datenstruktur.SetVersionLokal("Getriebemotor" + " " + "V3.0");

        var modelGetriebemotor = new ModelGetriebemotor(datenstruktur, _cancellationTokenSource);
        var vmGetriebemotor = new VmGetriebemotor(modelGetriebemotor, datenstruktur, _cancellationTokenSource);
        var baseWindow = new BaseWindow(vmGetriebemotor, datenstruktur, (int)Contracts.WpfBase.TabLaborplatte, _cancellationTokenSource);

        baseWindow.Show();
    }
}