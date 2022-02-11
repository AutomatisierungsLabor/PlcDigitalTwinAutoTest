using System.Threading;
using LibDatenstruktur;
using SoftCircuits.Silk;
using Xunit;

namespace LibPlcTestautomat.Test;

public class SetAiTest
{
    [Theory]
    [InlineData(0, 0, "uint16", 0, 0, 0, 0)]
    [InlineData(0, 1, "uint16", 1, 0, 0, 0)]
    [InlineData(0, 100, "uint16", 100, 0, 0, 0)]
    [InlineData(0, 12345, "uint16", 57, 48, 0, 0)]

    [InlineData(0, 0, "S7 / 16 Bit / Prozent", 0, 0, 0, 0)]
    [InlineData(0, 1, "S7 / 16 Bit / Prozent", 20, 1, 0, 0)]
    [InlineData(0, 200, "S7 / 16 Bit / Prozent", 0, 108, 0, 0)]
    [InlineData(0, 5000, "S7 / 16 Bit / Prozent", 0, 108, 0, 0)]
    public void SetAiTests(short startByte, short wert, string datenTyp, byte ai0, byte ai1, byte ai2, byte ai3)
    {
        CancellationTokenSource cancellationTokenSource = new();
        var datenstruktur = new Datenstruktur();
        var testAutomat = new TestAutomat(datenstruktur, cancellationTokenSource);

        var variable0 = new Variable();
        var variable1 = new Variable();
        var variable2 = new Variable();

        variable0.SetValue(startByte);
        variable1.SetValue(wert);
        variable2.SetValue(datenTyp);

        var arguments = new[] { variable0, variable1, variable2 };

        var args = new FunctionEventArgs("SetAnalogerEingang", arguments, new Variable());

        testAutomat.SetAnalogerEingang(args);
        Assert.Equal(ai0, datenstruktur.Ai[0]);
        Assert.Equal(ai1, datenstruktur.Ai[1]);
        Assert.Equal(ai2, datenstruktur.Ai[2]);
        Assert.Equal(ai3, datenstruktur.Ai[3]);
    }
}