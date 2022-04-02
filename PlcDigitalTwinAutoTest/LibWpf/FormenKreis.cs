using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace LibWpf;

public partial class LibWpf
{







    public void EllipseMarginStrokeSetFilling(int xPos, int xSpan, int yPos, int ySpan, SolidColorBrush rand, double strokeThicknes, Thickness margin, string wpfId)
    {
        var ellipse = new Ellipse
        {
            Stroke = rand,
            StrokeThickness = strokeThicknes,
            Margin = margin,
            Fill = new SolidColorBrush(Colors.Red)
        };
        ellipse.BindingSetFilling(wpfId);
        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, ellipse);
    }







    public void RipKreisFillStrokeMargin(int xPos, int xSpan, int yPos, int ySpan, SolidColorBrush fill, SolidColorBrush stroke, double strokeThicknes, Thickness margin)
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
    public void RipKreisStrokeMarginSetFilling(int xPos, int xSpan, int yPos, int ySpan, SolidColorBrush rand, Thickness margin, object wpfId)
    {
        var ellipse = new Ellipse
        {
            Stroke = rand,
            Margin = margin,
            Fill = new SolidColorBrush(Colors.Red)
        };

        if (wpfId != null) ellipse.RipSetFillingBinding(wpfId);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, ellipse);
    }
    public void RipKreisFillStrokeSetMargin(int xPos, int xSpan, int yPos, int ySpan, SolidColorBrush fill, SolidColorBrush stroke, double strokeThicknes, object wpfId)
    {
        var ellipse = new Ellipse
        {
            Fill = fill,
            Stroke = stroke,
            StrokeThickness = strokeThicknes
        };
        ellipse.RipSetMarginBinding(wpfId);
        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, ellipse);
    }
}