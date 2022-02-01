using LibPlcTools;
using Contracts;
using SoftCircuits.Silk;

namespace LibPlcTestautomat;

public partial class TestAutomat
{
    public void KommentarAnzeigen(FunctionEventArgs functionEventArgs)
    {
        var kommentar = functionEventArgs.Parameters[0].ToString();
        _zeilenNummerDataGrid++;
        _cbUpdateDataGrid(new DataGridZeile(_zeilenNummerDataGrid, "", TestAnzeige.Kommentar, kommentar, "", "", ""));
    }
    public void VersionAnzeigen()
    {
        _cbUpdateDataGrid(new DataGridZeile(_zeilenNummerDataGrid, "", TestAnzeige.Projektbezeichnung, $"SW PC: {_datenstruktur.VersionsStringLokal}","","",""));
        _zeilenNummerDataGrid++;

        _cbUpdateDataGrid(new DataGridZeile(_zeilenNummerDataGrid, "", TestAnzeige.Projektbezeichnung, $"SW PLC: {_datenstruktur.VersionsStringPlc}", "", "", ""));
        _zeilenNummerDataGrid++;
    }
    public void UpdateAnzeige(FunctionEventArgs functionEventArgs)
    {
        var silkTestergebnis = functionEventArgs.Parameters[0].ToString();
        var silkKommentar = functionEventArgs.Parameters[1].ToString();
        
        var ergebnis = silkTestergebnis switch
        {
            "Kommentar" => TestAnzeige.Kommentar,
            "Aktiv" => TestAnzeige.Aktiv,
            "Init" => TestAnzeige.Init,
            "Erfolgreich" => TestAnzeige.Erfolgreich,
            "Timeout" => TestAnzeige.Timeout,
            "Fehler" => TestAnzeige.Fehler,
            "TestEnde" => TestAnzeige.TestEnde,
            _ => TestAnzeige.UnbekanntesErgebnis
        };
        
        _cbUpdateDataGrid(new DataGridZeile(_zeilenNummerDataGrid, "", ergebnis, silkKommentar, "", "", ""));
        _zeilenNummerDataGrid++;
    }
    private void DataGridUpdaten(TestAnzeige testErgebnis, uint digOutSoll, string silkKommentar)
    {
        var diIst = new Uint(GetDigtalInputWord().ToString());
        var daIst = new Uint(GetDigitalOutputWord().ToString());
        var daSoll = new Uint(digOutSoll.ToString());

        _cbUpdateDataGrid(new DataGridZeile(_zeilenNummerDataGrid,
            $"{GetElapsedMilliseconds()}ms",
            testErgebnis,
            diIst.GetBinBit(GetAnzahlBitEingaenge()),
            daSoll.GetBinBit(GetAnzahlBitAusgaenge()),
            daIst.GetBinBit(GetAnzahlBitAusgaenge()),
            silkKommentar));

        // ReSharper disable once SwitchStatementHandlesSomeKnownEnumValuesWithDefault
        /*
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