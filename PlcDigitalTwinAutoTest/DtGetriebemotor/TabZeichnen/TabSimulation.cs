using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DtGetriebemotor.ViewModel;

namespace DtGetriebemotor.TabZeichnen;

public partial class TabZeichnen
{
    public static LibWpf.LibWpf TabSimulationZeichnen(VmGetriebemotor vmGetriebemotor, TabItem tabItem, string hintergrund)
    {
        var libWpf = new LibWpf.LibWpf(tabItem);
        libWpf.SetBackground(new BrushConverter().ConvertFromString(hintergrund) as SolidColorBrush);
        libWpf.GridZeichnen(50, 30, 40, 30, true);

      
    
        return libWpf;
    }
}