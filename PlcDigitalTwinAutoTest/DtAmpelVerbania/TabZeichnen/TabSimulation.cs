using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DtAmpelVerbania.ViewModel;

namespace DtAmpelVerbania.TabZeichnen;

public partial class TabZeichnen
{
    public static void TabSimulationZeichnen(VmAmpelVerbania vmAmpelVarbania, TabItem tabItem, string hintergrund)
    {
        var libWpf = new LibWpf.LibWpf(tabItem);
        libWpf.SetBackground(new BrushConverter().ConvertFromString(hintergrund) as SolidColorBrush);
        libWpf.GridZeichnen(50, 40, false, false, false);


        ///////////////////////////////////////////////////////////
        //
        // Bedienung - Rechts
        //
        /////////////////////////////////////////////////////////// 

        libWpf.RectangleFill(15, 11, 1, 17, Brushes.LightGray);

        var buttonRand = new Thickness(0, 0, 0, 0);

        libWpf.ButtonBackgroundContentMarginRounded("Modus 7-Segment Anzeige", 16, 9, 3, 2, 20, 12, Brushes.Violet, buttonRand, vmAmpelVarbania.ButtonSchalterCommand, "S2", nameof(vmAmpelVarbania.ClickModeS2));
        libWpf.ButtonBackgroundContentMarginRounded("Bitte drücken!", 16, 9, 14, 3, 30, 12, Brushes.LawnGreen, buttonRand, vmAmpelVarbania.ButtonTasterCommand, "S1", nameof(vmAmpelVarbania.ClickModeS1));



        ///////////////////////////////////////////////////////////
        //
        //  Simulation - Links
        //
        ///////////////////////////////////////////////////////////

        libWpf.Text("Autoampel", 0, 7, 1, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 26, Brushes.Black);

        libWpf.RectangleFillMarginStroke(1, 5, 5, 13, Brushes.LightGray, new Thickness(20, 20, 20, 20), Brushes.Black, 4);
        libWpf.EllipseStrokeBindingFilling(2, 3, 6, 3, Brushes.Black, 2, nameof(vmAmpelVarbania.BrushP11));
        libWpf.EllipseStrokeBindingFilling(2, 3, 10, 3, Brushes.Black, 2, nameof(vmAmpelVarbania.BrushP12));
        libWpf.EllipseStrokeBindingFilling(2, 3, 14, 3, Brushes.Black, 2, nameof(vmAmpelVarbania.BrushP13));


        libWpf.Text("Fußgängerampel", 6, 7, 1, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 26, Brushes.Black);

        libWpf.RectangleMarginStrokeBindingFill(7, 5, 3, 2, new Thickness(20, 0, 20, 0), Brushes.Black, 4, nameof(vmAmpelVarbania.BrushAnzeige));
        libWpf.TextMarginBindingContentVisibility(8, 3, 3, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 50, Brushes.Black, new Thickness(0, -10, 0, 0), nameof(vmAmpelVarbania.StringAnzeige), nameof(vmAmpelVarbania.VisibilityAnzeige));

        libWpf.SiebenSegmentAnzeigeBackgroundBindingColorValueVisibility(8, 3, 3, 2, new Thickness(24, 4, 25, 4), Brushes.DarkGray, nameof(vmAmpelVarbania.BrushAnzeige), nameof(vmAmpelVarbania.ShortSiebenSegmentAnzeige), nameof(vmAmpelVarbania.VisibilitySiebenSegmentAnzeige));

        libWpf.RectangleFillMarginStroke(7, 5, 5, 13, Brushes.LightGray, new Thickness(20, 20, 20, 20), Brushes.Black, 4);
        libWpf.EllipseStrokeBindingFilling(8, 3, 6, 3, Brushes.Black, 2, nameof(vmAmpelVarbania.BrushP21));
        libWpf.EllipseStrokeBindingFilling(8, 3, 10, 3, Brushes.Black, 2, nameof(vmAmpelVarbania.BrushP22));
        libWpf.EllipseStrokeBindingFilling(8, 3, 14, 3, Brushes.Black, 2, nameof(vmAmpelVarbania.BrushP23));

        libWpf.PlcError();
    }
}