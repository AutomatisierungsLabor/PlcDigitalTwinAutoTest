using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LibWpf;

public partial class LibWpf
{

    public WebBrowser WebBrowser(int xPos, int xSpan, int yPos, int ySpan, Thickness margin, Brush farbe)
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

}
