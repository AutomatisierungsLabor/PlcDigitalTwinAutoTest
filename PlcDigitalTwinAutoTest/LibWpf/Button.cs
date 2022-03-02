using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace LibWpf;

public partial class LibWpf
{
    public void ButtonRounded(int xPos, int xSpan, int yPos, int ySpan, int fontSize, int radius, Thickness margin, Brush background, ICommand cmd, object cmdParameter)
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
    public void ButtonRoundedSetBackground(int xPos, int xSpan, int yPos, int ySpan, int fontSize, int radius, Thickness margin, ICommand cmd, object cmdParameter)
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
    public void ButtonZweiBilder(int xPos, int xSpan, int yPos, int ySpan, int fontSize, string sourceOn, string sourceOff, Thickness margin, ICommand cmd, object cmdParameter)
    {
        var binding = (int)cmdParameter;

        var imageOn = new Image
        {
            Source = new BitmapImage(new Uri(@$"Bilder/{sourceOn}", UriKind.Relative)),
            Stretch = Stretch.Fill,
            Margin = margin
        };
        imageOn.SetSichtbarkeitEinBinding(binding);

        var imageOff = new Image
        {
            Source = new BitmapImage(new Uri(@$"Bilder/{sourceOff}", UriKind.Relative)),
            Stretch = Stretch.Fill,
            Margin = margin
        };
        imageOff.SetSichtbarkeitAusBinding(binding);

        var stackPanel = new StackPanel();
        stackPanel.Children.Add(imageOn);
        stackPanel.Children.Add(imageOff);

        var button = new Button
        {
            Content = stackPanel,
            FontSize = fontSize,
            Margin = margin,
            Command = cmd,
            CommandParameter = cmdParameter
        };

        button.SetBtnClickModeBinding(binding);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, button);
    }
}