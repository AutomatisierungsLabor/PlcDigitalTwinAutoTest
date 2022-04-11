using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using LibConfigPlc;

namespace LibAutoTestSilk.ViewModel;

public partial class VmAutoTesterSilk
{
    private ObservableCollection<DaEinstellungen> _daZeilenAlt = new();
    private ObservableCollection<DiEinstellungen> _diZeilenAlt = new();

    internal void DataGridBeschriften(DirectoryInfo ordnerAktuellesProjekt, ConfigPlc configPlc)
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

        TabBeschriftungDa(configPlc.Da.Zeilen, DaCollection);
        TabBeschrifungDi(configPlc.Di.Zeilen, DiCollection);

        AlleDpAktualisieren();
    }
    private void TabBeschriftungDa(ObservableCollection<DaEinstellungen> daZeilen, IReadOnlyList<VmDatenpunkte> vmDatenpunktes)
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
    private void TabBeschrifungDi(ObservableCollection<DiEinstellungen> diZeilen, IReadOnlyList<VmDatenpunkte> vmDatenpunktes)
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