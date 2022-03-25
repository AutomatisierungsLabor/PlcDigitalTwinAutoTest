using System;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WpfAnimatedGif;
using Image = System.Windows.Controls.Image;

namespace LibWpf;

public partial class LibWpf
{
    private static Image ImageErzeugen(string source, Thickness margin)
    {
        var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("LibWpf.Bilder." + source);
        if (stream == null) throw new Exception("Bild nicht gefunden:" + source);

        var bitmap = new BitmapImage();
        var image = new Image();
        
        stream.Position = 0;

        bitmap.BeginInit();
        bitmap.CacheOption = BitmapCacheOption.OnLoad;
        bitmap.StreamSource = stream;
        bitmap.EndInit();


        image.Source = bitmap;
        image.Stretch = Stretch.Uniform;
        image.Margin = margin;

        return image;
    }
    public void Bild(string source, int xPos, int xSpan, int yPos, int ySpan, Thickness margin)
    {
        var image = ImageErzeugen(source, margin);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, image);
    }
    public void BildSichtbarkeitEin(string source, int xPos, int xSpan, int yPos, int ySpan, Thickness margin, object wpfId)
    {
        var image = ImageErzeugen(source, margin);
        image.SetSichtbarkeitEinBinding(wpfId);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, image);
    }
    public void BildSichtbarkeitAus(string source, int xPos, int xSpan, int yPos, int ySpan, Thickness margin, object wpfId)
    {
        var image = ImageErzeugen(source, margin);
        image.SetSichtbarkeitAusBinding(wpfId);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, image);
    }
    public void BildDrehen(string source, int xPos, int xSpan, int yPos, int ySpan, Thickness margin, object wpfId)
    {
        _ = wpfId; // TODO noch fertigstellen!

        var image = ImageErzeugen(source, margin);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, image);
    }
    public void BildRand(string source, int xPos, int xSpan, int yPos, int ySpan, Thickness margin, object wpfId)
    {
        _ = wpfId; // TODO noch fertigstellen!

        var image = ImageErzeugen(source, margin);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, image);
    }
    public void BildAnimiert(string source, int xPos, int xSpan, int yPos, int ySpan, Thickness margin, RoutedEventHandler eventHandler)
    {
        _ = margin;
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