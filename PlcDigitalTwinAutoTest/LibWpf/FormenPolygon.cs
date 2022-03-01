using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;

namespace LibWpf;

public partial class LibWpf
{
    public void Polygon(int xPos, int xSpan, int yPos, int ySpan, SolidColorBrush fill, SolidColorBrush stroke, double strokeThickness, double[][] punkte)
    {
        var polyPoints = new PointCollection();
        foreach (var punkt in punkte) polyPoints.Add(new Point(punkt[0], punkt[1]));
       
        var polygon = new Polygon
        {
            Fill = fill,
            Stroke = stroke,
            StrokeThickness = strokeThickness,
            Points = polyPoints
        };

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, polygon);
    }
    public void PolygonSetWinkel(int xPos, int xSpan, int yPos, int ySpan, SolidColorBrush fill, SolidColorBrush stroke, double strokeThickness,  double[][] punkte, object wpfId)
    {
        var polyPoints = new PointCollection();
        foreach (var punkt in punkte) polyPoints.Add(new Point(punkt[0], punkt[1]));

        var polygon = new Polygon
        {
            Fill = fill,
            Stroke = stroke,
            StrokeThickness = strokeThickness,
            Points = polyPoints,
            RenderTransformOrigin = new Point(0.5, 0.5)
        };

        var b = new Binding($"Winkel[{(int)wpfId}]");
        var rt = new RotateTransform();
        BindingOperations.SetBinding(rt, RotateTransform.AngleProperty, b);
        polygon.RenderTransform = rt;

        polygon.SetTransformOriginBinding(wpfId);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, polygon);
    }
}