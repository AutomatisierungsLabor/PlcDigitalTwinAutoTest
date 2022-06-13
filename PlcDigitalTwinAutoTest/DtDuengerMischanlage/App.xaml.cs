using System.Threading;
using BasePlcDtAt;
using DtDuengerMischanlage.Model;
using DtDuengerMischanlage.ViewModel;
using LibDatenstruktur;

namespace DtDuengerMischanlage;

public partial class App
{
    private readonly CancellationTokenSource _cancellationTokenSource = new();
    public App()
    {
        var datenstruktur = new Datenstruktur();
        datenstruktur.SetVersionLokal("Düngermischanlage V3.0");
        datenstruktur.SetVorbeitungId("623");

        var modelMischanlage= new ModelMischanlage(datenstruktur, _cancellationTokenSource);
        var vmMischanlage = new VmMischanlage(modelMischanlage, datenstruktur, _cancellationTokenSource);
        var baseWindow = new BaseWindow(vmMischanlage, datenstruktur, (int)Contracts.WpfBase.TabSimulation, _cancellationTokenSource);

        baseWindow.Show();
    }
}