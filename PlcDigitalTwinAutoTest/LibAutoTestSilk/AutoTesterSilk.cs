using Contracts;
using LibAutoTestSilk.ViewModel;
using LibConfigDt;
using LibDatenstruktur;
using LibPlcTestautomat;
using SoftCircuits.Silk;
using System;
using System.IO;
using System.Threading;

namespace LibAutoTestSilk;

public class AutoTesterSilk
{
    public Silk.Silk Silk { get; set; }

    private readonly AutoTesterWindow _autoTesterWindow;
    private readonly VmAutoTesterSilk _vmAutoTesterSilk;
    private readonly Datenstruktur _datenstruktur;
    private readonly ConfigDt _configDt;
    private readonly TestAutomat _testAutomat;
    private DirectoryInfo _projektOrdner;
    private CompiledProgram _compiledProgram;
    private readonly CancellationTokenSource _cancellationTokenSource;

    public AutoTesterSilk(Datenstruktur datenstruktur, ConfigDt configPlc, TestAutomat testAutomat, Action closeWindow, CancellationTokenSource cancellationTokenSource)
    {
        _datenstruktur = datenstruktur;
        _configDt = configPlc;
        _testAutomat = testAutomat;
        _cancellationTokenSource = cancellationTokenSource;

        Silk = new Silk.Silk();
        _vmAutoTesterSilk = new VmAutoTesterSilk(cancellationTokenSource.Token);
        _autoTesterWindow = new AutoTesterWindow(_vmAutoTesterSilk, cancellationTokenSource, closeWindow);

        _testAutomat.SetReferenzen(_vmAutoTesterSilk.ZeilenNummerDataGrid);
        _testAutomat.SetCallbackDatagridUpdaten(_vmAutoTesterSilk.UpdateDataGrid);
    }
    public void SetProjekt(DirectoryInfo ordnerAktuellesProjekt)
    {
        _projektOrdner = ordnerAktuellesProjekt;
        _vmAutoTesterSilk.DataGridBeschriften(ordnerAktuellesProjekt, _configDt);
    }
    public void AutoTestStarten()
    {
        Compiler compiler;
        bool compilerlaufErfolgreich;

        AutoTestFensterOeffnen();

        Silk.ReferenzenUebergeben(_vmAutoTesterSilk, _datenstruktur, _testAutomat);

        _testAutomat.InfoAnzeigen("", TestAnzeige.CompilerStart, "");
        _testAutomat.StopwatchRestart();

        (compilerlaufErfolgreich, compiler, _compiledProgram) = Silk.Compile(Path.Combine(_projektOrdner.ToString(), "test.ssc", ""));

        if (compilerlaufErfolgreich)
        {
            _testAutomat.InfoAnzeigen($"{_testAutomat.StopwatchGetElapsedMilliseconds()}ms", TestAnzeige.CompilerErfolgreich, "");
            _testAutomat.StopwatchRestart();

            System.Threading.Tasks.Task.Run(SilkTask, _cancellationTokenSource.Token);
        }
        else
        {
            foreach (var error in compiler.Errors) _testAutomat.InfoAnzeigen($"{_testAutomat.StopwatchGetElapsedMilliseconds()}ms", TestAnzeige.CompilerError, error.ToString());
        }
    }
    private void SilkTask() => Silk.RunProgram(_compiledProgram, _cancellationTokenSource.Token);
    public void AutoTestFensterOeffnen()
    {
        _vmAutoTesterSilk.DataGridZeilen.Clear();
        _testAutomat.ResetZeilenNummer();
        _autoTesterWindow.Show();
    }
}