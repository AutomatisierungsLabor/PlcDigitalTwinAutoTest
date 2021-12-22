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
    public static void RechteckVis(int xPos, int xSpan, int yPos, int ySpan, Brush farbe, int wpfObject, Grid grid)
    {
        var rectangle = new Rectangle
        {
            Fill = farbe
        };

        rectangle.SetBinding(UIElement.VisibilityProperty, new Binding($"SichtbarEin[{wpfObject}]"));
        LibTexte.GridAnpassen(xPos, xSpan, yPos, ySpan, grid, rectangle);
    }
    public static void KreisRandVis(int xPos, int xSpan, int yPos, int ySpan, SolidColorBrush rand, Thickness margin, int binding,  Grid grid)
    {
        var ellipse = new Ellipse
        {
            Stroke = rand,
            Margin = margin,
            Fill = new SolidColorBrush(Colors.Red)
        };

        BindingOperations.SetBinding(ellipse, Shape.FillProperty, new Binding($"Farbe[{binding}]"));

        LibTexte.GridAnpassen(xPos, xSpan, yPos, ySpan, grid, ellipse);
    }

}