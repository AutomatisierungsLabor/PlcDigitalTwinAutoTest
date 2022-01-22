﻿using System.Threading;
using BasePlcDtAt;
using DtFibonacci.Model;
using DtFibonacci.ViewModel;
using LibDatenstruktur;

namespace DtFibonacci;

public partial class App
{
    public ModelFibonacci ModelFibonacci { get; set; }
    private readonly CancellationTokenSource _cancellationTokenSource = new();

    public App()
    {
        var datenstruktur = new Datenstruktur();

        ModelFibonacci = new ModelFibonacci(datenstruktur, _cancellationTokenSource);
        ModelFibonacci.SetVersionLokal("Fibonacci" + " " + "V3.0");

        var vmFibonacci = new VmFibonacci(ModelFibonacci, datenstruktur, _cancellationTokenSource);

        var baseWindow = new BaseWindow(vmFibonacci, datenstruktur, (int)BasePlcDtAt.BaseViewModel.VmBase.WpfBase.TabSimulation, _cancellationTokenSource);
        baseWindow.Show();
    }
}