using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DtBlinker.TabZeichnen;

public partial class TabZeichnen
{
    public static void TabAutoTestZeichnen(Grid grid, bool gridSichtbar, string hintergrund)
    {
        var libWpf = new LibWpf.LibWpf(grid);

        libWpf.Zeichnen(50, 20, 30, 20, gridSichtbar);

        libWpf.Text("AutoTest", 2, 20, 25, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 30, Brushes.Black);

        libWpf.PlcError(libWpf);
    }
}