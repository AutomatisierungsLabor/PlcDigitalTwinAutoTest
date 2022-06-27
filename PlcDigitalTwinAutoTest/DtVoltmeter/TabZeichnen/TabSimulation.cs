using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DtVoltmeter.ViewModel;

namespace DtVoltmeter.TabZeichnen;

public partial class TabZeichnen
{
    public static void TabSimulationZeichnen(VmVoltmeter vmVoltmeter, TabItem tabItem, string hintergrund)
    {
        var libWpf = new LibWpf.LibWpf(tabItem);
        libWpf.SetBackground(new BrushConverter().ConvertFromString(hintergrund) as SolidColorBrush);
        libWpf.GridZeichnen(50, 40, false, false, true);




        ///////////////////////////////////////////////////////////
        //
        // Bedienung - Rechts
        //
        ///////////////////////////////////////////////////////////

        libWpf.RectangleFill(18, 20, 1, 6, Brushes.LightGray);

        libWpf.Text("Analogsignal AI 0", 19, 18, 1, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.SliderMarginBindingValue(19, 18, 3, 1, Brushes.DarkGray, new Thickness(0, 0, 0, 0), 0, 32512, nameof(vmVoltmeter.DoubleAnalogsignal));

        libWpf.TextBindingContent(19,4,5,2,HorizontalAlignment.Left,  VerticalAlignment.Center, 20, Brushes.Black, nameof(vmVoltmeter.StringAnalogsignal));
        libWpf.TextBindingContent(28, 4, 5, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black, nameof(vmVoltmeter.StringAnalogInVolt));

        ///////////////////////////////////////////////////////////
        //
        //  Simulation - Links
        //
        ///////////////////////////////////////////////////////////

        libWpf.SiebenSegmentAnzeigeBindingBackgroundValue(1, 4, 1, 6,  Brushes.DodgerBlue,nameof(vmVoltmeter.BrushHintergrundFarbe), nameof(vmVoltmeter.ShortTausenderStelle));
        libWpf.SiebenSegmentAnzeigeBindingBackgroundValue(5, 4, 1, 6,  Brushes.DodgerBlue, nameof(vmVoltmeter.BrushHintergrundFarbe), nameof(vmVoltmeter.ShortHunderterStelle));
        libWpf.SiebenSegmentAnzeigeBindingBackgroundValue(9, 4, 1, 6,  Brushes.DodgerBlue, nameof(vmVoltmeter.BrushHintergrundFarbe), nameof(vmVoltmeter.ShortZehnerStelle));
        libWpf.SiebenSegmentAnzeigeBindingBackgroundValue(13, 4, 1, 6,  Brushes.DodgerBlue, nameof(vmVoltmeter.BrushHintergrundFarbe), nameof(vmVoltmeter.ShortEinerStelle));
    }
}