using System.Diagnostics;
using LibAutoTestSilk.ViewModel;
using LibDatenstruktur;
using SoftCircuits.Silk;

namespace LibAutoTestSilk.Silk;

public partial class Silk
{
    public VmAutoTesterSilk VmAutoTesterSilk { get; set; }
    public Datenstruktur Datenstruktur { get; set; }
    public Stopwatch SilkStopwatch { get; set; }

    public (bool erfolgreich, Compiler compiler, CompiledProgram program) Compile(string mySourceFile)
    {
        var compiler = new Compiler();
        CompilerRegisterFunctions(compiler);
        return compiler.Compile(mySourceFile, out var program) ? (true, compiler, program) : (false, compiler, program);
    }
    public void ReferenzenUebergeben(VmAutoTesterSilk vmAutoTesterSilk, Datenstruktur datenstruktur, Stopwatch silkStopwatch)
    {
        VmAutoTesterSilk = vmAutoTesterSilk;
        Datenstruktur = datenstruktur;
        SilkStopwatch = silkStopwatch;
    }
}