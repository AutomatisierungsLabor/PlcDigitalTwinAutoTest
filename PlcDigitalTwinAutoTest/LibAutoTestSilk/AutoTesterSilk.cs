using System;
using Contracts;
using LibAutoTestSilk.ViewModel;
using LibConfigPlc;
using LibDatenstruktur;
using LibPlcTestautomat;
using SoftCircuits.Silk;
using System.IO;
using System.Threading;

namespace LibAutoTestSilk;

public class AutoTesterSilk
{
    public Silk.Silk Silk { get; set; }

    private readonly AutoTesterWindow _autoTesterWindow;
    private readonly VmAutoTesterSilk _vmAutoTesterSilk;
    private readonly Datenstruktur _datenstruktur;
    private readonly ConfigPlc _configPlc;
    private readonly TestAutomat _testAutomat;
    private DirectoryInfo _projektOrdner;
    private CompiledProgram _compiledProgram;
    private readonly CancellationTokenSource _cancellationTokenSource;

    public AutoTesterSilk(Datenstruktur datenstruktur, ConfigPlc configPlc, TestAutomat testAutomat, Action closeWindow, CancellationTokenSource cancellationTokenSource)
    {
        _datenstruktur = datenstruktur;
        _configPlc = configPlc;
        _testAutomat = testAutomat;
        _cancellationTokenSource = cancellationTokenSource;

        Silk = new Silk.Silk();
        _vmAutoTesterSilk = new VmAutoTesterSilk(cancellationTokenSource);
        _autoTesterWindow = new AutoTesterWindow(_vmAutoTesterSilk, closeWindow);

        _testAutomat.SetReferenzen(_vmAutoTesterSilk.ZeilenNummerDataGrid);
        _testAutomat.SetCallbackDatagridUpdaten(_vmAutoTesterSilk.UpdateDataGrid);
    }
    public void SetProjekt(DirectoryInfo ordnerAktuellesProjekt)
    {
        _projektOrdner = ordnerAktuellesProjekt;
        _vmAutoTesterSilk.DataGridBeschriften(ordnerAktuellesProjekt, _configPlc);
    }
    public void AutoTestStarten()
    {
        Compiler compiler;
        bool compilerlaufErfolgreich;

        AutoTestFensterOeffnen();

        Silk.ReferenzenUebergeben(_vmAutoTesterSilk, _datenstruktur, _testAutomat);

        _testAutomat.InfoAnzeigen("", TestAnzeige.CompilerStart, "");
        _testAutomat.FuncRestartStopwatch();

        (compilerlaufErfolgreich, compiler, _compiledProgram) = Silk.Compile(Path.Combine(_projektOrdner.ToString(), "test.ssc", ""));

        if (compilerlaufErfolgreich)
        {
            _testAutomat.InfoAnzeigen($"{_testAutomat.GetElapsedMilliseconds()}ms", TestAnzeige.CompilerErfolgreich, "");
            _testAutomat.FuncRestartStopwatch();

            System.Threading.Tasks.Task.Run(SilkTask,_cancellationTokenSource.Token);
        }
        else
        {
            foreach (var error in compiler.Errors) _testAutomat.InfoAnzeigen($"{_testAutomat.GetElapsedMilliseconds()}ms", TestAnzeige.CompilerError, error.ToString());
        }
    }
    private void SilkTask() => Silk.RunProgram(_compiledProgram);
    public void AutoTestFensterOeffnen()
    {
        _vmAutoTesterSilk.DataGridZeilen.Clear();
        _testAutomat.ResetZeilenNummer();
        _autoTesterWindow.Show();
    }
}