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
    public void RectangleFillMargin(int xPos, int xSpan, int yPos, int ySpan, SolidColorBrush fill, Thickness margin)
    {
        var rectangle = new Rectangle
        {
            Fill = fill,
            Margin = margin
        };

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, rectangle);
    }
    public void RectangleSetFill(int xPos, int xSpan, int yPos, int ySpan, string bindingFilling)
    {
        var rectangle = new Rectangle();
        rectangle.BindingSetFilling(bindingFilling);
        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, rectangle);
    }
    public void RectangleStrokeSetFill(int xPos, int xSpan, int yPos, int ySpan, SolidColorBrush stroke, double strokeThicknes, string bindingFilling)
    {
        var rectangle = new Rectangle
        {
            Stroke = stroke,
            StrokeThickness = strokeThicknes
        };
        rectangle.BindingSetFilling(bindingFilling);
        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, rectangle);
    }
    public void RectangleFillSetVisibility(int xPos, int xSpan, int yPos, int ySpan, Brush fill, string bindingVisibility)
    {
        var rectangle = new Rectangle
        {
            Fill = fill
        };
        rectangle.BindingSetVisibility(bindingVisibility);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, rectangle);
    }
    public void RectangleFillSetMargin(int xPos, int xSpan, int yPos, int ySpan, Brush fill, string bindingMargin)
    {
        var rectangle = new Rectangle
        {
            Fill = fill
        };
        rectangle.BindingSetMargin(bindingMargin);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, rectangle);
    }
    public void RectangleFillStrokeSetMargin(int xPos, int xSpan, int yPos, int ySpan, Brush fill, SolidColorBrush stroke, double strokeThicknes, string bindingMargin)
    {
        var rectangle = new Rectangle
        {
            Fill = fill,
            Stroke = stroke,
            StrokeThickness = strokeThicknes
        };
        rectangle.BindingSetMargin(bindingMargin);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, rectangle);
    }
    public void RectangleMarginSetFill(int xPos, int xSpan, int yPos, int ySpan, Thickness margin, string bindingFilling)
    {
        var rectangle = new Rectangle
        {
            Margin = margin
        };
        rectangle.BindingSetFilling(bindingFilling);
        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, rectangle);
    }
    public void RectangleMarginStrokeSetFill(int xPos, int xSpan, int yPos, int ySpan, Thickness margin, SolidColorBrush stroke, double strokeThicknes, string bindingFilling)
    {
        var rectangle = new Rectangle
        {
            Margin = margin,
            Stroke = stroke,
            StrokeThickness = strokeThicknes
        };
        rectangle.BindingSetFilling(bindingFilling);
        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, rectangle);
    }
    public void RectangleFillMarginSetWinkel(int xPos, int xSpan, int yPos, int ySpan, SolidColorBrush fill, Thickness margin, string bindingWinkel, string bindingTransformOrigin)
    {
        var rectangle = new Rectangle
        {
            Margin = margin,
            Fill = fill,
            RenderTransformOrigin = new Point(0.5, 0.5)
        };

        var b = new Binding(bindingWinkel);
        var rt = new RotateTransform();
        BindingOperations.SetBinding(rt, RotateTransform.AngleProperty, b);
        rectangle.RenderTransform = rt;

        rectangle.BindingpSetTransformOrigin(bindingTransformOrigin);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, rectangle);
    }
    public void RectangleFillMarginStroke(int xPos, int xSpan, int yPos, int ySpan, SolidColorBrush fill, Thickness margin, SolidColorBrush stroke, double strokeThicknes)
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
    public void RectangleFillRundungStroke(int xPos, int xSpan, int yPos, int ySpan, double radiusX, double radiusY, SolidColorBrush fill, Rect rect, SolidColorBrush stroke, double strokeThicknes)
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
}