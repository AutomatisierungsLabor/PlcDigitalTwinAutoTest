using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using static System.Windows.Controls.Grid;

namespace LibWpf;

public class LibFormen
{
    public static void Rechteck(Grid grid, int xPos, int xSpan, int yPos, int ySpan, Brush farbe )
    {
        var hintergrund = new Rectangle
        {
            Fill = farbe
        };

        SetColumn(hintergrund, xPos);
        SetColumnSpan(hintergrund, xSpan);
        SetRow(hintergrund, yPos);
        SetRowSpan(hintergrund, ySpan);
        grid.Children.Add(hintergrund);
    }

}