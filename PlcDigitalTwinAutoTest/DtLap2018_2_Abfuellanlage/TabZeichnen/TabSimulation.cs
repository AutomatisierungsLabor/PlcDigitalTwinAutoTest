using DtLap2018_2_Abfuellanlage.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DtLap2018_2_Abfuellanlage.TabZeichnen;

public partial class TabZeichnen
{
    public static void TabSimulationZeichnen(VmLap2018 vmLap2018, TabItem tabItem, string hintergrund)
    {
        var libWpf = new LibWpf.LibWpf(tabItem);
        libWpf.SetBackground(new BrushConverter().ConvertFromString(hintergrund) as SolidColorBrush);
        libWpf.GridZeichnen(50, 30, 40, 30, false, false, true);


        var buttonRand = new Thickness(2, 5, 2, 5);
        var kreisRand = new Thickness(2, 2, 2, 2);
        var kreisRandFarbe = new SolidColorBrush(Colors.Black);

        ///////////////////////////////////////////////////////////
        //
        // Bedienung - Rechts
        //
        /////////////////////////////////////////////////////////// 

        libWpf.RectangleFill(25, 11, 1, 19, Brushes.LightGray);

        libWpf.Text("S1", 24, 3, 2, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("S2", 29, 3, 2, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("S3", 24, 3, 6, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("S4", 29, 3, 6, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.Text("F1", 24, 3, 10, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.Text("P1", 24, 3, 16, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("P2", 29, 3, 16, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);


        libWpf.ButtonBackgroundContentMarginRounded("Start", 27, 3, 2, 3, 20, 15, Brushes.Red, buttonRand, vmLap2018.ButtonTasterCommand, "S1", nameof(vmLap2018.ClickModeS1));
        libWpf.ButtonBackgroundContentMarginRounded("Stop", 32, 3, 2, 3, 20, 15, Brushes.Green, buttonRand, vmLap2018.ButtonTasterCommand, "S2", nameof(vmLap2018.ClickModeS2));
        libWpf.ButtonBackgroundContentMarginRounded("Vereinzeln", 27, 3, 6, 3, 16, 15, Brushes.LawnGreen, buttonRand, vmLap2018.ButtonTasterCommand, "S3", nameof(vmLap2018.ClickModeS3));
        libWpf.ButtonBackgroundContentMarginRounded("Quittieren", 32, 3, 6, 3, 16, 15, Brushes.MediumPurple, buttonRand, vmLap2018.ButtonTasterCommand, "S4", nameof(vmLap2018.ClickModeS4));

        libWpf.ButtonContentMarginRoundedSetBackground("Motorschutz", 27, 3, 10, 3, 14, 15, buttonRand, vmLap2018.ButtonSchalterCommand, "F1", nameof(vmLap2018.ClickModeF1), nameof(vmLap2018.BrushF1));


        libWpf.EllipseMarginStrokeSetFilling(27, 3, 16, 3, kreisRand, kreisRandFarbe, 2, nameof(vmLap2018.BrushP1));
        libWpf.EllipseMarginStrokeSetFilling(32, 3, 16, 3, kreisRand, kreisRandFarbe, 2, nameof(vmLap2018.BrushP2));

        libWpf.Text("Betrieb", 27, 3, 16, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("Störung", 32, 3, 16, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);



        ///////////////////////////////////////////////////////////
        //
        //  Simulation - Links
        //
        ///////////////////////////////////////////////////////////

        libWpf.ButtonBackgroundContentMarginRounded("RESET", 1, 3, 1, 3, 20, 15, Brushes.LightSkyBlue, buttonRand, vmLap2018.ButtonTasterCommand, "S1", nameof(vmLap2018.ClickModeAllesReset));
        libWpf.ButtonBackgroundContentMarginRounded("Nachfüllen", 19, 3, 1, 3, 16, 15, Brushes.LightSkyBlue, buttonRand, vmLap2018.ButtonTasterCommand, "S1", nameof(vmLap2018.ClickModeTankNachfuellen));
        libWpf.RectangleFillMargin(4, 1, 1, 16, Brushes.Gray, new Thickness(10, 0, 6, 0));
        libWpf.RectangleFillMargin(5, 1, 1, 16, Brushes.Gray, new Thickness(17, 0, 0, 0));

        libWpf.ImageMarginZweiBilderSetVisibility("VentilElektrischEin.jpg", "VentilElektrischAus.jpg", 7, 2, 15, 2, new Thickness(0, 0, 0, 0), nameof(vmLap2018.VisibilityEinK2), nameof(vmLap2018.VisibilityAusK2));
        libWpf.Text("K2", 6, 2, 15, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.RectangleFill(10, 8, 1, 10, Brushes.LightBlue);
        libWpf.RectangleFillStrokeSetMargin(10, 8, 1, 10, Brushes.Blue, Brushes.Blue, 0, nameof(vmLap2018.MarginPegel));

        libWpf.Text("K1", 11, 2, 13, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ImageMarginZweiBilderSetVisibility("VentilElektrischEin.jpg", "VentilElektrischAus.jpg", 12, 3, 13, 2, new Thickness(0, 0, 8, 0), nameof(vmLap2018.VisibilityEinK2), nameof(vmLap2018.VisibilityAusK2));
        libWpf.RectangleMarginSetFill(13, 2, 11, 2, new Thickness(25, 0, 25, 0), nameof(vmLap2018.BrushZuleitung));
        libWpf.RectangleMarginSetFill(13, 2, 15, 5, new Thickness(25, 0, 25, 0), nameof(vmLap2018.BrushAbleitung));

        libWpf.RectangleFillMargin(4, 14, 20, 1, Brushes.Gray, new Thickness(15, 0, 15, 20));
        libWpf.RectangleFillMargin(4, 14, 22, 1, Brushes.Gray, new Thickness(15, 20, 15, 0));
        libWpf.EllipseFillMarginStroke(3, 3, 20, 3, Brushes.Gray, new Thickness(0, 0, 0, 0), Brushes.Gray, 0);
        libWpf.EllipseFillMarginStroke(16, 3, 20, 3, Brushes.Gray, new Thickness(0, 0, 0, 0), Brushes.Gray, 0);
        libWpf.EllipseMarginStrokeSetFilling(3, 3, 20, 3, new Thickness(5, 5, 5, 5), Brushes.Gray, 2, nameof(vmLap2018.BrushQ1));
        libWpf.Text("Q1", 3, 3, 20, 3, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.Text("B1", 11, 2, 24, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ImageMarginZweiBilderSetVisibility("InitiatorenSchliesser.jpg", "InitiatorenBetaetigt.jpg", 13, 2, 24, 2, new Thickness(0, 0, 0, 0), nameof(vmLap2018.VisibilityEinB1), nameof(vmLap2018.VisibilityAusB1));


        libWpf.ImageSetMarginSetVisibility("Franziskaner.jpg", 1, 20, 1, 20, nameof(vmLap2018.MarginFlasche1), nameof(vmLap2018.VisibilityFlasche1));
        libWpf.ImageSetMarginSetVisibility("Kellerbier.jpg", 1, 20, 1, 20, nameof(vmLap2018.MarginFlasche2), nameof(vmLap2018.VisibilityFlasche2));
        libWpf.ImageSetMarginSetVisibility("OberLänder.jpg", 1, 20, 1, 20, nameof(vmLap2018.MarginFlasche3), nameof(vmLap2018.VisibilityFlasche3));
        libWpf.ImageSetMarginSetVisibility("Franziskaner.jpg", 1, 20, 1, 20, nameof(vmLap2018.MarginFlasche4), nameof(vmLap2018.VisibilityFlasche4));
        libWpf.ImageSetMarginSetVisibility("Kellerbier.jpg", 1, 20, 1, 20, nameof(vmLap2018.MarginFlasche5), nameof(vmLap2018.VisibilityFlasche5));
        libWpf.ImageSetMarginSetVisibility("OberLänder.jpg", 1, 20, 1, 20, nameof(vmLap2018.MarginFlasche6), nameof(vmLap2018.VisibilityFlasche6));

        libWpf.ImageSetVisibility("Fohrenburger0.jpg", 18, 6, 24, 6, nameof(vmLap2018.VisibilityFohrenburger0));
        libWpf.ImageSetVisibility("Fohrenburger1.jpg", 18, 6, 24, 6, nameof(vmLap2018.VisibilityFohrenburger1));
        libWpf.ImageSetVisibility("Fohrenburger2.jpg", 18, 6, 24, 6, nameof(vmLap2018.VisibilityFohrenburger2));
        libWpf.ImageSetVisibility("Fohrenburger3.jpg", 18, 6, 24, 6, nameof(vmLap2018.VisibilityFohrenburger3));
        libWpf.ImageSetVisibility("Fohrenburger4.jpg", 18, 6, 24, 6, nameof(vmLap2018.VisibilityFohrenburger4));
        libWpf.ImageSetVisibility("Fohrenburger5.jpg", 18, 6, 24, 6, nameof(vmLap2018.VisibilityFohrenburger5));
        libWpf.ImageSetVisibility("Fohrenburger6.jpg", 18, 6, 24, 6, nameof(vmLap2018.VisibilityFohrenburger6));

        libWpf.ImageSetVisibility("Mohren0.jpg", 18, 6, 24, 6, nameof(vmLap2018.VisibilityMohren0));
        libWpf.ImageSetVisibility("Mohren1.jpg", 18, 6, 24, 6, nameof(vmLap2018.VisibilityMohren1));
        libWpf.ImageSetVisibility("Mohren2.jpg", 18, 6, 24, 6, nameof(vmLap2018.VisibilityMohren2));
        libWpf.ImageSetVisibility("Mohren3.jpg", 18, 6, 24, 6, nameof(vmLap2018.VisibilityMohren3));
        libWpf.ImageSetVisibility("Mohren4.jpg", 18, 6, 24, 6, nameof(vmLap2018.VisibilityMohren4));
        libWpf.ImageSetVisibility("Mohren5.jpg", 18, 6, 24, 6, nameof(vmLap2018.VisibilityMohren5));
        libWpf.ImageSetVisibility("Mohren6.jpg", 18, 6, 24, 6, nameof(vmLap2018.VisibilityMohren6));


        // libWpf.PlcError();
    }
}