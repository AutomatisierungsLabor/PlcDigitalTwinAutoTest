using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DtLap2010_5_Pumpensteuerung.ViewModel;

namespace DtLap2010_5_Pumpensteuerung.TabZeichnen;

public partial class TabZeichnen
{
    public static void TabSimulationZeichnen(VmLap2010 vmLap2010, TabItem tabItem, string hintergrund)
    {
        var libWpf = new LibWpf.LibWpf(tabItem);
        libWpf.SetBackground(new BrushConverter().ConvertFromString(hintergrund) as SolidColorBrush);
        libWpf.GridZeichnen(50, 30, 40, 30, true);


        ///////////////////////////////////////////////////////////
        //
        // Bedienung - Rechts
        //
        /////////////////////////////////////////////////////////// 

        libWpf.RectangleFill(19, 12, 1, 30, Brushes.LightGray);

        var buttonRand = new Thickness(0, 0, 0, 0);
        libWpf.ButtonBackgroundContentMarginRounded("Hand", 20, 3, 2, 2, 14, 0, Brushes.LawnGreen, buttonRand, vmLap2010.ButtonTasterCommand, "Hand", nameof(vmLap2010.ClickModeHand));
        libWpf.ButtonBackgroundContentMarginRounded("Aus", 23, 3, 2, 2, 14, 0, Brushes.Gray, buttonRand, vmLap2010.ButtonTasterCommand, "Aus", nameof(vmLap2010.ClickModeAus));
        libWpf.ButtonBackgroundContentMarginRounded("Automatik", 26, 3, 2, 2, 14, 0, Brushes.Green, buttonRand, vmLap2010.ButtonTasterCommand, "Automatik", nameof(vmLap2010.ClickModeAutomatik));

        libWpf.RectangleFill(20, 9, 5, 9, Brushes.Gray);
        libWpf.EllipseFill(23, 3, 8, 3, Brushes.DarkGray);

        libWpf.Text("0", 20, 9, 5, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 30, Brushes.Black);
        libWpf.Text("Hand", 20, 9, 7, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 30, Brushes.Black);
        libWpf.Text("Auto ", 20, 9, 7, 2, HorizontalAlignment.Right, VerticalAlignment.Center, 30, Brushes.Black);

        libWpf.PolygonSetWinkel(21, 7, 6, 7, Brushes.Black, Brushes.Black, 0, new[] { new double[] { 105, 30 }, new double[] { 120, 60 }, new double[] { 120, 160 }, new double[] { 90, 160 }, new double[] { 90, 60 } }, nameof(vmLap2010.WinkelSchalter));


        libWpf.Text("S3", 20, 2, 15, 2, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonBackgroundContentMarginRounded("Reset", 22, 3, 15, 2, 14, 15, Brushes.Red, buttonRand, vmLap2010.ButtonTasterCommand, "S3", nameof(vmLap2010.ClickModeS3));

        libWpf.Text("P1", 20, 2, 20, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("P2", 25, 2, 20, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.EllipseStrokeSetFilling(22, 3, 20, 3, Brushes.Black, 2, nameof(vmLap2010.BrushP1));
        libWpf.EllipseStrokeSetFilling(27, 3, 20, 3, Brushes.Black, 2, nameof(vmLap2010.BrushP2));
        libWpf.Text("Pumpe", 22, 3, 20, 3, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("Störung", 27, 3, 20, 3, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);

        ///////////////////////////////////////////////////////////
        //
        //  Simulation - Links
        //
        ///////////////////////////////////////////////////////////


        libWpf.ButtonContentRoundedSetBackground("F1", 5, 3, 1, 2, 14, 5, vmLap2010.ButtonSchalterCommand, "F1", nameof(vmLap2010.ClickModeF1), nameof(vmLap2010.BrushF1));

        libWpf.RectangleFillMargin(1, 4, 4, 2, Brushes.Blue, new Thickness(0, 20, 0, 20));
        libWpf.RectangleMarginSetFill(5, 4, 4, 2, new Thickness(0, 20, 10, 20), nameof(vmLap2010.BrushZuleitungWaagrecht));
        libWpf.RectangleMarginSetFill(8, 2, 4, 10, new Thickness(20, 20, 20, 0), nameof(vmLap2010.BrushZuleitungSenkrecht));

        libWpf.RectangleFill(6, 6, 6, 10, Brushes.LightBlue);
        libWpf.RectangleFillSetMargin(6, 6, 6, 10, Brushes.Blue, nameof(vmLap2010.MarginPegel));

        var pumpeRand = new Thickness(0, 0, 0, 0);
        libWpf.Text("Q1", 2, 2, 3, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ImageMarginSetVisibility("PumpeWaagrechtAus.jpg", 4, 2, 4, 2, pumpeRand, nameof(vmLap2010.VisibilityAusQ1));
        libWpf.ImageMarginSetVisibility("PumpeWaagrechtEin.jpg", 4, 2, 4, 2, pumpeRand, nameof(vmLap2010.VisibilityEinQ1));


        libWpf.RectangleMarginSetFill(8, 2, 16, 3, new Thickness(20, 0, 20, 0), nameof(vmLap2010.BrushAbleitungOben));
        libWpf.RectangleMarginSetFill(8, 2, 19, 3, new Thickness(20, 0, 20, 0), nameof(vmLap2010.BrushAbleitungUnten));

        libWpf.Text("Y1", 5, 2, 18, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonMarginSetVisibilityZweiBilder(7, 3, 18, 2, "VentilElektrischEin.jpg", "VentilElektrischAus.jpg", new Thickness(7, 0, 7, 0), vmLap2010.ButtonSchalterCommand, "Y1", nameof(vmLap2010.ClickModeY1), nameof(vmLap2010.VisibilityEinY1), nameof(vmLap2010.VisibilityAusY1));


        var kontakteRand = new Thickness(20, 5, 0, 5);

        libWpf.Text("B1", 12, 2, 7, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ImageMarginSetVisibility("Schwimmerschalter.jpg", 13, 2, 7, 2, kontakteRand, nameof(vmLap2010.VisibilityAusB1));
        libWpf.ImageMarginSetVisibility("SchwimmerschalterBetaetigt.jpg", 13, 2, 7, 2, kontakteRand, nameof(vmLap2010.VisibilityEinB1));


        libWpf.Text("B2", 12, 2, 14, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ImageMarginSetVisibility("Schwimmerschalter.jpg", 13, 2, 14, 2, kontakteRand, nameof(vmLap2010.VisibilityAusB2));
        libWpf.ImageMarginSetVisibility("SchwimmerschalterBetaetigt.jpg", 13, 2, 14, 2, kontakteRand, nameof(vmLap2010.VisibilityEinB2));



        // libWpf.PlcError();
    }
}