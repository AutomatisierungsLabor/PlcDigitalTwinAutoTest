using Contracts;
using LibPlcTools;
using SoftCircuits.Silk;
using System.Diagnostics;

namespace LibPlcTestautomat;

public partial class TestAutomat
{
    public void BitmusterTesten(FunctionEventArgs functionEventArgs)
    {
        var daBitMuster = functionEventArgs.Parameters[0].ToInteger();
        var daBitMaske = functionEventArgs.Parameters[1].ToInteger();
        var timeout = new ZeitDauer(functionEventArgs.Parameters[2].ToString());
        var kommentar = functionEventArgs.Parameters[3].ToString();

        var stopwatch = new Stopwatch();
        stopwatch.Start();

        while (stopwatch.ElapsedMilliseconds < timeout.DauerMs && !_cancellationTokenSource.IsCancellationRequested)
        {

            Thread.Sleep(50);

            var daIst = GetDigitalOutputWord();

            if ((daIst & (short)daBitMaske) == (short)daBitMuster)
            {
                DataGridUpdaten(TestAnzeige.Erfolgreich, (uint)daBitMuster, kommentar);
                return;
            }

            DataGridUpdaten(TestAnzeige.Aktiv, (uint)daBitMuster, kommentar);
        }

        DataGridUpdaten(TestAnzeige.Timeout, (uint)daBitMuster, kommentar);
    }
}