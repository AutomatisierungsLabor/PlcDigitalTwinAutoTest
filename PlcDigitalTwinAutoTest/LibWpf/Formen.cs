using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace LibWpf;

public partial class LibWpf
{
    public void Linie(int xPos, int xSpan, int yPos, int ySpan, double x1, double y1, double x2, double y2, double breite, Brush farbe)
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
        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, linie);
    }
    public void LinieSetVisibility(int xPos, int xSpan, int yPos, int ySpan, double x1, double y1, double x2, double y2, double breite, Brush farbe, string bindingVisibility)
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
        linie.BindingSetVisibility(bindingVisibility);
        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, linie);
    }
    public void Border(int xPos, int xSpan, int yPos, int ySpan, Brush farbe, Thickness rand)
    {
        var border = new Border
        {
            BorderBrush = farbe,
            BorderThickness = rand
        };
        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, border);
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