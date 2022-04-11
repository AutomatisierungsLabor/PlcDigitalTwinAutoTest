using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WpfAnimatedGif;

namespace LibWpf;

public partial class LibWpf
{
    private static (Image image, BitmapImage bitmapImage) ImageErzeugen(string source, Thickness margin)
    {
        var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("LibWpf.Bilder." + source);
        if (stream == null) throw new Exception("Image nicht gefunden:" + source);

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
    public void Image(string source, int xPos, int xSpan, int yPos, int ySpan, Thickness margin)
    {
        var (image, _) = ImageErzeugen(source, margin);
        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, image);
    }
    public void ImageSetVisibility(string source, int xPos, int xSpan, int yPos, int ySpan,  string setVisibility)
    {
        var (imageEin, _) = ImageErzeugen(source, new Thickness(0,0,0,0));
        imageEin.BindingImageSetVisibility(setVisibility);
        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, imageEin);
    }
    public void ImageMarginSetVisibility(string source, int xPos, int xSpan, int yPos, int ySpan, Thickness margin, string setVisibility)
    {
        var (imageEin, _) = ImageErzeugen(source, margin);
        imageEin.BindingImageSetVisibility(setVisibility);
        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, imageEin);
    }
    public void ImageMarginZweiBilderSetVisibility(string sourceOn, string sourceOff, int xPos, int xSpan, int yPos, int ySpan, Thickness margin, string setVisibilityEin, string setVisibilityAus)
    {
        var (imageOn, _) = ImageErzeugen(sourceOn, margin);
        imageOn.BindingButtonSetVisibility(setVisibilityEin);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, imageOn);

        var (imageOff, _) = ImageErzeugen(sourceOff, margin);
        imageOff.BindingButtonSetVisibility(setVisibilityAus);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, imageOff);
    }
    public void ImageMarginSetDrehen(string source, int xPos, int xSpan, int yPos, int ySpan, Thickness margin, object bindingWinkel)
    {
        _ = bindingWinkel; // TODO noch fertigstellen!

        var (image, _) = ImageErzeugen(source, margin);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, image);
    }
    public void ImageSetMargin(string source, int xPos, int xSpan, int yPos, int ySpan, Thickness margin, object bindingMargin)
    {
        _ = bindingMargin; // TODO noch fertigstellen!

        var (image, _) = ImageErzeugen(source, margin);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, image);
    }
    public void ImageSetMarginSetVisibility(string source, int xPos, int xSpan, int yPos, int ySpan, string bindingMargin, string bindingVisability)
    {
        var (image, _) = ImageErzeugen(source, new Thickness(0, 0, 0, 0));
        image.BindingSetVisibility(bindingVisability);
        image.BindingImageSetMargin(bindingMargin);

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