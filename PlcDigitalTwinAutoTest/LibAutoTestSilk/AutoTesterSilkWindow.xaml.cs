using LibAutoTestSilk.Model;
using LibAutoTestSilk.ViewModel;
using LibConfigPlc;
using LibDatenstruktur;
using System;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media;
using LibAutoTestSilk.TestAutomat;
using LibAutoTestSilk.Zeichnen;

namespace LibAutoTestSilk;

public partial class AutoTesterWindow
{
    public ModelAutoTesterSilk ModelSilkAutoTester { get; set; }
    public VmAutoTesterSilk VmAutoTesterSilk { get; set; }
    public DirectoryInfo OrdnerAktuellesProjekt { get; set; }
    private bool FensterAktiv;

    public AutoTesterWindow(Datenstruktur datenstruktur, ConfigPlc configPlc)
    {
        VmAutoTesterSilk = new VmAutoTesterSilk();
        ModelSilkAutoTester = new ModelAutoTesterSilk(this, datenstruktur, configPlc, VmAutoTesterSilk);

        InitializeComponent();
        DataContext = VmAutoTesterSilk;

        _ = new DiDaBeschriften(GridTest);

        DataGrid.ItemContainerGenerator.StatusChanged += (_, _) =>
        {

            var count = VmAutoTesterSilk.DataGridZeilen.Count;
            if (count < 1) return;

            for (var zeile = 0; zeile < count; zeile++)
            {
                var row = (DataGridRow)DataGrid.ItemContainerGenerator.ContainerFromIndex(zeile);
                if (row == null) continue;

                row.Background = VmAutoTesterSilk.DataGridZeilen[zeile].Ergebnis switch
                {
                    TestAnzeige.Aktiv => Brushes.White,
                    TestAnzeige.AufBitmusterWarten => Brushes.Yellow,
                    TestAnzeige.CompilerErfolgreich => Brushes.LawnGreen,
                    TestAnzeige.CompilerError => Brushes.Red,
                    TestAnzeige.Erfolgreich => Brushes.LawnGreen,
                    TestAnzeige.Fehler => Brushes.Red,
                    TestAnzeige.ImpulsWarZuKurz => Brushes.LawnGreen,
                    TestAnzeige.ImpulsWarZuLang => Brushes.LawnGreen,
                    TestAnzeige.Init => Brushes.Aquamarine,
                    TestAnzeige.Kommentar => Brushes.White,
                    TestAnzeige.TestEnde => Brushes.CornflowerBlue,
                    TestAnzeige.TestStart => Brushes.CornflowerBlue,
                    TestAnzeige.Timeout => Brushes.Orange,
                    TestAnzeige.UnbekanntesErgebnis => Brushes.Red,
                    TestAnzeige.Projektbezeichnung => Brushes.White,
                    TestAnzeige.CompilerStart => Brushes.Cyan,
                    _ => throw new ArgumentOutOfRangeException("Unbekanntés Ergebnis" + VmAutoTesterSilk.DataGridZeilen[zeile].Ergebnis)
                };
            }
        };

        FensterAktiv = true;
        Closing += (_, e) =>
        {
            e.Cancel = true;
            if (FensterAktiv)
            {
                FensterAktiv = false;
                Hide();
            }
            else
            {
                FensterAktiv = true;
                Show();
            }

        };
    }
}