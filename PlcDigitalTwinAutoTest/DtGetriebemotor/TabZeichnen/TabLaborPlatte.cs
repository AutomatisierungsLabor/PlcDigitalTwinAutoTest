using System.Windows;
using System.Windows.Controls;

namespace DtGetriebemotor.TabZeichnen;

public partial class TabZeichnen
{
    public static LibWpf.LibWpf TabLaborPlatteZeichnen(ViewModel.VmGetriebemotor vmGetriebemotor, TabItem tabItem, string hintergrund)
    {
        var libWpf = new LibWpf.LibWpf(tabItem);

        libWpf.GridZeichnen(50, 30, 30, 30, false);
        libWpf.Bild("getriebemotor_mit_gabellichtschranke.jpg", 1, 25, 1, 22, new Thickness(0, 0, 0, 0));

        return libWpf;
    }
}