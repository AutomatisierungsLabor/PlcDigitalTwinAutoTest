using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace LibWpf;

public partial class LibWpf
{
    public void ButtonBackgroundContentRounded(string content, int xPos, int xSpan, int yPos, int ySpan, int fontSize, int radius, Brush background, ICommand cmd, object cmdParameter, string bindingClickMode)
    {
        var button = new Button
        {
            Content = content,
            FontSize = fontSize,
            Background = background,
            Command = cmd,
            CommandParameter = cmdParameter
        };

        button.Loaded += (_, _) =>
        {
            if (button.Template.FindName("border", button) is Border border) border.CornerRadius = new CornerRadius(radius);
        };

        button.ButtonBindingClickMode(bindingClickMode);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, button);
    }
    public void ButtonBackgroundContentMarginRounded(string content, int xPos, int xSpan, int yPos, int ySpan, int fontSize, int radius, Brush background, Thickness margin, ICommand cmd, object cmdParameter, string bindingClickMode)
    {
        var button = new Button
        {
            Content = content,
            FontSize = fontSize,
            Margin = margin,
            Background = background,
            Command = cmd,
            CommandParameter = cmdParameter
        };

        button.Loaded += (_, _) =>
        {
            if (button.Template.FindName("border", button) is Border border) border.CornerRadius = new CornerRadius(radius);
        };

        button.ButtonBindingClickMode(bindingClickMode);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, button);
    }
    public void ButtonRoundedSetBackground(int xPos, int xSpan, int yPos, int ySpan, int fontSize, int radius, ICommand cmd, string cmdParameter, string bindingClickMode, string bindingBackground)
    {
        var button = new Button
        {
            FontSize = fontSize,
            Command = cmd,
            CommandParameter = cmdParameter
        };

        button.Loaded += (_, _) =>
        {
            if (button.Template.FindName("border", button) is Border border) border.CornerRadius = new CornerRadius(radius);
        };

        button.ButtonBindingClickMode(bindingClickMode);
        button.FrameworkElementBindingBackground(bindingBackground);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, button);
    }
    public void ButtonContentRoundedSetBackground(string content, int xPos, int xSpan, int yPos, int ySpan, int fontSize, int radius, ICommand cmd, string cmdParameter, string bindingClickMode, string bindingBackground)
    {
        var button = new Button
        {
            Content = content,
            FontSize = fontSize,
            Command = cmd,
            CommandParameter = cmdParameter
        };

        button.Loaded += (_, _) =>
        {
            if (button.Template.FindName("border", button) is Border border) border.CornerRadius = new CornerRadius(radius);
        };

        button.ButtonBindingClickMode(bindingClickMode);
        button.FrameworkElementBindingBackground(bindingBackground);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, button);
    }
    public void ButtonContentMarginRoundedSetBackground(string content, int xPos, int xSpan, int yPos, int ySpan, int fontSize, int radius, Thickness margin, ICommand cmd, string cmdParameter, string bindingClickMode, string bindingBackground)
    {
        var button = new Button
        {
            Content = content,
            FontSize = fontSize,
            Margin = margin,
            Command = cmd,
            CommandParameter = cmdParameter
        };

        button.Loaded += (_, _) =>
        {
            if (button.Template.FindName("border", button) is Border border) border.CornerRadius = new CornerRadius(radius);
        };

        button.ButtonBindingClickMode(bindingClickMode);
        button.FrameworkElementBindingBackground(bindingBackground);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, button);
    }
    public void ButtonMarginSetVisibilityZweiBilder(int xPos, int xSpan, int yPos, int ySpan, string sourceOn, string sourceOff, Thickness margin, ICommand cmd, object cmdParameter, string bindingClickMode, string bindingVisibilityEin, string bindingVisibilityAus)
    {
        var (imageOn, _) = ImageErzeugen(sourceOn, margin);
        var buttonOn = new Button
        {
            Content = imageOn,
            Margin = margin,
            Command = cmd,
            CommandParameter = cmdParameter
        };
        buttonOn.ButtonBindingClickMode(bindingClickMode);
        buttonOn.FrameworkElementBindingVisibility(bindingVisibilityEin);
        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, buttonOn);

        var (imageOff, _) = ImageErzeugen(sourceOff, margin);
        var buttonOff = new Button
        {
            Content = imageOff,
            Margin = margin,
            Command = cmd,
            CommandParameter = cmdParameter
        };
        buttonOff.ButtonBindingClickMode(bindingClickMode);
        buttonOff.FrameworkElementBindingVisibility(bindingVisibilityAus);
        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, buttonOff);
    }
    public void ButtonBackgroundMarginRoundedSetContend(int xPos, int xSpan, int yPos, int ySpan, int fontSize, int radius, Brush background, Thickness margin, ICommand cmd, string cmdParameter, string bindingClickMode, string bindingContent)
    {
        var button = new Button
        {
            FontSize = fontSize,
            Margin = margin,
            Background = background,
            Command = cmd,
            CommandParameter = cmdParameter
        };

        button.Loaded += (_, _) =>
        {
            if (button.Template.FindName("border", button) is Border border) border.CornerRadius = new CornerRadius(radius);
        };

        button.ButtonBindingContent(bindingContent);
        button.ButtonBindingClickMode(bindingClickMode);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, button);
    }
    public void ButtonBackgroundContentMarginRoundedSetVisability(string content, int xPos, int xSpan, int yPos, int ySpan, int fontSize, int radius, Brush background, Thickness margin, ICommand cmd, object cmdParameter, string bindingClickMode, string bindingVisibility)
    {
        var button = new Button
        {
            Content = content,
            FontSize = fontSize,
            Margin = margin,
            Background = background,
            Command = cmd,
            CommandParameter = cmdParameter
        };

        button.Loaded += (_, _) =>
        {
            if (button.Template.FindName("border", button) is Border border) border.CornerRadius = new CornerRadius(radius);
        };

        button.ButtonBindingClickMode(bindingClickMode);
        button.FrameworkElementBindingVisibility(bindingVisibility);
        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, button);
    }
    public void ButtonBackgroundMarginRoundedSetEnableSetContend(int xPos, int xSpan, int yPos, int ySpan, int fontSize, int radius, Brush background, Thickness margin, ICommand cmd, string cmdParameter, string bindingClickMode, string bindingEnable, string bindingContent)
    {
        var button = new Button
        {
            FontSize = fontSize,
            Margin = margin,
            Background = background,
            Command = cmd,
            CommandParameter = cmdParameter
        };

        button.Loaded += (_, _) =>
        {
            if (button.Template.FindName("border", button) is Border border) border.CornerRadius = new CornerRadius(radius);
        };

        //  BindingOperations.SetBinding(button, )

        button.ButtonBindingContent(bindingContent);
        button.ButtonBindingClickMode(bindingClickMode);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, button);
    }
    public void ButtonBildSetMargin(int xPos, int xSpan, int yPos, int ySpan, string source, ICommand cmd, object cmdParameter, string bindingClickMode, string bindingMargin)
    {
        var (image, _) = ImageErzeugen(source, new Thickness(0, 0, 0, 0));
        var button = new Button
        {
            Content = image,
            Command = cmd,
            CommandParameter = cmdParameter
        };
        button.ButtonBindingClickMode(bindingClickMode);
        button.ButtonBindingMargin(bindingMargin);
        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, button);
    }
    public void ButtonImageMarginRotateSetVisibility(int xPos, int xSpan, int yPos, int ySpan, string source, Thickness margin, int winkel, ICommand cmd, object cmdParameter, string bindingClickMode, string bindingVisibility)
    {

        var (image, _) = ImageErzeugen(source, margin);
        var button = new Button
        {
            Content = image,
            Margin = margin,
            Command = cmd,
            CommandParameter = cmdParameter,
            RenderTransformOrigin = new Point(0.5, 0.5),
            LayoutTransform = new RotateTransform { Angle = winkel }
        };

        button.ButtonBindingClickMode(bindingClickMode);
        button.FrameworkElementBindingVisibility(bindingVisibility);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, button);
    }
}