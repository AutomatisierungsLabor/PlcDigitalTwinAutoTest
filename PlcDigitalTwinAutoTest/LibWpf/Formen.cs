using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;

namespace LibWpf;

public partial class LibWpf
{
    public void Linie(int x1, int y1, int x2, int y2, int xSpan, int ySpan, int breite, Brush farbe, Grid grid)
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

        GridAnpassen(0, xSpan, 0, ySpan, grid, linie);
    }
    public void Rechteck(int xPos, int xSpan, int yPos, int ySpan, Brush farbe)
    {
        var hintergrund = new Rectangle
        {
            Fill = farbe
        };

        GridAnpassen(xPos, xSpan, yPos, ySpan, Grid, hintergrund);
    }

    public void RechteckRand(int xPos, int xSpan, int yPos, int ySpan, Thickness margin, Brush farbe)
    {
        var hintergrund = new Rectangle
        {
            Fill = farbe,
            Margin = margin
        };

        GridAnpassen(xPos, xSpan, yPos, ySpan, Grid, hintergrund);
    }


    public void RechteckFarbeUmschalten(int xPos, int xSpan, int yPos, int ySpan, SolidColorBrush rand, Thickness margin, int binding)
    {
        var rectangle = new Rectangle
        {
            Stroke = rand,
            Margin = margin,
            Fill = new SolidColorBrush(Colors.Red)
        };

        BindingOperations.SetBinding(rectangle, Shape.FillProperty, new Binding($"Farbe[{binding}]"));

        GridAnpassen(xPos, xSpan, yPos, ySpan, Grid, rectangle);
    }
    public void Border(int xPos, int xSpan, int yPos, int ySpan, Brush farbe, Thickness rand)
    {
        var border = new Border
        {
            BorderBrush = farbe,
            BorderThickness = rand
        };

        GridAnpassen(xPos, xSpan, yPos, ySpan, Grid, border);
    }

    public void RechteckVis(int xPos, int xSpan, int yPos, int ySpan, Brush farbe, int wpfObject)
    {
        var rectangle = new Rectangle
        {
            Fill = farbe
        };

        rectangle.SetBinding(UIElement.VisibilityProperty, new Binding($"SichtbarEin[{wpfObject}]"));
        GridAnpassen(xPos, xSpan, yPos, ySpan, Grid, rectangle);
    }
    public void KreisRandVis(int xPos, int xSpan, int yPos, int ySpan, SolidColorBrush rand, Thickness margin, int binding)
    {
        var ellipse = new Ellipse
        {
            Stroke = rand,
            Margin = margin,
            Fill = new SolidColorBrush(Colors.Red)
        };

        BindingOperations.SetBinding(ellipse, Shape.FillProperty, new Binding($"Farbe[{binding}]"));

        GridAnpassen(xPos, xSpan, yPos, ySpan, Grid, ellipse);
    }

    public StackPanel StackPanel(int xPos, int xSpan, int yPos, int ySpan, Thickness margin, Brush farbe)
    {
        var stackPanel = new StackPanel
        {
            Name = "StackPanel",
            Background = farbe,
            Margin = margin
        };

        Grid.SetColumn(stackPanel, xPos);
        Grid.SetColumnSpan(stackPanel, xSpan);
        Grid.SetRow(stackPanel, yPos);
        Grid.SetRowSpan(stackPanel, ySpan);
        Grid.Children.Add(stackPanel);

        return stackPanel;
    }
}