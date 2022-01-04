using SoftCircuits.Silk;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace LibAutoTestSilk.Silk;

public partial class Silk
{
    private void TestAblauf(FunctionEventArgs e)
    {
        var listeDi = new List<DiSetzen>();
        var listeDa = new List<DaTesten>();

        for (var i = 0; i < e.Parameters[0].ListCount; i++)
        {
            listeDi.Add(new DiSetzen(
                (ulong)e.Parameters[0][i][0].ToInteger(),
                e.Parameters[0][i][1].ToString(),
                e.Parameters[0][i][2].ToString()));
        }
        //DiSetzen.SetAktuellerSchritt(0);

        for (var i = 0; i < e.Parameters[1].ListCount; i++)
        {
            listeDa.Add(new DaTesten(
                (ulong)e.Parameters[1][i][0].ToInteger(),
                (ulong)e.Parameters[1][i][1].ToInteger(),
                e.Parameters[1][i][2].ToString(),
                e.Parameters[1][i][3].ToFloat(),
                e.Parameters[1][i][4].ToString(),
                e.Parameters[1][i][5].ToString()));
        }
        //DaTesten.SetAktuellerSchritt(0);

        var gesamteTimeOutZeit = listeDa.Sum(test => test.GetTimeoutMs());

        var stopwatch = new Stopwatch();

        stopwatch.Start();

        while (stopwatch.ElapsedMilliseconds < gesamteTimeOutZeit)
        {
            Thread.Sleep(10);

            var testAblaufDiFertig = FunktionDigEingaenge(listeDi, stopwatch);
            var testAblaufDaFertig = FunktionDigAusgaenge(listeDa, stopwatch);

            if (testAblaufDiFertig && testAblaufDaFertig) return;
        }
        DataGridAnzeigeUpdaten(TestAutomat.TestAnzeige.Timeout, 0, "uups");
    }
    private bool FunktionDigEingaenge(IReadOnlyList<DiSetzen> listeDi, Stopwatch aktuelleZeit)
    {
        var schritt = 0; //DiSetzen.GetAktuellerSchritt();
        var aufgabe = listeDi[schritt];

        switch (aufgabe.GetAktuellerStatus())
        {
            case DiSetzen.StatusDi.Init:
                if (aufgabe.GetDauer().DauerMs == 0)
                {
                    aufgabe.SetAktuellerStatus(DiSetzen.StatusDi.SchrittAbgeschlossen);
                    return true;
                }

                DataGridAnzeigeUpdaten(TestAutomat.TestAnzeige.Erfolgreich, 0, "DI[" + schritt + "]: " + aufgabe.GetKommentar());
                aufgabe.SetStartzeit(aktuelleZeit.ElapsedMilliseconds);
                aufgabe.SetAktuellerStatus(DiSetzen.StatusDi.SchrittAktiv);
                SetDigitaleEingaengeWord(aufgabe.GetBitmuster());
                return false;

            case DiSetzen.StatusDi.SchrittAktiv:
                SetDigitaleEingaengeWord(aufgabe.GetBitmuster());

                if (aktuelleZeit.ElapsedMilliseconds <= aufgabe.GetEndZeit()) return false;

                aufgabe.SetAktuellerStatus(DiSetzen.StatusDi.SchrittAbgeschlossen);
                //DiSetzen.SetNaechsterSchritt();
                return false;

            case DiSetzen.StatusDi.SchrittAbgeschlossen:
                SetDigitaleEingaengeWord(aufgabe.GetBitmuster());
                break;
            default: throw new ArgumentOutOfRangeException(aufgabe.GetAktuellerStatus().ToString());
        }
        return false;
    }
    private bool FunktionDigAusgaenge(IReadOnlyList<DaTesten> listeDa, Stopwatch aktuelleZeit)
    {
        var schritt = 0; //= DaTesten.GetAktuellerSchritt();
        if (schritt >= listeDa.Count) return true;
        var aufgabe = listeDa[schritt];

        var digBitmaske = aufgabe.GetBitMaske().GetDec();
        var digBitmuster = aufgabe.GetBitMuster().GetDec();
        var digOutputIst = GetDaWord();

        switch (aufgabe.GetAktuellerStatus())
        {
            case DaTesten.StatusDa.Init:
                aufgabe.SetStartzeit(aktuelleZeit.ElapsedMilliseconds);
                aufgabe.SetAktuellerStatus(DaTesten.StatusDa.AufBitmusterWarten);
                VmSilkAutoTester.ZeilenNummerDataGrid++;
                DataGridAnzeigeUpdaten(TestAutomat.TestAnzeige.Aktiv, (uint)digBitmuster, "DA[" + schritt + "]: " + aufgabe.GetKommentar());
                return false;

            case DaTesten.StatusDa.AufBitmusterWarten:
                DataGridAnzeigeUpdaten(TestAutomat.TestAnzeige.AufBitmusterWarten, (uint)digBitmuster, "DA[" + schritt + "]: " + aufgabe.GetKommentar());
                if ((digOutputIst & digBitmaske) == digBitmuster) aufgabe.SetAktuellerStatus(DaTesten.StatusDa.BitmusterLiegtAn);
                if (aktuelleZeit.ElapsedMilliseconds > aufgabe.GetTimeoutMs())
                {
                    DataGridAnzeigeUpdaten(TestAutomat.TestAnzeige.Timeout, (uint)digBitmuster, "DA[" + schritt + "]: " + aufgabe.GetKommentar());
                    aufgabe.SetAktuellerStatus(DaTesten.StatusDa.Timeout);
                    //DaTesten.SetNaechsterSchritt();
                    return false;
                }
                break;

            case DaTesten.StatusDa.BitmusterLiegtAn:
                if ((digOutputIst & digBitmaske) != digBitmuster)
                {
                    if (aktuelleZeit.ElapsedMilliseconds < aufgabe.GetZeitdauerMin())
                    {
                        aufgabe.SetAktuellerStatus(DaTesten.StatusDa.SchrittAbgeschlossen);
                        DataGridAnzeigeUpdaten(TestAutomat.TestAnzeige.ImpulsWarZuKurz, (uint)digBitmuster, "DA[" + schritt + "]: " + aufgabe.GetKommentar());
                        //DaTesten.SetNaechsterSchritt();
                    }

                    if (aktuelleZeit.ElapsedMilliseconds < aufgabe.GetZeitdauerMax())
                    {
                        aufgabe.SetAktuellerStatus(DaTesten.StatusDa.SchrittAbgeschlossen);
                        DataGridAnzeigeUpdaten(TestAutomat.TestAnzeige.Erfolgreich, (uint)digBitmuster, "DA[" + schritt + "]: " + aufgabe.GetKommentar());
                        //DaTesten.SetNaechsterSchritt();
                    }
                }

                if (aktuelleZeit.ElapsedMilliseconds <= aufgabe.GetZeitdauerMax()) return false;

                aufgabe.SetAktuellerStatus(DaTesten.StatusDa.SchrittAbgeschlossen);
                DataGridAnzeigeUpdaten(TestAutomat.TestAnzeige.ImpulsWarZuLang, (uint)digBitmuster, "DA[" + schritt + "]: " + aufgabe.GetKommentar());
                //DaTesten.SetNaechsterSchritt();
                return false;

            case DaTesten.StatusDa.SchrittAbgeschlossen:
            case DaTesten.StatusDa.Timeout:
                DataGridAnzeigeUpdaten(TestAutomat.TestAnzeige.Fehler, (uint)digBitmuster, "DA[" + schritt + "]: " + "Status:" + aufgabe.GetAktuellerStatus());
                return false;
            default: throw new ArgumentOutOfRangeException(aufgabe.GetAktuellerStatus().ToString());
        }
        return false;
    }
}