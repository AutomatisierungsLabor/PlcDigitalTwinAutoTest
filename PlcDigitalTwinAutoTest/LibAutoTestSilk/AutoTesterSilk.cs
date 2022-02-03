using Contracts;
using LibAutoTestSilk.ViewModel;
using LibConfigPlc;
using LibDatenstruktur;
using LibPlcKommunikation;
using LibPlcTestautomat;
using SoftCircuits.Silk;
using System.IO;

namespace LibAutoTestSilk;

public class AutoTesterSilk
{
    public AutoTesterWindow AutoTesterWindow;
    public VmAutoTesterSilk VmAutoTesterSilk { get; set; }
    public Datenstruktur Datenstruktur { get; set; }
    public ConfigPlc ConfigPlc { get; set; }
    public TestAutomat TestAutomat { get; set; }
    public Silk.Silk Silk { get; set; }
    public DirectoryInfo OrdnerAktuellesProjekt { get; set; }
    public PlcDaemon PlcDaemon { get; set; }

    private bool _compilerlaufErfolgreich;
    private CompiledProgram _compiledProgram;


    public AutoTesterSilk(Datenstruktur datenstruktur, PlcDaemon plcDaemon, ConfigPlc configPlc, TestAutomat testAutomat)
    {
        Datenstruktur = datenstruktur;
        PlcDaemon = plcDaemon;
        ConfigPlc = configPlc;
        TestAutomat = testAutomat;

        VmAutoTesterSilk = new VmAutoTesterSilk();
        AutoTesterWindow = new AutoTesterWindow(VmAutoTesterSilk);

        TestAutomat.SetReferenzen(VmAutoTesterSilk.ZeilenNummerDataGrid);
        TestAutomat.SetCallbackDatagridUpdaten(VmAutoTesterSilk.UpdateDataGrid);
        Silk = new Silk.Silk();
    }
    public void SetProjekt(DirectoryInfo ordnerAktuellesProjekt)
    {
        OrdnerAktuellesProjekt = ordnerAktuellesProjekt;
        VmAutoTesterSilk.SetNeuesTestProjekt(ordnerAktuellesProjekt, ConfigPlc);
    }
    public void TestStarten()
    {
        AutoTesterWindow.Show();
        AutoTestStarten();
    }

    public void AutoTestStarten()
    {
        Compiler compiler;

        Silk.ReferenzenUebergeben(VmAutoTesterSilk, Datenstruktur, TestAutomat);

        VmAutoTesterSilk.DataGridKommentarAnzeigen(VmAutoTesterSilk.ZeilenNummerDataGrid++, "0", TestAnzeige.CompilerStart, "");

        TestAutomat.RestartStopwatch();

        (_compilerlaufErfolgreich, compiler, _compiledProgram) = Silk.Compile(Path.Combine(OrdnerAktuellesProjekt.ToString(), "test.ssc", ""));

        if (_compilerlaufErfolgreich)
        {
            VmAutoTesterSilk.DataGridKommentarAnzeigen(VmAutoTesterSilk.ZeilenNummerDataGrid++, $"{TestAutomat.GetElapsedMilliseconds()}ms", TestAnzeige.CompilerErfolgreich, "");

            TestAutomat.RestartStopwatch();
            Silk.RunProgram(_compiledProgram);
        }
        else
        {
            foreach (var error in compiler.Errors)
            {
                VmAutoTesterSilk.DataGridKommentarAnzeigen(VmAutoTesterSilk.ZeilenNummerDataGrid++, $"{TestAutomat.GetElapsedMilliseconds()}ms", TestAnzeige.CompilerError, error.ToString());
            }
        }
    }
}