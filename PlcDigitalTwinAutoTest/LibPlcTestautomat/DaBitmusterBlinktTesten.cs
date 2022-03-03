using Contracts;
using LibPlcTools;
using System.Diagnostics;
using SoftCircuits.Silk;

namespace LibPlcTestautomat;

public partial class TestAutomat
{
    private enum SchritteBlinken
    {
        Starten = 0,
        AufPosFlankeWarten = 1,
        AufNegFlankeWarten = 2
    }

    public void FuncBitmusterBlinktTesten(FunctionEventArgs args)
    {
        var bitMuster = args.Parameters[0].ToInteger();
        var bitMaske = args.Parameters[1].ToInteger();
        var periodenDauer = new ZeitDauer(args.Parameters[2].ToString());
        var tastVerhaeltnis = args.Parameters[3].ToFloat();
        var anzahlPerioden = args.Parameters[4].ToInteger();
        var toleranz = args.Parameters[5].ToFloat();
        var timeout = new ZeitDauer(args.Parameters[6].ToString());
        var kommentar = args.Parameters[7].ToString();

        var periodenDauerMax = periodenDauer.DauerMs * (1 + toleranz);
        var periodenDauerMin = periodenDauer.DauerMs * (1 - toleranz);

        var tastVerhaeltnisMax = tastVerhaeltnis * (1 + toleranz);
        var tastVerhaeltnisMin = tastVerhaeltnis * (1 - toleranz);

        var anzeigeUpdaten = 0;
        const int anzeigeUpdatenSollwert = 10;

        var messungAktiv = false;
        var tastverhaeltnis = 0.0;
        var halbwellenAnzahl = 0;
        var zeitImpuls = 0.0;
        var zeitPause = 0.0;
        var schritte = SchritteBlinken.Starten;
        var periodenDauerMessen = new Stopwatch();
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        while (stopwatch.ElapsedMilliseconds < timeout.DauerMs)
        {
            Thread.Sleep(10);

            var digitalOutput = GetDigitalOutputWord();
            var aktuellePeriodenDauer = zeitImpuls + zeitPause;

            if (zeitImpuls > 0) tastverhaeltnis = zeitImpuls / aktuellePeriodenDauer;

            switch (schritte)
            {
                case SchritteBlinken.Starten:
                    messungAktiv = false;

                    schritte = (digitalOutput & (short)bitMaske) > 0
                        ? SchritteBlinken.AufNegFlankeWarten
                        : SchritteBlinken.AufPosFlankeWarten;
                    break;

                case SchritteBlinken.AufPosFlankeWarten:

                    if ((digitalOutput & (short)bitMaske) == (short)bitMuster)
                    {
                        if (messungAktiv) zeitPause = periodenDauerMessen.ElapsedMilliseconds;

                        schritte = SchritteBlinken.AufNegFlankeWarten;
                        periodenDauerMessen.Restart();
                        halbwellenAnzahl++;
                        messungAktiv = true;
                    }
                    break;

                case SchritteBlinken.AufNegFlankeWarten:
                    if ((digitalOutput & (short)bitMaske) == 0)
                    {
                        if (messungAktiv) zeitImpuls = periodenDauerMessen.ElapsedMilliseconds;

                        schritte = SchritteBlinken.AufPosFlankeWarten;
                        periodenDauerMessen.Restart();
                        halbwellenAnzahl++;
                        messungAktiv = true;
                    }
                    break;

                default:
                    throw new ArgumentOutOfRangeException(schritte.ToString());
            }

            if (anzeigeUpdaten++ <= anzeigeUpdatenSollwert) continue;
            anzeigeUpdaten = 0;

            if (messungAktiv)
            {
                if (aktuellePeriodenDauer > periodenDauerMax || aktuellePeriodenDauer < periodenDauerMin)
                {
                    DataGridUpdaten(TestAnzeige.Fehler, (uint)bitMuster, $"{kommentar}: Falsche Periodendauer: {aktuellePeriodenDauer}ms");
                    return;
                }

                if (tastverhaeltnis > tastVerhaeltnisMax || tastverhaeltnis < tastVerhaeltnisMin)
                {
                    DataGridUpdaten(TestAnzeige.Fehler, (uint)bitMuster, $"{kommentar}: Falsches Tastverhältnis: {tastverhaeltnis:F2}ms");
                    return;
                }


                if (halbwellenAnzahl > 2 * anzahlPerioden)
                {
                    DataGridUpdaten(TestAnzeige.Erfolgreich, (uint)bitMuster, $"{kommentar}: E:{zeitImpuls}ms A: {zeitPause}ms → {100 * tastverhaeltnis:F1}%");
                    return;
                }
            }
            DataGridUpdaten(TestAnzeige.Aktiv, (uint)bitMuster, $"{kommentar}: I:{zeitImpuls}ms A: {zeitPause}ms → {100 * tastverhaeltnis:F1}%");
        }
        DataGridUpdaten(TestAnzeige.Timeout, (uint)bitMuster, kommentar);
    }
}