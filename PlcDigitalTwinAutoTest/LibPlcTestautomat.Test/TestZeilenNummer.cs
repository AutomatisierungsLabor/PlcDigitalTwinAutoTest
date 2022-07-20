using LibDatenstruktur;
using System.Threading;
using Xunit;

namespace LibPlcTestautomat.Test;

public class TestZeilenNummer
{
    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 1)]
    [InlineData(2, 2)]

    public void TestsIncrementResetZeilenNummer(short increments, short zeilenNummer)
    {
        var cancellationTokenSource = new CancellationTokenSource();
        var datenstruktur = new Datenstruktur();
        var testAutomat = new TestAutomat(datenstruktur, cancellationTokenSource);

        testAutomat.ResetZeilenNummer();
        Assert.Equal(0, testAutomat.GetZeilenNummer());

        for (var i = 0; i < increments; i++) testAutomat.IncrementZeilenNummer();

        Assert.Equal(zeilenNummer, testAutomat.GetZeilenNummer());
    }
}
