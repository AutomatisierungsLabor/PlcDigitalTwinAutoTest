﻿using Contracts;
using LibPlcTools;
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

    internal uint GetDigtalInputWord() => Simatic.Digital_CombineTwoByte(_datenstruktur.Di[0], _datenstruktur.Di[1]);
    internal uint GetDigitalOutputWord() => Simatic.Digital_CombineTwoByte(_datenstruktur.Da[0], _datenstruktur.Da[1]);

    private void BitmusterBlinktTesten(FunctionEventArgs args)
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

            var digitalOutput = GetDigitalOutputWord();

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
                                DataGridAnzeigeUpdaten(TestAnzeige.Fehler, (uint)bitMuster, $"{kommentar}: Falsche Periodendauer: {aktuellePeriodenDauer}ms");
                                return;
                            }

                            if (tastverhaeltnis > tastVerhaeltnisMax || tastverhaeltnis < tastVerhaeltnisMin)
                            {
                                DataGridAnzeigeUpdaten(TestAnzeige.Fehler, (uint)bitMuster, $"{kommentar}: Falsches Tastverhältnis: {tastverhaeltnis:F2}ms");
                                return;
                            }

                            periodenAnzahl++;
                            if (periodenAnzahl > anzahlPerioden)
                            {
                                DataGridAnzeigeUpdaten(TestAnzeige.Erfolgreich, (uint)bitMuster, $"{kommentar}: E:{zeitImpuls}ms A: {zeitPause}ms → {100 * tastverhaeltnis:F1}%");
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
                    throw new ArgumentOutOfRangeException(schritte.ToString());
            }

            DataGridAnzeigeUpdaten(TestAnzeige.Aktiv, (uint)bitMuster, $"{kommentar}: I:{zeitImpuls}ms A: {zeitPause}ms → {100 * tastverhaeltnis:F1}%");
        }

        DataGridAnzeigeUpdaten(TestAnzeige.Timeout, (uint)bitMuster, kommentar);
    }
}