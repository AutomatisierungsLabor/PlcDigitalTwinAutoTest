using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LibAutoTestSilk.Zeichnen;

public class DiDaBeschriften
{
    public DiDaBeschriften(Grid grid)
    {
        var libWpf = new LibWpf.LibWpf(grid);

        libWpf.RectangleFill(2, 1, 1, 1, Brushes.Chartreuse);
        libWpf.RectangleFill(3, 1, 1, 1, Brushes.Silver);
        libWpf.RectangleFill(4, 1, 1, 1, Brushes.OrangeRed);

        for (var i = 0; i < 8; i++)
        {
            var x0 = 10 + 12 * (i + i / 4);
            var margin0 = new Thickness(240 - x0, 0, 0, 5);

            libWpf.TextVerticalMarginWidthSetTextSetVisibility(2, 2, 1, 1, HorizontalAlignment.Left, VerticalAlignment.Bottom, 12, margin0, 100, Brushes.Black, $"StringBezeichnungDi0{i}", $"VisibilityDi0{i}");
            libWpf.TextVerticalMarginWidthSetTextSetVisibility(3, 2, 1, 1, HorizontalAlignment.Left, VerticalAlignment.Bottom, 12, margin0, 100, Brushes.Black, $"StringBezeichnungDa0{i}", $"VisibilityDa0{i}");
            libWpf.TextVerticalMarginWidthSetTextSetVisibility(4, 2, 1, 1, HorizontalAlignment.Left, VerticalAlignment.Bottom, 12, margin0, 100, Brushes.Black, $"StringBezeichnungDa0{i}", $"VisibilityDa0{i}");

            var j = i + 8;
            var x1 = 10 + 12 * (j + j / 4);
            var margin1 = new Thickness(240 - x1, 0, 0, 5);

            libWpf.TextVerticalMarginWidthSetTextSetVisibility(2, 2, 1, 1, HorizontalAlignment.Left, VerticalAlignment.Bottom, 12, margin1, 100, Brushes.Black, $"StringBezeichnungDi1{i}", $"VisibilityDi1{i}");
            libWpf.TextVerticalMarginWidthSetTextSetVisibility(3, 2, 1, 1, HorizontalAlignment.Left, VerticalAlignment.Bottom, 12, margin1, 100, Brushes.Black, $"StringBezeichnungDa1{i}", $"VisibilityDa1{i}");
            libWpf.TextVerticalMarginWidthSetTextSetVisibility(4, 2, 1, 1, HorizontalAlignment.Left, VerticalAlignment.Bottom, 12, margin1, 100, Brushes.Black, $"StringBezeichnungDa1{i}", $"VisibilityDa1{i}");
        }
    }
}