using System.Threading;
using LibConfigPlc;
using SoftCircuits.Silk;
using System.Diagnostics;
using System.IO;
using LibDatenstruktur;
using LibSilkAutoTester.TestAutomat;


namespace LibSilkAutoTester.Model;

public class ModelSilkAutoTester
{
    public Datenstruktur Datenstruktur { get; set; }
    public ConfigPlc ConfigPlc { get; set; }
    public string TestSource { get; set; }
    public Stopwatch SilkStopwatch { get; set; }

    public short DataGridZeile { get; set; }


    private  bool _compilerlaufErfolgreich;
    private  CompiledProgram _compiledProgram;

    private readonly TestAusgabeFenster _testAusgabeFenster;

    private const int ZeilenAbstand = 10;
    private const int SpaltenBreite = 300 - 15; // rechter Rand

    public ModelSilkAutoTester(TestAusgabeFenster testAusgabeFenster, LibDatenstruktur.Datenstruktur datenstruktur, ConfigPlc configPlc)
    {
        _testAusgabeFenster = testAusgabeFenster;
        Datenstruktur = datenstruktur;
        ConfigPlc = configPlc;

        System.Threading.Tasks.Task.Run(ModelTask);
    }

    internal void ModelTask()
    {

        while (true)
        {

            Thread.Sleep(10);
        }
    }

    public void AutoTestStarten()
    {


        Compiler compiler;
        SilkStopwatch = new Stopwatch();

        Silk.Silk.ReferenzenUebergeben(Datenstruktur, SilkStopwatch);

        UpdateDataGrid(new DataGridZeile(
            DataGridZeile++,
            "0",
            TestAutomat.TestAnzeige.CompilerStart,
            " ",       // DigInput 
            " ",       // DigOutput Soll
            " ",       // DigOutput Ist
            " "));

        SilkStopwatch.Start();
        (_compilerlaufErfolgreich, compiler, _compiledProgram) = Silk.Silk.Compile(TestSource);


        if (_compilerlaufErfolgreich)
        {
            UpdateDataGrid(new DataGridZeile(
                DataGridZeile++,
                $"{SilkStopwatch.ElapsedMilliseconds}ms",
              TestAnzeige.CompilerErfolgreich,
                " ",       // DigInput 
                " ",       // DigOutput Soll
                " ",       // DigOutput Ist
                " "));

            System.Threading.Tasks.Task.Run(TestRunnerTask);
        }
        else
        {
            foreach (var error in compiler.Errors)
            {
                UpdateDataGrid(new DataGridZeile(
                    DataGridZeile++,
                    $"{SilkStopwatch.ElapsedMilliseconds}ms",
                    TestAnzeige.CompilerError,
                    error.ToString(),   // DigInpt
                    " ",                // DigOutput Soll
                    " ",                // DigOutput Ist
                    " "));
            }
        }

    }

    private void TestRunnerTask()
    {
        SilkStopwatch.Restart();
        if (_compilerlaufErfolgreich) Silk.Silk.RunProgram(_compiledProgram);
    }

    public void UpdateDataGrid(TestAutomat.DataGridZeile dataGridZeile)
    {

    }


}