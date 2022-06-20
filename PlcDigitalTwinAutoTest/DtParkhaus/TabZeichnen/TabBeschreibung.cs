using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DtParkhaus.TabZeichnen;

public partial class TabZeichnen
{

    public static void TabBeschreibungZeichnen(ViewModel.VmParkhaus vmParkhaus, TabItem tabItem, string hintergrund)
    {
        _ = vmParkhaus;

        var libWpf = new LibWpf.LibWpf(tabItem);
        libWpf.SetBackground(new BrushConverter().ConvertFromString(hintergrund) as SolidColorBrush);

        libWpf.GridZeichnen(50, 30, false, false, true);
        libWpf.Text("Beschreibung", 2, 20, 25, 3, HorizontalAlignment.Left, VerticalAlignment.Top, 30, Brushes.Black);

        libWpf.PlcError();
    }
}