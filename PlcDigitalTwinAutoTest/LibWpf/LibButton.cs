using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static System.Windows.Controls.Grid;

namespace LibWpf;

public class LibButton
{
    public static void ButtonVis(string content, int xPos, int xSpan, int yPos, int ySpan, int fontSize, Thickness margin, ICommand cmd, object cmdParameter, string bindingClick, Grid grid)
    {
        var button = new Button
        {
            Content = content,
            FontSize = fontSize,
            Margin = margin,
            Command = cmd,
            CommandParameter = cmdParameter
        };
        button.SetBinding(ButtonBase.ClickModeProperty, new Binding(bindingClick));
        LibTexte.GridAnpassen(xPos, xSpan, yPos, ySpan, grid, button);
    }

    public static void ButtonOnOffVis(int xPos, int xSpan, int yPos, int ySpan, int fontSize, string sourceOn, string sourceOff, Thickness margin, ICommand cmd, object cmdParameter,Grid grid)
    {
        var binding = (int)cmdParameter;

        var imageOn = new Image
        {
            Source = new BitmapImage(new Uri(@$"Bilder/{sourceOn}", UriKind.Relative)),
            Stretch = Stretch.Fill,
            Margin = margin
        };
        imageOn.SetBinding(UIElement.VisibilityProperty, new Binding($"SichtbarEin[{binding}]"));


        var imageOff = new Image
        {
            Source = new BitmapImage(new Uri(@$"Bilder/{sourceOff}", UriKind.Relative)),
            Stretch = Stretch.Fill,
            Margin = margin
        };
        imageOff.SetBinding(UIElement.VisibilityProperty, new Binding($"SichtbarAus[{binding}]"));

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

        button.SetBinding(ButtonBase.ClickModeProperty, new Binding($"ClkMode[{binding}]"));

        LibTexte.GridAnpassen(xPos, xSpan, yPos, ySpan, grid, button);
    }
}