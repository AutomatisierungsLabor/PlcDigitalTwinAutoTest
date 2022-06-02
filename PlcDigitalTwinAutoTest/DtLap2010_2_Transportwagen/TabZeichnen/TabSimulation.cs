using DtLap2010_2_Transportwagen.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DtLap2010_2_Transportwagen.TabZeichnen;

public partial class TabZeichnen
{
    public static void TabSimulationZeichnen(VmLap2010 vmLap2010, TabItem tabItem, string hintergrund)
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

        libWpf.RectangleFill(25, 11, 1, 15, Brushes.LightGray);

        libWpf.Text("S1", 24, 3, 2, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("S2", 29, 3, 2, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("S3", 24, 3, 5, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.Text("P1", 24, 3, 8, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);


        libWpf.ButtonBackgroundContentMarginRounded("Start", 27, 3, 2, 3, 14, 15, Brushes.Green, buttonRand, vmLap2010.ButtonTasterCommand, "S1", nameof(vmLap2010.ClickModeS1));
        libWpf.ButtonBackgroundContentMarginRounded("Not Halt", 32, 3, 2, 3, 14, 15, Brushes.Red, buttonRand, vmLap2010.ButtonSchalterCommand, "S2", nameof(vmLap2010.ClickModeS2));
        libWpf.ButtonBackgroundContentMarginRounded("Reset", 27, 3, 5, 3, 14, 15, Brushes.Red, buttonRand, vmLap2010.ButtonTasterCommand, "S3", nameof(vmLap2010.ClickModeS3));

        libWpf.EllipseMarginStrokeSetFilling(27, 3, 8, 3, kreisRand, kreisRandFarbe, 2, nameof(vmLap2010.BrushP1));
        libWpf.Text("Störung", 27, 3, 8, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 16, Brushes.Black);

        libWpf.ButtonContentRoundedSetBackground("Störung", 27, 3, 12, 3, 14, 15, vmLap2010.ButtonSchalterCommand, "F1", nameof(vmLap2010.ClickModeF1), nameof(vmLap2010.BrushF1));

        ///////////////////////////////////////////////////////////
        //
        //  Simulation - Links
        //
        ///////////////////////////////////////////////////////////


        libWpf.RectangleFillSetVisibility(8, 2, 2, 4, Brushes.Firebrick, nameof(vmLap2010.VisibilityFuellen));
        libWpf.Polygon(14, 5, 1, 5, Brushes.DarkOrange, Brushes.Black, 2, new[] { new double[] { 20, 10 }, new double[] { 120, 10 }, new double[] { 120, 120 }, new double[] { 100, 160 }, new double[] { 40, 160 }, new double[] { 20, 120 } });

        libWpf.RectangleFillStrokeSetMargin(1, 20, 8, 4, Brushes.Gray, Brushes.Black, 3, nameof(vmLap2010.PositionWagenkasten));
        libWpf.EllipseFillStrokeSetMargin(1, 20, 12, 1, Brushes.Red, Brushes.Black, 2, nameof(vmLap2010.PositionRadLinks));
        libWpf.EllipseFillStrokeSetMargin(1, 20, 12, 1, Brushes.Red, Brushes.Black, 2, nameof(vmLap2010.PositionRadRechts));

        libWpf.RectangleFill(1, 20, 13, 1, Brushes.Gray);


        var kontakteRand = new Thickness(0, 5, 5, 5);

        libWpf.Text("B1", 1, 2, 15, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ImageMarginSetVisibility("InitiatorenSchliesser.jpg", 3, 2, 15, 2, kontakteRand, nameof(vmLap2010.VisibilityAusB1));
        libWpf.ImageMarginSetVisibility("InitiatorenBetaetigt.jpg", 3, 2, 15, 2, kontakteRand, nameof(vmLap2010.VisibilityEinB1));

        libWpf.Text("B2", 16, 2, 15, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ImageMarginSetVisibility("InitiatorenSchliesser.jpg", 18, 2, 15, 2, kontakteRand, nameof(vmLap2010.VisibilityAusB2));
        libWpf.ImageMarginSetVisibility("InitiatorenBetaetigt.jpg", 18, 2, 15, 2, kontakteRand, nameof(vmLap2010.VisibilityEinB2));


        libWpf.RectangleStrokeSetFill(9, 2, 15, 2, Brushes.Black, 2, nameof(vmLap2010.BrushQ1));
        libWpf.RectangleStrokeSetFill(11, 2, 15, 2, Brushes.Black, 2, nameof(vmLap2010.BrushQ2));
        libWpf.Text("Q1 (LL)", 9, 2, 15, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 16, Brushes.Black);
        libWpf.Text("Q2 (RL)", 11, 2, 15, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 16, Brushes.Black);


        libWpf.TextContendSetVisibility("Kurzschluß", 9, 4, 19, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black, nameof(vmLap2010.VisibilityKurzschluss));
        libWpf.EllipseFillSetVisibility(9, 4, 18, 4, Brushes.Red, nameof(vmLap2010.VisibilityKurzschluss));


        // libWpf.PlcError();
    }
}