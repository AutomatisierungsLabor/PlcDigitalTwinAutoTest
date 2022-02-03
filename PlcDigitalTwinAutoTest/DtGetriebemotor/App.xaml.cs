using BasePlcDtAt;
using DtGetriebemotor.Model;
using DtGetriebemotor.ViewModel;
using LibDatenstruktur;
using System.Threading;

namespace DtGetriebemotor;

public partial class App
{
    public ModelGetriebemotor ModelGetriebemotor { get; set; }
    private readonly CancellationTokenSource _cancellationTokenSource = new();
    public App()
    {
        var datenstruktur = new Datenstruktur();

        ModelGetriebemotor = new ModelGetriebemotor(datenstruktur, _cancellationTokenSource);
        ModelGetriebemotor.SetVersionLokal("Getriebemotor" + " " + "V3.0");

        var vmGetriebemotor = new VmGetriebemotor(ModelGetriebemotor, datenstruktur, _cancellationTokenSource);

        var baseWindow = new BaseWindow(vmGetriebemotor, datenstruktur, (int)Contracts.WpfBase.TabLaborplatte, _cancellationTokenSource);
        baseWindow.Show();
    }
}