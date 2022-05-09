using DtLap2010_3_Ofentuersteuerung.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DtLap2010_3_Ofentuersteuerung.TabZeichnen;

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

        libWpf.RectangleFill(20, 10, 2, 10, Brushes.LightGray);

        libWpf.Text("S1", 19, 3, 2, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("S2", 19, 3, 5, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("S3", 24, 3, 5, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.Text("P1", 19, 3, 8, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);


        libWpf.ButtonBackgroundContentMarginRounded("Halt", 22, 3, 2, 3, 14, 15, Brushes.Red, buttonRand, vmLap2010.ButtonTasterCommand, "S1", nameof(vmLap2010.ClickModeS1));
        libWpf.ButtonBackgroundContentMarginRounded("Öffnen", 22, 3, 5, 3, 14, 15, Brushes.Green, buttonRand, vmLap2010.ButtonTasterCommand, "S2", nameof(vmLap2010.ClickModeS2));
        libWpf.ButtonBackgroundContentMarginRounded("Schliessen", 27, 3, 5, 3, 14, 15, Brushes.Green, buttonRand, vmLap2010.ButtonTasterCommand, "S3", nameof(vmLap2010.ClickModeS3));

        libWpf.EllipseMarginStrokeSetFilling(22, 3, 8, 3, kreisRand, kreisRandFarbe, 2, nameof(vmLap2010.BrushP1));
        libWpf.Text("Schliessen", 22, 3, 8, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 16, Brushes.Black);


        ///////////////////////////////////////////////////////////
        //
        //  Simulation - Links
        //
        ///////////////////////////////////////////////////////////

        libWpf.VideoAutoPlay("Flammen.mp4", 7, 3, 5, 3);

        libWpf.ImageMarginSetDrehen("Zahnrad.png", 2, 3, 10, 3, new Thickness(0, 0, 0, 0), nameof(vmLap2010.ZahnradWinkel));
        libWpf.ImageSetMargin("Zahnstange.png", 2, 20, 8, 3, new Thickness(0, 0, 0, 0), nameof(vmLap2010.ZahnstangePosition));

        libWpf.RectangleFillStrokeSetMargin(2, 4, 5, 4, Brushes.Gray, Brushes.Black, 2, nameof(vmLap2010.OfentuerePosition));

        libWpf.ButtonBackgroundContentMarginRounded("Lichtschranke", 22, 3, 2, 3, 14, 15, Brushes.Red, buttonRand, vmLap2010.ButtonTasterCommand, "B2", nameof(vmLap2010.ClickModeB2));

        var kontakteRand = new Thickness(0, 5, 5, 5);

        libWpf.Text("B1", 8, 2, 15, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ImageMarginSetVisibility("InitiatorenSchliesser.jpg", 11, 2, 15, 2, kontakteRand, nameof(vmLap2010.VisibilityAusB1));
        libWpf.ImageMarginSetVisibility("InitiatorenBetaetigt.jpg", 11, 2, 15, 2, kontakteRand, nameof(vmLap2010.VisibilityEinB1));

        libWpf.Text("B2", 12, 2, 15, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ImageMarginSetVisibility("InitiatorenSchliesser.jpg", 15, 2, 15, 2, kontakteRand, nameof(vmLap2010.VisibilityAusB2));
        libWpf.ImageMarginSetVisibility("InitiatorenBetaetigt.jpg", 15, 2, 15, 2, kontakteRand, nameof(vmLap2010.VisibilityEinB2));

        libWpf.Text("B3", 16, 2, 15, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ImageMarginSetVisibility("InitiatorenSchliesser.jpg", 19, 2, 15, 2, kontakteRand, nameof(vmLap2010.VisibilityAusB3));
        libWpf.ImageMarginSetVisibility("InitiatorenBetaetigt.jpg", 19, 2, 15, 2, kontakteRand, nameof(vmLap2010.VisibilityEinB3));


        libWpf.RectangleStrokeSetFill(2, 2, 15, 2, Brushes.Black, 2, nameof(vmLap2010.BrushQ1));
        libWpf.RectangleStrokeSetFill(4, 2, 15, 2, Brushes.Black, 2, nameof(vmLap2010.BrushQ2));
        libWpf.Text("Q1 (LL)", 2, 2, 15, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 16, Brushes.Black);
        libWpf.Text("Q2 (RL)", 4, 2, 15, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 16, Brushes.Black);

        libWpf.TextContendSetVisibility("Kurzschluß", 9, 4, 19, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black, nameof(vmLap2010.VisibilityKurzschluss));
        libWpf.EllipseFillSetVisibility(9, 4, 18, 4, Brushes.Red, nameof(vmLap2010.VisibilityKurzschluss));

        // libWpf.PlcError();
    }
}