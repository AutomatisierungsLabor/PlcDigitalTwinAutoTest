using System.Diagnostics;
using System.Threading;
using LibAutoTestSilk.TestAutomat;
using LibAutoTestSilk.ViewModel;
using LibConfigPlc;
using LibDatenstruktur;
using SoftCircuits.Silk;

namespace LibAutoTestSilk.Model;

public class ModelAutoTesterSilk
{
    public Datenstruktur Datenstruktur { get; set; }
    public ConfigPlc ConfigPlc { get; set; }
    public Stopwatch SilkStopwatch { get; set; }


    private bool _compilerlaufErfolgreich;
    private CompiledProgram _compiledProgram;
    private readonly AutoTesterWindow _autoTesterWindow;
    private readonly VmAutoTesterSilk _vmSilkAutoTester;

    public ModelAutoTesterSilk(AutoTesterWindow autoTesterWindow, Datenstruktur datenstruktur, ConfigPlc configPlc, VmAutoTesterSilk vmSilkAutoTester)
    {
        _autoTesterWindow = autoTesterWindow;
        Datenstruktur = datenstruktur;
        ConfigPlc = configPlc;
        _vmSilkAutoTester = vmSilkAutoTester;

        System.Threading.Tasks.Task.Run(ModelTask);
    }
    internal void ModelTask()
    {

        while (true)
        {

            Thread.Sleep(10);
        }
        // ReSharper disable once FunctionNeverReturns
    }
    public void AutoTestStarten()
    {
        Compiler compiler;
        SilkStopwatch = new Stopwatch();

        Silk.Silk.ReferenzenUebergeben(_vmSilkAutoTester, Datenstruktur, SilkStopwatch);

        _vmSilkAutoTester.DataGridZeilen.Add(new DataGridZeile(
            _vmSilkAutoTester.ZeilenNummerDataGrid++,
            "0",
            TestAnzeige.CompilerStart,
            " ",
            " ",
            " ",
            " "));

        SilkStopwatch.Start();

        (_compilerlaufErfolgreich, compiler, _compiledProgram) = Silk.Silk.Compile(@$"{_autoTesterWindow.OrdnerAktuellesProjekt}\test.ssc");


        if (_compilerlaufErfolgreich)
        {
            _vmSilkAutoTester.DataGridZeilen.Add(new DataGridZeile(
                _vmSilkAutoTester.ZeilenNummerDataGrid++,
                  $"{SilkStopwatch.ElapsedMilliseconds}ms",
              TestAnzeige.CompilerErfolgreich,
                " ",
                " ",
                " ",
                " "));

            System.Threading.Tasks.Task.Run(TestRunnerTask);
        }
        else
        {
            foreach (var error in compiler.Errors)
            {
                _vmSilkAutoTester.DataGridZeilen.Add(new DataGridZeile(
                    _vmSilkAutoTester.ZeilenNummerDataGrid++,
                     $"{SilkStopwatch.ElapsedMilliseconds}ms",
                    TestAnzeige.CompilerError,
                    error.ToString(),
                    " ",
                    " ",
                    " "));
            }
        }
    }


    private void TestRunnerTask()
    {
        SilkStopwatch.Restart();
        if (_compilerlaufErfolgreich) Silk.Silk.RunProgram(_compiledProgram);
    }

}