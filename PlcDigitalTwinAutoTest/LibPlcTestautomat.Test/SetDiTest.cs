using LibDatenstruktur;
using SoftCircuits.Silk;
using Xunit;

namespace LibPlcTestautomat.Test;

public class SetDiTest
{
    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(1, 1, 0)]
    [InlineData(2, 2, 0)]
    [InlineData(256, 0, 1)]
    public void SetDiTests(short zahl, byte di0, byte di1)
    {
        var datenstruktur = new Datenstruktur();
        var testAutomat = new TestAutomat(datenstruktur);

        var variable = new Variable();
        variable.SetValue(zahl);
        var arguments = new[] { variable };

        var functionEventArgs = new FunctionEventArgs("SetDigitaleEingaenge", arguments, new Variable());
        testAutomat.SetDigitaleEingaenge(functionEventArgs);
        Assert.Equal(di0, datenstruktur.Di[0]);
        Assert.Equal(di1, datenstruktur.Di[1]);
    }
}