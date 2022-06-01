using LibConfigDt;
using System.Windows;
using System.Windows.Media;

namespace LibDisplayPlc.PlcZeichnen;

public partial class PlcZeichnen
{
    private static void PlcAaZeichnen(LibWpf.LibWpf libWpf, ConfigDt configDt, int posX, int posY)
    {
        if (configDt.GetAnzahlAa() == 0) return;

        foreach (var analogeAusgaenge in configDt.DtConfig.AnalogeAusgaenge.EaConfig)
        {
            libWpf.Text($"AA[{analogeAusgaenge.StartByte}]:", posX, 5, posY, 1, HorizontalAlignment.Left, VerticalAlignment.Center, SchriftKlein, Brushes.Blue);
            libWpf.TextSetContent(posX + 2, 5, posY, 1, HorizontalAlignment.Left, VerticalAlignment.Center, SchriftKlein, Brushes.MediumVioletRed, $"StringWertAa0{analogeAusgaenge.StartByte}");
            libWpf.Text(analogeAusgaenge.Bezeichnung, posX + 8, 5, posY, 1, HorizontalAlignment.Left, VerticalAlignment.Center, SchriftKlein, Brushes.BlueViolet);

            posY += AbstandY;
        }
    }
    private static void PlcAiZeichnen(LibWpf.LibWpf libWpf, ConfigDt configDt, int posX, int posY)
    {
        if (configDt.GetAnzahlAi() == 0) return;

        foreach (var analogeEingaenge in configDt.DtConfig.AnalogeEingaenge.EaConfig)
        {
            libWpf.Text($"AI[{analogeEingaenge.StartByte}]:", posX, 5, posY, 1, HorizontalAlignment.Left, VerticalAlignment.Center, SchriftKlein, Brushes.Blue);
            libWpf.TextSetContent(posX + 2, 5, posY, 1, HorizontalAlignment.Left, VerticalAlignment.Center, SchriftKlein, Brushes.MediumVioletRed, $"StringWertAi0{analogeEingaenge.StartByte}");
            libWpf.Text(analogeEingaenge.Bezeichnung, posX + 8, 5, posY, 1, HorizontalAlignment.Left, VerticalAlignment.Center, SchriftKlein, Brushes.BlueViolet);

            posY += AbstandY;
        }
    }
}