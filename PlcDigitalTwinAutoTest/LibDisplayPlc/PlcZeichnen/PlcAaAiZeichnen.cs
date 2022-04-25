using System.Windows;
using System.Windows.Media;
using LibConfigPlc;

namespace LibDisplayPlc.PlcZeichnen;

public partial class PlcZeichnen
{
    private static void PlcAaZeichnen(LibWpf.LibWpf libWpf, ConfigPlc configPlc, int offsetX, int offsetY)
    {
        var posY = 0;

        if (configPlc.Aa.AnzZeilen == 0) return;

        foreach (var zeile in configPlc.Aa.Zeilen)
        {
            libWpf.Text($"AA[{zeile.StartByte}]:", offsetX, 5, offsetY + posY, 1, HorizontalAlignment.Left, VerticalAlignment.Center, SchriftKlein, Brushes.Blue);
            libWpf.TextSetContent(offsetX + 2, 5, offsetY + posY, 1, HorizontalAlignment.Left, VerticalAlignment.Center, SchriftKlein, Brushes.MediumVioletRed, $"StringWertAa0{zeile.StartByte}");
            libWpf.Text(zeile.Bezeichnung, offsetX + 4, 5, offsetY + posY, 1, HorizontalAlignment.Left, VerticalAlignment.Center, SchriftKlein, Brushes.BlueViolet);

            posY += AbstandY;
        }
    }
    private static void PlcAiZeichnen(LibWpf.LibWpf libWpf, ConfigPlc configPlc, int offsetX, int offsetY)
    {
        var posY = 0;

        if (configPlc.Ai.AnzZeilen == 0) return;

        foreach (var zeile in configPlc.Ai.Zeilen)
        {
            libWpf.Text($"AI[{zeile.StartByte}]:", offsetX, 5, offsetY + posY, 1, HorizontalAlignment.Left, VerticalAlignment.Center, SchriftKlein, Brushes.Blue);
            libWpf.TextSetContent(offsetX + 2, 5, offsetY + posY, 1, HorizontalAlignment.Left, VerticalAlignment.Center, SchriftKlein, Brushes.MediumVioletRed, $"StringWertAi0{zeile.StartByte}");
            libWpf.Text(zeile.Bezeichnung, offsetX + 4, 5, offsetY + posY, 1, HorizontalAlignment.Left, VerticalAlignment.Center, SchriftKlein, Brushes.BlueViolet);

            posY += AbstandY;
        }
    }
}