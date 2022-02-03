using LibDisplayPlc.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LibDisplayPlc.PlcZeichnen;

public class PlcZeichnen
{
    public PlcZeichnen(Grid plcGrid)
    {
        const int schriftGanzGross = 50;
        const int schriftGross = 25;
        const int schriftKlein = 18;

        var libWpf = new LibWpf.LibWpf(plcGrid);

        libWpf.GridZeichnen(25, 30, 28, 30, false);

        libWpf.Rechteck(1, 22, 8, 12, Brushes.LightGray);

        ///////////////////////////////////////////////////////////////////
        //  obere Hälfte zeichnen
        ///////////////////////////////////////////////////////////////////

        // Linke 8 Eingänge
        libWpf.Text("DI", 3, 2, 10, 2, HorizontalAlignment.Center, VerticalAlignment.Center, schriftGross, Brushes.White);
        libWpf.Text("a", 4, 2, 10, 2, HorizontalAlignment.Center, VerticalAlignment.Center, schriftKlein, Brushes.White);
        libWpf.Border(3, 8, 8, 4, Brushes.White, new Thickness(3, 0, 3, 3));

        for (var i = 0; i < 8; i++)
        {
            libWpf.TextVertikalVis(3 + i, 1, 1, 6, HorizontalAlignment.Center, VerticalAlignment.Bottom, schriftKlein, new Thickness(0, 0, 0, 0), 180, Brushes.Black, i + (int)WpfObjects.DiBeschreibung00);
            libWpf.TextVis(2 + i, 3, 6, 2, HorizontalAlignment.Center, VerticalAlignment.Bottom, schriftKlein, Brushes.Black, i + (int)WpfObjects.Di00);
            libWpf.RechteckFarbeUmschalten(3 + i, 1, 8, 1, Brushes.Black, new Thickness(1, 1, 1, 1), i + (int)WpfObjects.Di00);
            libWpf.Text($".{i}", 3 + i, 2, 9, 2, HorizontalAlignment.Left, VerticalAlignment.Top, schriftKlein, Brushes.White);
        }
        // Rechte 8 Eingänge
        libWpf.Text("DI", 13, 2, 10, 2, HorizontalAlignment.Center, VerticalAlignment.Center, schriftGross, Brushes.White);
        libWpf.Text("b", 14, 2, 10, 2, HorizontalAlignment.Center, VerticalAlignment.Center, schriftKlein, Brushes.White);
        libWpf.Border(13, 8, 8, 4, Brushes.White, new Thickness(3, 0, 3, 3));

        for (var i = 0; i < 8; i++)
        {
            libWpf.TextVertikalVis(13 + i, 1, 1, 6, HorizontalAlignment.Center, VerticalAlignment.Bottom, schriftKlein, new Thickness(0, 0, 0, 0), 180, Brushes.Black, i + (int)WpfObjects.DiBeschreibung10);
            libWpf.TextVis(12 + i, 3, 8, 2, HorizontalAlignment.Center, VerticalAlignment.Bottom, schriftKlein, Brushes.Black, i + (int)WpfObjects.Di10);
            libWpf.RechteckFarbeUmschalten(13 + i, 1, 8, 1, Brushes.Black, new Thickness(1, 1, 1, 1), i + (int)WpfObjects.Di10);
            libWpf.Text($".{i}", 13 + i, 2, 9, 2, HorizontalAlignment.Left, VerticalAlignment.Top, schriftKlein, Brushes.White);
        }

        ///////////////////////////////////////////////////////////////////
        //  Mitte
        ///////////////////////////////////////////////////////////////////

        libWpf.Text("S7-1214 DC/DC/DC", 3, 18, 12, 4, HorizontalAlignment.Center, VerticalAlignment.Center, schriftGanzGross, Brushes.White);

        ///////////////////////////////////////////////////////////////////
        //  untere Hälfte zeichnen
        ///////////////////////////////////////////////////////////////////

        // Linke 8 Ausgänge
        libWpf.Text("DA", 3, 2, 16, 2, HorizontalAlignment.Center, VerticalAlignment.Center, schriftGross, Brushes.White);
        libWpf.Text("a", 4, 2, 16, 2, HorizontalAlignment.Center, VerticalAlignment.Center, schriftGross, Brushes.White);
        libWpf.Border(3, 8, 16, 4, Brushes.White, new Thickness(3, 3, 3, 0));

        for (var i = 0; i < 8; i++)
        {
            libWpf.TextVertikalVis(3 + i, 1, 21, 6, HorizontalAlignment.Center, VerticalAlignment.Top, schriftKlein, new Thickness(0, 0, 0, 0), 180, Brushes.Black, i + (int)WpfObjects.DaBeschreibung00);
            libWpf.TextVis(2 + i, 3, 20, 2, HorizontalAlignment.Center, VerticalAlignment.Top, schriftKlein, Brushes.Black, i + (int)WpfObjects.Da00);
            libWpf.RechteckFarbeUmschalten(3 + i, 1, 19, 1, Brushes.Black, new Thickness(1, 1, 1, 1), i + (int)WpfObjects.Da00);
            libWpf.Text($".{i}", 3 + i, 2, 18, 2, HorizontalAlignment.Left, VerticalAlignment.Top, schriftKlein, Brushes.White);
        }
        // Rechte 8 Ausgänge
        libWpf.Text("DA", 13, 2, 16, 2, HorizontalAlignment.Center, VerticalAlignment.Center, schriftGross, Brushes.White);
        libWpf.Text("b", 14, 2, 16, 2, HorizontalAlignment.Center, VerticalAlignment.Center, schriftGross, Brushes.White);
        libWpf.Border(13, 8, 16, 4, Brushes.White, new Thickness(3, 3, 3, 0));

        for (var i = 0; i < 8; i++)
        {
            libWpf.TextVertikalVis(13 + i, 1, 21, 6, HorizontalAlignment.Center, VerticalAlignment.Top, schriftKlein, new Thickness(0, 0, 0, 0), 180, Brushes.Black, i + (int)WpfObjects.DaBeschreibung10);
            libWpf.TextVis(12 + i, 3, 20, 2, HorizontalAlignment.Center, VerticalAlignment.Top, schriftKlein, Brushes.Black, i + (int)WpfObjects.Da10);
            libWpf.RechteckFarbeUmschalten(13 + i, 1, 19, 1, Brushes.Black, new Thickness(1, 1, 1, 1), i + (int)WpfObjects.Da10);
            libWpf.Text($".{i}", 13 + i, 2, 18, 2, HorizontalAlignment.Left, VerticalAlignment.Top, schriftKlein, Brushes.White);
        }
    }
}