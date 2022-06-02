using DtSchleifmaschine.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DtSchleifmaschine.TabZeichnen;

public partial class TabZeichnen
{
    public static void TabSimulationZeichnen(VmSchleifmaschine vmSchleifmaschine, TabItem tabItem, string hintergrund)
    {
        var libWpf = new LibWpf.LibWpf(tabItem);
        libWpf.SetBackground(new BrushConverter().ConvertFromString(hintergrund) as SolidColorBrush);
        libWpf.GridZeichnen(50, 30, 40, 30, false, false, false);


        libWpf.EllipseFillMarginStroke(2, 8, 1, 8, Brushes.SlateGray, new Thickness(2, 2, 2, 2), Brushes.SlateGray, 0);
        libWpf.RectangleFillMarginSetWinkel(5, 2, 1, 2, Brushes.Yellow, new Thickness(25, 0, 25, 20), nameof(vmSchleifmaschine.Winkel), nameof(vmSchleifmaschine.PointTransformOrigin));

        libWpf.TextSetContent(2, 8, 9, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 30, Brushes.Black, nameof(vmSchleifmaschine.StringSchleifmaschineDrehzahl));

        libWpf.RectangleFillSetVisibility(2, 20, 12, 2, Brushes.Red, nameof(vmSchleifmaschine.VisibilityEinB1));
        libWpf.TextContendSetVisibility("Schleifmaschine Übersynchron!", 2, 20, 12, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black, nameof(vmSchleifmaschine.VisibilityEinB1));


        libWpf.PointerGauge(12, 10, 1, 10, "Drehzahl", 0, 3000, 80, 225, "AktuelleDrehzahl");


        var buttonRand = new Thickness(2, 5, 2, 5);

        libWpf.RectangleFill(2, 5, 15, 8, Brushes.LightGray);

        libWpf.Text("-S1", 2, 2, 15, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonBackgroundContentMarginRounded("I", 4, 3, 15, 3, 50, 15, Brushes.LawnGreen, buttonRand, vmSchleifmaschine.ButtonTasterCommand, "S1", nameof(vmSchleifmaschine.ClickModeS1));

        libWpf.Text("-S0", 2, 2, 18, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonBackgroundContentMarginRounded("STOP", 4, 3, 18, 2, 20, 5, Brushes.Red, buttonRand, vmSchleifmaschine.ButtonTasterCommand, "S0", nameof(vmSchleifmaschine.ClickModeS0));

        libWpf.Text("-S2", 2, 2, 20, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonBackgroundContentMarginRounded("II", 4, 3, 20, 3, 50, 15, Brushes.LawnGreen, buttonRand, vmSchleifmaschine.ButtonTasterCommand, "S2", nameof(vmSchleifmaschine.ClickModeS2));


        libWpf.EllipseFillMarginStroke(15, 4, 15, 4, Brushes.Yellow, new Thickness(0, 0, 0, 0), Brushes.Red, 2);





        var kreisRand = new Thickness(2, 2, 2, 2);
        var kreisRandFarbe = new SolidColorBrush(Colors.Black);

        libWpf.RectangleFill(30, 5, 1, 6, Brushes.LightGray);

        libWpf.Text("-F1", 30, 2, 1, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonContentMarginRoundedSetBackground("?", 32, 3, 1, 3, 50, 5, buttonRand, vmSchleifmaschine.ButtonSchalterCommand, "F1", nameof(vmSchleifmaschine.ClickModeF1), nameof(vmSchleifmaschine.BrushF1));

        libWpf.Text("-F2", 30, 2, 4, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonContentMarginRoundedSetBackground("??", 32, 3, 4, 3, 50, 5, buttonRand, vmSchleifmaschine.ButtonSchalterCommand, "F2", nameof(vmSchleifmaschine.ClickModeF2), nameof(vmSchleifmaschine.BrushF2));


        libWpf.RectangleFill(30, 5, 8, 11, Brushes.LightGray);

        libWpf.Text("-P1", 30, 2, 8, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.EllipseMarginStrokeSetFilling(32, 3, 8, 3, kreisRand, kreisRandFarbe, 2, nameof(vmSchleifmaschine.BrushP1));
        libWpf.Text("langsam", 32, 3, 8, 3, HorizontalAlignment.Center, VerticalAlignment.Center, 10, Brushes.Black);

        libWpf.Text("-P2", 30, 2, 12, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.EllipseMarginStrokeSetFilling(32, 3, 12, 3, kreisRand, kreisRandFarbe, 2, nameof(vmSchleifmaschine.BrushP2));
        libWpf.Text("schnell", 32, 3, 12, 3, HorizontalAlignment.Center, VerticalAlignment.Center, 10, Brushes.Black);

        libWpf.Text("-P3", 30, 2, 16, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.EllipseMarginStrokeSetFilling(32, 3, 16, 3, kreisRand, kreisRandFarbe, 2, nameof(vmSchleifmaschine.BrushP3));
        libWpf.Text("schnell", 32, 3, 16, 3, HorizontalAlignment.Center, VerticalAlignment.Center, 10, Brushes.Black);




        libWpf.RectangleFill(30, 5, 21, 2, Brushes.LightGray);

        libWpf.Text("-S4", 30, 2, 21, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonBackgroundContentMarginRounded("Reset", 32, 3, 21, 2, 20, 5, Brushes.Red, buttonRand, vmSchleifmaschine.ButtonTasterCommand, "S4", nameof(vmSchleifmaschine.ClickModeS4));

        libWpf.ButtonMarginSetVisibilityZweiBilder(22, 4, 15, 4, "NotHalt.jpg", "NotHaltGedrueckt.jpg", new Thickness(0, 0, 0, 0), vmSchleifmaschine.ButtonSchalterCommand, "S3", nameof(vmSchleifmaschine.ClickModeS3), nameof(vmSchleifmaschine.VisibilityEinS3), nameof(vmSchleifmaschine.VisibilityEinS3));
        libWpf.Text("-S3", 20, 2, 16, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);


        // libWpf.PlcError();
    }
}