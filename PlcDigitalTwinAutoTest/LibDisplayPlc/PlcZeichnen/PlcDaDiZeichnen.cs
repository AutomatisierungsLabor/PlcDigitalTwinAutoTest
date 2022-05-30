using System.Windows;
using System.Windows.Media;

namespace LibDisplayPlc.PlcZeichnen;

public partial class PlcZeichnen
{
    private static void PlcRahmenZeichnen(LibWpf.LibWpf wpf, string grossDiDa, string ab, string wertDiDa, int offsetX, int offsetY1, int offsetY2, Thickness rand)
    {
        wpf.Text(grossDiDa, offsetX, 2, offsetY1, 2, HorizontalAlignment.Center, VerticalAlignment.Center, SchriftGross, Brushes.White);
        wpf.Text(ab, offsetX + 1, 2, offsetY1, 2, HorizontalAlignment.Center, VerticalAlignment.Center, SchriftKlein, Brushes.White);
        wpf.TextSetContent(offsetX + 4, 4, offsetY1, 2, HorizontalAlignment.Center, VerticalAlignment.Center, SchriftGross, Brushes.Violet, wertDiDa);
        wpf.Border(offsetX, 8, offsetY2, 4, Brushes.White, rand);
    }
    private static void PlcLedZeichnen(LibWpf.LibWpf wpf, string prefix, int offsetX, int offsetY1, int offsetY2)
    {
        for (var i = 0; i < 8; i++)
        {
            wpf.RectangleMarginStrokeSetFill(offsetX + i, 1, offsetY1, 1, new Thickness(1, 1, 1, 1), Brushes.Black, 2, $"Brush{prefix}{i}");
            wpf.Text($".{i}", offsetX + i, 2, offsetY2, 2, HorizontalAlignment.Left, VerticalAlignment.Top, SchriftKlein, Brushes.White);
        }
    }

    private static void PlcBeschriftungKommentarZeichnen(LibWpf.LibWpf wpf, string prefix, VerticalAlignment alignment,
        int offsetX, int offsetYKommentar, int offsetYBezeichnung)
    {
        for (var i = 0; i < 8; i++)
        {
            wpf.TextVerticalWidthSetTextSetVisibility(offsetX + i, 1, offsetYKommentar, 6, HorizontalAlignment.Center,
                alignment, SchriftKlein, 180, Brushes.Black, $"StringKommentar{prefix}{i}", $"Visibility{prefix}{i}");
            wpf.TextSetContendSetVisibility(offsetX - 1 + i, 3, offsetYBezeichnung, 2, HorizontalAlignment.Center,
                alignment, SchriftKlein, Brushes.Black, $"StringBezeichnung{prefix}{i}", $"Visibility{prefix}{i}");
        }
    }
}