using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WpfAnimatedGif;

namespace LibWpf;

public partial class LibWpf
{
    private static (Image image, BitmapImage bitmapImage) ImageErzeugen(string source, Thickness margin)
    {
        var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("LibWpf.Bilder." + source);
        if (stream == null) throw new Exception("Bild nicht gefunden:" + source);

        var bitmapImage = new BitmapImage();
        var image = new Image();

        stream.Position = 0;

        bitmapImage.BeginInit();
        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
        bitmapImage.StreamSource = stream;
        bitmapImage.EndInit();

        image.Source = bitmapImage;
        image.Stretch = Stretch.Uniform;
        image.Margin = margin;

        return (image, bitmapImage);
    }
    public void Bild(string source, int xPos, int xSpan, int yPos, int ySpan, Thickness margin)
    {
        var (image, _) = ImageErzeugen(source, margin);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, image);
    }
    public void BildSetVisibilityEin(string source, int xPos, int xSpan, int yPos, int ySpan, Thickness margin, object wpfId)
    {
        var (image, _) = ImageErzeugen(source, margin);
        image.SetVisibilityEinBinding(wpfId);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, image);
    }
    public void BildSetVisibilityAus(string source, int xPos, int xSpan, int yPos, int ySpan, Thickness margin, object wpfId)
    {
        var (image, _) = ImageErzeugen(source, margin);
        image.SetVisibilityAusBinding(wpfId);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, image);
    }
    public void BildSetVisibilityEinAus(string sourceOn, string sourceOff, int xPos, int xSpan, int yPos, int ySpan, Thickness margin, object wpfId)
    {
        var (imageOn, _) = ImageErzeugen(sourceOn, margin);
        imageOn.SetVisibilityEinBinding(wpfId);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, imageOn);

        var (imageOff, _) = ImageErzeugen(sourceOff, margin);
        imageOff.SetVisibilityAusBinding(wpfId);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, imageOff);
    }
    public void BildSetMarginVisibilityEin(string source, int xPos, int xSpan, int yPos, int ySpan, object wpfId)
    {
        var (image, _) = ImageErzeugen(source, new Thickness(0,0,0,0));
        image.SetVisibilityEinBinding(wpfId);
        
        BindingOperations.SetBinding(image, FrameworkElement.MarginProperty, new Binding($"Margin[{(int)wpfId}]"));
        
        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, image);
    }
    public void BildSetDrehen(string source, int xPos, int xSpan, int yPos, int ySpan, Thickness margin, object wpfId)
    {
        _ = wpfId; // TODO noch fertigstellen!

        var (image, _) = ImageErzeugen(source, margin);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, image);
    }
    public void BildSetMargin(string source, int xPos, int xSpan, int yPos, int ySpan, Thickness margin, object wpfId)
    {
        _ = wpfId; // TODO noch fertigstellen!

        var (image, _) = ImageErzeugen(source, margin);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, image);
    }
    public void BildAnimiert(string source, int xPos, int xSpan, int yPos, int ySpan, Thickness margin, RoutedEventHandler eventHandler)
    {
        var (image, bitmapImage) = ImageErzeugen(source, margin);

        ImageBehavior.SetAnimatedSource(image, bitmapImage);
        ImageBehavior.SetAutoStart(image, false);
        ImageBehavior.AddAnimationLoadedHandler(image, eventHandler);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, image);
    }
}