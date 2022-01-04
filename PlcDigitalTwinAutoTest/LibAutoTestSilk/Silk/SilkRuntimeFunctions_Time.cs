using LibPlc;
using SoftCircuits.Silk;
using System.Threading;

namespace LibAutoTestSilk.Silk;

public partial class Silk
{
    public void Sleep(FunctionEventArgs e)
    {
        var sleepTime = new ZeitDauer(e.Parameters[0].ToString());
        Thread.Sleep((int)sleepTime.DauerMs);
    }
    private void ResetStopwatch() => SilkStopwatch.Restart();
}