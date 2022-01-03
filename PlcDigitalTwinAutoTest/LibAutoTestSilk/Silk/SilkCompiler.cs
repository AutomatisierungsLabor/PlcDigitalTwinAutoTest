using System.Diagnostics;
using LibAutoTestSilk.ViewModel;
using LibDatenstruktur;
using SoftCircuits.Silk;

namespace LibAutoTestSilk.Silk;

public partial class Silk
{
    public static VmAutoTesterSilk VmSilkAutoTester{ get; set; }
    public static Datenstruktur Datenstruktur { get; set; }
    public static Stopwatch SilkStopwatch { get; set; }


    public static (bool erfolgreich, Compiler compiler, CompiledProgram program) Compile(string mySourceFile)
    {
        var compiler = new Compiler();
        CompilerRegisterFunctions(compiler);
        return compiler.Compile(mySourceFile, out var program) ? (true, compiler, program) : (false, compiler, program);
    }
    public static void ReferenzenUebergeben(VmAutoTesterSilk vmSilkAutoTester, Datenstruktur datenstruktur, Stopwatch silkStopwatch)
    {
        VmSilkAutoTester = vmSilkAutoTester;
        Datenstruktur = datenstruktur;
        SilkStopwatch = silkStopwatch;
    }
}