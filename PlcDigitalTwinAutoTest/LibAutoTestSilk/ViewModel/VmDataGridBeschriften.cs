using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using LibConfigDt;

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
            if (File.Exists(pfad))
            {
                Log.Debug("TestSource: " + pfad);
                StringSourceCode = File.ReadAllText(pfad);
            }
            else
            {
                Log.Debug("Es fehlt der TestSource: " + pfad);
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        TabBeschriftungDa(configDt.DtConfig.DigitaleAusgaenge.EaConfig, DaCollection, _daZeilenAlt);
        TabBeschriftungDa(configDt.DtConfig.DigitaleEingaenge.EaConfig, DiCollection, _diZeilenAlt);

        AlleDpAktualisieren();
    }
    private static void TabBeschriftungDa(EaConfig[] eaZeilen, IReadOnlyList<VmDatenpunkte> vmDatenpunktes, IEnumerable daZeilenAlt)
    {
        if (daZeilenAlt == eaZeilen) return;

        for (var i = 0; i < 20; i++) vmDatenpunktes[i].DpVisibility = Visibility.Hidden;

        foreach (var zeile in eaZeilen)
        {
            var bitPos = 10 * zeile.StartByte + zeile.StartBit;

            vmDatenpunktes[bitPos].DpVisibility = Visibility.Visible;
            vmDatenpunktes[bitPos].DpBezeichnung = zeile.Bezeichnung;
        }
    }
}