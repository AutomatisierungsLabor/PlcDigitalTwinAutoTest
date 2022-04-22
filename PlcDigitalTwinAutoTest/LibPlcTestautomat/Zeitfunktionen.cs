using LibPlcTools;
using SoftCircuits.Silk;

namespace LibPlcTestautomat;

public partial class TestAutomat
{
#pragma warning disable CA1822 // Mark members as static
    public void FuncSleep(FunctionEventArgs args) => Thread.Sleep((int)new ZeitDauer(args.Parameters[0].ToString()).DauerMs);
#pragma warning restore CA1822 // Mark members as static
    public void StopwatchRestart() => _stopwatch.Restart();
    public long StopwatchGetElapsedMilliseconds() => _stopwatch.ElapsedMilliseconds;
}