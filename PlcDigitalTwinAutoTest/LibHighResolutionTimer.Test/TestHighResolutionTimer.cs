using System.Diagnostics;
using Xunit;

namespace LibHighResTimer.Test;

public class TestHighResolutionTimer
{
    private long _laufzeit;
    private Stopwatch _stopUhr;

    [Theory]
    [InlineData(1, 0, 2)]
    [InlineData(2, 1, 3)]
    [InlineData(3, 2, 4)]
    [InlineData(4, 3, 5)]

    public void TestsHighResolutionTimer(int soll, long expectedMin, long expectedMax)
    {
        _laufzeit = 0;

        _stopUhr = new Stopwatch();


        var highResTimer = new HighResTimer();
        highResTimer.MicroTimerElapsed += (_, _) =>
        {
            if (_laufzeit == 0) _laufzeit = _stopUhr.ElapsedMilliseconds; // läuft öfter auf!
        };

        highResTimer.Interval = 1000 * soll;

        _stopUhr.Start();
        highResTimer.Enabled = true;
        System.Threading.Thread.Sleep(10);
        highResTimer.Enabled = false;

        Assert.InRange(_laufzeit, expectedMin, expectedMax);
    }
}