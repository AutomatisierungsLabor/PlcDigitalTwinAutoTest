using System.Threading;
using LibPlc;
using SoftCircuits.Silk;

namespace LibAutoTestSilk.Silk;

public partial class Silk
{
    public static void Sleep(FunctionEventArgs e)
    {
        var sleepTime = new ZeitDauer(e.Parameters[0].ToString());
        Thread.Sleep((int)sleepTime.DauerMs);
    }
    private static void ResetStopwatch() => SilkStopwatch.Restart();
}