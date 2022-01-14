using System.Text;
using System.Threading;
using LibAutoTestSilk.TestAutomat;
using LibPlcTools;
using SoftCircuits.Silk;

namespace LibAutoTestSilk.Silk;

public partial class Silk
{
    public enum BetriebsartAutoTest
    {
        Automatik = 0,
        Einzelschritt = 1
    }
    private bool EinzelSchrittAusfuehren;
    private BetriebsartAutoTest betriebsartAutoTest = BetriebsartAutoTest.Automatik;
    private int _anzahlBitEingaenge = 16;
    private int _anzahlBitAusgaenge = 16;
    private void IncrementDataGridId()
    {
        VmAutoTesterSilk.ZeilenNummerDataGrid++;

        if (betriebsartAutoTest == BetriebsartAutoTest.Automatik) return;

        while (!EinzelSchrittAusfuehren)
        {
            Thread.Sleep(10);
        }

        EinzelSchrittAusfuehren = false;
    }
    private void UpdateAnzeige(FunctionEventArgs e)
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
    private void DataGridAnzeigeUpdaten(TestAnzeige testErgebnis, uint digOutSoll, string silkKommentar)
    {
        var digitalInput = GetDigtalInputWord();
        var digitalOutput = GetDigitalOutputWord();

        var dInput = new Uint(digitalInput.ToString());
        var dOutputIst = new Uint(digitalOutput.ToString());
        var dOutputSoll = new Uint(digOutSoll.ToString());
        // ReSharper disable once SwitchStatementHandlesSomeKnownEnumValuesWithDefault
        switch (testErgebnis)
        {
            case TestAnzeige.Kommentar:
            case TestAnzeige.Version:
                VmAutoTesterSilk.UpdateDataGrid(new DataGridZeile(
                    VmAutoTesterSilk.ZeilenNummerDataGrid,
                    " ",
                    testErgebnis,
                    silkKommentar,
                    " ",
                    " ",
                    " "));
                break;
            default:
                VmAutoTesterSilk.UpdateDataGrid(new DataGridZeile(
                    VmAutoTesterSilk.ZeilenNummerDataGrid,
                    $"{SilkStopwatch.ElapsedMilliseconds}ms",
                    testErgebnis,
                    dInput.GetHexBit(_anzahlBitEingaenge) + "  " + dInput.GetBinBit(_anzahlBitEingaenge),
                    dOutputSoll.GetHexBit(_anzahlBitAusgaenge) + "  " + dOutputSoll.GetBinBit(_anzahlBitAusgaenge),
                    dOutputIst.GetHexBit(_anzahlBitAusgaenge) + "  " + dOutputIst.GetBinBit(_anzahlBitAusgaenge),
                    silkKommentar));
                break;
        }
    }
    private void KommentarAnzeigen(FunctionEventArgs e)
    {
        var kommentar = e.Parameters[0].ToString();
        VmAutoTesterSilk.ZeilenNummerDataGrid++;
        DataGridAnzeigeUpdaten(TestAnzeige.Kommentar, 0, kommentar);
    }
    private void VersionAnzeigen()
    {
       // var textLaenge = "DummyText VersionInputSps";// Datenstruktur.VersionInputSps[1];
        var enc = new ASCIIEncoding();
        //var version = enc.GetString(Datenstruktur.VersionInputSps, 2, textLaenge);
        
        DataGridAnzeigeUpdaten(TestAnzeige.Version, 0, "Dummy Text");
       
        VmAutoTesterSilk.ZeilenNummerDataGrid++;
    }

    public void EinzelnerSchrittAusfuehren() => EinzelSchrittAusfuehren = true;

    public void SetBetriebsart(bool b) => betriebsartAutoTest = b ? BetriebsartAutoTest.Einzelschritt : BetriebsartAutoTest.Automatik;
}