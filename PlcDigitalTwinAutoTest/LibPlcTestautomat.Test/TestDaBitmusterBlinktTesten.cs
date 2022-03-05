using System.Diagnostics;
using System.Threading;
using Contracts;
using LibDatenstruktur;
using SoftCircuits.Silk;
using Xunit;

namespace LibPlcTestautomat.Test;

public class TestDaBitmusterBlinktTesten
{
    private (int _tEin, int _tPeriodendauer, byte _bitMuster) _blinkerDaten;


    public bool ThreadAktiv;
    public Datenstruktur Datenstruktur = new();


    [Theory]
    [InlineData(1, 1, "T#100ms", 0.5, 1, 0.1, "T#1000ms", "kein TestKommentar", 50, 100, 1, TestAnzeige.Timeout)]

    [InlineData(1, 2, "T#100ms", 0.5, 1, 0.1, "T#500ms", "kein TestKommentar", 25, 50, 1, TestAnzeige.Timeout)]   // Bitmuster != Bitmaske

    public void TestsDaBitmusterBlinktTimeout(int bitMuster, int bitMaske, string periodendauer, float tastverhaeltnis, int anzahlPerioden, float toleranz, string timeout, string kommentar, int tEin, int tPeriodendauer, byte blinkerBitMuster, TestAnzeige testAnzeige)
    {
        _blinkerDaten = (tEin, tPeriodendauer, blinkerBitMuster);
        ThreadAktiv = true;
        System.Threading.Tasks.Task.Run(BlinkerTask);

        var cancellationTokenSource = new CancellationTokenSource();
        var testAutomat = new TestAutomat(Datenstruktur, cancellationTokenSource);
        var args = new FunctionEventArgs("BitmusterBlinktTesten",
            new[] { new Variable(bitMuster), new Variable(bitMaske), new Variable(periodendauer), new Variable(tastverhaeltnis), new Variable(anzahlPerioden), new Variable(toleranz), new Variable(timeout), new Variable(kommentar) },
            new Variable());


        testAutomat.SetCallbackDatagridUpdaten(DatenSpeichern);
        testAutomat.FuncBitmusterBlinktTesten(args);

        // Assert.Equal(kommentar, _zeile.Kommentar);
        Assert.Equal(testAnzeige, _zeile.Ergebnis);

        // ThreadAktiv = false;
    }
    private DataGridZeile _zeile = new(0, "", TestAnzeige.CompilerErfolgreich, "", "", "", "");
    private void DatenSpeichern(DataGridZeile zeile) => _zeile = zeile;
    private void BlinkerTask()
    {
        var zeitMessung = new Stopwatch();
        zeitMessung.Start();

        Datenstruktur.Da[1] = 0;

        do
        {
            if (zeitMessung.ElapsedMilliseconds < _blinkerDaten._tEin) Datenstruktur.Da[0] = _blinkerDaten._bitMuster;
            else Datenstruktur.Da[0] = (byte)~_blinkerDaten._bitMuster;

            if (zeitMessung.ElapsedMilliseconds > _blinkerDaten._tPeriodendauer) zeitMessung.Restart();

            Thread.Sleep(1);
        } while (ThreadAktiv);
    }
}