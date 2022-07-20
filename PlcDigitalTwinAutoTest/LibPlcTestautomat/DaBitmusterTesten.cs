using Contracts;
using LibPlcTools;
using SoftCircuits.Silk;
using System.Diagnostics;

namespace LibPlcTestautomat;

public partial class TestAutomat
{
    public void FuncBitmusterTesten(FunctionEventArgs args)
    {
        var daBitMuster = args.Parameters[0].ToInteger();
        var daBitMaske = args.Parameters[1].ToInteger();
        var timeout = new ZeitDauer(args.Parameters[2].ToString());
        var kommentar = args.Parameters[3].ToString();

        var stopwatch = new Stopwatch();
        stopwatch.Start();

        while (stopwatch.ElapsedMilliseconds < timeout.DauerMs && !_cancellationTokenSource.IsCancellationRequested)
        {
            Thread.Sleep(50);

            if ((GetDigitalOutputWord() & (short)daBitMaske) == (short)daBitMuster)
            {
                DataGridUpdaten(TestAnzeige.Erfolgreich, (uint)daBitMuster, kommentar);
                IncrementZeilenNummer();
                StopwatchRestart();
                return;
            }

            DataGridUpdaten(TestAnzeige.Aktiv, (uint)daBitMuster, kommentar);
        }
        DataGridUpdaten(TestAnzeige.Timeout, (uint)daBitMuster, kommentar);
        IncrementZeilenNummer();
        StopwatchRestart();
    }
}