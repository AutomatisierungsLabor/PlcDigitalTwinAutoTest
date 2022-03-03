using System.Threading;
using Contracts;
using LibDatenstruktur;
using SoftCircuits.Silk;
using Xunit;

namespace LibPlcTestautomat.Test;

public class TestDaBitmusterTesten
{

    [Theory]
    [InlineData(0, 0, "T#100ms", "kein Kommentart", 0, 0, TestAnzeige.Erfolgreich)]
    [InlineData(1, 3, "T#100ms", "kein Kommentart", 0, 0, TestAnzeige.Timeout)]
    [InlineData(1, 3, "T#100ms", "kein Kommentart", 1, 0, TestAnzeige.Erfolgreich)]
    [InlineData(3, 3, "T#100ms", "kein Kommentart", 3, 0, TestAnzeige.Erfolgreich)]
    [InlineData(1, 2, "T#100ms", "kein Kommentart", 3, 0, TestAnzeige.Timeout)]

    public void TestsDaBitmusterTimeout(int bitMuster, int bitMaske, string zeitDauer, string kommentar, byte da0, byte da1, TestAnzeige testAnzeige)
    {
        var cancellationTokenSource = new CancellationTokenSource();
        var datenstruktur = new Datenstruktur();
        var testAutomat = new TestAutomat(datenstruktur, cancellationTokenSource);
        var args = new FunctionEventArgs("BitmusterTesten", new[] { new Variable(bitMuster), new Variable(bitMaske), new Variable(zeitDauer), new Variable(kommentar) }, new Variable());

        datenstruktur.Da[0] = da0;
        datenstruktur.Da[1] = da1;

        testAutomat.SetCallbackDatagridUpdaten(DatenSpeichern);
        testAutomat.FuncBitmusterTesten(args);

        Assert.Equal(kommentar, _zeile.Kommentar);
        Assert.Equal(testAnzeige, _zeile.Ergebnis);
    }

    private DataGridZeile _zeile = new(0, "", TestAnzeige.CompilerErfolgreich, "", "", "", "");
    private void DatenSpeichern(DataGridZeile zeile) => _zeile = zeile;
}