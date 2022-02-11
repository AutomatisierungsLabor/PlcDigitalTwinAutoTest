using Contracts;
using SoftCircuits.Silk;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace LibAutoTestSilk.Silk;

public partial class Silk
{
    private int _diAktuellerSchtritt;
    private int _daAktuellerSchritt;
    private void TestAblauf(FunctionEventArgs args)
    {
        var listeDigEingaenge = new List<DiSetzen>();
        _diAktuellerSchtritt = 0;

        for (var i = 0; i < args.Parameters[0].ListCount; i++)
        {
            listeDigEingaenge.Add(new DiSetzen(
                (ulong)args.Parameters[0][i][0].ToInteger(),
                args.Parameters[0][i][1].ToString(),
                args.Parameters[0][i][2].ToString()));
        }


        var listeDigAusgaenge = new List<DaTesten>();
        _daAktuellerSchritt = 0;

        for (var i = 0; i < args.Parameters[1].ListCount; i++)
        {
            listeDigAusgaenge.Add(new DaTesten(
                (ulong)args.Parameters[1][i][0].ToInteger(),
                (ulong)args.Parameters[1][i][1].ToInteger(),
                args.Parameters[1][i][2].ToString(),
                args.Parameters[1][i][3].ToFloat(),
                args.Parameters[1][i][4].ToString(),
                args.Parameters[1][i][5].ToString()));
        }

        var gesamteTimeOutZeit = listeDigAusgaenge.Sum(test => test.GetTimeoutMs());
        var stopwatch = new Stopwatch();

        stopwatch.Start();

        while (stopwatch.ElapsedMilliseconds < gesamteTimeOutZeit)
        {
            Thread.Sleep(10);

            var testAblaufDiFertig = FunktionDigEingaenge(listeDigEingaenge, stopwatch);
            var testAblaufDaFertig = FunktionDigAusgaenge(listeDigAusgaenge, stopwatch);

            if (testAblaufDiFertig && testAblaufDaFertig) return;
        }
        DataGridAnzeigeUpdaten(TestAnzeige.Timeout, 0, "uups");
    }
    private bool FunktionDigEingaenge(IReadOnlyList<DiSetzen> listeDi, Stopwatch aktuelleZeit)
    {
        var aktZeileDi = listeDi[_diAktuellerSchtritt];
        switch (aktZeileDi.GetAktuellerStatus())
        {
            case DiSetzen.StatusDigEingaenge.Init:
                if (aktZeileDi.GetDauer().DauerMs == 0)
                {
                    aktZeileDi.SetAktuellerStatus(DiSetzen.StatusDigEingaenge.SchrittAbgeschlossen);
                    return true;
                }

                DataGridAnzeigeUpdaten(TestAnzeige.Erfolgreich, 0, "DI[" + _diAktuellerSchtritt + "]: " + aktZeileDi.GetKommentar());
                aktZeileDi.SetStartzeit(aktuelleZeit.ElapsedMilliseconds);
                aktZeileDi.SetAktuellerStatus(DiSetzen.StatusDigEingaenge.SchrittAktiv);
                SetDigitaleEingaengeWord(aktZeileDi.GetBitmuster());
                return false;

            case DiSetzen.StatusDigEingaenge.SchrittAktiv:
                SetDigitaleEingaengeWord(aktZeileDi.GetBitmuster());

                if (aktuelleZeit.ElapsedMilliseconds <= aktZeileDi.GetEndZeit()) return false;

                aktZeileDi.SetAktuellerStatus(DiSetzen.StatusDigEingaenge.SchrittAbgeschlossen);
                _diAktuellerSchtritt++;
                return false;

            case DiSetzen.StatusDigEingaenge.SchrittAbgeschlossen:
                SetDigitaleEingaengeWord(aktZeileDi.GetBitmuster());
                break;
            default: throw new ArgumentOutOfRangeException(aktZeileDi.GetAktuellerStatus().ToString());
        }
        return false;
    }
    private bool FunktionDigAusgaenge(IReadOnlyList<DaTesten> listeDa, Stopwatch aktuelleZeit)
    {
        if (_daAktuellerSchritt >= listeDa.Count) return true;
        var aktZeileDa = listeDa[_daAktuellerSchritt];

        var digBitmaske = aktZeileDa.GetBitMaske().GetDec();
        var digBitmuster = aktZeileDa.GetBitMuster().GetDec();
        var digOutputIst = GetDigitalOutputWord();

        switch (aktZeileDa.GetAktuellerStatus())
        {
            case DaTesten.StatusDigAusgaenge.Init:
                aktZeileDa.SetStartzeit(aktuelleZeit.ElapsedMilliseconds);
                aktZeileDa.SetAktuellerStatus(DaTesten.StatusDigAusgaenge.AufBitmusterWarten);
                _vmAutoTesterSilk.ZeilenNummerDataGrid++;
                DataGridAnzeigeUpdaten(TestAnzeige.Aktiv, (uint)digBitmuster, "DA[" + _daAktuellerSchritt + "]: " + aktZeileDa.GetKommentar());
                return false;

            case DaTesten.StatusDigAusgaenge.AufBitmusterWarten:
                DataGridAnzeigeUpdaten(TestAnzeige.AufBitmusterWarten, (uint)digBitmuster, "DA[" + _daAktuellerSchritt + "]: " + aktZeileDa.GetKommentar());
                if ((digOutputIst & digBitmaske) == digBitmuster) aktZeileDa.SetAktuellerStatus(DaTesten.StatusDigAusgaenge.BitmusterLiegtAn);
                if (aktuelleZeit.ElapsedMilliseconds > aktZeileDa.GetTimeoutMs())
                {
                    DataGridAnzeigeUpdaten(TestAnzeige.Timeout, (uint)digBitmuster, "DA[" + _daAktuellerSchritt + "]: " + aktZeileDa.GetKommentar());
                    aktZeileDa.SetAktuellerStatus(DaTesten.StatusDigAusgaenge.Timeout);
                    _daAktuellerSchritt++;
                    return false;
                }
                break;

            case DaTesten.StatusDigAusgaenge.BitmusterLiegtAn:
                if ((digOutputIst & digBitmaske) != digBitmuster)
                {
                    if (aktuelleZeit.ElapsedMilliseconds < aktZeileDa.GetZeitdauerMin())
                    {
                        aktZeileDa.SetAktuellerStatus(DaTesten.StatusDigAusgaenge.SchrittAbgeschlossen);
                        DataGridAnzeigeUpdaten(TestAnzeige.ImpulsWarZuKurz, (uint)digBitmuster, "DA[" + _daAktuellerSchritt + "]: " + aktZeileDa.GetKommentar());
                        _daAktuellerSchritt++;
                    }

                    if (aktuelleZeit.ElapsedMilliseconds < aktZeileDa.GetZeitdauerMax())
                    {
                        aktZeileDa.SetAktuellerStatus(DaTesten.StatusDigAusgaenge.SchrittAbgeschlossen);
                        DataGridAnzeigeUpdaten(TestAnzeige.Erfolgreich, (uint)digBitmuster, "DA[" + _daAktuellerSchritt + "]: " + aktZeileDa.GetKommentar());
                        _daAktuellerSchritt++;
                    }
                }

                if (aktuelleZeit.ElapsedMilliseconds <= aktZeileDa.GetZeitdauerMax()) return false;

                aktZeileDa.SetAktuellerStatus(DaTesten.StatusDigAusgaenge.SchrittAbgeschlossen);
                DataGridAnzeigeUpdaten(TestAnzeige.ImpulsWarZuLang, (uint)digBitmuster, "DA[" + _daAktuellerSchritt + "]: " + aktZeileDa.GetKommentar());
                _daAktuellerSchritt++;
                return false;

            case DaTesten.StatusDigAusgaenge.SchrittAbgeschlossen:
            case DaTesten.StatusDigAusgaenge.Timeout:
                DataGridAnzeigeUpdaten(TestAnzeige.Fehler, (uint)digBitmuster, "DA[" + _daAktuellerSchritt + "]: " + "Status:" + aktZeileDa.GetAktuellerStatus());
                return false;
            default: throw new ArgumentOutOfRangeException(aktZeileDa.GetAktuellerStatus().ToString());
        }
        return false;
    }
}