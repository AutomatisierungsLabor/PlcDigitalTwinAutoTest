using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using DtKata.Model;
using DtKata.ViewModel;

namespace DtLap2018_1_Silosteuerung;

public partial class App
{
    private readonly CancellationTokenSource _cancellationTokenSource = new();
    public App()
    {
        var datenstruktur = new Datenstruktur();
        datenstruktur.SetVersionLokal("Kata V3.0");
        datenstruktur.SetVorbeitungId("610");

        var modelKata = new ModelKata(datenstruktur, _cancellationTokenSource);
        var vmKata = new VmKata(modelKata, datenstruktur, _cancellationTokenSource);
        var baseWindow = new BaseWindow(vmKata, datenstruktur, (int)Contracts.WpfBase.TabSimulation, _cancellationTokenSource);

        baseWindow.Show();
    }
}