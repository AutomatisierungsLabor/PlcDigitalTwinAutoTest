using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DtLap2018_4_Niveauregelung.ViewModel;

namespace DtLap2018_4_Niveauregelung.TabZeichnen;

public partial class TabZeichnen
{
    public static void TabSimulationZeichnen(VmLap2018 vmLap2018, TabItem tabItem, string hintergrund)
    {
        var libWpf = new LibWpf.LibWpf(tabItem);
        libWpf.SetBackground(new BrushConverter().ConvertFromString(hintergrund) as SolidColorBrush);
        libWpf.GridZeichnen(50, 40, false, false, true);

        var buttonRand = new Thickness(2, 5, 2, 5);
        var kreisRand = new Thickness(2, 2, 2, 2);
        var kreisRandFarbe = new SolidColorBrush(Colors.Black);




        ///////////////////////////////////////////////////////////
        //
        // Bedienung - Rechts
        //
        /////////////////////////////////////////////////////////// 

        libWpf.RectangleFill(25, 11, 2, 20, Brushes.LightGray);

        libWpf.Text("S1", 25, 2, 2, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("S2", 30, 2, 2, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("P1", 25, 2, 6, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.ButtonBackgroundContentMarginRounded("Start", 27, 3, 2, 3, 14, 15, Brushes.LawnGreen, buttonRand, vmLap2018.ButtonTasterCommand, "S1", nameof(vmLap2018.ClickModeS1));
        libWpf.ButtonBackgroundContentMarginRounded("Stop", 32, 3, 2, 3, 14, 15, Brushes.Red, buttonRand, vmLap2018.ButtonTasterCommand, "S2", nameof(vmLap2018.ClickModeS2));
        libWpf.ButtonBackgroundContentMarginRounded("Reset", 27, 3, 6, 3, 14, 15, Brushes.DeepPink, buttonRand, vmLap2018.ButtonTasterCommand, "S3", nameof(vmLap2018.ClickModeS3));

        libWpf.EllipseMarginStrokeSetFilling(27, 3, 10, 3, kreisRand, kreisRandFarbe, 2, nameof(vmLap2018.BrushP1));
        libWpf.Text("Störung", 27, 3, 10, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.EllipseMarginStrokeSetFilling(27, 3, 14, 3, kreisRand, kreisRandFarbe, 2, nameof(vmLap2018.BrushP2));
        libWpf.Text("Betrieb", 27, 3, 14, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.EllipseMarginStrokeSetFilling(27, 3, 18, 3, kreisRand, kreisRandFarbe, 2, nameof(vmLap2018.BrushP3));
        libWpf.Text("Füllstand", 27, 3, 18, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);

        ///////////////////////////////////////////////////////////
        //
        //  Simulation - Links
        //
        ///////////////////////////////////////////////////////////


        libWpf.ButtonContentRoundedSetBackground("F1", 3, 4, 1, 2, 14, 5, vmLap2018.ButtonSchalterCommand, "F1", nameof(vmLap2018.ClickModeF1), nameof(vmLap2018.BrushF1));
        libWpf.ButtonContentRoundedSetBackground("F2", 13, 4, 1, 2, 14, 5, vmLap2018.ButtonSchalterCommand, "F2", nameof(vmLap2018.ClickModeF2), nameof(vmLap2018.BrushF2));


        libWpf.RectangleFillMargin(1, 4, 4, 2, Brushes.Blue, new Thickness(0, 15, 0, 15));
        libWpf.RectangleMarginSetFill(5, 4, 4, 2, new Thickness(0, 15, 15, 15), nameof(vmLap2018.BrushZuleitungLinksWaagrecht));
        libWpf.RectangleMarginSetFill(8, 2, 4, 8, new Thickness(15, 15, 15, 0), nameof(vmLap2018.BrushZuleitungLinksSenkrecht));

        libWpf.ImageMarginZweiBilderRotateSetVisibility("PumpeEin.jpg", "PumpeAus.jpg", 6, 2, 4, 2, 90, new Thickness(0, 0, 0, 0), nameof(vmLap2018.VisibilityEinQ1), nameof(vmLap2018.VisibilityAusQ1));
        libWpf.Text("Q1", 3, 2, 3, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.RectangleFillMargin(15, 4, 4, 2, Brushes.Blue, new Thickness(0, 15, 0, 15));
        libWpf.RectangleMarginSetFill(10, 4, 4, 2, new Thickness(15, 15, 0, 15), nameof(vmLap2018.BrushZuleitungRechtsWaagrecht));
        libWpf.RectangleMarginSetFill(10, 2, 4, 8, new Thickness(15, 15, 15, 0), nameof(vmLap2018.BrushZuleitungRechtsSenkrecht));

        libWpf.ImageMarginZweiBilderRotateSetVisibility("PumpeEin.jpg", "PumpeAus.jpg", 14, 2, 6, 2, 270, new Thickness(0, 0, 0, 0), nameof(vmLap2018.VisibilityEinQ2), nameof(vmLap2018.VisibilityAusQ2));
        libWpf.Text("Q2", 13, 2, 3, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);


        libWpf.RectangleFill(6, 8, 7, 12, Brushes.LightBlue);
        libWpf.RectangleFillSetMargin(6, 8, 7, 12, Brushes.Blue, nameof(vmLap2018.ThicknessFuellstand));

        libWpf.TextSetContent(6, 8, 12, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 25, Brushes.GreenYellow, nameof(vmLap2018.StringFuellstand));

        libWpf.RectangleMarginSetFill(9, 2, 19, 2, new Thickness(15, 0, 15, 0), nameof(vmLap2018.BrushZuleitungRechtsWaagrecht));
        libWpf.RectangleMarginSetFill(9, 2, 22, 3, new Thickness(15, 0, 15, 0), nameof(vmLap2018.BrushZuleitungRechtsSenkrecht));
        libWpf.Text("Y1", 7, 2, 21, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonMarginSetVisibilityZweiBilder(8, 3, 21, 2, "VentilElektrischEin.jpg", "VentilElektrischAus.jpg", new Thickness(0, 0, 5, 0), vmLap2018.ButtonSchalterCommand, "Y1", nameof(vmLap2018.ClickModeY1), nameof(vmLap2018.VisibilityEinY1), nameof(vmLap2018.VisibilityAusY1));


        libWpf.ImageMarginZweiBilderSetVisibility("Schwimmerschalter.jpg", "SchwimmerschalterBetaetigt.jpg", 15, 3, 7, 2, new Thickness(0, 0, 25, 0), nameof(vmLap2018.VisibilityEinB3), nameof(vmLap2018.VisibilityAusB3));
        libWpf.Text("B3", 14, 2, 7, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.ImageMarginZweiBilderSetVisibility("Schwimmerschalter.jpg", "SchwimmerschalterBetaetigt.jpg", 15, 3, 14, 2, new Thickness(0, 0, 25, 0), nameof(vmLap2018.VisibilityEinB2), nameof(vmLap2018.VisibilityAusB2));
        libWpf.Text("B2", 14, 2, 14, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.ImageMarginZweiBilderSetVisibility("Schwimmerschalter.jpg", "SchwimmerschalterBetaetigt.jpg", 15, 3, 17, 2, new Thickness(0, 0, 25, 0), nameof(vmLap2018.VisibilityEinB1), nameof(vmLap2018.VisibilityAusB1));
        libWpf.Text("B1", 14, 2, 17, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);


        libWpf.PlcError();
    }
}