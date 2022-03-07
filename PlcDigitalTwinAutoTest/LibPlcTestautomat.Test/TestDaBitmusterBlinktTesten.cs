using System.Threading;
using Contracts;
using LibDatenstruktur;
using LibHighResTimer;
using SoftCircuits.Silk;
using Xunit;

namespace LibPlcTestautomat.Test;

public class TestDaBitmusterBlinktTesten
{
    public Datenstruktur Datenstruktur = new();

    [Theory]
    [InlineData(1, 1, "T#20ms", 0.5, 2, 0.2, "T#300ms", "kein TestKommentar", 10, 20, 1, TestAnzeige.Erfolgreich)]
    [InlineData(1, 1, "T#40ms", 0.5, 2, 0.1, "T#300ms", "kein TestKommentar", 20, 40, 1, TestAnzeige.Erfolgreich)]
    [InlineData(1, 1, "T#40ms", 0.25, 2, 0.1, "T#300ms", "kein TestKommentar", 10, 40, 1, TestAnzeige.Erfolgreich)]
    [InlineData(1, 1, "T#40ms", 0.75, 2, 0.1, "T#300ms", "kein TestKommentar", 30, 40, 1, TestAnzeige.Erfolgreich)]

    [InlineData(1, 2, "T#100ms", 0.5, 2, 0.1, "T#400ms", "kein TestKommentar", 25, 50, 1, TestAnzeige.Timeout)]   // Bitmuster != Bitmaske

    public void TestsDaBitmusterBlinktTimeout(int bitMuster, int bitMaske, string periodendauer, float tastverhaeltnis, int anzahlPerioden, float toleranz, string timeout, string kommentar, int tEin, int tPeriodendauer, byte blinkerBitMuster, TestAnzeige testAnzeige)
    {
        Datenstruktur.Da[1] = 0;
        var zeit = 0;
        var highResTimer = new HighResTimer
        {
            Interval = 1000,
            Enabled = true
        };

        highResTimer.MicroTimerElapsed += (_, _) =>
        {
            if (zeit < tEin) Datenstruktur.Da[0] = blinkerBitMuster;
            else Datenstruktur.Da[0] = (byte)~blinkerBitMuster;

            if (zeit++ >= tPeriodendauer) zeit = 0;
        };

        var cancellationTokenSource = new CancellationTokenSource();
        var testAutomat = new TestAutomat(Datenstruktur, cancellationTokenSource);
        var args = new FunctionEventArgs("BitmusterBlinktTesten",
            new[] { new Variable(bitMuster), new Variable(bitMaske), new Variable(periodendauer), new Variable(tastverhaeltnis), new Variable(anzahlPerioden), new Variable(toleranz), new Variable(timeout), new Variable(kommentar) },
            new Variable());

        testAutomat.SetCallbackDatagridUpdaten(DatenSpeichern);
        testAutomat.FuncBitmusterBlinktTesten(args);

        // Assert.Equal(kommentar, _zeile.Kommentar);
        Assert.Equal(testAnzeige, _zeile.Ergebnis);

        highResTimer.Enabled = false;
    }
    private DataGridZeile _zeile = new(0, "", TestAnzeige.CompilerErfolgreich, "", "", "", "");
    private void DatenSpeichern(DataGridZeile zeile) => _zeile = zeile;
}