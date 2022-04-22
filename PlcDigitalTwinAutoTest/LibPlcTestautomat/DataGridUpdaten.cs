using Contracts;
using LibPlcTools;
using SoftCircuits.Silk;

namespace LibPlcTestautomat;

public partial class TestAutomat
{
    public void InfoAnzeigen(string zeit, TestAnzeige testAnzeige, string kommentar)
    {
        _zeilenNummerDataGrid++;
        _cbUpdateDataGrid(new DataGridZeile(_zeilenNummerDataGrid, zeit, testAnzeige, kommentar, "", "", ""));
    }
    public void FuncKommentarAnzeigen(FunctionEventArgs args)
    {
        var kommentar = args.Parameters[0].ToString();
        _zeilenNummerDataGrid++;
        _cbUpdateDataGrid(new DataGridZeile(_zeilenNummerDataGrid, "", TestAnzeige.Kommentar, kommentar, "", "", ""));
    }
    public void FuncVersionAnzeigen()
    {
        _cbUpdateDataGrid(new DataGridZeile(_zeilenNummerDataGrid, "", TestAnzeige.Projektbezeichnung, $"SW PC: {_datenstruktur.VersionsStringLokal}", "", "", ""));
        _zeilenNummerDataGrid++;

        _cbUpdateDataGrid(new DataGridZeile(_zeilenNummerDataGrid, "", TestAnzeige.Projektbezeichnung, $"SW PLC: {_datenstruktur.VersionsStringPlc}", "", "", ""));
        _zeilenNummerDataGrid++;
    }
    private void DataGridUpdaten(TestAnzeige testErgebnis, uint digOutSoll, string silkKommentar)
    {
        var diIst = new Uint(GetDigtalInputWord().ToString());
        var daIst = new Uint(GetDigitalOutputWord().ToString());
        var daSoll = new Uint(digOutSoll.ToString());

        _cbUpdateDataGrid?.Invoke(new DataGridZeile(_zeilenNummerDataGrid,
            $"{StopwatchGetElapsedMilliseconds()}ms",
            testErgebnis,
            diIst.GetBinBit(GetAnzahlBitEingaenge()),
            daSoll.GetBinBit(GetAnzahlBitAusgaenge()),
            daIst.GetBinBit(GetAnzahlBitAusgaenge()),
            silkKommentar));
    }
}