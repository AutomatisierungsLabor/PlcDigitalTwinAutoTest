using LibConfigDt;
using System.Windows;
using System.Windows.Media;

namespace LibDisplayPlc.PlcZeichnen;

public partial class PlcZeichnen
{
    private static void PlcAaZeichnen(LibWpf.LibWpf libWpf, ConfigDt configDt, int offsetX, int offsetY)
    {
        var posY = 0;

        if (configDt.GetAnzahlAa() == 0) return;

        foreach (var analogeAusgaenge in configDt.DtConfig.AnalogeAusgaenge.EaConfig)
        {
            libWpf.Text($"AA[{analogeAusgaenge.StartByte}]:", offsetX, 5, offsetY + posY, 1, HorizontalAlignment.Left, VerticalAlignment.Center, SchriftKlein, Brushes.Blue);
            libWpf.TextSetContent(offsetX + 2, 5, offsetY + posY, 1, HorizontalAlignment.Left, VerticalAlignment.Center, SchriftKlein, Brushes.MediumVioletRed, $"StringWertAa0{analogeAusgaenge.StartByte}");
            libWpf.Text(analogeAusgaenge.Bezeichnung, offsetX + 8, 5, offsetY + posY, 1, HorizontalAlignment.Left, VerticalAlignment.Center, SchriftKlein, Brushes.BlueViolet);

            posY += AbstandY;
        }
    }
    private static void PlcAiZeichnen(LibWpf.LibWpf libWpf, ConfigDt configDt, int offsetX, int offsetY)
    {
        var posY = 0;

        if (configDt.GetAnzahlAi() == 0) return;

        foreach (var analogeEingaenge in configDt.DtConfig.AnalogeEingaenge.EaConfig)
        {
            libWpf.Text($"AI[{analogeEingaenge.StartByte}]:", offsetX, 5, offsetY + posY, 1, HorizontalAlignment.Left, VerticalAlignment.Center, SchriftKlein, Brushes.Blue);
            libWpf.TextSetContent(offsetX + 2, 5, offsetY + posY, 1, HorizontalAlignment.Left, VerticalAlignment.Center, SchriftKlein, Brushes.MediumVioletRed, $"StringWertAi0{analogeEingaenge.StartByte}");
            libWpf.Text(analogeEingaenge.Bezeichnung, offsetX + 8, 5, offsetY + posY, 1, HorizontalAlignment.Left, VerticalAlignment.Center, SchriftKlein, Brushes.BlueViolet);

            posY += AbstandY;
        }
    }
}