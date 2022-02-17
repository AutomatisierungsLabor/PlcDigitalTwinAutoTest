using System.Windows;
using System.Windows.Controls;
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

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, label);
    }
    public void TextVis(int xPos, int xSpan, int yPos, int ySpan, HorizontalAlignment horizontal, VerticalAlignment vertical, int fontSize, Brush farbe, object wpfId)
    {
        var label = new Label
        {
            FontSize = fontSize,
            Foreground = farbe,
            HorizontalAlignment = horizontal,
            VerticalAlignment = vertical
        };


        label.SetContentBinding(wpfId);
        label.SetSichtbarkeitEinBinding(wpfId);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, label);
    }
    public void TextVertikalVis(int xPos, int xSpan, int yPos, int ySpan, HorizontalAlignment horizontal, VerticalAlignment vertical, int fontSize, Thickness rand, int width, Brush farbe, object wpfId)
    {
        var text = new TextBlock
        {
            FontSize = fontSize,
            FontWeight = FontWeights.Bold,
            Foreground = farbe,
            Width = width,
            Margin = rand,
            HorizontalAlignment = horizontal,
            VerticalAlignment = vertical,
            RenderTransformOrigin = new Point(0.5, 0.5),
            LayoutTransform = new RotateTransform { Angle = 270 }
        };

        text.SetTextBlockBinding(wpfId);
        text.SetSichtbarkeitEinBinding(wpfId);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, text);
    }
}