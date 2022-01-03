using System.Text;
using System.Threading;
using LibAutoTestSilk.TestAutomat;
using LibDatenstruktur;
using LibPlc;
using SoftCircuits.Silk;

namespace LibAutoTestSilk.Silk;

public partial class Silk
{
    private static int _anzahlBitEingaenge = 16;
    private static int _anzahlBitAusgaenge = 16;
    private static void IncrementDataGridId()
    {
        VmSilkAutoTester.ZeilenNummerDataGrid++;

        if (Datenstruktur.BetriebsartTestablauf == BetriebsartTestablauf.Automatik) return;

        while (!Datenstruktur.NaechstenSchrittGehen) { Thread.Sleep(10); }

        Datenstruktur.NaechstenSchrittGehen = false;
    }
    private static void UpdateAnzeige(FunctionEventArgs e)
    {
        var silkTestergebnis = e.Parameters[0].ToString();
        var silkKommentar = e.Parameters[1].ToString();

        // ReSharper disable once ConvertSwitchStatementToSwitchExpression
        var ergebnis = silkTestergebnis switch
        {
            "Kommentar" => TestAnzeige.Kommentar,
            "Aktiv" => TestAnzeige.Aktiv,
            "Init" => TestAnzeige.Init,
            "Erfolgreich" => TestAnzeige.Erfolgreich,
            "Timeout" => TestAnzeige.Timeout,
            "Fehler" => TestAnzeige.Fehler,
            "Test abgeschlossen" => TestAnzeige.Kommentar,
            _ => TestAnzeige.UnbekanntesErgebnis
        };

        DataGridAnzeigeUpdaten(ergebnis, 0, silkKommentar);
    }
    private static void DataGridAnzeigeUpdaten(TestAnzeige testAnzeige, uint digOutSoll, string silkKommentar)
    {
        var digitalInput = GetDiWord();
        var digitalOutput = GetDaWord();

        var dInput = new Uint(digitalInput.ToString());
        var dOutputIst = new Uint(digitalOutput.ToString());
        var dOutputSoll = new Uint(digOutSoll.ToString());
        // ReSharper disable once SwitchStatementHandlesSomeKnownEnumValuesWithDefault
        switch (testAnzeige)
        {
            case TestAnzeige.Kommentar:
            case TestAnzeige.Version:
                VmSilkAutoTester.UpdateDataGrid(new DataGridZeile(
                    VmSilkAutoTester.ZeilenNummerDataGrid,
                    " ",
                    testAnzeige,
                    " ",
                    " ",
                    " ",
                    silkKommentar));
                break;
            default:
                VmSilkAutoTester.UpdateDataGrid(new DataGridZeile(
                    VmSilkAutoTester.ZeilenNummerDataGrid,
                   $"{SilkStopwatch.ElapsedMilliseconds}ms",
                    testAnzeige,
                    dInput.GetHexBit(_anzahlBitEingaenge) + "  " + dInput.GetBinBit(_anzahlBitEingaenge),
                    dOutputSoll.GetHexBit(_anzahlBitAusgaenge) + "  " + dOutputSoll.GetBinBit(_anzahlBitAusgaenge),
                    dOutputIst.GetHexBit(_anzahlBitAusgaenge) + "  " + dOutputIst.GetBinBit(_anzahlBitAusgaenge),
                    silkKommentar));
                break;
        }
    }
    private static void KommentarAnzeigen(FunctionEventArgs e)
    {
        var kommentar = e.Parameters[0].ToString();
        VmSilkAutoTester.ZeilenNummerDataGrid++;
        DataGridAnzeigeUpdaten(TestAnzeige.Kommentar, 0, kommentar);
    }
    private static void VersionAnzeigen()
    {
        //var textLaenge = Datenstruktur.VersionInputSps[1];
        var enc = new ASCIIEncoding();
        const string version = "Dieser Text muss noch geändert werden!";
        //  var version = enc.GetString(Datenstruktur.VersionInputSps, 2, textLaenge);

        DataGridAnzeigeUpdaten(TestAnzeige.Version, 0, version);
        VmSilkAutoTester.ZeilenNummerDataGrid++;
    }
}