using LibAutoTestSilk.ViewModel;
using LibDatenstruktur;
using SoftCircuits.Silk;
using System.Diagnostics;

namespace LibAutoTestSilk.Silk;

public partial class Silk
{
    public VmAutoTesterSilk VmSilkAutoTester { get; set; }
    public Datenstruktur Datenstruktur { get; set; }
    public Stopwatch SilkStopwatch { get; set; }


    public (bool erfolgreich, Compiler compiler, CompiledProgram program) Compile(string mySourceFile)
    {
        var compiler = new Compiler();
        CompilerRegisterFunctions(compiler);
        return compiler.Compile(mySourceFile, out var program) ? (true, compiler, program) : (false, compiler, program);
    }
    public void ReferenzenUebergeben(VmAutoTesterSilk vmSilkAutoTester, Datenstruktur datenstruktur, Stopwatch silkStopwatch)
    {
        VmSilkAutoTester = vmSilkAutoTester;
        Datenstruktur = datenstruktur;
        SilkStopwatch = silkStopwatch;
    }
}