using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace LibWpf;

public partial class LibWpf
{
    public void ButtonContentRounded(int xPos, int xSpan, int yPos, int ySpan, int fontSize, int radius, Thickness margin, Brush background, ICommand cmd, object cmdParameter)
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

        button.SetBtnContentBinding(cmdParameter);
        button.SetBtnClickModeBinding(cmdParameter);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, button);
    }
    public void ButtonBackgroundContentRounded(int xPos, int xSpan, int yPos, int ySpan, int fontSize, int radius, Thickness margin, ICommand cmd, object cmdParameter)
    {
        var button = new Button
        {
            FontSize = fontSize,
            Margin = margin,
            Command = cmd,
            CommandParameter = cmdParameter
        };

        button.Loaded += (_, _) =>
        {
            if (button.Template.FindName("border", button) is Border border) border.CornerRadius = new CornerRadius(radius);
        };

        button.SetBtnBackgroundBinding(cmdParameter);
        button.SetBtnContentBinding(cmdParameter);
        button.SetBtnClickModeBinding(cmdParameter);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, button);
    }
    public void ButtonZweiBilder(int xPos, int xSpan, int yPos, int ySpan, string sourceOn, string sourceOff, Thickness margin, ICommand cmd, object cmdParameter)
    {
        var (imageOn, _) = ImageErzeugen(sourceOn, margin);
        var buttonOn = new Button
        {
            Content = imageOn,
            Margin = margin,
            Command = cmd,
            CommandParameter = cmdParameter
        };
        buttonOn.RipSetVisibilityEinBinding(cmdParameter);
        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, buttonOn);

        var (imageOff, _) = ImageErzeugen(sourceOff, margin);
        var buttonOff = new Button
        {
            Content = imageOff,
            Margin = margin,
            Command = cmd,
            CommandParameter = cmdParameter
        };
        buttonOff.RipSetVisibilityAusBinding(cmdParameter);
        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, buttonOff);
    }
}