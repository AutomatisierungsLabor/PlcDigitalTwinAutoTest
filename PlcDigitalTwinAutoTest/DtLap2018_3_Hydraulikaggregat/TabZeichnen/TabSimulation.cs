using System.Windows;
using DtLap2018_3_Hydraulikaggregat.ViewModel;
using System.Windows.Controls;
using System.Windows.Media;

namespace DtLap2018_3_Hydraulikaggregat.TabZeichnen;

public partial class TabZeichnen
{
    public static void TabSimulationZeichnen(VmLap2018 vmLap2018, TabItem tabItem, string hintergrund)
    {
        _ = vmLap2018;
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

        libWpf.RectangleFill(35, 11, 1, 15, Brushes.LightGray);

        libWpf.Text("S1", 35, 2, 1, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("S2", 40, 2, 1, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("S3", 35, 2, 4, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.ButtonBackgroundContentMarginRounded("Start", 37, 3, 1, 3, 20, 15, Brushes.LawnGreen, buttonRand, vmLap2018.ButtonTasterCommand, "S1", nameof(vmLap2018.ClickModeS1));
        libWpf.ButtonBackgroundContentMarginRounded("Stop", 42, 3, 1, 3, 20, 15, Brushes.Red, buttonRand, vmLap2018.ButtonTasterCommand, "S2", nameof(vmLap2018.ClickModeS2));
        libWpf.ButtonBackgroundContentMarginRounded("Quittieren", 37, 3, 4, 3, 18, 15, Brushes.DeepPink, buttonRand, vmLap2018.ButtonTasterCommand, "S3", nameof(vmLap2018.ClickModeS3));



        libWpf.Text("P1", 35, 2, 7, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.EllipseMarginStrokeBindingFilling(37, 3, 7, 3, kreisRand, kreisRandFarbe, 2, nameof(vmLap2018.BrushP1));
        libWpf.TextMargin("Betriebs", 37, 3, 7, 3, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black, new Thickness(0, 10, 0, 30));
        libWpf.TextMargin("bereit", 37, 3, 7, 3, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black, new Thickness(0, 30, 0, 10));

        libWpf.Text("P2", 40, 2, 7, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.EllipseMarginStrokeBindingFilling(42, 3, 7, 3, kreisRand, kreisRandFarbe, 2, nameof(vmLap2018.BrushP2));
        libWpf.TextMargin("Sammel", 42, 3, 7, 3, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black, new Thickness(0, 10, 0, 30));
        libWpf.TextMargin("störung", 42, 3, 7, 3, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black, new Thickness(0, 30, 0, 10));

        libWpf.Text("P3", 35, 2, 10, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.EllipseMarginStrokeBindingFilling(37, 3, 10, 3, kreisRand, kreisRandFarbe, 2, nameof(vmLap2018.BrushP1));
        libWpf.TextMargin("Motor", 37, 3, 10, 3, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black, new Thickness(0, 10, 0, 30));
        libWpf.TextMargin("störung", 37, 3, 10, 3, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black, new Thickness(0, 30, 0, 10));

        libWpf.Text("P4", 40, 2, 10, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.EllipseMarginStrokeBindingFilling(42, 3, 10, 3, kreisRand, kreisRandFarbe, 2, nameof(vmLap2018.BrushP2));
        libWpf.Text("Überdruck", 42, 3, 10, 3, HorizontalAlignment.Center, VerticalAlignment.Center, 17, Brushes.Black);

        libWpf.Text("P5", 35, 2, 13, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.EllipseMarginStrokeBindingFilling(37, 3, 13, 3, kreisRand, kreisRandFarbe, 2, nameof(vmLap2018.BrushP2));
        libWpf.Text("Öldruck", 37, 3, 13, 3, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.Text("P6", 40, 2, 13, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.EllipseMarginStrokeBindingFilling(42, 3, 13, 3, kreisRand, kreisRandFarbe, 2, nameof(vmLap2018.BrushP2));
        libWpf.Text("Ölstand", 42, 3, 13, 3, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);


        ///////////////////////////////////////////////////////////
        // Erweiterung Ölkühler
        /////////////////////////////////////////////////////////// 

        libWpf.RectangleFill(35, 11, 17, 6, Brushes.LightGray);

        libWpf.ButtonBackgroundContentMarginRounded("B4", 37, 3, 18, 3, 18, 15, Brushes.DeepPink, buttonRand, vmLap2018.ButtonSchalterCommand, "B4", nameof(vmLap2018.ClickModeB4));

        libWpf.Text("P7", 40, 2, 18, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.EllipseMarginStrokeBindingFilling(42, 3, 18, 3, kreisRand, kreisRandFarbe, 2, nameof(vmLap2018.BrushP7));
        libWpf.Text("Lüfter", 42, 3, 18, 3, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.Text("Q4", 40, 2, 21, 2, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.RectangleMarginStrokeBindingFill(42, 3, 21, 2, kreisRand, kreisRandFarbe, 2, nameof(vmLap2018.BrushQ4));
        libWpf.Text("Lüfter", 42, 3, 21, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.RectangleFillBindingVisibility(35, 11, 17, 6, Brushes.LightGray, nameof(vmLap2018.VisibilityErweiterungOelkuehler));
        libWpf.CheckBox(35, 1, 17, 1, new Thickness(0, 0, 0, 0), HorizontalAlignment.Center, VerticalAlignment.Center, vmLap2018.ButtonSchalterCommand, "ErweiterungOelKuehler");
        libWpf.Text("Erweiterung Ölkühler", 36, 10, 17, 1, HorizontalAlignment.Left, VerticalAlignment.Center, 16, Brushes.Black);

        ///////////////////////////////////////////////////////////
        // Erweiterung Zylinder
        /////////////////////////////////////////////////////////// 

        libWpf.RectangleFill(35, 11, 24, 5, Brushes.LightGray);

        libWpf.ButtonBackgroundContentMarginRounded("S4", 37, 3, 25, 3, 18, 15, Brushes.DeepPink, buttonRand, vmLap2018.ButtonTasterCommand, "S4", nameof(vmLap2018.ClickModeS4));

        libWpf.Text("K1", 40, 2, 25, 2, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.RectangleMarginStrokeBindingFill(42, 3, 25, 2, kreisRand, kreisRandFarbe, 2, nameof(vmLap2018.BrushK1));
        libWpf.Text("Ausfahren", 42, 3, 25, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 18, Brushes.Black);

        libWpf.Text("K2", 40, 2, 27, 2, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.RectangleMarginStrokeBindingFill(42, 3, 27, 2, kreisRand, kreisRandFarbe, 2, nameof(vmLap2018.BrushK2));
        libWpf.Text("Einfahren", 42, 3, 27, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 18, Brushes.Black);

        libWpf.RectangleFillBindingVisibility(35, 11, 24, 5, Brushes.LightGray, nameof(vmLap2018.VisibilityErweiterungZylinder));
        libWpf.CheckBox(35, 1, 24, 1, new Thickness(0, 0, 0, 0), HorizontalAlignment.Center, VerticalAlignment.Center, vmLap2018.ButtonSchalterCommand, "ErweiterungZylinder");
        libWpf.Text("Erweiterung Zylinder", 36, 10, 24, 1, HorizontalAlignment.Left, VerticalAlignment.Center, 16, Brushes.Black);

        ///////////////////////////////////////////////////////////
        // Erweiterung Ölfilter
        /////////////////////////////////////////////////////////// 

        libWpf.RectangleFill(35, 11, 30, 4, Brushes.LightGray);

        libWpf.ButtonBackgroundContentMarginRounded("B5", 37, 3, 31, 3, 18, 15, Brushes.DeepPink, buttonRand, vmLap2018.ButtonSchalterCommand, "B5", nameof(vmLap2018.ClickModeB5));

        libWpf.Text("P8", 40, 2, 31, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.EllipseMarginStrokeBindingFilling(42, 3, 31, 3, kreisRand, kreisRandFarbe, 2, nameof(vmLap2018.BrushP8));
        libWpf.Text("Lüfter", 42, 3, 31, 3, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.RectangleFillBindingVisibility(35, 11, 30, 4, Brushes.LightGray, nameof(vmLap2018.VisibilityErweiterungOelfilter));
        libWpf.CheckBox(35, 1, 30, 1, new Thickness(0, 0, 0, 0), HorizontalAlignment.Center, VerticalAlignment.Center, vmLap2018.ButtonSchalterCommand, "ErweiterungOelFilter");
        libWpf.Text("Erweiterung Ölfilter", 36, 10, 30, 1, HorizontalAlignment.Left, VerticalAlignment.Center, 16, Brushes.Black);



        ///////////////////////////////////////////////////////////
        //
        // Simulation - Links
        //
        /////////////////////////////////////////////////////////// 

        // Behälter links
        libWpf.RectangleFillRundungStroke(1, 12, 10, 20, 10, 10, null, new Rect(20, 1, 300, 598), Brushes.Black, 2);
        libWpf.Polygon(11, 10, 25, 5, Brushes.LightBlue, Brushes.Black, 2, new[] { new double[] { 210, 0 }, new double[] { 270, 0 }, new double[] { 270, 130 }, new double[] { 20, 130 }, new double[] { 20, 70 }, new double[] { 210, 70 } });
        libWpf.RectangleFillRundungStroke(1, 12, 27, 3, 10, 10, Brushes.LightBlue, new Rect(20, 1, 300, 88), Brushes.Black, 2);
        libWpf.RectangleFillMargin(10, 2, 27, 3, Brushes.LightBlue, new Thickness(0, 10, 9, 20));
        libWpf.RectangleFillBindingMargin(1, 12, 10, 20, Brushes.LightBlue, nameof(vmLap2018.ThicknessFuellstand));
        libWpf.TextBindingContent(1, 12, 20, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 30, Brushes.GreenYellow, nameof(vmLap2018.StringFuellstand));
        libWpf.ButtonBackgroundContentMarginRounded("Nachfüllen!", 5, 4, 22, 2, 20, 15, Brushes.Sienna, buttonRand, vmLap2018.ButtonTasterCommand, "Nachfuellen", nameof(vmLap2018.ClickModeNachfuellen));

        //Behälter rechts
        libWpf.RectangleFillRundungStroke(15, 8, 1, 24, 10, 10, Brushes.LightBlue, new Rect(20, 0, 200, 420), Brushes.Black, 2);
        libWpf.RectangleFillMarginStroke(18, 2, 14, 10, Brushes.LightBlue, new Thickness(0, 0, 0, 0), Brushes.Black, 2);
        libWpf.RectangleFillMargin(17, 4, 13, 2, Brushes.LightBlue, new Thickness(0, 0, 0, 2));

        // Pumpe
        libWpf.EllipseFillMarginStroke(17, 4, 22, 4, Brushes.DeepPink, new Thickness(0, 0, 0, 0), Brushes.Black, 2);
        libWpf.Polygon(17, 4, 22, 4, Brushes.LightBlue, Brushes.Black, 2, new[] { new double[] { 60, 2 }, new double[] { 80, 30 }, new double[] { 40, 30 } });







        libWpf.ButtonContentRoundedSetBackground("Überdruck", 25, 4, 19, 2, 14, 5, vmLap2018.ButtonSchalterCommand, "B3", nameof(vmLap2018.ClickModeB3), nameof(vmLap2018.BrushB3));



        libWpf.RectangleStrokeBindingFill(25, 4, 23, 1, Brushes.Black, 2, nameof(vmLap2018.BrushQ1));
        libWpf.RectangleStrokeBindingFill(25, 2, 24, 1, Brushes.Black, 2, nameof(vmLap2018.BrushQ2));
        libWpf.RectangleStrokeBindingFill(27, 2, 24, 1, Brushes.Black, 2, nameof(vmLap2018.BrushQ3));
        libWpf.Text("Q1 (Netz)", 25, 4, 23, 1, HorizontalAlignment.Center, VerticalAlignment.Center, 15, Brushes.Black);
        libWpf.Text("Q2 ( Y )", 25, 2, 24, 1, HorizontalAlignment.Center, VerticalAlignment.Center, 15, Brushes.Black);
        libWpf.Text("Q3 ( △ )", 27, 2, 24, 1, HorizontalAlignment.Center, VerticalAlignment.Center, 15, Brushes.Black);


        libWpf.ButtonContentRoundedSetBackground("F1", 25, 4, 26, 2, 14, 5, vmLap2018.ButtonSchalterCommand, "F1", nameof(vmLap2018.ClickModeF1), nameof(vmLap2018.BrushF1));

        libWpf.TextContendBindingVisibility("Kurzschluss!", 31, 4, 22, 4, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black, nameof(vmLap2018.VisibilityEinKurzschluss));
        libWpf.EllipseFillBindingVisibility(31, 4, 22, 4, Brushes.Red, nameof(vmLap2018.VisibilityEinKurzschluss));


        libWpf.ImageMarginZweiBilderBindingVisibility("Schwimmerschalter.jpg", "SchwimmerschalterBetaetigt.jpg", 13, 3, 22, 2, new Thickness(0, 0, 25, 0), nameof(vmLap2018.VisibilityEinB1), nameof(vmLap2018.VisibilityAusB1));
        libWpf.Text("B1", 12, 2, 22, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.ImageMarginZweiBilderBindingVisibility("Schwimmerschalter.jpg", "SchwimmerschalterBetaetigt.jpg", 21, 3, 16, 2, new Thickness(0, 0, 25, 0), nameof(vmLap2018.VisibilityEinB2), nameof(vmLap2018.VisibilityAusB2));
        libWpf.Text("B2", 20, 2, 16, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.ImageMarginZweiBilderBindingVisibility("Schwimmerschalter.jpg", "SchwimmerschalterBetaetigt.jpg", 21, 3, 19, 2, new Thickness(0, 0, 25, 0), nameof(vmLap2018.VisibilityEinB3), nameof(vmLap2018.VisibilityAusB3));
        libWpf.Text("B3", 20, 2, 19, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);







        libWpf.PointerGaugeBindingValue(23, 10, 1, 10, "Druck", 0, 10, 165, 188, "DoubleAktuellerDruck");



        //libWpf.PlcError();
    }
}