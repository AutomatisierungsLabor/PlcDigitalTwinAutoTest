using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DtKata.TabZeichnen;

public partial class TabZeichnen
{
    public static void TabAutoTestZeichnen(Grid grid, bool gridSichtbar, string hintergrund)
    {
        LibWpf.LibGrid.Zeichnen(50, 20, 30, 20, gridSichtbar, grid);

        LibWpf.LibTexte.Text("AutoTest", 2, 20, 25, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 30, Brushes.Black, grid);
        
        LibWpf.LibMeldungen.PlcError(grid);
    }
}