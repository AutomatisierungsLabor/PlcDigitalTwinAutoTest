using System.Diagnostics;
using LibDatenstruktur;
using SoftCircuits.Silk;

namespace LibSilkAutoTester.Silk;

public partial class Silk
{
    /*
    public static AutoTesterWindow AutoTesterWindow { get; set; }
   
    public static IPlc Plc { get; set; }
    */
 public static Datenstruktur Datenstruktur { get; set; }
    public static Stopwatch SilkStopwatch { get; set; }


    public static (bool erfolgreich, Compiler compiler, CompiledProgram program) Compile(string mySourceFile)
    {
        var compiler = new Compiler();
        CompilerRegisterFunctions(compiler);
        return compiler.Compile( mySourceFile, out var program) ? (true, compiler, program) : (false, compiler, program);
    }
    
    public static void ReferenzenUebergeben( Datenstruktur datenstruktur, Stopwatch silkStopwatch)
    {
       // AutoTesterWindow = autoTesterWindow;
        Datenstruktur = datenstruktur;
        SilkStopwatch = silkStopwatch;
       // Plc = plc;
    }
    
}