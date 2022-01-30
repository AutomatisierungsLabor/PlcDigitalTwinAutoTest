using System.Diagnostics;
using LibConfigPlc;
using LibDatenstruktur;
using System.IO;
using LibAutoTestSilk.ViewModel;
using LibTestDatensammlung;
using SoftCircuits.Silk;

namespace LibAutoTestSilk;

public class AutoTesterSilk
{
    public AutoTesterWindow AutoTesterWindow;
    public VmAutoTesterSilk VmAutoTesterSilk { get; set; }
    public Datenstruktur Datenstruktur { get; set; }
    public ConfigPlc ConfigPlc { get; set; }
    public LibPlcTestautomat.TestAutomat TestAutomat { get; set; }
    public Silk.Silk Silk { get; set; }
    public Stopwatch SilkStopwatch { get; set; }
    public DirectoryInfo OrdnerAktuellesProjekt { get; set; }

    private bool _compilerlaufErfolgreich;
    private CompiledProgram _compiledProgram;


    public AutoTesterSilk(Datenstruktur datenstruktur, ConfigPlc configPlc, LibPlcTestautomat.TestAutomat testAutomat)
    {
        Datenstruktur = datenstruktur;
        ConfigPlc = configPlc;
        TestAutomat = testAutomat;

        VmAutoTesterSilk = new VmAutoTesterSilk();
        AutoTesterWindow = new AutoTesterWindow(VmAutoTesterSilk);

        TestAutomat.SetReferenzen( VmAutoTesterSilk.ZeilenNummerDataGrid, VmAutoTesterSilk.DataGridZeilen);

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
        SilkStopwatch = new Stopwatch();

        Silk.ReferenzenUebergeben(VmAutoTesterSilk, Datenstruktur, TestAutomat, SilkStopwatch);

        VmAutoTesterSilk.DataGridKommentarAnzeigen(VmAutoTesterSilk.ZeilenNummerDataGrid++, "0", TestAnzeige.CompilerStart,"");
       
        SilkStopwatch.Start();

        (_compilerlaufErfolgreich, compiler, _compiledProgram) = Silk.Compile(Path.Combine(OrdnerAktuellesProjekt.ToString(), "test.ssc",""));

        if (_compilerlaufErfolgreich)
        {
            VmAutoTesterSilk.DataGridKommentarAnzeigen(VmAutoTesterSilk.ZeilenNummerDataGrid++, $"{SilkStopwatch.ElapsedMilliseconds}ms", TestAnzeige.CompilerErfolgreich,"");

            SilkStopwatch.Restart();
            Silk.RunProgram(_compiledProgram);
        }
        else
        {
            foreach (var error in compiler.Errors)
            {
                VmAutoTesterSilk.DataGridKommentarAnzeigen(VmAutoTesterSilk.ZeilenNummerDataGrid++, $"{SilkStopwatch.ElapsedMilliseconds}ms", TestAnzeige.CompilerError, error.ToString());
            }
        }
    }
}