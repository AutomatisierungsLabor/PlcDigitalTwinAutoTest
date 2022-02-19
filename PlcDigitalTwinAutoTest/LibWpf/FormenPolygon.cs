using System.Windows;
using System.Windows.Controls;
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

        Grid.SetColumn(polygon, xPos);
        Grid.SetColumnSpan(polygon, xSpan);
        Grid.SetRow(polygon, yPos);
        Grid.SetRowSpan(polygon, ySpan);
        Grid.Children.Add(polygon);
    }
}