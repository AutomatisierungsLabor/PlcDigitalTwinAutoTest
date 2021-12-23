using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using LibConfigPlc;
using LibDisplayPlc.ViewModel;

namespace LibDisplayPlc.PlcZeichnen;

public class PlcZeichnen
{
    private readonly ConfigPlc _configPlc;

    public PlcZeichnen(ConfigPlc configPlc, Grid plcGrid)
    {
        const int spaltenBreite = 30;
        const int reiheHoehe = 35;
        const int reiheObererRand = 10;
        const int reiheKommentar = 200;
        const int reiheBezeichnung = 50;
        const int reiheLabel = 25;

        const int schriftGanzGross = 35;
        const int schriftGross = 14;
        const int schriftKlein = 12;


        _configPlc = configPlc;


        LibWpf.LibGrid.Zeichnen(50, 20, 25, 20, true, plcGrid);

        LibWpf.LibFormen.Rechteck(1, 40, 10, 9, Brushes.LightGray, plcGrid);
        // LibWpf.LibFormen.Border(3,8,10,3, Brushes.White,new Thickness(3,0,3,3),_grid);

        ///////////////////////////////////////////////////////////////////
        //  obere Hälfte zeichnen
        ///////////////////////////////////////////////////////////////////

        // Linke 8 Eingänge
        LibWpf.LibTexte.Text("DI", 3, 2, 11, 2, HorizontalAlignment.Center, VerticalAlignment.Center, schriftGross, Brushes.White, plcGrid);
        LibWpf.LibTexte.Text("a", 4, 2, 11, 2, HorizontalAlignment.Center, VerticalAlignment.Center, schriftKlein, Brushes.White, plcGrid);
        LibWpf.LibFormen.Border(3, 8, 10, 3, Brushes.White, new Thickness(3, 0, 3, 3), plcGrid);

        for (var i = 0; i < 8; i++)
        {
            LibWpf.LibTexte.TextVertikalVis(3 + i, 1, 2, 6, HorizontalAlignment.Center, VerticalAlignment.Center, 10, Brushes.Black, i + (int)WpfObjects.DiBeschreibung00, plcGrid);
            LibWpf.LibTexte.TextVis(3 + i, 1, 9, 1, HorizontalAlignment.Center, VerticalAlignment.Center, 10, Brushes.Black, i + (int)WpfObjects.Di00, plcGrid);
            LibWpf.LibFormen.RechteckFarbeUmschalten(3 + i, 1, 9, 1, Brushes.Black, new Thickness(1, 1, 1, 1), i + (int)WpfObjects.Di00, plcGrid);
            LibWpf.LibTexte.Text($".{i}", 3 + i, 2, 10, 2, HorizontalAlignment.Left, VerticalAlignment.Center, schriftKlein, Brushes.White, plcGrid);
        }

        // Rechte 8 Eingänge
        LibWpf.LibTexte.Text("DI",  13, 2, 11, 2, HorizontalAlignment.Center, VerticalAlignment.Center, schriftGross, Brushes.White, plcGrid);
        LibWpf.LibTexte.Text("b", 14, 2, 11, 2, HorizontalAlignment.Center, VerticalAlignment.Center, schriftKlein, Brushes.White, plcGrid);
        LibWpf.LibFormen.Border(13, 8, 10, 3, Brushes.White, new Thickness(3, 0, 3, 3), plcGrid);

        for (var i = 0; i < 8; i++)
        {
            LibWpf.LibTexte.TextVertikalVis(13 + i, 1, 2, 6, HorizontalAlignment.Center, VerticalAlignment.Center, 10, Brushes.Black, i + (int)WpfObjects.DiBeschreibung10, plcGrid);
            LibWpf.LibTexte.TextVis(13 + i, 1, 9, 1, HorizontalAlignment.Center, VerticalAlignment.Center, 10, Brushes.Black, i + (int)WpfObjects.Di10, plcGrid);
            LibWpf.LibFormen.RechteckFarbeUmschalten(13 + i, 1, 9, 1, Brushes.Black, new Thickness(1, 1, 1, 1), i + (int)WpfObjects.Di10, plcGrid);
            LibWpf.LibTexte.Text($".{i}", 13 + i, 2, 10, 2, HorizontalAlignment.Left, VerticalAlignment.Center, schriftKlein, Brushes.White, plcGrid);
        }

    }
}