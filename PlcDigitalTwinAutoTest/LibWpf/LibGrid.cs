using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using static System.Windows.Controls.Grid;

namespace LibWpf;

public class LibGrid
{
    public static void Zeichnen(Grid grid, int anzX, int breiteX, int anzY, int hoeheY, bool gridSichtbar)
    {
        for (var i = 0; i < anzX; i++) grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(breiteX) });
        for (var i = 0; i < anzY; i++) grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(hoeheY) });


        if (!gridSichtbar) return;


        var linie = new Line
        {
            Stroke = new SolidColorBrush(Colors.Black),
            StrokeThickness = 10,
            X1 = 0,
            Y1 = 0,
            X2 = 2000,
            Y2 = 2000
        };

        SetColumn(linie, 0);
        SetColumnSpan(linie, anzX);
        SetRow(linie, 0);
        SetRowSpan(linie, anzY);

        grid.Children.Add(linie);

    }
}