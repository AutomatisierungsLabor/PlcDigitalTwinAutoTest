using System.Windows;
using System.Windows.Controls;

namespace DtLinearachse.TabZeichnen;

public partial class TabZeichnen
{
    public static void TabLaborPlatteZeichnen(ViewModel.VmLinearachse vmFibonacci, TabItem tabItem, string hintergrund)
    {
        var libWpf = new LibWpf.LibWpf(tabItem);

        libWpf.GridZeichnen(50, 30, 30, 30, false);
        libWpf.Bild("PlatteLinearachse.jpg", 1, 25, 1, 22, new Thickness(0, 0, 0, 0));

        libWpf.PlcError();
    }
}