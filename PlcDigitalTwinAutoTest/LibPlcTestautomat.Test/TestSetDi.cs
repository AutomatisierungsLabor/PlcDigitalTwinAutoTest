using System.Threading;
using LibDatenstruktur;
using SoftCircuits.Silk;
using Xunit;

namespace LibPlcTestautomat.Test;

public class TestSetDi
{
    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(1, 1, 0)]
    [InlineData(2, 2, 0)]
    [InlineData(256, 0, 1)]
    public void TestsSetDi(short zahl, byte di0, byte di1)
    {
        var cancellationTokenSource = new CancellationTokenSource();
        var datenstruktur = new Datenstruktur();
        var testAutomat = new TestAutomat(datenstruktur, cancellationTokenSource);
        var args = new FunctionEventArgs("SetDigitaleEingaenge",new[] { new Variable(zahl) } , new Variable());

        testAutomat.FuncSetDigitaleEingaenge(args);
        Assert.Equal(di0, datenstruktur.Di[0]);
        Assert.Equal(di1, datenstruktur.Di[1]);
    }
}