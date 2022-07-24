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
        libWpf.GridZeichnen(50, 40, false, false, true);

        var buttonRand = new Thickness(2, 5, 2, 5);
        var kreisRand = new Thickness(2, 2, 2, 2);
        var kreisRandFarbe = new SolidColorBrush(Colors.Black);

        ///////////////////////////////////////////////////////////
        //
        // Bedienung - Rechts
        //
        /////////////////////////////////////////////////////////// 

        libWpf.RectangleFill(23, 11, 1, 12, Brushes.LightGray);

        libWpf.Text("S1", 22, 3, 2, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("S2", 27, 3, 2, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("S3", 22, 3, 5, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.Text("P1", 22, 3, 9, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);


        libWpf.ButtonBackgroundContentMarginRounded("Start", 25, 3, 2, 3, 20, 15, Brushes.Green, buttonRand, vmLap2010.ButtonTasterCommand, "S1", nameof(vmLap2010.ClickModeS1));
        libWpf.ButtonContentMarginRoundedSetBackground("Not Halt", 30, 3, 2, 3, 20, 15, buttonRand, vmLap2010.ButtonSchalterCommand, "S2", nameof(vmLap2010.ClickModeS2), nameof(vmLap2010.BrushS2));
        libWpf.ButtonBackgroundContentMarginRounded("Reset", 25, 3, 5, 3, 20, 15, Brushes.Red, buttonRand, vmLap2010.ButtonTasterCommand, "S3", nameof(vmLap2010.ClickModeS3));

        libWpf.EllipseMarginStrokeBindingFilling(25, 3, 9, 3, kreisRand, kreisRandFarbe, 2, nameof(vmLap2010.BrushP1));
        libWpf.Text("Störung", 25, 3, 9, 3, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);


        ///////////////////////////////////////////////////////////
        //
        //  Simulation - Links
        //
        ///////////////////////////////////////////////////////////


        libWpf.RectangleFillBindingVisibility(17, 2, 5, 4, Brushes.Firebrick, nameof(vmLap2010.VisibilityFuellen));
        libWpf.Polygon(16, 5, 1, 5, Brushes.DarkOrange, Brushes.Black, 2, new[] { new double[] { 2, 10 }, new double[] { 120, 10 }, new double[] { 120, 120 }, new double[] { 100, 160 }, new double[] { 22, 160 }, new double[] { 2, 120 } });

        libWpf.RectangleFillStrokeBindingMargin(1, 20, 8, 4, Brushes.Gray, Brushes.Black, 3, nameof(vmLap2010.ThicknessPositionWagenkasten));
        libWpf.EllipseFillStrokeBindingMargin(1, 20, 12, 1, Brushes.Red, Brushes.Black, 2, nameof(vmLap2010.ThicknessPositionRadLinks));
        libWpf.EllipseFillStrokeBindingMargin(1, 20, 12, 1, Brushes.Red, Brushes.Black, 2, nameof(vmLap2010.ThicknessPositionRadRechts));

        libWpf.RectangleFill(0, 22, 13, 1, Brushes.Gray);


        var kontakteRand = new Thickness(0, 5, 5, 5);

        libWpf.Text("B1", 1, 2, 15, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ImageMarginBindingVisibility("InitiatorenSchliesser.jpg", 3, 2, 15, 2, kontakteRand, nameof(vmLap2010.VisibilityAusB1));
        libWpf.ImageMarginBindingVisibility("InitiatorenBetaetigt.jpg", 3, 2, 15, 2, kontakteRand, nameof(vmLap2010.VisibilityEinB1));

        libWpf.Text("B2", 16, 2, 15, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ImageMarginBindingVisibility("InitiatorenSchliesser.jpg", 18, 2, 15, 2, kontakteRand, nameof(vmLap2010.VisibilityAusB2));
        libWpf.ImageMarginBindingVisibility("InitiatorenBetaetigt.jpg", 18, 2, 15, 2, kontakteRand, nameof(vmLap2010.VisibilityEinB2));


        libWpf.RectangleStrokeBindingFill(8, 3, 15, 2, Brushes.Black, 2, nameof(vmLap2010.BrushQ1));
        libWpf.RectangleStrokeBindingFill(11, 3, 15, 2, Brushes.Black, 2, nameof(vmLap2010.BrushQ2));
        libWpf.Text("Q1 (LL)", 8, 3, 15, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("Q2 (RL)", 11, 3, 15, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.ButtonContentRoundedSetBackground("F1", 8, 6, 18, 2, 20, 5, vmLap2010.ButtonSchalterCommand, "F1", nameof(vmLap2010.ClickModeF1), nameof(vmLap2010.BrushF1));

        libWpf.TextContendBindingVisibility("Kurzschluß", 9, 6, 12, 6, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black, nameof(vmLap2010.VisibilityKurzschluss));
        libWpf.EllipseFillBindingVisibility(9, 6, 12, 6, Brushes.Red, nameof(vmLap2010.VisibilityKurzschluss));


        // libWpf.PlcError();
    }
}