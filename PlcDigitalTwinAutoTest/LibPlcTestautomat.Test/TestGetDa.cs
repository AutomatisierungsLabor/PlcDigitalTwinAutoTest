using LibDatenstruktur;
using SoftCircuits.Silk;
using System.Threading;
using Xunit;

namespace LibPlcTestautomat.Test;

public class TestGetDa
{
    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(1, 0, 1)]
    [InlineData(0, 1, 256)]
    public void TestsGetDigitalOutputWord(byte da0, byte da1, uint erwartet)
    {
        var cancellationTokenSource = new CancellationTokenSource();
        var datenstruktur = new Datenstruktur();
        var testAutomat = new TestAutomat(datenstruktur, cancellationTokenSource);

        datenstruktur.Da[0] = da0;
        datenstruktur.Da[1] = da1;

        Assert.Equal(erwartet, testAutomat.GetDigitalOutputWord());
    }


    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(1, 0, 1)]
    [InlineData(0, 1, 256)]
    public void TestsGetDa(byte da0, byte da1, short erwartet)
    {
        var cancellationTokenSource = new CancellationTokenSource();
        var datenstruktur = new Datenstruktur();
        var testAutomat = new TestAutomat(datenstruktur, cancellationTokenSource);

        datenstruktur.Da[0] = da0;
        datenstruktur.Da[1] = da1;

        var args = new FunctionEventArgs("GetDigitaleAusgaenge",
            new[] { new Variable(0) },
            new Variable());

        testAutomat.FuncGetDigitaleAusgaenge(args);

        Assert.Equal(erwartet, args.ReturnValue[0].ToInteger());
    }
}