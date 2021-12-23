using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace LibWpf;

public partial class LibWpf
{
    public void Text(string text, int xPos, int xSpan, int yPos, int ySpan, HorizontalAlignment horizontal, VerticalAlignment vertical, int fontSize, Brush farbe)
    {
        var label = new Label
        {
            Content = text,
            FontSize = fontSize,
            Foreground = farbe,
            HorizontalAlignment = horizontal,
            VerticalAlignment = vertical
        };

        GridAnpassen(xPos, xSpan, yPos, ySpan, Grid, label);
    }
    public void TextVis(int xPos, int xSpan, int yPos, int ySpan, HorizontalAlignment horizontal, VerticalAlignment vertical, int fontSize, Brush farbe, int wpfObject)
    {
        var label = new Label
        {
            FontSize = fontSize,
            Foreground = farbe,
            HorizontalAlignment = horizontal,
            VerticalAlignment = vertical
        };

        label.SetBinding(ContentControl.ContentProperty, new Binding($"Text[{wpfObject }]"));
        label.SetBinding(UIElement.VisibilityProperty, new Binding($"SichtbarEin[{wpfObject}]"));

        GridAnpassen(xPos, xSpan, yPos, ySpan, Grid, label);
    }

    public void TextVertikalVis(int xPos, int xSpan, int yPos, int ySpan, HorizontalAlignment horizontal, VerticalAlignment vertical, int fontSize, Thickness rand, Brush farbe, int wpfObject)
    {
        var text = new TextBlock
        {
            FontSize = fontSize,
            FontWeight = FontWeights.Bold,
            Foreground = farbe,
            Padding = rand,
            Background = new SolidColorBrush(Colors.LightGoldenrodYellow),
            HorizontalAlignment = horizontal,
            VerticalAlignment = vertical,
            RenderTransformOrigin = new Point(0.5, 0.5),
            LayoutTransform = new RotateTransform { Angle = 270 }
        };

        text.SetBinding(ContentControl.ContentProperty, new Binding($"Text[{wpfObject }]"));
        text.SetBinding(UIElement.VisibilityProperty, new Binding($"SichtbarEin[{wpfObject}]"));

        GridAnpassen(xPos, xSpan, yPos, ySpan, Grid, text);
    }
}