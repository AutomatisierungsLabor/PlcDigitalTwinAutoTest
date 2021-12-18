using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using static System.Windows.Controls.Grid;


namespace LibWpf;

public class LibTexte
{
    public static void Text(string text, int xPos, int xSpan, int yPos, int ySpan,
                            HorizontalAlignment horizontal, VerticalAlignment vertical, int fontSize, Brush farbe,
                            /*DependencyProperty visibilityProperty,*/ Grid grid)
    {
        var label = new Label
        {
            Content = text,
            FontSize = fontSize,
            Foreground = farbe,
            HorizontalAlignment = horizontal,
            VerticalAlignment = vertical
        };

        SetColumn(label, xPos);
        SetColumnSpan(label, xSpan);
        SetRow(label, yPos);
        SetRowSpan(label, ySpan);
        grid.Children.Add(label);
    }

    public static void TextViz(int xPos, int xSpan, int yPos, int ySpan,
        HorizontalAlignment horizontal, VerticalAlignment vertical, int fontSize, Brush farbe,
        int wpfObject, DependencyProperty visibilityProperty, Grid grid)
    {
        var label = new Label
        {
            FontSize = fontSize,
            Foreground = farbe,
            HorizontalAlignment = horizontal,
            VerticalAlignment = vertical
        };

        label.SetBinding(ContentControl.ContentProperty, new Binding($"Text[{wpfObject }]"));
        label.SetBinding(visibilityProperty, new Binding($"SichtbarEin[{wpfObject}]"));


        SetColumn(label, xPos);
        SetColumnSpan(label, xSpan);
        SetRow(label, yPos);
        SetRowSpan(label, ySpan);
        grid.Children.Add(label);
    }
}