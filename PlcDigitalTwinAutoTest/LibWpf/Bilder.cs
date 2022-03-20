using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WpfAnimatedGif;

namespace LibWpf;

public partial class LibWpf
{

    public void Bild(string source, int xPos, int xSpan, int yPos, int ySpan, Thickness margin)
    {
        var image = new Image
        {
            Source = new BitmapImage(new Uri(@$"Bilder\{source}", UriKind.Relative)),
            Stretch = Stretch.Fill,
            Margin = margin
        };

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, image);
    }
    public void BildSichtbarkeitEin(string source, int xPos, int xSpan, int yPos, int ySpan, Thickness margin, object wpfId)
    {
        var image = new Image
        {
            Source = new BitmapImage(new Uri(@$"Bilder\{source}", UriKind.Relative)),
            Stretch = Stretch.Fill,
            Margin = margin
        };

        image.SetSichtbarkeitEinBinding(wpfId);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, image);
    }
    public void BildSichtbarkeitAus(string source, int xPos, int xSpan, int yPos, int ySpan, Thickness margin, object wpfId)
    {
        var image = new Image
        {
            Source = new BitmapImage(new Uri(@$"Bilder\{source}", UriKind.Relative)),
            Stretch = Stretch.Fill,
            Margin = margin
        };

        image.SetSichtbarkeitAusBinding(wpfId);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, image);
    }
    public void BildDrehen(string source, int xPos, int xSpan, int yPos, int ySpan, Thickness margin, object wpfId)
    {
        _ = wpfId; // TODO noch fertigstellen!
       var image = new Image
        {
            Source = new BitmapImage(new Uri(@$"Bilder\{source}", UriKind.Relative)),
            Stretch = Stretch.Fill,
            Margin = margin
        };

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, image);
    }
    public void BildRand(string source, int xPos, int xSpan, int yPos, int ySpan, object wpfId)
    {
        _ = wpfId; // TODO noch fertigstellen!
       var image = new Image
        {
            Source = new BitmapImage(new Uri(@$"Bilder\{source}", UriKind.Relative)),
            Stretch = Stretch.Fill
        };

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, image);
    }
    public void BildAnimiert(string source, int xPos, int xSpan, int yPos, int ySpan, RoutedEventHandler eventHandler)
    {
        var img = new Image();
        var image = new BitmapImage();
        image.BeginInit();
        image.UriSource = new Uri(@$"Bilder\{source}", UriKind.Relative);
        image.EndInit();

        ImageBehavior.SetAnimatedSource(img, image);
        ImageBehavior.SetAutoStart(img, false);
        ImageBehavior.AddAnimationLoadedHandler(img, eventHandler);
        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, img);
    }
}