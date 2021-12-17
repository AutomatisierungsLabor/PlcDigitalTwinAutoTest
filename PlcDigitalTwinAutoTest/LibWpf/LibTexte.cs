using System.Windows.Controls;
using System.Windows.Media;
using static System.Windows.Controls.Grid;


namespace LibWpf;

public class LibTexte
{
    public static void Text(Grid grid,  int xPos, int xSpan, int yPos, int ySpan, string text, int fontSize, Brush farbe)
    {
        var label = new Label
        {
            FontSize = fontSize,
            Foreground = farbe,
            Content =text
        };

        SetColumn(label, xPos);
        SetColumnSpan(label, xSpan);
        SetRow(label, yPos);
        SetRowSpan(label, ySpan);
        grid.Children.Add(label);
    }
}