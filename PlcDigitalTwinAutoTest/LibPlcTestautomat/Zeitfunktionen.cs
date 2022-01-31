using LibPlcTools;
using SoftCircuits.Silk;

namespace LibPlcTestautomat;

public partial class TestAutomat
{
    public void Sleep(FunctionEventArgs functionEventArgs)
    {
        var sleepTime = new ZeitDauer(functionEventArgs.Parameters[0].ToString());
        Thread.Sleep((int)sleepTime.DauerMs);
    }

    public void RestartStopwatch() => _stopwatch.Restart();
    public long GetElapsedMilliseconds() => _stopwatch.ElapsedMilliseconds;
}