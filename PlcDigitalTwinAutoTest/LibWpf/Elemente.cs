using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace LibWpf;

public partial class LibWpf
{
    public DataGrid DataGrid(int xPos, int xSpan, int yPos, int ySpan, Thickness margin, System.Collections.IEnumerable liste)
    {
        var dataGrid = new DataGrid
        {
            Margin = margin,
            ItemsSource = liste
        };

        Grid.SetColumn(dataGrid, xPos);
        Grid.SetColumnSpan(dataGrid, xSpan);
        Grid.SetRow(dataGrid, yPos);
        Grid.SetRowSpan(dataGrid, ySpan);
        Grid.Children.Add(dataGrid);

        return dataGrid;
    }
    public WebBrowser WebBrowser(int xPos, int xSpan, int yPos, int ySpan, Thickness margin)
    {
        var webBrowser = new WebBrowser
        {
            Name = "WebBrowser",
            Margin = margin
        };

        Grid.SetColumn(webBrowser, xPos);
        Grid.SetColumnSpan(webBrowser, xSpan);
        Grid.SetRow(webBrowser, yPos);
        Grid.SetRowSpan(webBrowser, ySpan);
        Grid.Children.Add(webBrowser);

        return webBrowser;
    }
    
#pragma warning disable CA1822 // Member 'RadioButton' does not access instance data and can be marked as static 
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
#pragma warning restore CA1822 // Member 'RadioButton' does not access instance data and can be marked as static  

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
    public ComboBox ComboBox(int xPos, int xSpan, int yPos, int ySpan, int fontSize, Thickness margin)
    {
        var comboBox = new ComboBox
        {
            SelectedIndex = 0,
            IsDropDownOpen = true,
            IsReadOnly = true,
            FontSize = fontSize,
            Margin = margin
        };

        Grid.SetColumn(comboBox, xPos);
        Grid.SetColumnSpan(comboBox, xSpan);
        Grid.SetRow(comboBox, yPos);
        Grid.SetRowSpan(comboBox, ySpan);
        Grid.Children.Add(comboBox);

        return comboBox;
    }
    public void SliderMarginBindingValue(int xPos, int xSpan, int yPos, int ySpan, Brush background, Thickness margin, double min, double max, string bindingValue)
    {
        var slider = new Slider
        {
            Background = background,
            Margin = margin,
            Minimum = min,
            Maximum = max
        };

        slider.SliderBindingValue(bindingValue);

        Grid.SetColumn(slider, xPos);
        Grid.SetColumnSpan(slider, xSpan);
        Grid.SetRow(slider, yPos);
        Grid.SetRowSpan(slider, ySpan);
        Grid.Children.Add(slider);
    }
}