using System.Windows;
using System.Windows.Media;

namespace LibDisplayPlc.PlcZeichnen;

public partial class PlcZeichnen
{
    private static void PlcDaZeichnen(LibWpf.LibWpf wpf, string prefix, string ab, string da, int offsetX, int offsetY)
    {
        wpf.Text("DA", offsetX, 2, offsetY, 2, HorizontalAlignment.Center, VerticalAlignment.Center, SchriftGross, Brushes.White);
        wpf.Text(ab, offsetX + 1, 2, offsetY, 2, HorizontalAlignment.Center, VerticalAlignment.Center, SchriftGross, Brushes.White);
        wpf.TextSetContent(offsetX + 4, 4, offsetY, 2, HorizontalAlignment.Center, VerticalAlignment.Center, SchriftGross, Brushes.Violet, da);
        wpf.Border(offsetX, 8, offsetY, 4, Brushes.White, new Thickness(3, 3, 3, 0));

        for (var i = 0; i < 8; i++)
        {
            wpf.TextVerticalWidthSetTextSetVisibility(offsetX + i, 1, offsetY + 5, 6, HorizontalAlignment.Center, VerticalAlignment.Top, SchriftKlein, 180, Brushes.Black, $"StringKommentar{prefix}{i}", $"VisibilityDi0{i}");
            wpf.TextSetContendSetVisibility(offsetX - 1 + i, 3, offsetY + 4, 2, HorizontalAlignment.Center, VerticalAlignment.Top, SchriftKlein, Brushes.Black, $"StringBezeichnung{prefix}{i}", $"Visibility{prefix}{i}");
            wpf.RectangleMarginStrokeSetFill(offsetX + i, 1, offsetY + 3, 1, new Thickness(1, 1, 1, 1), Brushes.Black, 2, $"Brush{prefix}{i}");
            wpf.Text($".{i}", offsetX + i, 2, offsetY + 2, 2, HorizontalAlignment.Left, VerticalAlignment.Top, SchriftKlein, Brushes.White);
        }
    }
    private static void PlcDiZeichnen(LibWpf.LibWpf wpf, string prefix, string ab, string di, int offsetX, int offsetY)
    {
        wpf.Text("DI", offsetX, 2, offsetY + 8, 2, HorizontalAlignment.Center, VerticalAlignment.Center, SchriftGross, Brushes.White);
        wpf.Text(ab, offsetX + 1, 2, offsetY + 8, 2, HorizontalAlignment.Center, VerticalAlignment.Center, SchriftKlein, Brushes.White);
        wpf.TextSetContent(offsetX + 4, 4, offsetY + 8, 2, HorizontalAlignment.Center, VerticalAlignment.Center, SchriftGross, Brushes.Violet, di);
        wpf.Border(offsetX, 8, offsetY + 6, 4, Brushes.White, new Thickness(3, 0, 3, 3));

        for (var i = 0; i < 8; i++)
        {
            wpf.TextVerticalWidthSetTextSetVisibility(offsetX + i, 1, offsetY - 1, 6, HorizontalAlignment.Center, VerticalAlignment.Bottom, SchriftKlein, 180, Brushes.Black, $"StringKommentar{prefix}{i}", $"VisibilityDi0{i}");
            wpf.TextSetContendSetVisibility(offsetX - 1 + i, 3, offsetY + 4, 2, HorizontalAlignment.Center, VerticalAlignment.Bottom, SchriftKlein, Brushes.Black, $"StringBezeichnung{prefix}{i}", $"Visibility{prefix}{i}");
            wpf.RectangleMarginStrokeSetFill(offsetX + i, 1, offsetY + 6, 1, new Thickness(1, 1, 1, 1), Brushes.Black, 2, $"Brush{prefix}{i}");
            wpf.Text($".{i}", offsetX + i, 2, offsetY + 7, 2, HorizontalAlignment.Left, VerticalAlignment.Top, SchriftKlein, Brushes.White);
        }
    }
}