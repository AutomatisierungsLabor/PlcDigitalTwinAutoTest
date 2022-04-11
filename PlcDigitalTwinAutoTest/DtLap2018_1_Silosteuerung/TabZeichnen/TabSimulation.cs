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
        libWpf.ButtonBackgroundMarginRoundedSetContend(2, 6, 2, 2, 20, 5, Brushes.BlueViolet, new Thickness(0, 0, 0, 0), vmLap2018.ButtonSchalterCommand, "RutscheVoll", nameof(vmLap2018.ClickRutscheVoll), nameof(vmLap2018.StringRutscheVoll));

        libWpf.EllipseMarginStrokeSetFilling(4, 2, 9, 2, new Thickness(4, 4, 4, 4), Brushes.Black, 2, nameof(vmLap2018.BrushQ2));
        libWpf.Text("Q2", 4, 2, 9, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.ButtonRoundedSetBackground(6, 3, 10, 2, 20, 5, vmLap2018.ButtonSchalterCommand, "F2", nameof(vmLap2018.ClickModeF2), nameof(vmLap2018.BrushF2));



        // Materialsilo mit Ventil, ...

        libWpf.RectangleFill(15, 8, 5, 8, Brushes.LightGray);
        libWpf.RectangleFillSetMargin(15, 8, 5, 8, Brushes.Firebrick, nameof(vmLap2018.MarginSilo));
        libWpf.Text("Materialsilo", 15, 8, 5, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.TextSetContent(15, 8, 10, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black, nameof(vmLap2018.StringMaterialSiloFuellstand));

        libWpf.Text("Y1", 16, 2, 14, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ImageMarginZweiBilderSetVisibility("VentilElektrischEin.jpg", "VentilElektrischAus.jpg", 17, 3, 14, 2, new Thickness(0, 0, 5, 0), nameof(vmLap2018.VisibilityEinY1), nameof(vmLap2018.VisibilityAusY1));
        libWpf.RectangleMarginSetFill(15, 8, 13, 1, new Thickness(110, 0, 110, 0), nameof(vmLap2018.BrushMaterialOben));
        libWpf.RectangleMarginSetFill(15, 8, 16, 2, new Thickness(110, 0, 110, 0), nameof(vmLap2018.BrushMaterialUnten));

        // Förderband
        libWpf.RectangleFillMargin(10, 10, 18, 1, Brushes.Gray, new Thickness(0, 0, 0, 20));
        libWpf.RectangleFillMargin(10, 10, 19, 1, Brushes.Gray, new Thickness(0, 20, 0, 0));
        libWpf.EllipseFillMarginStroke(9, 2, 18, 2, Brushes.Gray, new Thickness(0, 0, 0, 0), Brushes.Gray, 2);
        libWpf.EllipseMarginStrokeSetFilling(19, 2, 18, 2, new Thickness(0, 0, 0, 0), Brushes.Gray, 2, nameof(vmLap2018.BrushQ1));
        libWpf.Text("Q1", 19, 2, 18, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.ButtonContentMarginRoundedSetBackground("F1", 19, 3, 20, 2, 20, 5, new Thickness(5, 5, 5, 5), vmLap2018.ButtonSchalterCommand, "F1", nameof(vmLap2018.ClickModeF1), nameof(vmLap2018.BrushF1));

        // Wagen mit Endschaltern

        libWpf.PolygonSetMargin(1, 20, 21, 10, Brushes.White, Brushes.Black, 2, new[] {
                new double[] {5,5}, new double[] {10,5}, new double[] {10,100}, new double[] {270,100}, new double[] {270,5}, new double[] {275,5},
                new double[] {275,140}, new double[] {260,140}, new double[] {260,110}, new double[] {20,110}, new double[] {20,140}, new double[] {5,140} },
            nameof(vmLap2018.MarginPositionWagen));

        libWpf.RectangleFillSetMargin(1, 20, 21, 10, Brushes.Firebrick, nameof(vmLap2018.MarginPostionWagenInhalt));

        libWpf.Text("B1", 17, 2, 28, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ImageMarginZweiBilderSetVisibility("InitiatorenSchliesser.jpg", "InitiatorenBetaetigt.jpg", 19, 2, 28, 2, new Thickness(0, 0, 0, 0), nameof(vmLap2018.VisibilityEinB1), nameof(vmLap2018.VisibilityEinB1));

        libWpf.Text("B2", 10, 2, 28, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ImageMarginZweiBilderSetVisibility("InitiatorenSchliesser.jpg", "InitiatorenBetaetigt.jpg", 12, 2, 28, 2, new Thickness(0, 0, 0, 0), nameof(vmLap2018.VisibilityEinB2), nameof(vmLap2018.VisibilityEinB2));

        libWpf.ButtonBackgroundContentRounded("Nach links", 2, 4, 30, 2, 20, 5, Brushes.LawnGreen, vmLap2018.ButtonTasterCommand, "WagenNachLinks", nameof(vmLap2018.ClickModeWagenNachLinks));
        libWpf.ButtonBackgroundContentRounded("Nach rechts", 12, 4, 30, 2, 20, 5, Brushes.LawnGreen, vmLap2018.ButtonTasterCommand, "WagenNachRechts", nameof(vmLap2018.ClickModeWagenNachRechts));

        ///////////////////////////////////////////////////////////
        //
        // Bedienung - Rechts
        //
        /////////////////////////////////////////////////////////// 

        var buttonRand = new Thickness(2, 5, 2, 5);
        var kreisRand = new Thickness(2, 2, 2, 2);

        libWpf.RectangleFill(25, 11, 1, 12, Brushes.LightGray);

        libWpf.Text("P1", 24, 3, 2, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("P2", 29, 3, 2, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.EllipseMarginStrokeSetFilling(27, 3, 2, 3, kreisRand, Brushes.Black, 2, nameof(vmLap2018.BrushP1));
        libWpf.EllipseMarginStrokeSetFilling(32, 3, 2, 3, kreisRand, Brushes.Black, 2, nameof(vmLap2018.BrushP2));


        libWpf.Text("S0", 24, 3, 6, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("S1", 29, 3, 6, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonBackgroundContentMarginRounded("Aus", 27, 3, 6, 3, 20, 15, Brushes.Red, buttonRand, vmLap2018.ButtonTasterCommand, "S0", nameof(vmLap2018.ClickModeS0));
        libWpf.ButtonBackgroundContentMarginRounded("Ein", 32, 3, 6, 3, 20, 15, Brushes.Green, buttonRand, vmLap2018.ButtonTasterCommand, "S1", nameof(vmLap2018.ClickModeS1));


        libWpf.Text("S2", 24, 3, 10, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("S3", 29, 3, 10, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonMarginSetVisibilityZweiBilder(27, 3, 10, 3, "NotHalt.jpg", "NotHaltGedrueckt.jpg", buttonRand, vmLap2018.ButtonSchalterCommand, "S2", nameof(vmLap2018.ClickModeS2), nameof(vmLap2018.VisibilityEinS1), nameof(vmLap2018.VisibilityAusS1));
        libWpf.ButtonBackgroundContentMarginRounded("Reset", 32, 3, 10, 3, 20, 15, Brushes.Green, buttonRand, vmLap2018.ButtonTasterCommand, "S3", nameof(vmLap2018.ClickModeS3));








    }
}