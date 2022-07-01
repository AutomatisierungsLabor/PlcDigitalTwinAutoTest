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
    public void TextMargin(string content, int xPos, int xSpan, int yPos, int ySpan, HorizontalAlignment horizontal, VerticalAlignment vertical, int fontSize, Brush farbe, Thickness margin)
    {
        var label = new Label
        {
            Content = content,
            FontSize = fontSize,
            Foreground = farbe,
            HorizontalAlignment = horizontal,
            VerticalAlignment = vertical,
            Margin = margin
        };

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, label);
    }
    public void TextMarginMonospaced(string content, int xPos, int xSpan, int yPos, int ySpan, HorizontalAlignment horizontal, VerticalAlignment vertical, int fontSize, Brush farbe, Thickness margin)
    {
        var label = new Label
        {
            Content = content,
            FontSize = fontSize,
            Foreground = farbe,
            HorizontalAlignment = horizontal,
            VerticalAlignment = vertical,
            Margin = margin,
            FontFamily = new FontFamily("Lucida Sans Typewriter")
        };

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, label);
    }
    public void TextMarginMonospacedBindingForeground(string content, int xPos, int xSpan, int yPos, int ySpan, HorizontalAlignment horizontal, VerticalAlignment vertical, int fontSize, Thickness margin, string bindingForeground)
    {
        var label = new Label
        {
            Content = content,
            FontSize = fontSize,
            HorizontalAlignment = horizontal,
            VerticalAlignment = vertical,
            Margin = margin,
            FontFamily = new FontFamily("Lucida Sans Typewriter")
        };

        label.FrameworkElementBindingForeground(bindingForeground);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, label);
    }
    public void TextContendBindingVisibility(string content, int xPos, int xSpan, int yPos, int ySpan, HorizontalAlignment horizontal, VerticalAlignment vertical, int fontSize, Brush foreground, string visibility)
    {
        var label = new Label
        {
            Content = content,
            FontSize = fontSize,
            Foreground = foreground,
            HorizontalAlignment = horizontal,
            VerticalAlignment = vertical
        };

        label.FrameworkElementBindingVisibility(visibility);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, label);
    }
    public void TextBindingContent(int xPos, int xSpan, int yPos, int ySpan, HorizontalAlignment horizontal, VerticalAlignment vertical, int fontSize, Brush farbe, string bindingContent)
    {
        var label = new Label
        {
            FontSize = fontSize,
            Foreground = farbe,
            HorizontalAlignment = horizontal,
            VerticalAlignment = vertical
        };

        label.ContentControlBindingContent(bindingContent);
        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, label);
    }
    public void TextMarginBindingContentVisibility(int xPos, int xSpan, int yPos, int ySpan, HorizontalAlignment horizontal, VerticalAlignment vertical, int fontSize, Brush farbe, Thickness margin, string bindingContent, string bindingVisibility)
    {
        var label = new Label
        {
            FontSize = fontSize,
            Foreground = farbe,
            HorizontalAlignment = horizontal,
            VerticalAlignment = vertical,
            Margin = margin
        };

        label.ContentControlBindingContent(bindingContent);
        label.FrameworkElementBindingVisibility(bindingVisibility);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, label);
    }
    public void TextBindingContentVisibility(int xPos, int xSpan, int yPos, int ySpan, HorizontalAlignment horizontal, VerticalAlignment vertical, int fontSize, Brush farbe, string bindingContent, string bindingVisibility)
    {
        var label = new Label
        {
            FontSize = fontSize,
            Foreground = farbe,
            HorizontalAlignment = horizontal,
            VerticalAlignment = vertical
        };

        label.ContentControlBindingContent(bindingContent);
        label.FrameworkElementBindingVisibility(bindingVisibility);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, label);
    }
    public void TextVerticalWidthBindingTextVisibility(int xPos, int xSpan, int yPos, int ySpan, HorizontalAlignment horizontal, VerticalAlignment vertical, int fontSize, int width, Brush farbe, string bindingText, string bindingVisability)
    {
        var text = new TextBlock
        {
            FontSize = fontSize,
            FontWeight = FontWeights.Bold,
            Foreground = farbe,
            Width = width,
            HorizontalAlignment = horizontal,
            VerticalAlignment = vertical,
            RenderTransformOrigin = new Point(0.5, 0.5),
            LayoutTransform = new RotateTransform { Angle = 270 }
        };

        text.TextBlockBindingText(bindingText);
        text.FrameworkElementBindingVisibility(bindingVisability);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, text);
    }
    public void TextVerticalMarginWidthBindingTextVisibility(int xPos, int xSpan, int yPos, int ySpan, HorizontalAlignment horizontal, VerticalAlignment vertical, int fontSize, Thickness margin, int width, Brush farbe, string bindingText, string bindingVisability)
    {
        var text = new TextBlock
        {
            FontSize = fontSize,
            FontWeight = FontWeights.Bold,
            Foreground = farbe,
            Width = width,
            Margin = margin,
            HorizontalAlignment = horizontal,
            VerticalAlignment = vertical,
            RenderTransformOrigin = new Point(0.5, 0.5),
            LayoutTransform = new RotateTransform { Angle = 270 }
        };

        text.TextBlockBindingText(bindingText);
        text.FrameworkElementBindingVisibility(bindingVisability);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, text);
    }
}