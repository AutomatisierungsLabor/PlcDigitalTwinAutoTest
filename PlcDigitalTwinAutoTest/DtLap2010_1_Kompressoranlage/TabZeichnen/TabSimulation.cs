using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DtLap2010_1_Kompressoranlage.ViewModel;

namespace DtLap2010_1_Kompressoranlage.TabZeichnen;

public partial class TabZeichnen
{
    public static void TabSimulationZeichnen(VmLap2010 vmLap2010, TabItem tabItem, string hintergrund)
    {
        var libWpf = new LibWpf.LibWpf(tabItem);
        libWpf.SetBackground(new BrushConverter().ConvertFromString(hintergrund) as SolidColorBrush);
        libWpf.GridZeichnen(50, 30, 40, 30, true);

        var buttonRand = new Thickness(2, 5, 2, 5);
        var kreisRand = new Thickness(2, 2, 2, 2);
        var kreisRandFarbe = new SolidColorBrush(Colors.Black);

        ///////////////////////////////////////////////////////////
        //
        // Bedienung - Rechts
        //
        /////////////////////////////////////////////////////////// 

        libWpf.RectangleFill(20, 11, 1, 9, Brushes.LightGray);

        libWpf.Text("S1", 19, 3, 2, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("S2", 24, 3, 2, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("P1", 19, 3, 6, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("P2", 24, 3, 6, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.ButtonBackgroundContentMarginRounded("Aus", 22, 3, 2, 3, 20, 15, Brushes.Red, buttonRand, vmLap2010.ButtonTasterCommand, "S1", nameof(vmLap2010.ClickModeS1));
        libWpf.ButtonBackgroundContentMarginRounded("Ein", 27, 3, 2, 3, 20, 15, Brushes.Green, buttonRand, vmLap2010.ButtonTasterCommand, "S2", nameof(vmLap2010.ClickModeS2));

        libWpf.EllipseMarginStrokeSetFilling(22, 3, 6, 3, kreisRand, kreisRandFarbe, 2, nameof(vmLap2010.BrushP1));
        libWpf.EllipseMarginStrokeSetFilling(27, 3, 6, 3, kreisRand, kreisRandFarbe, 2, nameof(vmLap2010.BrushP2));


        ///////////////////////////////////////////////////////////
        //
        //  Simulation - Links
        //
        ///////////////////////////////////////////////////////////

        libWpf.RectangleFillRundungStroke(2, 20, 1, 15, 25, 15, Brushes.LightBlue, new Rect(0, 0, 210, 300), Brushes.Black, 2);
        libWpf.RectangleFillMarginStroke(4, 3, 11, 3, Brushes.LightBlue, new Thickness(10, 0, 10, 0), Brushes.Black, 2);
        libWpf.RectangleFillMargin(4, 3, 10, 2, Brushes.LightBlue, new Thickness(12, 0, 12, 0));

        libWpf.Polygon(0, 7, 15, 6, Brushes.LightBlue, Brushes.Black, 2, new[] { new double[] { 130, 20 }, new double[] { 200, 20 }, new double[] { 200, 150 }, new double[] { 20, 150 }, new double[] { 20, 90 }, new double[] { 130, 90 } });

        libWpf.EllipseFillMarginStroke(3, 5, 12, 5, Brushes.Blue, new Thickness(10, 10, 10, 10), Brushes.Black, 2);
        libWpf.Polygon(3, 5, 13, 5, Brushes.Blue, Brushes.Black, 2, new[] { new double[] { 70, 2 }, new double[] { 90, 30 }, new double[] { 50, 30 } });


        var kontakteRand = new Thickness(0, 5, 5, 5);

        libWpf.Text("B1", 9, 2, 5, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ImageMarginSetVisibility("InitiatorenSchliesser.jpg", 11, 2, 5, 2, kontakteRand, nameof(vmLap2010.VisibilityAusB1));
        libWpf.ImageMarginSetVisibility("InitiatorenBetaetigt.jpg", 11, 2, 5, 2, kontakteRand, nameof(vmLap2010.VisibilityEinB1));


        libWpf.RectangleStrokeSetFill(10, 4, 15, 1, Brushes.Black, 2, nameof(vmLap2010.BrushQ1));
        libWpf.RectangleStrokeSetFill(10, 2, 16, 1, Brushes.Black, 2, nameof(vmLap2010.BrushQ2));
        libWpf.RectangleStrokeSetFill(12, 2, 16, 1, Brushes.Black, 2, nameof(vmLap2010.BrushQ3));
        libWpf.Text("Q1 (Netz)", 10, 4, 15, 1, HorizontalAlignment.Center, VerticalAlignment.Center, 15, Brushes.Black);
        libWpf.Text("Q2 ( Y )", 10, 2, 16, 1, HorizontalAlignment.Center, VerticalAlignment.Center, 15, Brushes.Black);
        libWpf.Text("Q3 ( △ )", 12, 2, 16, 1, HorizontalAlignment.Center, VerticalAlignment.Center, 15, Brushes.Black);


        libWpf.ButtonContentRoundedSetBackground("F1", 10, 4, 18, 2, 14, 5, vmLap2010.ButtonSchalterCommand, "F1", nameof(vmLap2010.ClickModeF1), nameof(vmLap2010.BrushF1));

        libWpf.TextContendSetVisibility("Kurzschluss!", 10, 4, 18, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black, nameof(vmLap2010.VisibilityKurzschluss));
        libWpf.EllipseFillSetVisibility(15, 4, 15, 4, Brushes.Red, nameof(vmLap2010.VisibilityKurzschluss));


        libWpf.PointerGauge(20, 10, 12, 10, "Druck", 0, 10, 165, 188, "AktuellerDruck");

        // libWpf.PlcError();
    }
}