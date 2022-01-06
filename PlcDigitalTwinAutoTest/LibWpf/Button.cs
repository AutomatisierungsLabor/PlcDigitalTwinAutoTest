using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace LibWpf;

public partial class LibWpf
{
    public void Button(int xPos, int xSpan, int yPos, int ySpan, int fontSize, Thickness margin, ICommand cmd, object cmdParameter, bool enabled = true, bool visibility = true)
    {
        var button = new Button
        {
            FontSize = fontSize,
            Margin = margin,
            Command = cmd,
            CommandParameter = cmdParameter
        };

        if (enabled) button.SetIsEnabledBinding(cmdParameter);
        if (visibility) button.SetSichtbarkeitEinBinding(cmdParameter);
        button.SetBtnContentBinding(cmdParameter);
        button.SetBtnClickModeBinding(cmdParameter);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, button);
    }
    public void ButtonOnOffVis(int xPos, int xSpan, int yPos, int ySpan, int fontSize, string sourceOn, string sourceOff, Thickness margin, ICommand cmd, object cmdParameter)
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