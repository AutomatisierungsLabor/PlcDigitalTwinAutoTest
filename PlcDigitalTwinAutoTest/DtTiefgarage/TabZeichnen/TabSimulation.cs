using System.Windows.Controls;
using System.Windows.Media;
using DtTiefgarage.ViewModel;

namespace DtTiefgarage.TabZeichnen;

public partial class TabZeichnen
{
    public static void TabSimulationZeichnen(VmTiefgarage vmTiefgarage, TabItem tabItem, string hintergrund)
    {
        var libWpf = new LibWpf.LibWpf(tabItem);
        libWpf.SetBackground(new BrushConverter().ConvertFromString(hintergrund) as SolidColorBrush);
        libWpf.GridZeichnen(50, 30, 40, 30, false, false, false);



        libWpf.PlcError();
    }
}