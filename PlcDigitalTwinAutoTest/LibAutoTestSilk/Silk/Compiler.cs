using LibAutoTestSilk.ViewModel;
using LibDatenstruktur;
using SoftCircuits.Silk;

namespace LibAutoTestSilk.Silk;

public partial class Silk
{
    public VmAutoTesterSilk VmAutoTesterSilk { get; set; }
    public Datenstruktur Datenstruktur { get; set; }
    public LibPlcTestautomat.TestAutomat TestAutomat { get; set; }

    public (bool erfolgreich, Compiler compiler, CompiledProgram program) Compile(string mySourceFile)
    {
        var compiler = new Compiler();
        CompilerRegisterFunctions(compiler);
        return compiler.Compile(mySourceFile, out var program) ? (true, compiler, program) : (false, compiler, program);
    }
    public void ReferenzenUebergeben(VmAutoTesterSilk vmAutoTesterSilk, Datenstruktur datenstruktur, LibPlcTestautomat.TestAutomat testAutomat)
    {
        VmAutoTesterSilk = vmAutoTesterSilk;
        Datenstruktur = datenstruktur;
        TestAutomat = testAutomat;
    }
}