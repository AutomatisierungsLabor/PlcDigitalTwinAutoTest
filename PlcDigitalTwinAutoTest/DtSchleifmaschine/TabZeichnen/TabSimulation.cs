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
        libWpf.GridZeichnen(50, 40, false, false, true);


        libWpf.EllipseFillMarginStroke(2, 8, 1, 8, Brushes.SlateGray, new Thickness(2, 2, 2, 2), Brushes.SlateGray, 0);
        libWpf.RectangleFillMarginSetWinkel(5, 2, 1, 2, Brushes.Yellow, new Thickness(25, 0, 25, 20), nameof(vmSchleifmaschine.Winkel), nameof(vmSchleifmaschine.PointTransformOrigin));

        libWpf.TextSetContent(2, 8, 9, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 30, Brushes.Black, nameof(vmSchleifmaschine.StringSchleifmaschineDrehzahl));

        libWpf.RectangleFillSetVisibility(2, 20, 12, 2, Brushes.Red, nameof(vmSchleifmaschine.VisibilityEinB1));
        libWpf.TextContendSetVisibility("Schleifmaschine Übersynchron!", 2, 20, 12, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black, nameof(vmSchleifmaschine.VisibilityEinB1));


        libWpf.PointerGauge(12, 10, 1, 10, "Drehzahl", 0, 3000, 80, 225, "AktuelleDrehzahl");


        var buttonRand = new Thickness(2, 5, 2, 5);

        libWpf.RectangleFill(2, 5, 14, 8, Brushes.LightGray);

        libWpf.Text("-S1", 2, 2, 14, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("-P1", 2, 2, 15, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonContentMarginRoundedSetBackground("I", 4, 3, 14, 3, 50, 15, buttonRand, vmSchleifmaschine.ButtonTasterCommand, "S1", nameof(vmSchleifmaschine.ClickModeS1), nameof(vmSchleifmaschine.BrushP1));

        libWpf.Text("-S0", 2, 2, 17, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonBackgroundContentMarginRounded("STOP", 4, 3, 17, 2, 20, 5, Brushes.Red, buttonRand, vmSchleifmaschine.ButtonTasterCommand, "S0", nameof(vmSchleifmaschine.ClickModeS0));

        libWpf.Text("-S2", 2, 2, 19, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("-P2", 2, 2, 20, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonContentMarginRoundedSetBackground("II", 4, 3, 19, 3, 50, 15, buttonRand, vmSchleifmaschine.ButtonTasterCommand, "S2", nameof(vmSchleifmaschine.ClickModeS2), nameof(vmSchleifmaschine.BrushP2));



        var kreisRand = new Thickness(2, 2, 2, 2);


        libWpf.Text("-Q1", 8, 2, 14, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.RectangleMarginStrokeSetFill(10, 4, 14, 2, kreisRand, Brushes.Black, 2, nameof(vmSchleifmaschine.BrushQ1));
        libWpf.Text("Langsam", 10, 4, 14, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.Text("-Q2", 8, 2, 16, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.RectangleMarginStrokeSetFill(10, 4, 16, 2, kreisRand, Brushes.Black, 2, nameof(vmSchleifmaschine.BrushQ2));
        libWpf.Text("Schnell", 10, 4, 16, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.Text("-P3", 8, 2, 19, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.EllipseMarginStrokeSetFilling(10, 3, 19, 3, kreisRand, Brushes.Black, 2, nameof(vmSchleifmaschine.BrushP3));


        libWpf.Text("-F1", 15, 2, 14, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonContentMarginRoundedSetBackground("Thermorelais", 17, 5, 14, 2, 20, 5, buttonRand, vmSchleifmaschine.ButtonSchalterCommand, "F1", nameof(vmSchleifmaschine.ClickModeF1), nameof(vmSchleifmaschine.BrushF1));

        libWpf.Text("-F2", 15, 2, 16, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonContentMarginRoundedSetBackground("Thermorelais", 17, 5, 16, 2, 20, 5, buttonRand, vmSchleifmaschine.ButtonSchalterCommand, "F2", nameof(vmSchleifmaschine.ClickModeF2), nameof(vmSchleifmaschine.BrushF2));

        libWpf.Text("-S3", 23, 2, 14, 4, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonMarginSetVisibilityZweiBilder(25, 4, 14, 4, "NotHalt.jpg", "NotHaltGedrueckt.jpg", buttonRand, vmSchleifmaschine.ButtonSchalterCommand, "S3", nameof(vmSchleifmaschine.ClickModeS3), nameof(vmSchleifmaschine.VisibilityEinS3), nameof(vmSchleifmaschine.VisibilityAusS3));

        libWpf.Text("-S4", 23, 2, 20, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonBackgroundContentMarginRounded("Reset", 25, 4, 20, 2, 20, 5, Brushes.DeepPink, buttonRand, vmSchleifmaschine.ButtonTasterCommand, "S4", nameof(vmSchleifmaschine.ClickModeS4));


        libWpf.RectangleFillSetVisibility(2, 8, 11, 2, Brushes.Yellow, nameof(vmSchleifmaschine.VisibilityUebersynchron));
        libWpf.TextContendSetVisibility("Übersychron!", 2, 8, 11, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 30, Brushes.Black, nameof(vmSchleifmaschine.VisibilityUebersynchron));

        // libWpf.PlcError();
    }
}