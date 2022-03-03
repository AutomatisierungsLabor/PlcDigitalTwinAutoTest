using System.Threading;
using Contracts;
using LibDatenstruktur;
using SoftCircuits.Silk;
using Xunit;

namespace LibPlcTestautomat.Test;

public class TestDaBitmusterBlinktTesten
{
    public bool ThreadAktiv;
    public Datenstruktur Datenstruktur = new();
    public (int tEin, int tAus, int bitMuster) BlinkerTuple;

    [Theory]
    [InlineData(1, 2, "T#100ms", 0.5, 2, 0.1, "T#500ms", "kein TestKommentar", {5,5,1}, TestAnzeige.Timeout)]


    public void TestsDaBitmusterBlinktTimeout(int bitMuster, int bitMaske, string periodendauer, float tastverhaeltnis, int anzahlPerioden, float toleranz, string timeout, string kommentar, (int tEin, int tAus, int bitMuster) blinkerTuple,  TestAnzeige testAnzeige)
    {
        BlinkerTuple = blinkerTuple;
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

        ThreadAktiv = false;
    }


    private DataGridZeile _zeile = new(0, "", TestAnzeige.CompilerErfolgreich, "", "", "", "");
    
    private void DatenSpeichern(DataGridZeile zeile) => _zeile = zeile;

    private void BlinkerTask()
    {
        Datenstruktur.Da[0] = 55;
        do
        {
            int temp = Datenstruktur.Da[0];

            Datenstruktur.Da[0] = (byte)~temp;
            Datenstruktur.Da[1] = 0;

            Thread.Sleep(100);
        } while (ThreadAktiv);
    }
}