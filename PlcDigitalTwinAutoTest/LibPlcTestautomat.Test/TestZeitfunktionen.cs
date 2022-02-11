using System.Threading;
using LibDatenstruktur;
using SoftCircuits.Silk;
using Xunit;

namespace LibPlcTestautomat.Test;

public class TestZeitfunktionen
{
    [Theory]
    [InlineData(0, 0, 5)]
    [InlineData(10, 10, 25)]
    [InlineData(100, 100, 120)]
    public void StopwatchTests(short dauer, short min, short max)
    {
        var cancellationTokenSource = new CancellationTokenSource();
        var datenstruktur = new Datenstruktur();
        var testAutomat = new TestAutomat(datenstruktur, cancellationTokenSource);
        var args = new FunctionEventArgs("Sleep", new[] { new Variable(dauer) }, new Variable());

        testAutomat.RestartStopwatch();
        Assert.InRange(testAutomat.GetElapsedMilliseconds(), 0, 5);
        testAutomat.Sleep(args);
        Assert.InRange(testAutomat.GetElapsedMilliseconds(), min, max);
    }
}