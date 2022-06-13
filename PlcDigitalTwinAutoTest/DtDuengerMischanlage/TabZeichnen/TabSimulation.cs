using System.Windows.Controls;
using System.Windows.Media;
using DtDuengerMischanlage.ViewModel;

namespace DtDuengerMischanlage.TabZeichnen;

public partial class TabZeichnen
{
    public static void TabSimulationZeichnen(VmMischanlage vmMischanlage, TabItem tabItem, string hintergrund)
    {
        var libWpf = new LibWpf.LibWpf(tabItem);
        libWpf.SetBackground(new BrushConverter().ConvertFromString(hintergrund) as SolidColorBrush);
        libWpf.GridZeichnen(50, 40, false, false, false);


        libWpf.PlcError();
    }
}