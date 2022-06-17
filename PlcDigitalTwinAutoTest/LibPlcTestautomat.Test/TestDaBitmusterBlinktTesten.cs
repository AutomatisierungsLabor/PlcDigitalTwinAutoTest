using Contracts;
using LibDatenstruktur;
using LibHighResTimer;
using SoftCircuits.Silk;
using System.Threading;
using Xunit;

namespace LibPlcTestautomat.Test;

public class TestDaBitmusterBlinktTesten
{
    private readonly Datenstruktur _datenstruktur = new();
    private DataGridZeile _zeile = new(0, "", TestAnzeige.CompilerErfolgreich, "", "", "", "");

    [Theory]
    [InlineData(1, 1, "T#20ms", 0.5, 3, 0.5, "T#500ms", "DaBitmusterBlinktTimeout 1", 10, 20, 1, TestAnzeige.Erfolgreich)]
    [InlineData(2, 2, "T#40ms", 0.5, 3, 0.2, "T#300ms", "DaBitmusterBlinktTimeout 2", 20, 40, 2, TestAnzeige.Erfolgreich)]
    [InlineData(3, 3, "T#40ms", 0.25, 3, 0.2, "T#300ms", "DaBitmusterBlinktTimeout 3", 10, 40, 3, TestAnzeige.Erfolgreich)]
    [InlineData(4, 4, "T#40ms", 0.75, 3, 0.2, "T#300ms", "DaBitmusterBlinktTimeout 4", 30, 40, 15, TestAnzeige.Erfolgreich)]

    [InlineData(1, 2, "T#100ms", 0.5, 3, 0.2, "T#500ms", "DaBitmusterBlinktTimeout 5", 25, 50, 1, TestAnzeige.Timeout)]   // Bitmuster != Bitmaske

    public void TestsDaBitmusterBlinktTimeout(int bitMuster, int bitMaske, string periodendauer, float tastverhaeltnis, int anzahlPerioden, float toleranz, string timeout, string kommentar, int tEin, int tPeriodendauer, byte blinkerBitMuster, TestAnzeige testAnzeige)
    {
        _datenstruktur.Da[1] = 0;
        var zeit = 0;
        var highResTimer = new HighResTimer
        {
            Interval = 1000,
            Enabled = true
        };

        highResTimer.MicroTimerElapsed += (_, _) =>
        {
            if (zeit < tEin) _datenstruktur.Da[0] = blinkerBitMuster;
            else _datenstruktur.Da[0] = (byte)~blinkerBitMuster;

            if (zeit++ >= tPeriodendauer) zeit = 0;
        };

        var cancellationTokenSource = new CancellationTokenSource();
        var testAutomat = new TestAutomat(_datenstruktur, cancellationTokenSource);
        var args = new FunctionEventArgs("BitmusterBlinktTesten",
            new[] { new Variable(bitMuster), new Variable(bitMaske), new Variable(periodendauer), new Variable(tastverhaeltnis), new Variable(anzahlPerioden), new Variable(toleranz), new Variable(timeout), new Variable(kommentar) },
            new Variable());

        testAutomat.SetCallbackDatagridUpdaten(DatenSpeichern);
        testAutomat.FuncBitmusterBlinktTesten(args);

        // Assert.Equal(kommentar, _zeile.Kommentar);
        Assert.Equal(testAnzeige, _zeile.Ergebnis);

        highResTimer.Enabled = false;
    }
    private void DatenSpeichern(DataGridZeile zeile) => _zeile = zeile;
}