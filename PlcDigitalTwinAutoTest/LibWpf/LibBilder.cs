using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static System.Windows.Controls.Grid;

namespace LibWpf;

public class LibBilder
{
    public static void BildVisEin(string source, int xPos, int xSpan, int yPos, int ySpan, Thickness margin, int binding, Grid grid)
    {
        var image = new Image
        {
            Source = new BitmapImage(new Uri(@$"Bilder\{source}", UriKind.Relative)),
            Stretch = Stretch.Fill,
            Margin = margin
        };

        image.SetBinding(UIElement.VisibilityProperty, new Binding($"SichtbarEin[{binding}]"));

        LibTexte.GridAnpassen(xPos, xSpan, yPos, ySpan, grid, image);
    }

    public static void BildVisAus(string source, int xPos, int xSpan, int yPos, int ySpan, Thickness margin, int binding, Grid grid)
    {
        var image = new Image
        {
            Source = new BitmapImage(new Uri(@$"Bilder\{source}", UriKind.Relative)),
            Stretch = Stretch.Fill,
            Margin = margin
        };

        image.SetBinding(UIElement.VisibilityProperty, new Binding($"SichtbarAus[{binding}]"));

        LibTexte.GridAnpassen(xPos, xSpan, yPos, ySpan, grid, image);
    }
}