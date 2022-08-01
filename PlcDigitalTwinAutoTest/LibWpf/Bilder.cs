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
#pragma warning disable CA1822 // can be marked as static
    public BitmapImage GetBild(string source)
    {
        var (_, bitmapImage) = ImageErzeugen(source, new Thickness(0, 0, 0, 0));
        return bitmapImage;
    }
#pragma warning restore CA1822 // can be marked as static

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
    public void ImageBindingVisibility(string source, int xPos, int xSpan, int yPos, int ySpan, string bindingVisibility)
    {
        var (imageEin, _) = ImageErzeugen(source, new Thickness(0, 0, 0, 0));
        imageEin.FrameworkElementBindingVisibility(bindingVisibility);
        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, imageEin);
    }
    public void ImageMarginBindingVisibility(string source, int xPos, int xSpan, int yPos, int ySpan, Thickness margin, string bindingVisibility)
    {
        var (imageEin, _) = ImageErzeugen(source, margin);
        imageEin.FrameworkElementBindingVisibility(bindingVisibility);
        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, imageEin);
    }
    public void ImageMarginZweiBilderBindingVisibility(string sourceOn, string sourceOff, int xPos, int xSpan, int yPos, int ySpan, Thickness margin, string bindingVisibilityEin, string bindingVisibilityAus)
    {
        var (imageOn, _) = ImageErzeugen(sourceOn, margin);
        imageOn.FrameworkElementBindingVisibility(bindingVisibilityEin);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, imageOn);

        var (imageOff, _) = ImageErzeugen(sourceOff, margin);
        imageOff.FrameworkElementBindingVisibility(bindingVisibilityAus);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, imageOff);
    }
    public void ImageMarginZweiBilderRotateBindingVisibility(string sourceOn, string sourceOff, int xPos, int xSpan, int yPos, int ySpan, int winkel, Thickness margin, string bindingVisibilityEin, string bindingVisibilityAus)
    {
        var rotateTransform = new RotateTransform(winkel);

        var (imageOn, _) = ImageErzeugen(sourceOn, margin);
        imageOn.FrameworkElementBindingVisibility(bindingVisibilityEin);
        imageOn.RenderTransform = rotateTransform;

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, imageOn);

        var (imageOff, _) = ImageErzeugen(sourceOff, margin);
        imageOff.FrameworkElementBindingVisibility(bindingVisibilityAus);
        imageOff.RenderTransform = rotateTransform;

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, imageOff);
    }
    public void ImageMarginBindingWinkel(string source, int xPos, int xSpan, int yPos, int ySpan, Thickness margin, string bindingWinkel)
    {
        var (image, _) = ImageErzeugen(source, margin);

        image.RenderTransformOrigin = new Point(0.5, 0.5);

        var b = new Binding(bindingWinkel);
        var rt = new RotateTransform();
        BindingOperations.SetBinding(rt, RotateTransform.AngleProperty, b);
        image.RenderTransform = rt;

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, image);
    }
    public void ImageBindingMargin(string source, int xPos, int xSpan, int yPos, int ySpan, Thickness margin, string bindingMargin)
    {
        var (image, _) = ImageErzeugen(source, margin);
        image.FrameworkElementBindingMargin(bindingMargin);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, image);
    }
    public void ImageSetMarginBindingVisibility(string source, int xPos, int xSpan, int yPos, int ySpan, string bindingMargin, string bindingVisability)
    {
        var (image, _) = ImageErzeugen(source, new Thickness(0, 0, 0, 0));
        image.FrameworkElementBindingVisibility(bindingVisability);
        image.FrameworkElementBindingMargin(bindingMargin);

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