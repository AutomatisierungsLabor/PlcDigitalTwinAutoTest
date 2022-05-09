using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using LibConfigDt;

namespace LibAutoTestSilk.ViewModel;

public partial class VmAutoTesterSilk
{
    private readonly EAConfig[] _daZeilenAlt = new EAConfig[32];
    private readonly EAConfig[] _diZeilenAlt = new EAConfig[32];

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

        TabBeschriftungDa(configDt.DtConfig.DigitaleAusgaenge, DaCollection, _daZeilenAlt);
        TabBeschriftungDa(configDt.DtConfig.DigitaleEingaenge, DiCollection, _diZeilenAlt);

        AlleDpAktualisieren();
    } 
    private static void TabBeschriftungDa(EAConfig[] eaZeilen, IReadOnlyList<VmDatenpunkte> vmDatenpunktes, EAConfig[] daZeilenAlt)
    {
        if (daZeilenAlt == eaZeilen) return;
        // ReSharper disable once RedundantAssignment
        daZeilenAlt = eaZeilen;

        for (var i = 0; i < 20; i++) vmDatenpunktes[i].DpVisibility = Visibility.Hidden;

        foreach (var zeile in eaZeilen)
        {
            var bitPos = 10 * zeile.StartByte + zeile.StartBit;

            vmDatenpunktes[bitPos].DpVisibility = Visibility.Visible;
            vmDatenpunktes[bitPos].DpBezeichnung = zeile.Bezeichnung;
        }
    }
}