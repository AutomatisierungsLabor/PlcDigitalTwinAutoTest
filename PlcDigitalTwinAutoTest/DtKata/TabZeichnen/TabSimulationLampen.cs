using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DtKata.ViewModel;

namespace DtKata.TabZeichnen;

public partial class TabZeichnen
{
    private static void TabSimulationLampen(Grid grid)
    {
        var rand = new Thickness(2, 2, 2, 2);
        var randFarbe = new SolidColorBrush(Colors.Black) ;

        LibWpf.LibFormen.KreisRandVis(20, 3, 2, 3, randFarbe, rand, (int)WpfObjects.P1, grid);
        LibWpf.LibFormen.KreisRandVis(20, 3, 6, 3, randFarbe, rand, (int)WpfObjects.P2, grid);
        LibWpf.LibFormen.KreisRandVis(20, 3, 10, 3, randFarbe, rand, (int)WpfObjects.P3, grid);
        LibWpf.LibFormen.KreisRandVis(20, 3, 14, 3, randFarbe, rand, (int)WpfObjects.P4, grid);
        LibWpf.LibFormen.KreisRandVis(20, 3, 18, 3, randFarbe, rand, (int)WpfObjects.P5, grid);
        LibWpf.LibFormen.KreisRandVis(20, 3, 22, 3, randFarbe, rand, (int)WpfObjects.P6, grid);
        LibWpf.LibFormen.KreisRandVis(20, 3, 26, 3, randFarbe, rand, (int)WpfObjects.P7, grid);
        LibWpf.LibFormen.KreisRandVis(20, 3, 30, 3, randFarbe, rand, (int)WpfObjects.P8, grid);
    }
}