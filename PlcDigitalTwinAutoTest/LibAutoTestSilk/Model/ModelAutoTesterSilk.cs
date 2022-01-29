using LibAutoTestSilk.TestAutomat;
using LibAutoTestSilk.ViewModel;
using LibConfigPlc;
using LibDatenstruktur;
using SoftCircuits.Silk;
using System.Diagnostics;
using System.Threading.Tasks;

namespace LibAutoTestSilk.Model;

public class ModelAutoTesterSilk
{
    public Silk.Silk Silk { get; set; }
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

        Silk = new Silk.Silk();
    }
    public void AutoTestStarten()
    {
        Compiler compiler;
        SilkStopwatch = new Stopwatch();

        Silk.ReferenzenUebergeben(_vmSilkAutoTester, Datenstruktur, SilkStopwatch);

        _vmSilkAutoTester.DataGridZeilen.Add(new DataGridZeile(
            _vmSilkAutoTester.ZeilenNummerDataGrid++,
            "0",
            TestAnzeige.CompilerStart,
            " ",
            " ",
            " ",
            " "));

        SilkStopwatch.Start();

        (_compilerlaufErfolgreich, compiler, _compiledProgram) = Silk.Compile(@$"{_autoTesterWindow.OrdnerAktuellesProjekt}\test.ssc");


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

            Task.Run(TestRunnerTask);
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
        if (_compilerlaufErfolgreich) Silk.RunProgram(_compiledProgram);
    }
    public void EinzelnerSchrittAusfuehren() => Silk.EinzelnerSchrittAusfuehren();
    public void SetBetriebsart(bool b) => Silk.SetBetriebsart(b);
}