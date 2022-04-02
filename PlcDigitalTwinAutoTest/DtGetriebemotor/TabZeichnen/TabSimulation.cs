using DtGetriebemotor.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DtGetriebemotor.TabZeichnen;

public partial class TabZeichnen
{
    public static void TabSimulationZeichnen(VmGetriebemotor vmGetriebemotor, TabItem tabItem, string hintergrund)
    {
        var libWpf = new LibWpf.LibWpf(tabItem);
        libWpf.SetBackground(new BrushConverter().ConvertFromString(hintergrund) as SolidColorBrush);
        libWpf.GridZeichnen(50, 30, 40, 30, true);



        libWpf.EllipseFillMarginStroke(7, 8, 2, 8, Brushes.SlateGray, new Thickness(2, 2, 2, 2), Brushes.SlateGray, 0);
        libWpf.RipRechteckFillMarginSetWinkel(10, 2, 3, 2, Brushes.Yellow, new Thickness(25, 0, 25, 20), WpfObjects.WinkelGetriebemotor);


        var kontakteRand = new Thickness(2, 5, 2, 5);

        libWpf.ImageSetVisibility("TasterSchliesser.jpg", 10, 2, 0, 2, kontakteRand, nameof(vmGetriebemotor.VisibilityAusB1));
        libWpf.ImageSetVisibility("TasterBetaetigt.jpg", 10, 2, 0, 2, kontakteRand, nameof(vmGetriebemotor.VisibilityEinB1));
        libWpf.Text("-B1", 9, 2, 0, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.ImageSetVisibility("TasterSchliesser.jpg", 15, 2, 2, 2, kontakteRand, nameof(vmGetriebemotor.VisibilityAusB2));
        libWpf.ImageSetVisibility("TasterBetaetigt.jpg", 15, 2, 2, 2, kontakteRand, nameof(vmGetriebemotor.VisibilityEinB2));
        libWpf.Text("-B2", 14, 2, 2, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);

        var buttonRand = new Thickness(2, 5, 2, 5);

        libWpf.RectangleFill(1, 5, 11, 8, Brushes.LightGray);
        libWpf.Text("-S1", 1, 2, 11, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonBackgroundMarginRoundedSetContend(3, 3, 11, 3, 50, 15, Brushes.LawnGreen, buttonRand, vmGetriebemotor.ButtonTasterCommand, "S1", nameof(vmGetriebemotor.ClickModeS1), nameof(vmGetriebemotor.StringS1));

        libWpf.Text("-S2", 1, 2, 16, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonBackgroundMarginRoundedSetContend(3, 3, 16, 3, 50, 15, Brushes.Red, buttonRand, vmGetriebemotor.ButtonTasterCommand, "S2", nameof(vmGetriebemotor.ClickModeS2), nameof(vmGetriebemotor.StringS2));


        libWpf.RectangleFill(8, 5, 11, 8, Brushes.LightGray);
        libWpf.Text("-S3", 8, 2, 11, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonBackgroundMarginRoundedSetContend(10, 3, 11, 3, 50, 15, Brushes.LawnGreen, buttonRand, vmGetriebemotor.ButtonTasterCommand, "S3", nameof(vmGetriebemotor.ClickModeS3), nameof(vmGetriebemotor.StringS3));

        libWpf.Text("-S4", 8, 2, 14, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonBackgroundMarginRoundedSetContend(10, 3, 14, 2, 30, 5, Brushes.Red, buttonRand, vmGetriebemotor.ButtonTasterCommand, "S4", nameof(vmGetriebemotor.ClickModeS4), nameof(vmGetriebemotor.StringS4));

        libWpf.Text("-S5", 8, 2, 16, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonBackgroundMarginRoundedSetContend(10, 3, 16, 3, 50, 15, Brushes.LawnGreen, buttonRand, vmGetriebemotor.ButtonTasterCommand, "S5", nameof(vmGetriebemotor.ClickModeS5), nameof(vmGetriebemotor.StringS5));


        libWpf.RectangleFill(15, 5, 11, 8, Brushes.LightGray);
        libWpf.Text("-S6", 15, 2, 11, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonBackgroundMarginRoundedSetContend(17, 3, 11, 3, 50, 15, Brushes.LawnGreen, buttonRand, vmGetriebemotor.ButtonTasterCommand, "S6", nameof(vmGetriebemotor.ClickModeS6), nameof(vmGetriebemotor.StringS6));

        libWpf.Text("-S7", 15, 2, 14, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonBackgroundMarginRoundedSetContend(17, 3, 14, 2, 30, 5, Brushes.Red, buttonRand, vmGetriebemotor.ButtonTasterCommand, "S7", nameof(vmGetriebemotor.ClickModeS7), nameof(vmGetriebemotor.StringS7));

        libWpf.Text("-S8", 15, 2, 16, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonBackgroundMarginRoundedSetContend(17, 3, 16, 3, 50, 15, Brushes.LawnGreen, buttonRand, vmGetriebemotor.ButtonTasterCommand, "S8", nameof(vmGetriebemotor.ClickModeS8), nameof(vmGetriebemotor.StringS8));

        var kreisRand = new Thickness(2, 2, 2, 2);
        var kreisRandFarbe = new SolidColorBrush(Colors.Black);

        libWpf.RectangleFill(1, 5, 20, 3, Brushes.LightGray);
        libWpf.Text("-P1", 1, 2, 20, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.EllipseMarginStrokeSetFilling(3, 3, 20, 3, kreisRand, kreisRandFarbe, 2, nameof(vmGetriebemotor.BrushP1));

        libWpf.RectangleFill(8, 5, 20, 3, Brushes.LightGray);
        libWpf.Text("-P2", 8, 2, 20, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.EllipseMarginStrokeSetFilling(10, 3, 20, 3, kreisRand, kreisRandFarbe, 2, nameof(vmGetriebemotor.BrushP2));

        libWpf.RectangleFill(15, 5, 20, 3, Brushes.LightGray);
        libWpf.Text("-P3", 15, 2, 20, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.EllipseMarginStrokeSetFilling(17, 3, 20, 3, kreisRand, kreisRandFarbe, 2, nameof(vmGetriebemotor.BrushP3));


        libWpf.ButtonMarginSetVisibilityZweiBilder(20, 4, 4, 4, "NotHalt.jpg", "NotHaltGedrueckt.jpg", buttonRand, vmGetriebemotor.ButtonSchalterCommand, "S91", nameof(vmGetriebemotor.VisibilityEinS91), nameof(vmGetriebemotor.VisibilityAusS91));
        libWpf.Text("-S9.1", 18, 2, 4, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("-S9.2", 18, 2, 5, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.PlcError();
    }
}