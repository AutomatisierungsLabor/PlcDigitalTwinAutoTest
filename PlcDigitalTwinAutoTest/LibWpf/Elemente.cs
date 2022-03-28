using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LibWpf;

public partial class LibWpf
{
    public WebBrowser WebBrowser(int xPos, int xSpan, int yPos, int ySpan, Thickness margin)
    {
        var werBrowser = new WebBrowser
        {
            Name = "WebBrowser",
            Margin = margin
        };

        Grid.SetColumn(werBrowser, xPos);
        Grid.SetColumnSpan(werBrowser, xSpan);
        Grid.SetRow(werBrowser, yPos);
        Grid.SetRowSpan(werBrowser, ySpan);
        Grid.Children.Add(werBrowser);

        return werBrowser;
    }
    public RadioButton RadioButton(string gruppenName, string testName, DirectoryInfo ordner, int fontSize, RoutedEventHandler testChecked)
    {

        var radioButton = new RadioButton
        {
            GroupName = gruppenName,
            Name = testName,
            FontSize = fontSize,
            Content = testName,
            Tag = ordner
        };

        radioButton.Checked += testChecked;
        return radioButton;
    }
    public void CheckBox(int xPos, int xSpan, int yPos, int ySpan, Thickness margin, HorizontalAlignment horizontal, VerticalAlignment vertical, ICommand cmd, object cmdParameter)
    {
        var checkbox = new CheckBox
        {
            Margin = margin,
            VerticalAlignment = vertical,
            HorizontalAlignment = horizontal,
            Command = cmd,
            CommandParameter = cmdParameter

        };

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, checkbox);
    }
}