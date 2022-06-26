using System.Windows;
using System.Windows.Media;

namespace LibDisplayPlc.PlcZeichnen;

public partial class PlcZeichnen
{
    private static void PlcRahmenZeichnen(LibWpf.LibWpf wpf, string grossDiDa, string ab, string wertDiDa, int xPos, int yPosBeschriftung, int yPosRahmen, Thickness rand)
    {
        wpf.Text(grossDiDa, xPos, 2, yPosBeschriftung, 2, HorizontalAlignment.Center, VerticalAlignment.Center, SchriftGross, Brushes.White);
        wpf.Text(ab, xPos + 1, 2, yPosBeschriftung, 2, HorizontalAlignment.Center, VerticalAlignment.Center, SchriftKlein, Brushes.White);
        wpf.TextBindingContent(xPos + 4, 4, yPosBeschriftung, 2, HorizontalAlignment.Center, VerticalAlignment.Center, SchriftGross, Brushes.Violet, wertDiDa);
        wpf.Border(xPos, 8, yPosRahmen, 4, Brushes.White, rand);
    }
    private static void PlcLedZeichnen(LibWpf.LibWpf wpf, string prefix, int xPos, int yPosNummer, int yPosLed)
    {
        for (var i = 0; i < 8; i++)
        {
            wpf.RectangleMarginStrokeBindingFill(xPos + i, 1, yPosNummer, 1, new Thickness(1, 1, 1, 1), Brushes.Black, 2, $"Brush{prefix}{i}");
            wpf.Text($".{i}", xPos + i, 2, yPosLed, 2, HorizontalAlignment.Left, VerticalAlignment.Top, SchriftKlein, Brushes.White);
        }
    }
    private static void PlcBeschriftungKommentarZeichnen(LibWpf.LibWpf wpf, string prefix, VerticalAlignment alignment, int xPos, int yPosKommentar, int yPosBezeichnung)
    {
        for (var i = 0; i < 8; i++)
        {
            wpf.TextVerticalWidthBindingTextVisibility(xPos + i, 1, yPosKommentar, 6, HorizontalAlignment.Center, alignment, SchriftKlein, 180, Brushes.Black, $"StringKommentar{prefix}{i}", $"Visibility{prefix}{i}");
            wpf.TextBindingContendVisibility(xPos - 1 + i, 3, yPosBezeichnung, 2, HorizontalAlignment.Center, alignment, SchriftKlein, Brushes.Black, $"StringBezeichnung{prefix}{i}", $"Visibility{prefix}{i}");
        }
    }
}