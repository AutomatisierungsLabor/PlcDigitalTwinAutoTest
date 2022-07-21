using System.Threading;
using BasePlcDtAt;
using DtBehaeltersteuerung.Model;
using DtBehaeltersteuerung.ViewModel;
using LibDatenstruktur;

namespace DtBehaeltersteuerung;
public partial class App
{
    private readonly CancellationTokenSource _cancellationTokenSource = new();
    public App()
    {
        var datenstruktur = new Datenstruktur();
        datenstruktur.SetVersionLokal("Behaeltersteuerung V3.0");
        datenstruktur.SetVorbeitungId("565");

        var modelBehaeltersteuerung = new ModelBehaeltersteuerung(datenstruktur, _cancellationTokenSource);
        var vmBehaeltersteuerung = new VmBehaeltersteuerung(modelBehaeltersteuerung, datenstruktur, _cancellationTokenSource);
        var baseWindow = new BaseWindow(vmBehaeltersteuerung, datenstruktur, (int)Contracts.WpfBase.TabSimulation, _cancellationTokenSource)
        {
            Height = 900,
            Width = 1200
        };

        baseWindow.Show();
    }
}