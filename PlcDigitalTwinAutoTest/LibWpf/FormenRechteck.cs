using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;

namespace LibWpf;

public partial class LibWpf
{
    public void Rechteck(int xPos, int xSpan, int yPos, int ySpan, Brush farbe)
    {
        var rectangle = new Rectangle
        {
            Fill = farbe
        };

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, rectangle);
    }

    public void RechteckRand(int xPos, int xSpan, int yPos, int ySpan, Brush farbe, object wpfId)
    {
        var rectangle = new Rectangle
        {
            Fill = farbe
        };
        rectangle.SetMarginBinding(wpfId);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, rectangle);
    }

    public void RechteckVis(int xPos, int xSpan, int yPos, int ySpan, Brush rand, object wpfId)
    {
        var rectangle = new Rectangle
        {
            Stroke = rand
        };
        rectangle.SetFillingBinding(wpfId);
        rectangle.SetSichtbarkeitEinBinding(wpfId);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, rectangle);
    }

    public void RechteckFarbeUmschalten(int xPos, int xSpan, int yPos, int ySpan, SolidColorBrush rand,
        Thickness margin, object wpfId)
    {
        var rectangle = new Rectangle
        {
            Stroke = rand,
            Margin = margin,
            Fill = new SolidColorBrush(Colors.Red)
        };

        rectangle.SetFillingBinding(wpfId);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, rectangle);
    }

    public void RechteckRotieren(int xPos, int xSpan, int yPos, int ySpan, SolidColorBrush farbe, Thickness margin,
        object wpfId)
    {
        var rectangle = new Rectangle
        {
            Margin = margin,
            Fill = farbe
        };

        var b = new Binding($"Winkel[{(int)wpfId}]");
        var rt = new RotateTransform();
        BindingOperations.SetBinding(rt, RotateTransform.AngleProperty, b);
        rectangle.RenderTransform = rt;

        rectangle.SetTransformOriginBinding(wpfId);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, rectangle);
    }
}