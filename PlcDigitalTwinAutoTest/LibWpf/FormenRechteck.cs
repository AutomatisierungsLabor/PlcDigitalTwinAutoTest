using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;

namespace LibWpf;

public partial class LibWpf
{
    public void RechteckFill(int xPos, int xSpan, int yPos, int ySpan, Brush fill)
    {
        var rectangle = new Rectangle
        {
            Fill = fill
        };

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, rectangle);
    }
    public void RechteckFillMargin(int xPos, int xSpan, int yPos, int ySpan, SolidColorBrush fill, Thickness margin)
    {
        var rectangle = new Rectangle
        {
            Fill = fill,
            Margin = margin
        };

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, rectangle);
    }
    public void RechteckFillMarginSetWinkel(int xPos, int xSpan, int yPos, int ySpan, SolidColorBrush fill, Thickness margin, object wpfId)
    {
        var rectangle = new Rectangle
        {
            Margin = margin,
            Fill = fill,
            RenderTransformOrigin = new Point(0.5, 0.5)
        };

        var b = new Binding($"Winkel[{(int)wpfId}]");
        var rt = new RotateTransform();
        BindingOperations.SetBinding(rt, RotateTransform.AngleProperty, b);
        rectangle.RenderTransform = rt;

        rectangle.SetTransformOriginBinding(wpfId);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, rectangle);
    }
    public void RechteckFillStrokeMargin(int xPos, int xSpan, int yPos, int ySpan, SolidColorBrush fill, SolidColorBrush stroke, double strokeThicknes, Thickness margin)
    {
        var rectangle = new Rectangle
        {
            Fill = fill,
            Stroke = stroke,
            StrokeThickness = strokeThicknes,
            Margin = margin
        };

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, rectangle);
    }
    public void RechteckFillStrokeSetMargin(int xPos, int xSpan, int yPos, int ySpan, Brush fill, SolidColorBrush stroke, double strokeThicknes, object wpfId)
    {
        var rectangle = new Rectangle
        {
            Fill = fill,
            Stroke = stroke,
            StrokeThickness = strokeThicknes
        };
        rectangle.SetMarginBinding(wpfId);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, rectangle);
    }
    public void RechteckFillStrokeRundung(int xPos, int xSpan, int yPos, int ySpan, double radiusX, double radiusY, SolidColorBrush fill, SolidColorBrush stroke, double strokeThicknes, Rect rect)
    {
        var rectangleGeometry = new RectangleGeometry
        {
            Rect = rect,
            RadiusX = radiusX,
            RadiusY = radiusY
        };

        var path = new Path
        {
            Fill = fill,
            Stroke = stroke,
            StrokeThickness = strokeThicknes,
            Data = rectangleGeometry
        };

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, path);
    }
    public void RechteckMarginSetFill(int xPos, int xSpan, int yPos, int ySpan, Thickness margin, object wpfId)
    {
        var rectangle = new Rectangle
        {
            Margin = margin
        };

        rectangle.SetFillingBinding(wpfId);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, rectangle);
    }
    public void RechteckSetFillSetVisibility(int xPos, int xSpan, int yPos, int ySpan, Brush rand, object wpfId)
    {
        var rectangle = new Rectangle
        {
            Stroke = rand
        };
        rectangle.SetFillingBinding(wpfId);
        rectangle.RipSetVisibilityEinBinding(wpfId);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, rectangle);
    }
    public void RechteckSetFill(int xPos, int xSpan, int yPos, int ySpan, SolidColorBrush stroke, Thickness margin, object wpfId)
    {
        var rectangle = new Rectangle
        {
            Stroke = stroke,
            Margin = margin,
            Fill = new SolidColorBrush(Colors.Red)
        };

        rectangle.SetFillingBinding(wpfId);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, rectangle);
    }

}