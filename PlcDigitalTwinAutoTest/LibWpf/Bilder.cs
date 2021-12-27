using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace LibWpf;

public partial class LibWpf
{
    public void BildVisEin(string source, int xPos, int xSpan, int yPos, int ySpan, Thickness margin, int binding)
    {
        var image = new Image
        {
            Source = new BitmapImage(new Uri(@$"Bilder\{source}", UriKind.Relative)),
            Stretch = Stretch.Fill,
            Margin = margin
        };

        image.SetBinding(UIElement.VisibilityProperty, new Binding($"SichtbarEin[{binding}]"));

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, image);
    }

    public void BildVisAus(string source, int xPos, int xSpan, int yPos, int ySpan, Thickness margin, int binding)
    {
        var image = new Image
        {
            Source = new BitmapImage(new Uri(@$"Bilder\{source}", UriKind.Relative)),
            Stretch = Stretch.Fill,
            Margin = margin
        };

        image.SetBinding(UIElement.VisibilityProperty, new Binding($"SichtbarAus[{binding}]"));

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, image);
    }
}