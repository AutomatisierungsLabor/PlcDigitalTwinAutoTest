using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;

namespace LibWpf;

public partial class LibWpf
{
    public void RectangleFill(int xPos, int xSpan, int yPos, int ySpan, Brush fill)
    {
        var rectangle = new Rectangle
        {
            Fill = fill
        };
        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, rectangle);
    }


    public void RectangleSetFill(int xPos, int xSpan, int yPos, int ySpan, object bindingFilling)
    {
        var rectangle = new Rectangle();
        rectangle.BindingSetFilling(bindingFilling);
        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, rectangle);
    }
    public void RectangleStrokeSetFill(int xPos, int xSpan, int yPos, int ySpan, SolidColorBrush stroke, double strokeThicknes, object bindingFilling)
    {
        var rectangle = new Rectangle()
        {
            Stroke = stroke,
            StrokeThickness = strokeThicknes
        };
        rectangle.BindingSetFilling(bindingFilling);
        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, rectangle);
    }



    public void RectangleFillSetVisibility(int xPos, int xSpan, int yPos, int ySpan, Brush fill, object wpfId)
    {
        var rectangle = new Rectangle
        {
            Fill = fill
        };
        rectangle.RipButtonSetVisibilityEinBinding(wpfId);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, rectangle);
    }









    public void RipRechteckFill(int xPos, int xSpan, int yPos, int ySpan, Brush fill)
    {
        var rectangle = new Rectangle
        {
            Fill = fill
        };

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, rectangle);
    }
    public void RipRechteckFillMargin(int xPos, int xSpan, int yPos, int ySpan, SolidColorBrush fill, Thickness margin)
    {
        var rectangle = new Rectangle
        {
            Fill = fill,
            Margin = margin
        };

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, rectangle);
    }
    public void RipRechteckFillMarginSetWinkel(int xPos, int xSpan, int yPos, int ySpan, SolidColorBrush fill, Thickness margin, object wpfId)
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

        rectangle.RipSetTransformOriginBinding(wpfId);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, rectangle);
    }
    public void RipRechteckFillStrokeMargin(int xPos, int xSpan, int yPos, int ySpan, SolidColorBrush fill, SolidColorBrush stroke, double strokeThicknes, Thickness margin)
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
    public void RipRechteckFillStrokeSetMargin(int xPos, int xSpan, int yPos, int ySpan, Brush fill, SolidColorBrush stroke, double strokeThicknes, object wpfId)
    {
        var rectangle = new Rectangle
        {
            Fill = fill,
            Stroke = stroke,
            StrokeThickness = strokeThicknes
        };
        rectangle.RipSetMarginBinding(wpfId);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, rectangle);
    }
    public void RipRechteckFillStrokeRundung(int xPos, int xSpan, int yPos, int ySpan, double radiusX, double radiusY, SolidColorBrush fill, SolidColorBrush stroke, double strokeThicknes, Rect rect)
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
    public void RipRechteckMarginSetFill(int xPos, int xSpan, int yPos, int ySpan, Thickness margin, object wpfId)
    {
        var rectangle = new Rectangle
        {
            Margin = margin
        };

        rectangle.RipSetFillingBinding(wpfId);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, rectangle);
    }
    public void RipRechteckSetFillSetVisibility(int xPos, int xSpan, int yPos, int ySpan, Brush rand, object wpfId)
    {
        var rectangle = new Rectangle
        {
            Stroke = rand
        };
        rectangle.RipSetFillingBinding(wpfId);
        rectangle.RipButtonSetVisibilityEinBinding(wpfId);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, rectangle);
    }
    public void RipRechteckSetFill(int xPos, int xSpan, int yPos, int ySpan, SolidColorBrush stroke, Thickness margin, object wpfId)
    {
        var rectangle = new Rectangle
        {
            Stroke = stroke,
            Margin = margin,
            Fill = new SolidColorBrush(Colors.Red)
        };

        rectangle.RipSetFillingBinding(wpfId);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, rectangle);
    }

}