using LibAutoTestSilk.ViewModel;
using LibDatenstruktur;
using SoftCircuits.Silk;

namespace LibAutoTestSilk.Silk;

public partial class Silk
{
    private VmAutoTesterSilk _vmAutoTesterSilk;
    private LibPlcTestautomat.TestAutomat _testAutomat;
    private Datenstruktur _datenstruktur;

    public (bool erfolgreich, Compiler compiler, CompiledProgram program) Compile(string mySourceFile)
    {
        var compiler = new Compiler();
        CompilerRegisterFunctions(compiler);
        return compiler.Compile(mySourceFile, out var program) ? (true, compiler, program) : (false, compiler, program);
    }
    public void ReferenzenUebergeben(VmAutoTesterSilk vmAutoTesterSilk, Datenstruktur datenstruktur, LibPlcTestautomat.TestAutomat testAutomat)
    {
        _vmAutoTesterSilk = vmAutoTesterSilk;
        _datenstruktur = datenstruktur;
        _testAutomat = testAutomat;
    }
}