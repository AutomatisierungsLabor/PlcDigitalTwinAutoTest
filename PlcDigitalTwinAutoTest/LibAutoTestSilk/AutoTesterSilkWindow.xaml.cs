using Contracts;
using LibAutoTestSilk.ViewModel;
using LibAutoTestSilk.Zeichnen;
using System;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Media;

namespace LibAutoTestSilk;

public partial class AutoTesterWindow
{
    public AutoTesterWindow(VmAutoTesterSilk vmAutoTesterSilk, CancellationTokenSource cancellationTokenSource, Action closeWindow)
    {
        InitializeComponent();
        DataContext = vmAutoTesterSilk;
        _ = new DiDaBeschriften(GridTest);

        DataGrid.ItemContainerGenerator.StatusChanged += (_, _) =>
        {
            var count = vmAutoTesterSilk.DataGridZeilen.Count;
            if (count < 1) return;

            for (var zeile = 0; zeile < count; zeile++)
            {
                var row = (DataGridRow)DataGrid.ItemContainerGenerator.ContainerFromIndex(zeile);
                if (row == null) continue;

                row.Background = vmAutoTesterSilk.DataGridZeilen[zeile].Ergebnis switch
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
                    _ => throw new ArgumentOutOfRangeException("Unbekanntés Ergebnis" + vmAutoTesterSilk.DataGridZeilen[zeile].Ergebnis)
                };
            }
        };

        Closing += (_, e) =>
        {
            e.Cancel = true;
            Hide();
            closeWindow();
            cancellationTokenSource.Cancel();
            //Application.Current.Shutdown();
        };
    }
}