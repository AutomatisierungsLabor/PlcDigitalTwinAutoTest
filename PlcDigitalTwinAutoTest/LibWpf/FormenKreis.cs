using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;

namespace LibWpf;

public partial class LibWpf
{
    public void EllipseFill(int xPos, int xSpan, int yPos, int ySpan, SolidColorBrush fill)
    {
        var ellipse = new Ellipse
        {
            Fill = fill
        };

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, ellipse);
    }
    public void EllipseFillMarginStroke(int xPos, int xSpan, int yPos, int ySpan, SolidColorBrush fill, Thickness margin, SolidColorBrush stroke, double strokeThicknes)
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
    public void EllipseFillBindingVisibility(int xPos, int xSpan, int yPos, int ySpan, SolidColorBrush fill, string bindingVisibility)
    {
        var ellipse = new Ellipse
        {
            Fill = fill
        };

        ellipse.FrameworkElementBindingVisibility(bindingVisibility);
        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, ellipse);
    }
    public void EllipseMarginStrokeBindingFilling(int xPos, int xSpan, int yPos, int ySpan, Thickness margin, SolidColorBrush stroke, double strokeThicknes, string bindingFilling)
    {
        var ellipse = new Ellipse
        {
            Stroke = stroke,
            StrokeThickness = strokeThicknes,
            Margin = margin,
            Fill = new SolidColorBrush(Colors.Red)
        };
        ellipse.ShapeBindingFilling(bindingFilling);
        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, ellipse);
    }
    public void EllipseStrokeBindingFilling(int xPos, int xSpan, int yPos, int ySpan, SolidColorBrush stroke, double strokeThicknes, string bindingFilling)
    {
        var ellipse = new Ellipse
        {
            Stroke = stroke,
            StrokeThickness = strokeThicknes,
            Fill = new SolidColorBrush(Colors.Red)
        };
        ellipse.ShapeBindingFilling(bindingFilling);
        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, ellipse);
    }
    public void EllipseFillStrokeBindingMargin(int xPos, int xSpan, int yPos, int ySpan, SolidColorBrush fill, SolidColorBrush stroke, double strokeThicknes, string bindingMargin)
    {
        var ellipse = new Ellipse
        {
            Fill = fill,
            Stroke = stroke,
            StrokeThickness = strokeThicknes
        };
        ellipse.ShapeBindingMargin(bindingMargin);
        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, ellipse);
    }
    public void EllipseFillRadiusBindingWinkel(int xPos, int xSpan, int yPos, int ySpan, SolidColorBrush fill, double radius,double faktor, string bindingWinkel)
    {
        var ellipseGeometry = new EllipseGeometry
        {
            Center = new Point(faktor *  xSpan , faktor * ySpan),
            RadiusX = radius,
            RadiusY = radius
        };

        var path = new Path
        {
            Data = ellipseGeometry,
            Fill = fill,
            RenderTransformOrigin = new Point(0.5, 0.5)
        };

        var b = new Binding(bindingWinkel);
        var rt = new RotateTransform();
        BindingOperations.SetBinding(rt, RotateTransform.AngleProperty, b);
        path.RenderTransform = rt;

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, path);
    }
}