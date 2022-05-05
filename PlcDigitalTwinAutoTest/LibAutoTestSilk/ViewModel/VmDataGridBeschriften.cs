using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using LibConfigDt;

namespace LibAutoTestSilk.ViewModel;

public partial class VmAutoTesterSilk
{
    private DaConfig[] _daZeilenAlt = new DaConfig[32];
    private DiConfig[] _diZeilenAlt = new DiConfig[32];

    internal void DataGridBeschriften(DirectoryInfo ordnerAktuellesProjekt, ConfigDt configDt)
    {
        try
        {
            var pfad = Path.Combine(ordnerAktuellesProjekt.ToString(), "test.ssc");
            Log.Debug("TestSource: " + pfad);
            StringSourceCode = File.ReadAllText(pfad);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        TabBeschriftungDa(configDt.DtConfig.DigitaleAusgaenge, DaCollection);
        TabBeschrifungDi(configDt.DtConfig.DigitaleEingaenge, DiCollection);

        AlleDpAktualisieren();
    } 
    private void TabBeschriftungDa(DaConfig[] daZeilen, IReadOnlyList<VmDatenpunkte> vmDatenpunktes)
    {
        if (_daZeilenAlt == daZeilen) return;
        _daZeilenAlt = daZeilen;

        for (var i = 0; i < 20; i++) vmDatenpunktes[i].DpVisibility = Visibility.Hidden;

        foreach (var zeile in daZeilen)
        {
            var bitPos = 10 * zeile.StartByte + zeile.StartBit;

            vmDatenpunktes[bitPos].DpVisibility = Visibility.Visible;
            vmDatenpunktes[bitPos].DpBezeichnung = zeile.Bezeichnung;
        }
    }
    private void TabBeschrifungDi(DiConfig[] diZeilen, IReadOnlyList<VmDatenpunkte> vmDatenpunktes)
    {
        if (_diZeilenAlt == diZeilen) return;
        _diZeilenAlt = diZeilen;

        for (var i = 0; i < 20; i++) vmDatenpunktes[i].DpVisibility = Visibility.Hidden;

        foreach (var zeile in diZeilen)
        {
            var bitPos = 10 * zeile.StartByte + zeile.StartBit;

            vmDatenpunktes[bitPos].DpVisibility = Visibility.Visible;
            vmDatenpunktes[bitPos].DpBezeichnung = zeile.Bezeichnung;
        }
    }
}