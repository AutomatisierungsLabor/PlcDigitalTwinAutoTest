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
        libWpf.GridZeichnen(50, 30, 40, 30, false, false, true);

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
        libWpf.EllipseMarginStrokeSetFilling(37, 3, 7, 3, kreisRand, kreisRandFarbe, 2, nameof(vmLap2018.BrushP1));
        libWpf.TextMargin("Betriebs", 37, 3, 7, 3, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black, new Thickness(0, 10, 0, 30));
        libWpf.TextMargin("bereit", 37, 3, 7, 3, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black, new Thickness(0, 30, 0, 10));

        libWpf.Text("P2", 40, 2, 7, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.EllipseMarginStrokeSetFilling(42, 3, 7, 3, kreisRand, kreisRandFarbe, 2, nameof(vmLap2018.BrushP2));
        libWpf.TextMargin("Sammel", 42, 3, 7, 3, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black, new Thickness(0, 10, 0, 30));
        libWpf.TextMargin("störung", 42, 3, 7, 3, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black, new Thickness(0, 30, 0, 10));

        libWpf.Text("P3", 35, 2, 10, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.EllipseMarginStrokeSetFilling(37, 3, 10, 3, kreisRand, kreisRandFarbe, 2, nameof(vmLap2018.BrushP1));
        libWpf.TextMargin("Motor", 37, 3, 10, 3, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black, new Thickness(0, 10, 0, 30));
        libWpf.TextMargin("störung", 37, 3, 10, 3, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black, new Thickness(0, 30, 0, 10));

        libWpf.Text("P4", 40, 2, 10, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.EllipseMarginStrokeSetFilling(42, 3, 10, 3, kreisRand, kreisRandFarbe, 2, nameof(vmLap2018.BrushP2));
        libWpf.Text("Überdruck", 42, 3, 10, 3, HorizontalAlignment.Center, VerticalAlignment.Center, 17, Brushes.Black);

        libWpf.Text("P5", 35, 2, 13, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.EllipseMarginStrokeSetFilling(37, 3, 13, 3, kreisRand, kreisRandFarbe, 2, nameof(vmLap2018.BrushP2));
        libWpf.Text("Öldruck", 37, 3, 13, 3, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.Text("P6", 40, 2, 13, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.EllipseMarginStrokeSetFilling(42, 3, 13, 3, kreisRand, kreisRandFarbe, 2, nameof(vmLap2018.BrushP2));
        libWpf.Text("Ölstand", 42, 3, 13, 3, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);


        ///////////////////////////////////////////////////////////
        // Erweiterung Ölkühler
        /////////////////////////////////////////////////////////// 

        libWpf.RectangleFill(35, 11, 17, 6, Brushes.LightGray);

        libWpf.ButtonBackgroundContentMarginRounded("B4", 37, 3, 18, 3, 18, 15, Brushes.DeepPink, buttonRand, vmLap2018.ButtonSchalterCommand, "B4", nameof(vmLap2018.ClickModeB4));

        libWpf.Text("P7", 40, 2, 18, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.EllipseMarginStrokeSetFilling(42, 3, 18, 3, kreisRand, kreisRandFarbe, 2, nameof(vmLap2018.BrushP7));
        libWpf.Text("Lüfter", 42, 3, 18, 3, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.Text("Q4", 40, 2, 21, 2, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.RectangleMarginStrokeSetFill(42, 3, 21, 2, kreisRand, kreisRandFarbe, 2, nameof(vmLap2018.BrushQ4));
        libWpf.Text("Lüfter", 42, 3, 21, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.RectangleFillSetVisibility(35,11,17,6,Brushes.LightGray, nameof(vmLap2018.VisibilityErweiterungOelkuehler));
        libWpf.CheckBox(35, 1, 17, 1, new Thickness(0, 0, 0, 0), HorizontalAlignment.Center, VerticalAlignment.Center, vmLap2018.ButtonSchalterCommand, "ErweiterungOelKuehler");
        libWpf.Text("Erweiterung Ölkühler", 36, 10, 17, 1, HorizontalAlignment.Left, VerticalAlignment.Center, 16, Brushes.Black);

        ///////////////////////////////////////////////////////////
        // Erweiterung Zylinder
        /////////////////////////////////////////////////////////// 

        libWpf.RectangleFill(35, 11, 24, 5, Brushes.LightGray);

        libWpf.ButtonBackgroundContentMarginRounded("S4", 37, 3, 25, 3, 18, 15, Brushes.DeepPink, buttonRand, vmLap2018.ButtonTasterCommand, "S4", nameof(vmLap2018.ClickModeS4));

        libWpf.Text("K1", 40, 2, 25, 2, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.RectangleMarginStrokeSetFill(42, 3, 25, 2, kreisRand, kreisRandFarbe, 2, nameof(vmLap2018.BrushK1));
        libWpf.Text("Ausfahren", 42, 3, 25, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 18, Brushes.Black);

        libWpf.Text("K2", 40, 2, 27, 2, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.RectangleMarginStrokeSetFill(42, 3, 27, 2, kreisRand, kreisRandFarbe, 2, nameof(vmLap2018.BrushK2));
        libWpf.Text("Einfahren", 42, 3, 27, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 18, Brushes.Black);

        libWpf.RectangleFillSetVisibility(35, 11, 24, 5, Brushes.LightGray, nameof(vmLap2018.VisibilityErweiterungZylinder));
        libWpf.CheckBox(35, 1, 24, 1, new Thickness(0, 0, 0, 0), HorizontalAlignment.Center, VerticalAlignment.Center, vmLap2018.ButtonSchalterCommand, "ErweiterungZylinder");
        libWpf.Text("Erweiterung Zylinder", 36, 10, 24, 1, HorizontalAlignment.Left, VerticalAlignment.Center, 16, Brushes.Black);

        ///////////////////////////////////////////////////////////
        // Erweiterung Ölfilter
        /////////////////////////////////////////////////////////// 



        libWpf.RectangleFill(35, 11, 30, 4, Brushes.LightGray);

        libWpf.ButtonBackgroundContentMarginRounded("B5", 37, 3, 31, 3, 18, 15, Brushes.DeepPink, buttonRand, vmLap2018.ButtonSchalterCommand, "B5", nameof(vmLap2018.ClickModeB5));

        libWpf.Text("P8", 40, 2, 31, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.EllipseMarginStrokeSetFilling(42, 3, 31, 3, kreisRand, kreisRandFarbe, 2, nameof(vmLap2018.BrushP8));
        libWpf.Text("Lüfter", 42, 3, 31, 3, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.RectangleFillSetVisibility(35, 11, 30, 4, Brushes.LightGray, nameof(vmLap2018.VisibilityErweiterungOelfilter));
        libWpf.CheckBox(35, 1, 30, 1, new Thickness(0, 0, 0, 0), HorizontalAlignment.Center, VerticalAlignment.Center, vmLap2018.ButtonSchalterCommand, "ErweiterungOelFilter");
        libWpf.Text("Erweiterung Ölfilter", 36, 10, 30, 1, HorizontalAlignment.Left, VerticalAlignment.Center, 16, Brushes.Black);




        //libWpf.PlcError();
    }
}