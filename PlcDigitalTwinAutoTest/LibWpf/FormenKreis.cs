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
    public void EllipseFillSetVisibility(int xPos, int xSpan, int yPos, int ySpan, SolidColorBrush fill, string bindingVisibility)
    {
        var ellipse = new Ellipse
        {
            Fill = fill
        };

        ellipse.BindingImageSetVisibility(bindingVisibility);
        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, ellipse);
    }
    public void EllipseMarginStrokeSetFilling(int xPos, int xSpan, int yPos, int ySpan, Thickness margin, SolidColorBrush stroke, double strokeThicknes, string bindingFilling)
    {
        var ellipse = new Ellipse
        {
            Stroke = stroke,
            StrokeThickness = strokeThicknes,
            Margin = margin,
            Fill = new SolidColorBrush(Colors.Red)
        };
        ellipse.BindingSetFilling(bindingFilling);
        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, ellipse);
    }
    public void EllipseStrokeSetFilling(int xPos, int xSpan, int yPos, int ySpan, SolidColorBrush stroke, double strokeThicknes, string bindingFilling)
    {
        var ellipse = new Ellipse
        {
            Stroke = stroke,
            StrokeThickness = strokeThicknes,
            Fill = new SolidColorBrush(Colors.Red)
        };
        ellipse.BindingSetFilling(bindingFilling);
        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, ellipse);
    }
    public void EllipseFillStrokeSetMargin(int xPos, int xSpan, int yPos, int ySpan, SolidColorBrush fill, SolidColorBrush stroke, double strokeThicknes, string bindingMargin)
    {
        var ellipse = new Ellipse
        {
            Fill = fill,
            Stroke = stroke,
            StrokeThickness = strokeThicknes
        };
        ellipse.BindingSetMargin(bindingMargin);
        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, ellipse);
    }
    public void EllipseFillRadiusSetWinkel(int xPos, int xSpan, int yPos, int ySpan, SolidColorBrush fill, double radius,double faktor, string bindingWinkel)
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