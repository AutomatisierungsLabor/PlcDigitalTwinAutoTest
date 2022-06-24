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

        libWpf.SiebenSegmentAnzeige(2, 5, 5, 10, nameof(vmVoltmeter.ShortAnzeige));

    }
}