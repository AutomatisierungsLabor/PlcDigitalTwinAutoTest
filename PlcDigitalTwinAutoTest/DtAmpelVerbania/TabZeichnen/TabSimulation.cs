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
        libWpf.GridZeichnen(50, 40, false, false, true);


        ///////////////////////////////////////////////////////////
        //
        // Bedienung - Rechts
        //
        /////////////////////////////////////////////////////////// 

        libWpf.RectangleFill(19, 12, 1, 30, Brushes.LightGray);

        var buttonRand = new Thickness(0, 0, 0, 0);
        
        libWpf.ButtonBackgroundContentMarginRounded("Bitte drücken!", 20, 5, 2, 2, 20, 12, Brushes.LawnGreen, buttonRand, vmAmpelVarbania.ButtonTasterCommand, "S1", nameof(vmAmpelVarbania.ClickModeS1));

        libWpf.ButtonBackgroundContentMarginRounded("Modus 7-Segment Anzeige", 20, 5, 8, 2, 20, 12, Brushes.Violet, buttonRand, vmAmpelVarbania.ButtonSchalterCommand, "S2", nameof(vmAmpelVarbania.ClickModeS2));


        ///////////////////////////////////////////////////////////
        //
        //  Simulation - Links
        //
        ///////////////////////////////////////////////////////////

        libWpf.Text("Autoampel", 0, 7, 2, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.RectangleFillMarginStroke(1, 5, 6, 13, Brushes.LightGray, new Thickness(20, 20, 20, 20), Brushes.Black, 4);
        libWpf.EllipseStrokeBindingFilling(2, 3, 7, 3, Brushes.Black, 2, nameof(vmAmpelVarbania.BrushP11));
        libWpf.EllipseStrokeBindingFilling(2, 3, 11, 3, Brushes.Black, 2, nameof(vmAmpelVarbania.BrushP12));
        libWpf.EllipseStrokeBindingFilling(2, 3, 15, 3, Brushes.Black, 2, nameof(vmAmpelVarbania.BrushP13));

        
        libWpf.Text("Fußgängerampel", 10, 7, 2, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.RectangleMarginStrokeBindingFill(11, 5, 4, 2, new Thickness(20, 0, 20, 0), Brushes.Black, 4, nameof(vmAmpelVarbania.BrushAnzeige));
        libWpf.TextMarginBindingContent(12, 3, 4, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 50, Brushes.Black, new Thickness(0, -10, 0, 0), nameof(vmAmpelVarbania.StringAnzeige));

        libWpf.RectangleFillMarginStroke(11, 5, 6, 13, Brushes.LightGray, new Thickness(20, 20, 20, 20), Brushes.Black, 4);
        libWpf.EllipseStrokeBindingFilling(12, 3, 7, 3, Brushes.Black, 2, nameof(vmAmpelVarbania.BrushP21));
        libWpf.EllipseStrokeBindingFilling(12, 3, 11, 3, Brushes.Black, 2, nameof(vmAmpelVarbania.BrushP22));
        libWpf.EllipseStrokeBindingFilling(12, 3, 15, 3, Brushes.Black, 2, nameof(vmAmpelVarbania.BrushP23));
        
        libWpf.PlcError();
    }
}