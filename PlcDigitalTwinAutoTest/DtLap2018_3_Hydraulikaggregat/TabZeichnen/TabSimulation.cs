using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DtLap2018_3_Hydraulikaggregat.ViewModel;

namespace DtLap2018_3_Hydraulikaggregat.TabZeichnen;

public partial class TabZeichnen
{
    public static void TabSimulationZeichnen(VmLap2018 vmLap2018, TabItem tabItem, string hintergrund)
    {
        var libWpf = new LibWpf.LibWpf(tabItem);
        libWpf.SetBackground(new BrushConverter().ConvertFromString(hintergrund) as SolidColorBrush);
        libWpf.GridZeichnen(50, 30, 40, 30, true);

      




        //libWpf.PlcError();
    }
}