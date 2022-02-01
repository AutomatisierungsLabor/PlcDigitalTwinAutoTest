using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Media;
using LibConfigPlc;
using Contracts;

namespace LibAutoTestSilk.ViewModel;

public partial class VmAutoTesterSilk
{
    private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);

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
    }
    internal void SetNeuesTestProjekt(DirectoryInfo ordnerAktuellesProjekt, ConfigPlc configPlc)
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

        for (var i = 0; i < 100; i++) SichtbarEin[i] = Visibility.Hidden;

        foreach (var zeile in configPlc.Di.Zeilen)
        {
            var bitPos = (int)WpfIndex.Di01 + 8 * zeile.StartByte + zeile.StartBit;
            if (bitPos > (int)WpfIndex.Di17) throw new ArgumentOutOfRangeException(bitPos.ToString());

            SichtbarEin[bitPos] = Visibility.Visible;
            Text[bitPos] = zeile.Bezeichnung;
        }

        foreach (var zeile in configPlc.Da.Zeilen)
        {
            var bitPos = (int)WpfIndex.Da01 + 8 * zeile.StartByte + zeile.StartBit;
            if (bitPos > (int)WpfIndex.Da17) throw new ArgumentOutOfRangeException(bitPos.ToString());

            SichtbarEin[bitPos] = Visibility.Visible;
            Text[bitPos] = zeile.Bezeichnung;
        }
    }

    public void DataGridKommentarAnzeigen(short zeilenNr, string zeit, TestAnzeige ergebnis, string digInput) => DataGridZeilen.Add(new DataGridZeile(zeilenNr, zeit, ergebnis, digInput, " ", " ", " "));
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