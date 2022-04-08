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
    public void TextContendSetVisibility(string content, int xPos, int xSpan, int yPos, int ySpan, HorizontalAlignment horizontal, VerticalAlignment vertical, int fontSize, Brush foreground, object visibility)
    {
        var label = new Label
        {
            Content = content,
            FontSize = fontSize,
            Foreground = foreground,
            HorizontalAlignment = horizontal,
            VerticalAlignment = vertical
        };
        
        label.BindingImageSetVisibility(visibility);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, label);
    }
    public void TextSetContent(int xPos, int xSpan, int yPos, int ySpan, HorizontalAlignment horizontal, VerticalAlignment vertical, int fontSize, Brush farbe, string bindingContent)
    {
        var label = new Label
        {
            FontSize = fontSize,
            Foreground = farbe,
            HorizontalAlignment = horizontal,
            VerticalAlignment = vertical
        };

        label.BindingSetContent(bindingContent);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, label);
    }
    public void TextSetContendSetVisibility(int xPos, int xSpan, int yPos, int ySpan, HorizontalAlignment horizontal, VerticalAlignment vertical, int fontSize, Brush farbe, string bindingContent,string bindingVisibility)
    {
        var label = new Label
        {
            FontSize = fontSize,
            Foreground = farbe,
            HorizontalAlignment = horizontal,
            VerticalAlignment = vertical
        };

        label.BindingSetContent(bindingContent);
        label.BindingSetVisibility(bindingVisibility);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, label);
    }

    public void RipTextSetContendSetVisibility(int xPos, int xSpan, int yPos, int ySpan, HorizontalAlignment horizontal, VerticalAlignment vertical, int fontSize, Brush farbe, object wpfId)
    {
        var label = new Label
        {
            FontSize = fontSize,
            Foreground = farbe,
            HorizontalAlignment = horizontal,
            VerticalAlignment = vertical
        };

       // label.BindingSetContent(bindingContent);
      //  label.BindingSetVisibility(bindingVisibility);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, label);
    }
    public void RipTextVerticalSetTextSetVisibility(int xPos, int xSpan, int yPos, int ySpan, HorizontalAlignment horizontal, VerticalAlignment vertical, int fontSize, Thickness rand, int width, Brush farbe, object wpfId)
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

        text.RipSetTextBlockBinding(wpfId);
        text.RipButtonSetVisibilityEinBinding(wpfId);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, text);
    }
}