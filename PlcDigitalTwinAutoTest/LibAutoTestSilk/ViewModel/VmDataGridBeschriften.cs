using LibConfigDt;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace LibAutoTestSilk.ViewModel;

public partial class VmAutoTesterSilk
{
    private readonly EaConfig[] _daZeilenAlt = new EaConfig[32];
    private readonly EaConfig[] _diZeilenAlt = new EaConfig[32];

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

        TabBeschriftungDa(configDt.DtConfig.DigitaleAusgaenge.EaConfigs, DaCollection, _daZeilenAlt);
        TabBeschriftungDa(configDt.DtConfig.DigitaleEingaenge.EaConfigs, DiCollection, _diZeilenAlt);

        AlleDpAktualisieren();
    }
    private static void TabBeschriftungDa(EaConfig[] eaZeilen, IReadOnlyList<VmDatenpunkte> vmDatenpunktes, EaConfig[] daZeilenAlt)
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