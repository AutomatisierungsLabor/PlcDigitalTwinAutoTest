using System.Threading;
using LibDatenstruktur;
using Xunit;

namespace LibPlcTestautomat.Test;

public class GetDiTest
{
    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(1, 0, 1)]
    [InlineData(0, 1, 256)]
    public void GetDiTests(byte di0, byte di1, uint erwartet)
    {
        CancellationTokenSource cancellationTokenSource = new();
        var datenstruktur = new Datenstruktur();
        var testAutomat = new TestAutomat(datenstruktur, cancellationTokenSource);

        datenstruktur.Di[0] = di0;
        datenstruktur.Di[1] = di1;
        Assert.Equal(erwartet, testAutomat.GetDigtalInputWord());
    }
}