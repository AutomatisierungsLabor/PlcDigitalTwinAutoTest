using System.Threading;
using LibDatenstruktur;
using SoftCircuits.Silk;
using Xunit;

namespace LibPlcTestautomat.Test;

public class GetDaTest
{
    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(1, 0, 1)]
    [InlineData(0, 1, 256)]
    public void GetDaTests(byte da0, byte da1, short erwartet)
    {
        CancellationTokenSource cancellationTokenSource = new();
        var datenstruktur = new Datenstruktur();
        var testAutomat = new TestAutomat(datenstruktur, cancellationTokenSource);

        datenstruktur.Da[0] = da0;
        datenstruktur.Da[1] = da1;

        var variable = new Variable();
        variable.SetValue(0);
        var arguments = new[] { variable };
        var functionEventArgs = new FunctionEventArgs("GetDigitaleAusgaenge", arguments, new Variable());
        testAutomat.GetDigitaleAusgaenge(functionEventArgs);

        Assert.Equal(erwartet, functionEventArgs.ReturnValue[0].ToInteger());
    }
}