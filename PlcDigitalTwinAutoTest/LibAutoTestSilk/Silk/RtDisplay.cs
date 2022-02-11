using Contracts;
using LibPlcTools;
using System.Threading;

namespace LibAutoTestSilk.Silk;

public partial class Silk
{
    public enum BetriebsartAutoTest
    {
        Automatik = 0,
        Einzelschritt = 1
    }

    private bool _einzelSchrittAusfuehren;
    private BetriebsartAutoTest _betriebsartAutoTest = BetriebsartAutoTest.Automatik;

    private void FuncIncrementDataGridId()
    {
        _vmAutoTesterSilk.ZeilenNummerDataGrid++;

        if (_betriebsartAutoTest == BetriebsartAutoTest.Automatik) return;

        while (!_einzelSchrittAusfuehren)
        {
            Thread.Sleep(10);
        }

        _einzelSchrittAusfuehren = false;
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
            case TestAnzeige.Projektbezeichnung:
                _vmAutoTesterSilk.UpdateDataGrid(new DataGridZeile(
                    _vmAutoTesterSilk.ZeilenNummerDataGrid,
                    "",
                    testErgebnis,
                    silkKommentar,
                    "",
                    "",
                    ""));
                break;
            default:
                _vmAutoTesterSilk.UpdateDataGrid(new DataGridZeile(
                    _vmAutoTesterSilk.ZeilenNummerDataGrid,
                    $"{_testAutomat.GetElapsedMilliseconds()}ms",
                    testErgebnis,
                     dInput.GetBinBit(_testAutomat.GetAnzahlBitEingaenge()),
                     dOutputSoll.GetBinBit(_testAutomat.GetAnzahlBitAusgaenge()),
                     dOutputIst.GetBinBit(_testAutomat.GetAnzahlBitAusgaenge()),
                    silkKommentar));
                break;
        }
    }
    public void EinzelnerSchrittAusfuehren() => _einzelSchrittAusfuehren = true;
    public void SetBetriebsart(bool b) => _betriebsartAutoTest = b ? BetriebsartAutoTest.Einzelschritt : BetriebsartAutoTest.Automatik;
}