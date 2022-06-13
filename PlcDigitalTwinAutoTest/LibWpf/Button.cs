using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace LibWpf;

public partial class LibWpf
{
    public void ButtonBackgroundContentRounded(string content, int xPos, int xSpan, int yPos, int ySpan, int fontSize, int radius, Brush background, ICommand cmd, object cmdParameter, string setClickMode)
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

        button.BindingButtonSetClickMode(setClickMode);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, button);
    }
    public void ButtonBackgroundContentMarginRounded(string content, int xPos, int xSpan, int yPos, int ySpan, int fontSize, int radius, Brush background, Thickness margin, ICommand cmd, object cmdParameter, string setClickMode)
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

        button.BindingButtonSetClickMode(setClickMode);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, button);
    }

    public void ButtonRoundedSetBackground(int xPos, int xSpan, int yPos, int ySpan, int fontSize, int radius, ICommand cmd, string cmdParameter, string setClickMode, string setBackground)
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

        button.BindingButtonSetClickMode(setClickMode);
        button.BindingButtonSetBackground(setBackground);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, button);
    }
    public void ButtonContentRoundedSetBackground(string content, int xPos, int xSpan, int yPos, int ySpan, int fontSize, int radius, ICommand cmd, string cmdParameter, string setClickMode, string setBackground)
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

        button.BindingButtonSetClickMode(setClickMode);
        button.BindingButtonSetBackground(setBackground);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, button);
    }
    public void ButtonContentMarginRoundedSetBackground(string content, int xPos, int xSpan, int yPos, int ySpan, int fontSize, int radius, Thickness margin, ICommand cmd, string cmdParameter, string setClickMode, string setBackground)
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

        button.BindingButtonSetClickMode(setClickMode);
        button.BindingButtonSetBackground(setBackground);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, button);
    }
    public void ButtonMarginSetVisibilityZweiBilder(int xPos, int xSpan, int yPos, int ySpan, string sourceOn, string sourceOff, Thickness margin, ICommand cmd, object cmdParameter, string setClickMode, string setVisibilityEin, string setVisibilityAus)
    {
        var (imageOn, _) = ImageErzeugen(sourceOn, margin);
        var buttonOn = new Button
        {
            Content = imageOn,
            Margin = margin,
            Command = cmd,
            CommandParameter = cmdParameter
        };
        buttonOn.BindingButtonSetClickMode(setClickMode);
        buttonOn.BindingButtonSetVisibility(setVisibilityEin);
        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, buttonOn);

        var (imageOff, _) = ImageErzeugen(sourceOff, margin);
        var buttonOff = new Button
        {
            Content = imageOff,
            Margin = margin,
            Command = cmd,
            CommandParameter = cmdParameter
        };
        buttonOff.BindingButtonSetClickMode(setClickMode);
        buttonOff.BindingButtonSetVisibility(setVisibilityAus);
        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, buttonOff);
    }
    public void ButtonBackgroundMarginRoundedSetContend(int xPos, int xSpan, int yPos, int ySpan, int fontSize, int radius, Brush background, Thickness margin, ICommand cmd, string cmdParameter, string setClickMode, string setContent)
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

        button.BindingButtonSetContent(setContent);
        button.BindingButtonSetClickMode(setClickMode);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, button);
    }
    public void ButtonBackgroundContentMarginRoundedSetVisability(string content, int xPos, int xSpan, int yPos, int ySpan, int fontSize, int radius, Brush background, Thickness margin, ICommand cmd, object cmdParameter, string setClickMode, string bindingVisibility)
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

        button.BindingButtonSetClickMode(setClickMode);
        button.BindingButtonSetVisibility(bindingVisibility);
        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, button);
    }
    public void ButtonBackgroundMarginRoundedSetEnableSetContend(int xPos, int xSpan, int yPos, int ySpan, int fontSize, int radius, Brush background, Thickness margin, ICommand cmd, string cmdParameter, string setClickMode, string setEnable, string setContent)
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

        button.BindingButtonSetContent(setContent);
        button.BindingButtonSetClickMode(setClickMode);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, button);
    }
    public void ButtonBildSetMargin(int xPos, int xSpan, int yPos, int ySpan, string source, ICommand cmd, object cmdParameter, string setClickMode, string setMargin)
    {
        var (image, _) = ImageErzeugen(source, new Thickness(0, 0, 0, 0));
        var button = new Button
        {
            Content = image,
            Command = cmd,
            CommandParameter = cmdParameter
        };
        button.BindingButtonSetClickMode(setClickMode);
        button.BindingButtonSetMargin(setMargin);
        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, button);
    }
}