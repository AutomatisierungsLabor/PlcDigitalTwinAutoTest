using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using LibAutoTestSilk.TestAutomat;
using SoftCircuits.Silk;

namespace LibAutoTestSilk.Silk;

public partial class Silk
{
    private void TestAblauf(FunctionEventArgs e)
    {
        var listeDigEingaenge = new List<DiSetzen>();
        var listeDigAusgaenge = new List<DaTesten>();

        for (var i = 0; i < e.Parameters[0].ListCount; i++)
        {
            listeDigEingaenge.Add(new DiSetzen(
                (ulong)e.Parameters[0][i][0].ToInteger(),   // BitMuster
                e.Parameters[0][i][1].ToString(),              // ZeitDauer
                e.Parameters[0][i][2].ToString()));         // Kommentar
        }
      //  DiSetzen.SetAktuellerSchritt(0);

        for (var i = 0; i < e.Parameters[1].ListCount; i++)
        {
            listeDigAusgaenge.Add(new DaTesten(
                (ulong)e.Parameters[1][i][0].ToInteger(),   // Bitmuster
                (ulong)e.Parameters[1][i][1].ToInteger(),    // Bitmaske
                e.Parameters[1][i][2].ToString(),              // Dauer
                e.Parameters[1][i][3].ToFloat(),             // Toleranz
                e.Parameters[1][i][4].ToString(),            // TimeOut
                e.Parameters[1][i][5].ToString()));         // Kommentar
        }
       // DaTesten.SetAktuellerSchritt(0);

        var gesamteTimeOutZeit = listeDigAusgaenge.Sum(test => test.GetTimeoutMs());

        var stopwatch = new Stopwatch();

        stopwatch.Start();

        while (stopwatch.ElapsedMilliseconds < gesamteTimeOutZeit)
        {
            Thread.Sleep(10);

            var testAblaufDigEingaengeFertig = FunktionDigEingaenge(listeDigEingaenge, stopwatch);
            var testAblaufDigAusgaengeFertig = FunktionDigAusgaenge(listeDigAusgaenge, stopwatch);

            if (testAblaufDigEingaengeFertig && testAblaufDigAusgaengeFertig) return;
        }
        DataGridAnzeigeUpdaten(TestAnzeige.Timeout, 0, "uups");
    }
    private bool FunktionDigEingaenge(IReadOnlyList<DiSetzen> listeDi, Stopwatch aktuelleZeit)
    {
        var schritt = 0; //DiSetzen.GetAktuellerSchritt();
        var aufgabe = listeDi[schritt];

        switch (aufgabe.GetAktuellerStatus())
        {
            case DiSetzen.StatusDigEingaenge.Init:
                if (aufgabe.GetDauer().DauerMs == 0)
                {
                    aufgabe.SetAktuellerStatus(DiSetzen.StatusDigEingaenge.SchrittAbgeschlossen);
                    return true;
                }

                DataGridAnzeigeUpdaten(TestAnzeige.Erfolgreich, 0, "DI[" + schritt + "]: " + aufgabe.GetKommentar());
                aufgabe.SetStartzeit(aktuelleZeit.ElapsedMilliseconds);
                aufgabe.SetAktuellerStatus(DiSetzen.StatusDigEingaenge.SchrittAktiv);
                SetDigitaleEingaengeWord(aufgabe.GetBitmuster());
                return false;

            case DiSetzen.StatusDigEingaenge.SchrittAktiv:
                SetDigitaleEingaengeWord(aufgabe.GetBitmuster());

                if (aktuelleZeit.ElapsedMilliseconds <= aufgabe.GetEndZeit()) return false;

                aufgabe.SetAktuellerStatus(DiSetzen.StatusDigEingaenge.SchrittAbgeschlossen);
               // DiSetzen.SetNaechsterSchritt();
                return false;

            case DiSetzen.StatusDigEingaenge.SchrittAbgeschlossen:
                SetDigitaleEingaengeWord(aufgabe.GetBitmuster());
                break;
            default: throw new ArgumentOutOfRangeException(aufgabe.GetAktuellerStatus().ToString());
        }
        return false;
    }
    private bool FunktionDigAusgaenge(IReadOnlyList<DaTesten> listeDa, Stopwatch aktuelleZeit)
    {
        var schritt = 0; // DaTesten.GetAktuellerSchritt();
        if (schritt >= listeDa.Count) return true;
        var aufgabe = listeDa[schritt];

        var digBitmaske = aufgabe.GetBitMaske().GetDec();
        var digBitmuster = aufgabe.GetBitMuster().GetDec();
        var digOutputIst = GetDigitalOutputWord();

        switch (aufgabe.GetAktuellerStatus())
        {
            case DaTesten.StatusDigAusgaenge.Init:
                aufgabe.SetStartzeit(aktuelleZeit.ElapsedMilliseconds);
                aufgabe.SetAktuellerStatus(DaTesten.StatusDigAusgaenge.AufBitmusterWarten);
                VmAutoTesterSilk.ZeilenNummerDataGrid++;
                DataGridAnzeigeUpdaten(TestAnzeige.Aktiv, (uint)digBitmuster, "DA[" + schritt + "]: " + aufgabe.GetKommentar());
                return false;

            case DaTesten.StatusDigAusgaenge.AufBitmusterWarten:
                DataGridAnzeigeUpdaten(TestAnzeige.AufBitmusterWarten, (uint)digBitmuster, "DA[" + schritt + "]: " + aufgabe.GetKommentar());
                if ((digOutputIst & digBitmaske) == digBitmuster) aufgabe.SetAktuellerStatus(DaTesten.StatusDigAusgaenge.BitmusterLiegtAn);
                if (aktuelleZeit.ElapsedMilliseconds > aufgabe.GetTimeoutMs())
                {
                    DataGridAnzeigeUpdaten(TestAnzeige.Timeout, (uint)digBitmuster, "DA[" + schritt + "]: " + aufgabe.GetKommentar());
                    aufgabe.SetAktuellerStatus(DaTesten.StatusDigAusgaenge.Timeout);
                   // DaTesten.SetNaechsterSchritt();
                    return false;
                }
                break;

            case DaTesten.StatusDigAusgaenge.BitmusterLiegtAn:
                if ((digOutputIst & digBitmaske) != digBitmuster)
                {
                    if (aktuelleZeit.ElapsedMilliseconds < aufgabe.GetZeitdauerMin())
                    {
                        aufgabe.SetAktuellerStatus(DaTesten.StatusDigAusgaenge.SchrittAbgeschlossen);
                        DataGridAnzeigeUpdaten(TestAnzeige.ImpulsWarZuKurz, (uint)digBitmuster, "DA[" + schritt + "]: " + aufgabe.GetKommentar());
                       // DaTesten.SetNaechsterSchritt();
                    }

                    if (aktuelleZeit.ElapsedMilliseconds < aufgabe.GetZeitdauerMax())
                    {
                        aufgabe.SetAktuellerStatus(DaTesten.StatusDigAusgaenge.SchrittAbgeschlossen);
                        DataGridAnzeigeUpdaten(TestAnzeige.Erfolgreich, (uint)digBitmuster, "DA[" + schritt + "]: " + aufgabe.GetKommentar());
                       // DaTesten.SetNaechsterSchritt();
                    }
                }

                if (aktuelleZeit.ElapsedMilliseconds <= aufgabe.GetZeitdauerMax()) return false;

                aufgabe.SetAktuellerStatus(DaTesten.StatusDigAusgaenge.SchrittAbgeschlossen);
                DataGridAnzeigeUpdaten(TestAnzeige.ImpulsWarZuLang, (uint)digBitmuster, "DA[" + schritt + "]: " + aufgabe.GetKommentar());
              //  DaTesten.SetNaechsterSchritt();
                return false;

            case DaTesten.StatusDigAusgaenge.SchrittAbgeschlossen:
            case DaTesten.StatusDigAusgaenge.Timeout:
                DataGridAnzeigeUpdaten(TestAnzeige.Fehler, (uint)digBitmuster, "DA[" + schritt + "]: " + "Status:" + aufgabe.GetAktuellerStatus());
                return false;
            default: throw new ArgumentOutOfRangeException(aufgabe.GetAktuellerStatus().ToString());
        }
        return false;
    }
}