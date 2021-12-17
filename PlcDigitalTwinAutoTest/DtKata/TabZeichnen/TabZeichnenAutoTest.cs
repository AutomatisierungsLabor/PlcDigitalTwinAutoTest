using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DtKata.TabZeichnen;

public partial class TabZeichnen
{
    public static void TabAutoTestZeichnen(Grid grid, bool gridSichtbar)
    {
        LibWpf.LibGrid.Zeichnen(grid, 5, 20, 10, 20, gridSichtbar);
        LibWpf.LibFormen.Rechteck(grid, 1, 1, 1, 1, Brushes.ForestGreen);
        LibWpf.LibFormen.Rechteck(grid, 3, 2, 3, 2, Brushes.Yellow);

        LibWpf.LibTexte.Text(grid, 2, 2, 3, 3, "AutoTest", 30, Brushes.Black);
    }
}