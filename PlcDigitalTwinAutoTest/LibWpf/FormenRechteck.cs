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
    public void RectangleBindingFill(int xPos, int xSpan, int yPos, int ySpan, string bindingFilling)
    {
        var rectangle = new Rectangle();
        rectangle.ShapeBindingFilling(bindingFilling);
        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, rectangle);
    }
    public void RectangleStrokeBindingFill(int xPos, int xSpan, int yPos, int ySpan, SolidColorBrush stroke, double strokeThicknes, string bindingFilling)
    {
        var rectangle = new Rectangle
        {
            Stroke = stroke,
            StrokeThickness = strokeThicknes
        };
        rectangle.ShapeBindingFilling(bindingFilling);
        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, rectangle);
    }
    public void RectangleFillBindingVisibility(int xPos, int xSpan, int yPos, int ySpan, Brush fill, string bindingVisibility)
    {
        var rectangle = new Rectangle
        {
            Fill = fill
        };
        rectangle.FrameworkElementBindingVisibility(bindingVisibility);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, rectangle);
    }
    public void RectangleFillBindingMargin(int xPos, int xSpan, int yPos, int ySpan, Brush fill, string bindingMargin)
    {
        var rectangle = new Rectangle
        {
            Fill = fill
        };
        rectangle.ShapeBindingMargin(bindingMargin);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, rectangle);
    }
    public void RectangleFillStrokeBindingMargin(int xPos, int xSpan, int yPos, int ySpan, Brush fill, SolidColorBrush stroke, double strokeThicknes, string bindingMargin)
    {
        var rectangle = new Rectangle
        {
            Fill = fill,
            Stroke = stroke,
            StrokeThickness = strokeThicknes
        };
        rectangle.ShapeBindingMargin(bindingMargin);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, rectangle);
    }
    public void RectangleMarginBindingFill(int xPos, int xSpan, int yPos, int ySpan, Thickness margin, string bindingFilling)
    {
        var rectangle = new Rectangle
        {
            Margin = margin
        };
        rectangle.ShapeBindingFilling(bindingFilling);
        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, rectangle);
    }
    public void RectangleMarginStrokeBindingFill(int xPos, int xSpan, int yPos, int ySpan, Thickness margin, SolidColorBrush stroke, double strokeThicknes, string bindingFilling)
    {
        var rectangle = new Rectangle
        {
            Margin = margin,
            Stroke = stroke,
            StrokeThickness = strokeThicknes
        };
        rectangle.ShapeBindingFilling(bindingFilling);
        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, rectangle);
    }
    public void RectangleFillMarginBindingWinkel(int xPos, int xSpan, int yPos, int ySpan, SolidColorBrush fill, Thickness margin, string bindingWinkel, string bindingTransformOrigin)
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

        rectangle.ShapeBindingTransformOrigin(bindingTransformOrigin);

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
            Stroke = stroke,
            StrokeThickness = strokeThicknes,
            Data = rectangleGeometry
        };

        if (fill != null) path.Fill = fill;

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, path);
    }
}