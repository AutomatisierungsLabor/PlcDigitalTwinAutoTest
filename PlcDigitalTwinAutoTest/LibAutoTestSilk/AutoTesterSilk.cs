using Contracts;
using LibAutoTestSilk.ViewModel;
using LibConfigPlc;
using LibDatenstruktur;
using LibPlcTestautomat;
using SoftCircuits.Silk;
using System.IO;

namespace LibAutoTestSilk;

public class AutoTesterSilk
{
    public Silk.Silk Silk { get; set; }

    private readonly AutoTesterWindow _autoTesterWindow;
    private readonly VmAutoTesterSilk _vmAutoTesterSilk;
    private readonly Datenstruktur _datenstruktur;
    private readonly ConfigPlc _configPlc;
    private readonly TestAutomat _testAutomat;
    private DirectoryInfo _ordnerAktuellesProjekt;
    private bool _compilerlaufErfolgreich;
    private CompiledProgram _compiledProgram;

    public AutoTesterSilk(Datenstruktur datenstruktur, ConfigPlc configPlc, TestAutomat testAutomat)
    {
        _datenstruktur = datenstruktur;
        _configPlc = configPlc;
        _testAutomat = testAutomat;

        _vmAutoTesterSilk = new VmAutoTesterSilk();
        _autoTesterWindow = new AutoTesterWindow(_vmAutoTesterSilk);

        _testAutomat.SetReferenzen(_vmAutoTesterSilk.ZeilenNummerDataGrid);
        _testAutomat.SetCallbackDatagridUpdaten(_vmAutoTesterSilk.DataGridNeueDaten);

        Silk = new Silk.Silk();
    }
    public void SetProjekt(DirectoryInfo ordnerAktuellesProjekt)
    {
        _ordnerAktuellesProjekt = ordnerAktuellesProjekt;
        _vmAutoTesterSilk.SetNeuesTestProjekt(ordnerAktuellesProjekt, _configPlc);
    }
    public void AutoTestFensterOeffnen() => _autoTesterWindow.Show();
    public void AutoTestStarten()
    {
        Compiler compiler;

        Silk.ReferenzenUebergeben(_vmAutoTesterSilk, _datenstruktur, _testAutomat);

        _testAutomat.InfoAnzeigen("", TestAnzeige.CompilerStart, "");

        _testAutomat.RestartStopwatch();

        (_compilerlaufErfolgreich, compiler, _compiledProgram) = Silk.Compile(Path.Combine(_ordnerAktuellesProjekt.ToString(), "test.ssc", ""));

        if (_compilerlaufErfolgreich)
        {
            _testAutomat.InfoAnzeigen($"{_testAutomat.GetElapsedMilliseconds()}ms", TestAnzeige.CompilerErfolgreich, "");

            _testAutomat.RestartStopwatch();
            Silk.RunProgram(_compiledProgram);
        }
        else
        {
            foreach (var error in compiler.Errors)
            {
                _testAutomat.InfoAnzeigen($"{_testAutomat.GetElapsedMilliseconds()}ms", TestAnzeige.CompilerError, error.ToString());
            }
        }
    }
}