using LibPlc;
using SoftCircuits.Silk;
using System;
using System.Diagnostics;
using System.Threading;

namespace LibAutoTestSilk.Silk;

public partial class Silk
{
    private enum SchritteBlinken
    {
        AufPosFlankeWarten = 0,
        AufNegFlankeWarten
    }

    internal uint GetDiWord() => Simatic.Digital_CombineTwoByte(Datenstruktur.Di[0], Datenstruktur.Da[1]);
    internal uint GetDaWord() => Simatic.Digital_CombineTwoByte(Datenstruktur.Di[0], Datenstruktur.Da[1]);

    private void GetDa(FunctionEventArgs e)
    {
        var digitalOutput = GetDaWord();
        e.ReturnValue.SetValue((int)digitalOutput);
    }
    private void BitmusterTesten(FunctionEventArgs e)
    {
        var bitMuster = e.Parameters[0].ToInteger();
        var bitMaske = e.Parameters[1].ToInteger();
        var timeout = new ZeitDauer(e.Parameters[2].ToString());
        var kommentar = e.Parameters[3].ToString();

        var stopwatch = new Stopwatch();
        stopwatch.Start();

        while (stopwatch.ElapsedMilliseconds < timeout.DauerMs)
        {

            Thread.Sleep(10);

            var digitalOutput = GetDaWord();

            if ((digitalOutput & (short)bitMaske) == (short)bitMuster)
            {
                DataGridAnzeigeUpdaten(TestAutomat.TestAnzeige.Erfolgreich, (uint)bitMuster, kommentar);
                return;
            }

            DataGridAnzeigeUpdaten(TestAutomat.TestAnzeige.Aktiv, (uint)bitMuster, kommentar);
        }

        DataGridAnzeigeUpdaten(TestAutomat.TestAnzeige.Timeout, (uint)bitMuster, kommentar);
    }
    private void BitmusterBlinktTesten(FunctionEventArgs e)
    {
        var bitMuster = e.Parameters[0].ToInteger();
        var bitMaske = e.Parameters[1].ToInteger();
        var periodenDauer = new ZeitDauer(e.Parameters[2].ToString());
        var tastVerhaeltnis = e.Parameters[3].ToFloat();
        var anzahlPerioden = e.Parameters[4].ToInteger();
        var toleranz = e.Parameters[5].ToFloat();
        var timeout = new ZeitDauer(e.Parameters[6].ToString());
        var kommentar = e.Parameters[7].ToString();

        var periodenDauerMax = periodenDauer.DauerMs * (1 + toleranz);
        var periodenDauerMin = periodenDauer.DauerMs * (1 - toleranz);

        var tastVerhaeltnisMax = tastVerhaeltnis * (1 + toleranz);
        var tastVerhaeltnisMin = tastVerhaeltnis * (1 - toleranz);

        var messungAktiv = false;
        var tastverhaeltnis = 0.0;
        var periodenAnzahl = 0;
        var zeitImpuls = 0.0;
        var zeitPause = 0.0;
        var schritte = SchritteBlinken.AufNegFlankeWarten;
        var periodenDauerMessen = new Stopwatch();
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        while (stopwatch.ElapsedMilliseconds < timeout.DauerMs)
        {
            Thread.Sleep(10);

            var digitalOutput = GetDaWord();

            var aktuellePeriodenDauer = zeitImpuls + zeitPause;
            if (zeitImpuls > 0) tastverhaeltnis = zeitImpuls / aktuellePeriodenDauer;

            switch (schritte)
            {
                case SchritteBlinken.AufPosFlankeWarten:
                    zeitPause = periodenDauerMessen.ElapsedMilliseconds;

                    if ((digitalOutput & (short)bitMaske) == (short)bitMuster)
                    {
                        if (messungAktiv)
                        {
                            if (aktuellePeriodenDauer > periodenDauerMax || aktuellePeriodenDauer < periodenDauerMin)
                            {
                                DataGridAnzeigeUpdaten(TestAutomat.TestAnzeige.Fehler, (uint)bitMuster, $"{kommentar}: Falsche Periodendauer: {aktuellePeriodenDauer}ms");
                                return;
                            }

                            if (tastverhaeltnis > tastVerhaeltnisMax || tastverhaeltnis < tastVerhaeltnisMin)
                            {
                                DataGridAnzeigeUpdaten(TestAutomat.TestAnzeige.Fehler, (uint)bitMuster, $"{kommentar}: Falsches Tastverhältnis: {tastverhaeltnis:F2}ms");
                                return;
                            }

                            periodenAnzahl++;
                            if (periodenAnzahl > anzahlPerioden)
                            {
                                DataGridAnzeigeUpdaten(TestAutomat.TestAnzeige.Erfolgreich, (uint)bitMuster, $"{kommentar}: E:{zeitImpuls}ms A: {zeitPause}ms → {100 * tastverhaeltnis:F1}%");
                                return;
                            }
                        }
                        messungAktiv = true;
                        schritte = SchritteBlinken.AufNegFlankeWarten;
                        periodenDauerMessen.Restart();
                    }
                    break;

                case SchritteBlinken.AufNegFlankeWarten:
                    zeitImpuls = periodenDauerMessen.ElapsedMilliseconds;
                    if ((digitalOutput & (short)bitMaske) == 0)
                    {
                        if (messungAktiv) periodenDauerMessen.Restart();
                        schritte = SchritteBlinken.AufPosFlankeWarten;
                    }
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            DataGridAnzeigeUpdaten(TestAutomat.TestAnzeige.Aktiv, (uint)bitMuster, $"{kommentar}: I:{zeitImpuls}ms A: {zeitPause}ms → {100 * tastverhaeltnis:F1}%");
        }

        DataGridAnzeigeUpdaten(TestAutomat.TestAnzeige.Timeout, (uint)bitMuster, kommentar);
    }
}