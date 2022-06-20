using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DtParkhaus.ViewModel;

namespace DtParkhaus.TabZeichnen;

public partial class TabZeichnen
{
    public static void TabSimulationZeichnen(VmParkhaus vmParkhaus, TabItem tabItem, string hintergrund)
    {
        var libWpf = new LibWpf.LibWpf(tabItem);
        libWpf.SetBackground(new BrushConverter().ConvertFromString(hintergrund) as SolidColorBrush);
        libWpf.GridZeichnen(50, 40, false, false, false);


        ///////////////////////////////////////////////////////////
        //
        // Bedienung - Rechts
        //
        /////////////////////////////////////////////////////////// 

        libWpf.RectangleFill(28, 10, 1, 28, Brushes.LightGray);

        var buttonRand = new Thickness(0, 0, 0, 0);


        libWpf.Text("Freie Parkplätze:", 29, 10, 2, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.TextSetContent(35, 10, 2, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black, nameof(vmParkhaus.StringFreieParkplaetze));
        libWpf.TextSetContent(35, 10, 3, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black, nameof(vmParkhaus.StringFreieParkplaetzeSoll));

        libWpf.ButtonBackgroundContentMarginRounded("Zufall", 29, 6, 6, 3, 20, 15, Brushes.LawnGreen, buttonRand, vmParkhaus.ButtonTasterCommand, "Zufall", nameof(vmParkhaus.ClickModeZufall));


        ///////////////////////////////////////////////////////////
        //
        // Simulation - Links
        //
        /////////////////////////////////////////////////////////// 

        const int breiteBox = 3;
        const int breitePkw = 3;
        const int hoeheBox = 6;
        const int hoehePkw = 4;

        var pkwFarbe = new[] { "PkwGelb.jpg", "PkwGruen.jpg" };
        var winkelPkw = new[] { 0, 180 };
        var randSensor = new Thickness[] { new(30, 15, 30, 15), new(30, 0, 30, 30) };
        var randBeschriftung = new Thickness[] { new(0, 10, 0, 10), new(0, 25, 0, 0) };
        var randPkw = new Thickness[] { new(10, 15, 10, 0), new(10, 0, 10, 15) };
        
        var yPosWaende = new[] { 1, 9, 15, 23 };
        var yPosSensor = new[] { 1, 13, 15, 27 };
        var yPosBeschriftung = new[] { 2, 13, 16, 27 };
        var yPosPkw = new[] { 3, 9, 17, 23 };

        
        libWpf.RectangleFillMargin(0, 26, 0, 2, Brushes.LightGray, new Thickness(25, 25, 25, 25));
        libWpf.RectangleFillMargin(0, 26, 14, 2, Brushes.LightGray, new Thickness(25, 25, 25, 25));
        libWpf.RectangleFillMargin(0, 26, 29, 1, Brushes.LightGray, new Thickness(25, 0, 25, 20));

        for (var reihe = 0; reihe < 4; reihe++)
        {
            for (var spalte = 0; spalte < 9; spalte++)
            {
                libWpf.RectangleFillMargin(spalte * breiteBox, 2, yPosWaende[reihe], hoeheBox, Brushes.LightGray, new Thickness(25, 0, 25, 0));
            }

            for (var spalte = 0; spalte < 8; spalte++)
            {
                libWpf.EllipseMarginStrokeSetFilling(1 + spalte * breiteBox, breiteBox, yPosSensor[reihe], 2, randSensor[reihe % 2], Brushes.Black, 2, $"BrushB{reihe}{spalte}");
                libWpf.TextMargin($"B{reihe}{spalte}", 1 + spalte * breiteBox, breiteBox, yPosBeschriftung[reihe], 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black, randBeschriftung[reihe % 2]);

                libWpf.ButtonImageMarginRotateSetVisibility(1 + spalte * breiteBox, breitePkw, yPosPkw[reihe], hoehePkw, pkwFarbe[spalte % 2], randPkw[reihe % 2], winkelPkw[reihe % 2], vmParkhaus.ButtonTasterCommand, $"{reihe}{spalte}", $"ClickModePkw{reihe}{spalte}", $"VisibilityPkw{reihe}{spalte}");
            }
        }

        libWpf.PlcError();
    }
}