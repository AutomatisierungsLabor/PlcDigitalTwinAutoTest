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
        libWpf.GridZeichnen(50, 40, false, false, false);

        var buttonRand = new Thickness(2, 5, 2, 5);
        var kreisRand = new Thickness(2, 2, 2, 2);
        var kreisRandFarbe = new SolidColorBrush(Colors.Black);

        ///////////////////////////////////////////////////////////
        //
        // Bedienung - Rechts
        //
        /////////////////////////////////////////////////////////// 

        libWpf.RectangleFill(24, 11, 1, 12, Brushes.LightGray);

        libWpf.Text("S1", 23, 3, 2, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("S2", 23, 3, 5, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("S3", 28, 3, 5, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.Text("P1", 23, 3, 9, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);


        libWpf.ButtonBackgroundContentMarginRounded("Halt", 26, 3, 2, 3, 18, 15, Brushes.Red, buttonRand, vmLap2010.ButtonTasterCommand, "S1", nameof(vmLap2010.ClickModeS1));
        libWpf.ButtonBackgroundContentMarginRounded("Öffnen", 26, 3, 5, 3, 18, 15, Brushes.Green, buttonRand, vmLap2010.ButtonTasterCommand, "S2", nameof(vmLap2010.ClickModeS2));
        libWpf.ButtonBackgroundContentMarginRounded("Schliessen", 31, 3, 5, 3, 18, 15, Brushes.Green, buttonRand, vmLap2010.ButtonTasterCommand, "S3", nameof(vmLap2010.ClickModeS3));

        libWpf.EllipseMarginStrokeBindingFilling(26, 3, 9, 3, kreisRand, kreisRandFarbe, 2, nameof(vmLap2010.BrushP1));
        libWpf.Text("Schliessen", 26, 3, 9, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 18, Brushes.Black);


        ///////////////////////////////////////////////////////////
        //
        //  Simulation - Links
        //
        ///////////////////////////////////////////////////////////

        libWpf.RectangleFill(17, 6, 3, 6, Brushes.Black);
        libWpf.VideoAutoPlay("Flammen.mp4", 17, 6, 3, 6);
        
        const int abstand = 10;
        libWpf.ImageMarginBindingWinkel("Zahnrad.png", 3, 5, 10, 5, new Thickness(abstand, abstand, abstand, abstand), nameof(vmLap2010.DoubleZahnradWinkel));
        libWpf.ImageBindingMargin("Zahnstange.png", 3, 20, 8, 3, new Thickness(0, 0, 0, 0), nameof(vmLap2010.ThicknessZahnstangePosition));

        libWpf.RectangleFillStrokeBindingMargin(3, 20, 3, 6, Brushes.Gray, Brushes.Black, 2, nameof(vmLap2010.ThicknessOfentuerePosition));



        var kontakteRand = new Thickness(0, 5, 5, 5);

        libWpf.Text("B1", 8, 2, 12, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ImageMarginZweiBilderBindingVisibility("InitiatorenBetaetigt.jpg", "InitiatorenSchliesser.jpg", 10, 2, 12, 2, kontakteRand, nameof(vmLap2010.VisibilityEinB1), nameof(vmLap2010.VisibilityAusB1));

        libWpf.Text("B2", 19, 2, 12, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ImageMarginZweiBilderBindingVisibility("InitiatorenBetaetigt.jpg", "InitiatorenSchliesser.jpg", 21, 2, 12, 2, kontakteRand, nameof(vmLap2010.VisibilityEinB2), nameof(vmLap2010.VisibilityAusB2));

        libWpf.ButtonBackgroundContentMarginRounded("Lichtschranke", 13, 5, 11, 3, 20, 15, Brushes.Red, buttonRand, vmLap2010.ButtonTasterCommand, "B3", nameof(vmLap2010.ClickModeB3));
        libWpf.Text("B3", 13, 2, 14, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ImageMarginZweiBilderBindingVisibility("InitiatorenBetaetigt.jpg", "InitiatorenSchliesser.jpg", 15, 2, 14, 2, kontakteRand, nameof(vmLap2010.VisibilityEinB3), nameof(vmLap2010.VisibilityAusB3));


        libWpf.RectangleStrokeBindingFill(2, 3, 15, 2, Brushes.Black, 2, nameof(vmLap2010.BrushQ1));
        libWpf.RectangleStrokeBindingFill(5, 3, 15, 2, Brushes.Black, 2, nameof(vmLap2010.BrushQ2));
        libWpf.Text("Q1 (LL)", 2, 3, 15, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("Q2 (RL)", 5, 3, 15, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.TextContendBindingVisibility("Kurzschluß", 9, 4, 19, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black, nameof(vmLap2010.VisibilityKurzschluss));
        libWpf.EllipseFillBindingVisibility(9, 4, 18, 4, Brushes.Red, nameof(vmLap2010.VisibilityKurzschluss));

        libWpf.PlcError();
    }
}