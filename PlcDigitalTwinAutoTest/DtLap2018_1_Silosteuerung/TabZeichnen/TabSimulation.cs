using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DtLap2018_1_Silosteuerung.ViewModel;

namespace DtLap2018_1_Silosteuerung.TabZeichnen;

public partial class TabZeichnen
{
    public static void TabSimulationZeichnen(VmLap2018 vmLap2018, TabItem tabItem, string hintergrund)
    {
        var libWpf = new LibWpf.LibWpf(tabItem);
        libWpf.SetBackground(new BrushConverter().ConvertFromString(hintergrund) as SolidColorBrush);
        libWpf.GridZeichnen(50, 30, 40, 30, true);

        ///////////////////////////////////////////////////////////
        //
        //  Simulation - Links
        //
        ///////////////////////////////////////////////////////////

        // Silo mit Schnecke, ....

        libWpf.BildAnimiert("Schneckenfoerderer.gif", 6, 14, 0, 13, new Thickness(0, -20, 0, 0), vmLap2018.AnimatedLoaded);

        libWpf.Polygon(1, 10, 1, 10, Brushes.White, Brushes.Black, 2, new[] { new double[] { 10, 10 }, new double[] { 240, 10 }, new double[] { 240, 100 }, new double[] { 150, 200 }, new double[] { 150, 300 }, new double[] { 10, 300 } });
        libWpf.RipButtonBackgroundContentRounded(2, 6, 2, 2, 20, 5, new Thickness(0, 0, 0, 0), vmLap2018.BtnSchalter, WpfObjects.RutscheVoll);

        libWpf.RipKreisStrokeMarginSetFilling(4, 2, 9, 2, Brushes.Gray, new Thickness(4, 4, 4, 4), WpfObjects.Q2);
        libWpf.Text("Q2", 4, 2, 9, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.RipButtonBackgroundContentRounded(6, 3, 10, 2, 20, 5, new Thickness(5, 5, 5, 5), vmLap2018.BtnSchalter, WpfObjects.F2);



        // Materialsilo mit Ventil, ...

        libWpf.RectangleFill(15, 8, 5, 8, Brushes.LightGray);
        libWpf.RipRechteckFillStrokeSetMargin(15, 8, 5, 8, Brushes.Firebrick, Brushes.Firebrick, 0, WpfObjects.MaterialSilo);
        libWpf.Text("Materialsilo", 15, 8, 5, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.TextSetContendSetVisibility(15, 8, 10, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black, WpfObjects.MaterialSiloFuellstand);

        libWpf.Text("Y1", 16, 2, 14, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.BildSetVisibilityEinAus("VentilElektrischEin.jpg", "VentilElektrischAus.jpg", 17, 3, 14, 2, new Thickness(0, 0, 5, 0), WpfObjects.Y1);
        libWpf.RipRechteckMarginSetFill(15, 8, 13, 1, new Thickness(110, 0, 110, 0), WpfObjects.MaterialOben);
        libWpf.RipRechteckMarginSetFill(15, 8, 16, 2, new Thickness(110, 0, 110, 0), WpfObjects.MaterialUnten);

        // Förderband
        libWpf.RipRechteckFillMargin(10, 10, 18, 1, Brushes.Gray, new Thickness(0, 0, 0, 20));
        libWpf.RipRechteckFillMargin(10, 10, 19, 1, Brushes.Gray, new Thickness(0, 20, 0, 0));
        libWpf.RipKreisFillStrokeMargin(9, 2, 18, 2, Brushes.Gray, Brushes.Gray, 0, new Thickness(0, 0, 0, 0));
        libWpf.RipKreisStrokeMarginSetFilling(19, 2, 18, 2, Brushes.Gray, new Thickness(0, 0, 0, 0), WpfObjects.Q1);
        libWpf.Text("Q1", 19, 2, 18, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.RipButtonBackgroundContentRounded(19, 3, 20, 2, 20, 5, new Thickness(5, 5, 5, 5), vmLap2018.BtnSchalter, WpfObjects.F1);

        // Wagen mit Endschaltern

        libWpf.PolygonSetMargin(1, 20, 21, 10, Brushes.White, Brushes.Black, 2, new[] {
                new double[] {5,5}, new double[] {10,5}, new double[] {10,100}, new double[] {270,100}, new double[] {270,5}, new double[] {275,5},
                new double[] {275,140}, new double[] {260,140}, new double[] {260,110}, new double[] {20,110}, new double[] {20,140}, new double[] {5,140} },
            WpfObjects.PositionWagen);

        libWpf.RipRechteckFillStrokeSetMargin(1, 20, 21, 10, Brushes.Firebrick, Brushes.Firebrick, 0, WpfObjects.PostionWagenInhalt);

        libWpf.Text("B1", 17, 2, 28, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.BildSetVisibilityEinAus("InitiatorenSchliesser.jpg", "InitiatorenBetaetigt.jpg", 19, 2, 28, 2, new Thickness(0, 0, 0, 0), WpfObjects.B1);

        libWpf.Text("B2", 10, 2, 28, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.BildSetVisibilityEinAus("InitiatorenSchliesser.jpg", "InitiatorenBetaetigt.jpg", 12, 2, 28, 2, new Thickness(0, 0, 0, 0), WpfObjects.B2);

        libWpf.ButtonBackgroundContentRounded("Nach links", 2, 4, 30, 2, 20, 5, Brushes.LawnGreen, vmLap2018.ButtonTasterCommand, "WagenNachLinks", nameof(vmLap2018.ClickModeWagenNachLinks));
        libWpf.ButtonBackgroundContentRounded("Nach rechts", 12, 4, 30, 2, 20, 5, Brushes.LawnGreen, vmLap2018.BtnTaster, "WagenNachRechts", nameof(vmLap2018.ClickModeWagenNachRechts));

        ///////////////////////////////////////////////////////////
        //
        // Bedienung - Rechts
        //
        /////////////////////////////////////////////////////////// 

        var buttonRand = new Thickness(2, 5, 2, 5);
        var kreisRand = new Thickness(2, 2, 2, 2);
        var kreisRandFarbe = new SolidColorBrush(Colors.Black);

        libWpf.RipRechteckFill(25, 11, 1, 12, Brushes.LightGray);

        libWpf.Text("P1", 24, 3, 2, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("P2", 29, 3, 2, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.RipKreisStrokeMarginSetFilling(27, 3, 2, 3, kreisRandFarbe, kreisRand, WpfObjects.P1);
        libWpf.RipKreisStrokeMarginSetFilling(32, 3, 2, 3, kreisRandFarbe, kreisRand, WpfObjects.P2);


        libWpf.Text("S0", 24, 3, 6, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("S1", 29, 3, 6, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonBackgroundContentMarginRounded("Aus", 27, 3, 6, 3, 20, 15, buttonRand, Brushes.Red, vmLap2018.ButtonTasterCommand, "S0", nameof(vmLap2018.ClickModeS0));
        libWpf.ButtonBackgroundContentMarginRounded("Ein", 32, 3, 6, 3, 20, 15, buttonRand, Brushes.Green, vmLap2018.ButtonTasterCommand, "S1", nameof(vmLap2018.ClickModeS1));


        libWpf.Text("S2", 24, 3, 10, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("S3", 29, 3, 10, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.RipButtonZweiBilder(27, 3, 10, 3, "NotHalt.jpg", "NotHaltGedrueckt.jpg", buttonRand, vmLap2018.ButtonTasterCommand, "S2", nameof(vmLap2018.ClickModeS2));
        libWpf.ButtonBackgroundContentMarginRounded("Reset,"32, 3, 10, 3, 20, 15, buttonRand, Brushes.Green, vmLap2018.ButtonTasterCommand, "S3", nameof(vmLap2018.ClickModeS3));








    }
}