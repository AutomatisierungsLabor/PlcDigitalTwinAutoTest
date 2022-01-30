using LibTestDatensammlung;

namespace LibPlcTestautomat;

public partial class TestAutomat
{
    private void DataGridUpdaten(TestAnzeige testErgebnis, uint digOutSoll, string silkKommentar)
    {
        /*
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
                VmAutoTesterSilk.UpdateDataGrid(new DataGridZeile(
                    VmAutoTesterSilk.ZeilenNummerDataGrid,
                    "",
                    testErgebnis,
                    silkKommentar,
                    "",
                    "",
                    ""));
                break;
            default:
                VmAutoTesterSilk.UpdateDataGrid(new DataGridZeile(
                    VmAutoTesterSilk.ZeilenNummerDataGrid,
                    $"{SilkStopwatch.ElapsedMilliseconds}ms",
                    testErgebnis,
                    dInput.GetBinBit(TestAutomat.GetAnzahlBitEingaenge()),
                    dOutputSoll.GetBinBit(TestAutomat.GetAnzahlBitAusgaenge()),
                    dOutputIst.GetBinBit(TestAutomat.GetAnzahlBitAusgaenge()),
                    silkKommentar));
                break;
        }
        */
    }
}