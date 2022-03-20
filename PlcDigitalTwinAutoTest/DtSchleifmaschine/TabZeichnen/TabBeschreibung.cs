using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DtSchleifmaschine.TabZeichnen;

public partial class TabZeichnen
{
    public static void TabBeschreibungZeichnen(ViewModel.VmSchleifmaschine vmSchleifmaschine, TabItem tabItem, string hintergrund)
    {
        _ = vmSchleifmaschine;
       var libWpf = new LibWpf.LibWpf(tabItem);
        libWpf.SetBackground(new BrushConverter().ConvertFromString(hintergrund) as SolidColorBrush);

        libWpf.GridZeichnen(50, 30, 30, 30, true);
        libWpf.Text("Beschreibung", 2, 20, 25, 3, HorizontalAlignment.Left, VerticalAlignment.Top, 30, Brushes.Black);

        libWpf.PlcError();
    }
}