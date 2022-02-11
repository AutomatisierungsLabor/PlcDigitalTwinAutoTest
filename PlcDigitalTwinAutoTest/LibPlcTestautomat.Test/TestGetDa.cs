using System.Threading;
using LibDatenstruktur;
using SoftCircuits.Silk;
using Xunit;

namespace LibPlcTestautomat.Test;

public class TestGetDa
{

    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(1, 0, 1)]
    [InlineData(0, 1, 256)]
    public void GetDigitalOutputWordTests(byte da0, byte da1, uint erwartet)
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
    public void GetDaTests(byte da0, byte da1, short erwartet)
    {
        var cancellationTokenSource = new CancellationTokenSource();
        var datenstruktur = new Datenstruktur();
        var testAutomat = new TestAutomat(datenstruktur, cancellationTokenSource);

        datenstruktur.Da[0] = da0;
        datenstruktur.Da[1] = da1;

        var args = new FunctionEventArgs("GetDigitaleAusgaenge",new[] { new Variable(0) } , new Variable());
        testAutomat.GetDigitaleAusgaenge(args);

        Assert.Equal(erwartet, args.ReturnValue[0].ToInteger());
    }
}