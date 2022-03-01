using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace LibWpf;

public partial class LibWpf
{
    public void Kreis(int xPos, int xSpan, int yPos, int ySpan, SolidColorBrush farbe, Thickness rand)
    {
        var ellipse = new Ellipse
        {
            Margin = rand,
            Fill = farbe
        };

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, ellipse);
    }

    public void KreisRandVis(int xPos, int xSpan, int yPos, int ySpan, SolidColorBrush rand, Thickness margin, object wpfId)
    {
        var ellipse = new Ellipse
        {
            Stroke = rand,
            Margin = margin,
            Fill = new SolidColorBrush(Colors.Red)
        };

        if (wpfId != null) ellipse.SetFillingBinding(wpfId);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, ellipse);
    }

    public void KreisFillStroke(int xPos, int xSpan, int yPos, int ySpan, SolidColorBrush fill, SolidColorBrush stroke, double strokeThicknes, Thickness margin)
    {
        var ellipse = new Ellipse
        {
            Fill = fill,
            Stroke = stroke,
            StrokeThickness = strokeThicknes,
            Margin = margin
        };

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, ellipse);
    }

    public void KreisRandPosition(int xPos, int xSpan, int yPos, int ySpan, SolidColorBrush fill, SolidColorBrush stroke, double strokeThicknes, object wpfId)
    {
        var ellipse = new Ellipse
        {
            Fill = fill,
            Stroke = stroke,
            StrokeThickness = strokeThicknes
        };
        ellipse.SetMarginBinding(wpfId);
        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, ellipse);
    }
}