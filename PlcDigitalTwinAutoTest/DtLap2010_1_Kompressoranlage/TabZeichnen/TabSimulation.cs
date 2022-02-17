using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DtLap2010_1_Kompressoranlage.ViewModel;

namespace DtLap2010_1_Kompressoranlage.TabZeichnen;

public partial class TabZeichnen
{
    public static void TabSimulationZeichnen(VmLap2010 vmKata, TabItem tabItem, string hintergrund)
    {
        var libWpf = new LibWpf.LibWpf(tabItem);
        libWpf.SetBackground(new BrushConverter().ConvertFromString(hintergrund) as SolidColorBrush);
        libWpf.GridZeichnen(50, 30, 40, 30, true);

        var buttonRand = new Thickness(2, 5, 2, 5);

   
        
       // libWpf.PlcError();
    }
}