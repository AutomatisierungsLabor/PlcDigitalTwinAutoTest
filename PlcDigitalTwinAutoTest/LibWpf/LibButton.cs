using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static System.Windows.Controls.Grid;

namespace LibWpf;

public class LibButton
{
    public static void ButtonViz(string content, int xPos, int xSpan, int yPos, int ySpan, int fontSize, Thickness margin, System.Windows.Input.ICommand cmd, object cmdParameter, string bindingClick, DependencyProperty clickModeProperty, Grid grid)
    {
        var button = new Button
        {
            Content = content,
            FontSize = fontSize,
            Margin = margin,
            Command = cmd,
            CommandParameter = cmdParameter
        };
        button.SetBinding(clickModeProperty, new Binding(bindingClick));

        SetColumn(button, xPos);
        SetColumnSpan(button, xSpan);
        SetRow(button, yPos);
        SetRowSpan(button, ySpan);

        grid.Children.Add(button);
    }

    public static void ButtonOnOffViz(int xPos, int xSpan, int yPos, int ySpan, int fontSize,
        string sourceOn, string sourceOff, string bindingOn, string bindingOff,
        Thickness margin, System.Windows.Input.ICommand cmd, object cmdParameter, string bindingClick,
        DependencyProperty clickModeProperty, DependencyProperty visibilityProperty, Grid grid)
    {
        var imageOn = new Image
        {
            Source = new BitmapImage(new Uri(sourceOn, UriKind.Relative)),
            Stretch = Stretch.Fill,
            Margin = margin
        };
        imageOn.SetBinding(visibilityProperty, new Binding(bindingOn));


        var imageOff = new Image
        {
            Source = new BitmapImage(new Uri(sourceOff, UriKind.Relative)),
            Stretch = Stretch.Fill,
            Margin = margin
        };
        imageOff.SetBinding(visibilityProperty, new Binding(bindingOff));

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

        button.SetBinding(clickModeProperty, new Binding(bindingClick));

        SetColumn(button, xPos);
        SetColumnSpan(button, xSpan);
        SetRow(button, yPos);
        SetRowSpan(button, ySpan);


        grid.Children.Add(button);
    }
}