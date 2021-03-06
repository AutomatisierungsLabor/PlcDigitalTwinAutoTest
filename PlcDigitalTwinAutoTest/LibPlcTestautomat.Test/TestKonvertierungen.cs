using LibDatenstruktur;
using SoftCircuits.Silk;
using System.Threading;
using Xunit;

namespace LibPlcTestautomat.Test;

public class TestKonvertierungen
{
    [Theory]
    [InlineData("2#0000", 0)]
    [InlineData("2#0001", 1)]
    [InlineData("2#0001_0000", 16)]
    [InlineData("2#0001_0000_0000", 256)]
    [InlineData("16#00", 0)]
    [InlineData("16#01", 1)]
    [InlineData("16#FF", 255)]
    public void TestsPlcToDec(string zahl, short ergebnis)
    {
        var cancellationTokenSource = new CancellationTokenSource();
        var datenstruktur = new Datenstruktur();
        var testAutomat = new TestAutomat(datenstruktur, cancellationTokenSource);
        var args = new FunctionEventArgs("PlcToDec",
            new[] { new Variable(zahl) },
            new Variable());

        testAutomat.FuncPlcToDec(args);
        Assert.Equal(ergebnis, args.ReturnValue[0].ToInteger());
    }
}