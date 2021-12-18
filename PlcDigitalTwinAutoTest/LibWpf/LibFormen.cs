using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;
using static System.Windows.Controls.Grid;

namespace LibWpf;

public class LibFormen
{
    public static void Linie(int x1, int y1, int x2, int y2, int xSpan, int ySpan, int breite, Brush farbe, Grid grid)
    {
        var linie = new Line
        {
            Stroke = farbe,
            StrokeThickness = breite,
            X1 = x1,
            Y1 = y1,
            X2 = x2,
            Y2 = y2
        };

        SetColumn(linie, 0);
        SetColumnSpan(linie, xSpan);
        SetRow(linie, 0);
        SetRowSpan(linie, ySpan);

        grid.Children.Add(linie);

    }
    public static void Rechteck(int xPos, int xSpan, int yPos, int ySpan, Brush farbe, Grid grid)
    {
        var hintergrund = new Rectangle
        {
            Fill = farbe
        };

        SetColumn(hintergrund, xPos);
        SetColumnSpan(hintergrund, xSpan);
        SetRow(hintergrund, yPos);
        SetRowSpan(hintergrund, ySpan);
        grid.Children.Add(hintergrund);
    }
    public static void RechteckViz(int xPos, int xSpan, int yPos, int ySpan, Brush farbe, int wpfObject, DependencyProperty visibilityProperty, Grid grid)
    {
        var rectangle = new Rectangle
        {
            Fill = farbe
        };

        rectangle.SetBinding(visibilityProperty, new Binding($"SichtbarEin[{wpfObject}]"));

        SetColumn(rectangle, xPos);
        SetColumnSpan(rectangle, xSpan);
        SetRow(rectangle, yPos);
        SetRowSpan(rectangle, ySpan);
        grid.Children.Add(rectangle);
    }
    public static void KreisRandViz(int xPos, int xSpan, int yPos, int ySpan, SolidColorBrush rand, Thickness margin, string bindingViz, DependencyProperty visibilityProperty, Grid grid)
    {
        var ellipse = new Ellipse()
        {
            Stroke = rand,
            Margin = margin
        };

        ellipse.SetBinding(visibilityProperty, new Binding(bindingViz));

        SetColumn(ellipse, xPos);
        SetColumnSpan(ellipse, xSpan);
        SetRow(ellipse, yPos);
        SetRowSpan(ellipse, ySpan);
        grid.Children.Add(ellipse);
    }

}