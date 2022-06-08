using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DtGetriebemotor.TabZeichnen;

public partial class TabZeichnen
{
    public static void TabLaborPlatteZeichnen(ViewModel.VmGetriebemotor vmGetriebemotor, TabItem tabItem, string hintergrund)
    {
        _ = vmGetriebemotor;
        var libWpf = new LibWpf.LibWpf(tabItem);
        libWpf.SetBackground(new BrushConverter().ConvertFromString(hintergrund) as SolidColorBrush);

        libWpf.GridZeichnen(50, 30, false, false, false);
        libWpf.Image("GetriebemotorMitGabellichtschranke.jpg", 1, 25, 1, 22, new Thickness(0, 0, 0, 0));

        libWpf.PlcError();
    }
}