using DtKata.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DtKata.TabZeichnen;

public partial class TabZeichnen
{
    public static void TabSimulationZeichnen(VmKata vmKata, TabItem tabItem, string hintergrund)
    {
        var libWpf = new LibWpf.LibWpf(tabItem);
        libWpf.SetBackground(new BrushConverter().ConvertFromString(hintergrund) as SolidColorBrush);
        libWpf.GridZeichnen(50, 40, false, false, false);

        var buttonRand = new Thickness(2, 5, 2, 5);

        libWpf.ButtonBackgroundContentMarginRounded("S1", 1, 3, 1, 2, 20, 15, Brushes.LawnGreen, buttonRand, vmKata.ButtonTasterCommand, "S1", nameof(vmKata.ClickModeS1));
        libWpf.ButtonBackgroundContentMarginRounded("S2", 1, 3, 3, 2, 20, 15, Brushes.LawnGreen, buttonRand, vmKata.ButtonTasterCommand, "S2", nameof(vmKata.ClickModeS2));
        libWpf.ButtonBackgroundContentMarginRounded("S3", 1, 3, 5, 2, 20, 15, Brushes.Red, buttonRand, vmKata.ButtonTasterCommand, "S3", nameof(vmKata.ClickModeS3));
        libWpf.ButtonBackgroundContentMarginRounded("S4", 1, 3, 7, 2, 20, 15, Brushes.Red, buttonRand, vmKata.ButtonTasterCommand, "S4", nameof(vmKata.ClickModeS4));

        libWpf.ButtonMarginSetVisibilityZweiBilder(1, 3, 10, 2, "SchiebeSchalterOn.jpg", "SchiebeSchalterOff.jpg", buttonRand, vmKata.ButtonSchalterCommand, "S5", nameof(vmKata.ClickModeS5), nameof(vmKata.VisibilityEinS5), nameof(vmKata.VisibilityAusS5));
        libWpf.ButtonMarginSetVisibilityZweiBilder(1, 3, 12, 2, "SchiebeSchalterOn.jpg", "SchiebeSchalterOff.jpg", buttonRand, vmKata.ButtonSchalterCommand, "S6", nameof(vmKata.ClickModeS6), nameof(vmKata.VisibilityEinS6), nameof(vmKata.VisibilityAusS6));
        libWpf.ButtonMarginSetVisibilityZweiBilder(1, 3, 14, 2, "KippschalterOn.jpg", "KippschalterOff.jpg", buttonRand, vmKata.ButtonSchalterCommand, "S7", nameof(vmKata.ClickModeS7), nameof(vmKata.VisibilityEinS7), nameof(vmKata.VisibilityAusS7));
        libWpf.ButtonMarginSetVisibilityZweiBilder(1, 3, 16, 2, "KippschalterOn.jpg", "KippschalterOff.jpg", buttonRand, vmKata.ButtonSchalterCommand, "S8", nameof(vmKata.ClickModeS8), nameof(vmKata.VisibilityEinS8), nameof(vmKata.VisibilityAusS8));

        var kontakteRand = new Thickness(0, 5, 5, 5);

        libWpf.ImageMarginSetVisibility("TasterBetaetigt.jpg", 5, 2, 1, 2, kontakteRand, nameof(vmKata.VisibilityEinS1));
        libWpf.ImageMarginSetVisibility("TasterSchliesser.jpg", 5, 2, 1, 2, kontakteRand, nameof(vmKata.VisibilityAusS1));

        libWpf.ImageMarginSetVisibility("TasterBetaetigt.jpg", 5, 2, 3, 2, kontakteRand, nameof(vmKata.VisibilityEinS2));
        libWpf.ImageMarginSetVisibility("TasterSchliesser.jpg", 5, 2, 3, 2, kontakteRand, nameof(vmKata.VisibilityAusS2));

        libWpf.ImageMarginSetVisibility("TasterBetaetigt.jpg", 5, 2, 5, 2, kontakteRand, nameof(vmKata.VisibilityEinS3));
        libWpf.ImageMarginSetVisibility("TasterSchliesser.jpg", 5, 2, 5, 2, kontakteRand, nameof(vmKata.VisibilityAusS3));

        libWpf.ImageMarginSetVisibility("TasterBetaetigt.jpg", 5, 2, 7, 2, kontakteRand, nameof(vmKata.VisibilityEinS4));
        libWpf.ImageMarginSetVisibility("TasterSchliesser.jpg", 5, 2, 7, 2, kontakteRand, nameof(vmKata.VisibilityAusS4));

        libWpf.ImageMarginSetVisibility("TasterBetaetigt.jpg", 5, 2, 10, 2, kontakteRand, nameof(vmKata.VisibilityEinS5));
        libWpf.ImageMarginSetVisibility("TasterSchliesser.jpg", 5, 2, 10, 2, kontakteRand, nameof(vmKata.VisibilityAusS5));

        libWpf.ImageMarginSetVisibility("TasterBetaetigt.jpg", 5, 2, 12, 2, kontakteRand, nameof(vmKata.VisibilityEinS6));
        libWpf.ImageMarginSetVisibility("TasterSchliesser.jpg", 5, 2, 12, 2, kontakteRand, nameof(vmKata.VisibilityAusS6));

        libWpf.ImageMarginSetVisibility("TasterBetaetigt.jpg", 5, 2, 14, 2, kontakteRand, nameof(vmKata.VisibilityEinS7));
        libWpf.ImageMarginSetVisibility("TasterSchliesser.jpg", 5, 2, 14, 2, kontakteRand, nameof(vmKata.VisibilityAusS7));

        libWpf.ImageMarginSetVisibility("TasterBetaetigt.jpg", 5, 2, 16, 2, kontakteRand, nameof(vmKata.VisibilityEinS8));
        libWpf.ImageMarginSetVisibility("TasterSchliesser.jpg", 5, 2, 16, 2, kontakteRand, nameof(vmKata.VisibilityAusS8));

        var marginKreis = new Thickness(2, 2, 2, 2);
        var farbeKreisRand = new SolidColorBrush(Colors.Black);

        libWpf.EllipseMarginStrokeSetFilling(10, 2, 1, 2, marginKreis, farbeKreisRand, 2, nameof(vmKata.BrushP1));
        libWpf.EllipseMarginStrokeSetFilling(10, 2, 3, 2, marginKreis, farbeKreisRand, 2, nameof(vmKata.BrushP2));
        libWpf.EllipseMarginStrokeSetFilling(10, 2, 5, 2, marginKreis, farbeKreisRand, 2, nameof(vmKata.BrushP3));
        libWpf.EllipseMarginStrokeSetFilling(10, 2, 7, 2, marginKreis, farbeKreisRand, 2, nameof(vmKata.BrushP4));
        libWpf.EllipseMarginStrokeSetFilling(10, 2, 10, 2, marginKreis, farbeKreisRand, 2, nameof(vmKata.BrushP5));
        libWpf.EllipseMarginStrokeSetFilling(10, 2, 12, 2, marginKreis, farbeKreisRand, 2, nameof(vmKata.BrushP6));
        libWpf.EllipseMarginStrokeSetFilling(10, 2, 14, 2, marginKreis, farbeKreisRand, 2, nameof(vmKata.BrushP7));
        libWpf.EllipseMarginStrokeSetFilling(10, 2, 16, 2, marginKreis, farbeKreisRand, 2, nameof(vmKata.BrushP8));

        libWpf.PlcError();
    }
}