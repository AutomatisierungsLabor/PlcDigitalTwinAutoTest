using System;
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
            Text[(int)WpfIndex.SoureCode] = File.ReadAllText(pfad);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        TabBeschriftungDa(configPlc.Da.Zeilen);
        TabBeschrifungDi(configPlc.Di.Zeilen);
    }
    private void TabBeschriftungDa(ObservableCollection<DaEinstellungen> daZeilen)
    {
        if (_daZeilenAlt == daZeilen) return;
        _daZeilenAlt = daZeilen;

        for (var i = (int)WpfIndex.Da01; i <= (int)WpfIndex.Da17; i++) SichtbarEin[i] = Visibility.Hidden;

        foreach (var zeile in daZeilen)
        {
            var bitPos = (int)WpfIndex.Da01 + 8 * zeile.StartByte + zeile.StartBit;
            if (bitPos > (int)WpfIndex.Da17) throw new ArgumentOutOfRangeException(bitPos.ToString());

            SichtbarEin[bitPos] = Visibility.Visible;
            Text[bitPos] = zeile.Bezeichnung;
        }
    }
    private void TabBeschrifungDi(ObservableCollection<DiEinstellungen> diZeilen)
    {
        if (_diZeilenAlt == diZeilen) return;
        _diZeilenAlt = diZeilen;

        for (var i = (int)WpfIndex.Di01; i <= (int)WpfIndex.Di17; i++) SichtbarEin[i] = Visibility.Hidden;

        foreach (var zeile in diZeilen)
        {
            var bitPos = (int)WpfIndex.Di01 + 8 * zeile.StartByte + zeile.StartBit;
            if (bitPos > (int)WpfIndex.Di17) throw new ArgumentOutOfRangeException(bitPos.ToString());

            SichtbarEin[bitPos] = Visibility.Visible;
            Text[bitPos] = zeile.Bezeichnung;
        }
    }
}