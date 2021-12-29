using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace LibWpf;

public partial class LibWpf
{

    public void ButtonCallback(string content, int xPos, int xSpan, int yPos, int ySpan, int fontSize, Thickness margin, RoutedEventHandler testStarten)
    {

        var button = new Button
        {
            Content = content,
            FontSize = fontSize,
            Margin = margin
        };

        button.Click += testStarten;

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, button);
    }



    public void ButtonVis(string content, int xPos, int xSpan, int yPos, int ySpan, int fontSize, Thickness margin, ICommand cmd, object cmdParameter, string bindingClick)
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
        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, button);
    }

    public void ButtonText(int xPos, int xSpan, int yPos, int ySpan, int fontSize, Thickness margin, ICommand cmd, object cmdParameter)
    {
        var button = new Button
        {
            FontSize = fontSize,
            Margin = margin,
            Command = cmd,
            CommandParameter = cmdParameter
        };
        button.SetBinding(ContentControl.ContentProperty, new Binding($"Text[{(int)cmdParameter}]"));
        button.SetBinding(ButtonBase.ClickModeProperty, new Binding($"ClkMode[{(int)cmdParameter}]" ));
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

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, button);
    }
}