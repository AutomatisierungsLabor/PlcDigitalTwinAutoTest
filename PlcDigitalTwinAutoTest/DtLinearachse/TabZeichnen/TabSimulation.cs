using DtLinearachse.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DtLinearachse.TabZeichnen;

public partial class TabZeichnen
{
    public static void TabSimulationZeichnen(VmLinearachse vmLinearachse, TabItem tabItem, string hintergrund)
    {
        var libWpf = new LibWpf.LibWpf(tabItem);
        libWpf.SetBackground(new BrushConverter().ConvertFromString(hintergrund) as SolidColorBrush);
        libWpf.GridZeichnen(50, 40, false, false, true);


        libWpf.RectangleFill(3, 2, 1, 7, Brushes.Black);
        libWpf.RectangleFill(5, 20, 3, 3, Brushes.DarkGray);
        libWpf.RectangleFill(5, 20, 4, 1, Brushes.Black);
        libWpf.RectangleFill(25, 2, 1, 7, Brushes.Black);

        libWpf.RectangleFillStrokeBindingMargin(5, 20, 1, 7, Brushes.Yellow, Brushes.Black, 2, nameof(vmLinearachse.MarginPositionSchlitten));

        var kontakteRand = new Thickness(2, 5, 2, 5);
        libWpf.Text("-B1", 3, 2, 8, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ImageMarginBindingVisibility("TasterSchliesser.jpg", 4, 2, 8, 2, kontakteRand, nameof(vmLinearachse.VisibilityAusB1));
        libWpf.ImageMarginBindingVisibility("TasterBetaetigt.jpg", 4, 2, 8, 2, kontakteRand, nameof(vmLinearachse.VisibilityEinB1));

        libWpf.Text("-B2", 23, 2, 8, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ImageMarginBindingVisibility("TasterSchliesser.jpg", 23, 2, 8, 2, kontakteRand, nameof(vmLinearachse.VisibilityAusB2));
        libWpf.ImageMarginBindingVisibility("TasterBetaetigt.jpg", 23, 2, 8, 2, kontakteRand, nameof(vmLinearachse.VisibilityAusB2));




        var buttonRand = new Thickness(2, 5, 2, 5);

        libWpf.RectangleFill(1, 5, 11, 8, Brushes.LightGray);
        libWpf.Text("-S1", 1, 2, 11, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonBackgroundContentMarginRounded("①", 3, 3, 11, 3, 50, 15, Brushes.LawnGreen, buttonRand, vmLinearachse.ButtonTasterCommand, "S1", nameof(vmLinearachse.ClickModeS1));

        libWpf.Text("-P1", 1, 2, 14, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.RectangleMarginBindingFill(3, 3, 14, 2, buttonRand, nameof(vmLinearachse.BrushP1));

        libWpf.Text("-S2", 1, 2, 16, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonBackgroundContentMarginRounded("⓪", 3, 3, 16, 3, 50, 15, Brushes.Red, buttonRand, vmLinearachse.ButtonTasterCommand, "S2", nameof(vmLinearachse.ClickModeS2));


        libWpf.RectangleFill(8, 5, 11, 8, Brushes.LightGray);
        libWpf.Text("-S3", 8, 2, 11, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonBackgroundContentMarginRounded("I", 10, 3, 11, 3, 50, 15, Brushes.LawnGreen, buttonRand, vmLinearachse.ButtonTasterCommand, "S3", nameof(vmLinearachse.ClickModeS3));

        libWpf.Text("-S9", 8, 2, 14, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonBackgroundContentMarginRounded("STOP", 10, 3, 14, 2, 30, 5, Brushes.Red, buttonRand, vmLinearachse.ButtonTasterCommand, "S9", nameof(vmLinearachse.ClickModeS9));

        libWpf.Text("-S4", 8, 2, 16, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonBackgroundContentMarginRounded("II", 10, 3, 16, 3, 50, 15, Brushes.LawnGreen, buttonRand, vmLinearachse.ButtonTasterCommand, "S4", nameof(vmLinearachse.ClickModeS4));


        libWpf.RectangleFill(15, 5, 11, 8, Brushes.LightGray);
        libWpf.Text("-S5", 15, 2, 11, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonBackgroundContentMarginRounded("↑", 17, 3, 11, 3, 50, 15, Brushes.LawnGreen, buttonRand, vmLinearachse.ButtonTasterCommand, "S5", nameof(vmLinearachse.ClickModeS5));

        libWpf.Text("-S9", 15, 2, 14, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonBackgroundContentMarginRounded("STOP", 17, 3, 14, 2, 30, 5, Brushes.Red, buttonRand, vmLinearachse.ButtonTasterCommand, "S9", nameof(vmLinearachse.ClickModeS9));

        libWpf.Text("-S6", 15, 2, 16, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonBackgroundContentMarginRounded("↓", 17, 3, 16, 3, 50, 15, Brushes.LawnGreen, buttonRand, vmLinearachse.ButtonTasterCommand, "S6", nameof(vmLinearachse.ClickModeS6));


        libWpf.RectangleFill(22, 5, 11, 8, Brushes.LightGray);
        libWpf.Text("-S7", 22, 2, 11, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonBackgroundContentMarginRounded("+", 24, 3, 11, 3, 50, 15, Brushes.LawnGreen, buttonRand, vmLinearachse.ButtonTasterCommand, "S7", nameof(vmLinearachse.ClickModeS7));
        libWpf.Text("-S9", 22, 2, 14, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonBackgroundContentMarginRounded("STOP", 24, 3, 14, 2, 30, 5, Brushes.Red, buttonRand, vmLinearachse.ButtonTasterCommand, "S9", nameof(vmLinearachse.ClickModeS9));

        libWpf.Text("-S8", 22, 2, 16, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonBackgroundContentMarginRounded("-", 24, 3, 16, 3, 50, 15, Brushes.LawnGreen, buttonRand, vmLinearachse.ButtonTasterCommand, "S8", nameof(vmLinearachse.ClickModeS8));


        var kreisRand = new Thickness(2, 2, 2, 2);
        var kreisRandFarbe = new SolidColorBrush(Colors.Black);

        libWpf.RectangleFill(1, 5, 20, 3, Brushes.LightGray);
        libWpf.Text("-P2", 1, 2, 20, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.EllipseMarginStrokeBindingFilling(3, 3, 20, 3, kreisRand, kreisRandFarbe, 2, nameof(vmLinearachse.BrushP2));

        libWpf.RectangleFill(8, 5, 20, 3, Brushes.LightGray);
        libWpf.Text("-P3", 8, 2, 20, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.EllipseMarginStrokeBindingFilling(10, 3, 20, 3, kreisRand, kreisRandFarbe, 2, nameof(vmLinearachse.BrushP3));

        libWpf.RectangleFill(15, 5, 20, 3, Brushes.LightGray);
        libWpf.Text("-P4", 15, 2, 20, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.EllipseMarginStrokeBindingFilling(17, 3, 20, 3, kreisRand, kreisRandFarbe, 2, nameof(vmLinearachse.BrushP4));

        libWpf.RectangleFill(22, 5, 20, 3, Brushes.LightGray);
        libWpf.ButtonMarginSetVisibilityZweiBilder(24, 3, 20, 3, "NotHalt.jpg", "NotHaltGedrueckt.jpg", buttonRand, vmLinearachse.ButtonSchalterCommand, "S10", nameof(vmLinearachse.ClickModeS10), nameof(vmLinearachse.VisibilityEinS10), nameof(vmLinearachse.VisibilityAusS10));
        libWpf.Text("-S10", 22, 2, 20, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("-S11", 22, 2, 21, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.PlcError();
    }
}