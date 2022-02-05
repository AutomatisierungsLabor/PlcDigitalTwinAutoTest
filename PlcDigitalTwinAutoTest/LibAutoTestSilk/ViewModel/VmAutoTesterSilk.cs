using Contracts;
using LibConfigPlc;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Media;

namespace LibAutoTestSilk.ViewModel;

public partial class VmAutoTesterSilk
{
    private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);


    private ObservableCollection<DaEinstellungen> _daZeilenAlt = new();
    private ObservableCollection<DiEinstellungen> _diZeilenAlt = new();

    public enum WpfIndex
    {
        Di01 = 0,
        Di17 = 15,
        Da01 = 16,
        Da17 = 31,
        SoureCode = 32
    }
    public VmAutoTesterSilk()
    {
        DataGridZeilen = new ObservableCollection<DataGridZeile>();

        for (var i = 0; i < 100; i++)
        {
            SichtbarEin.Add(Visibility.Hidden);
            Farbe.Add(Brushes.White);
            Text.Add("");
        }
    } internal void SetNeuesTestProjekt(DirectoryInfo ordnerAktuellesProjekt, ConfigPlc configPlc)
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
        
        DaZeilenZeichnen(configPlc.Da.Zeilen);
        DiZeilenZeichnen(configPlc.Di.Zeilen);
    }
    private void DaZeilenZeichnen(ObservableCollection<DaEinstellungen> daZeilen)
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
    private void DiZeilenZeichnen(ObservableCollection<DiEinstellungen> diZeilen)
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

    public void DataGridNeueDaten(DataGridZeile zeile)
    {
        UpdateDataGrid(zeile);
    }
    public void UpdateDataGrid(DataGridZeile zeile)
    {
        Application.Current.Dispatcher.Invoke(() =>
        {
            var zeilenNr = zeile.ZeilenNr;
            if (DataGridZeilen.Count <= zeilenNr) DataGridZeilen.Add(zeile);
            else DataGridZeilen[zeilenNr] = zeile;
        });
    }
}