using System.Windows.Controls;
using System.Windows.Media;
using DtLeitungszuordnungsTester.ViewModel;

namespace DtLeitungszuordnungsTester.TabZeichnen;

public partial class TabZeichnen
{
    public static void TabSimulationZeichnen(VmLeitungszuordnungsTester vmLeitungszuordnungsTester, TabItem tabItem, string hintergrund)
    {
        _ = vmLeitungszuordnungsTester;
        var libWpf = new LibWpf.LibWpf(tabItem);
        libWpf.SetBackground(new BrushConverter().ConvertFromString(hintergrund) as SolidColorBrush);
        libWpf.GridZeichnen(50, 30, 40, 30, false);
        
        libWpf.PlcError();
    }
}