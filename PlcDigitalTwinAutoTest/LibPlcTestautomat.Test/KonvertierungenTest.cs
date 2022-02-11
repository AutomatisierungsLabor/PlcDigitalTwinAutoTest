using System.Threading;
using LibDatenstruktur;
using SoftCircuits.Silk;
using Xunit;

namespace LibPlcTestautomat.Test;

public class KonvertierungenTest
{
    [Theory]
    [InlineData("2#0000", 0)]
    [InlineData("2#0001", 1)]
    [InlineData("2#0001_0000", 16)]
    [InlineData("2#0001_0000_0000", 256)]
    [InlineData("16#00", 0)]
    [InlineData("16#01", 1)]
    [InlineData("16#FF", 255)]
    public void PlcToDecTest(string zahl, short ergebnis)
    {
        CancellationTokenSource cancellationTokenSource = new();
        var datenstruktur = new Datenstruktur();
        var testAutomat = new TestAutomat(datenstruktur, cancellationTokenSource);

        var variable = new Variable();
        variable.SetValue(zahl);
        var arguments = new[] { variable };

        var args = new FunctionEventArgs("PlcToDec", arguments, new Variable());
        testAutomat.PlcToDec(args);
        Assert.Equal(ergebnis, args.ReturnValue[0].ToInteger());
    }
}