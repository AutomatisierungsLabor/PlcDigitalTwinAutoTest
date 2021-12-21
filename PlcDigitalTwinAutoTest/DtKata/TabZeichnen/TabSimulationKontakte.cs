using System.Windows;
using System.Windows.Controls;

namespace DtKata.TabZeichnen;

public partial class TabZeichnen
{
    private static void TabSimulationKontakte(Grid grid)
    {
        LibWpf.LibBilder.BildViz("Bilder\\Taster_SchliesserHellgrau.jpg", 10, 2, 2, 3, new Thickness(0, 5, 5, 5),
            $"SichtbarAus[{(int)ViewModel.ViewModel.WpfObjects.S1}]", UIElement.VisibilityProperty, grid);
        LibWpf.LibBilder.BildViz("Bilder\\Taster_BetaetigtHellgrau.jpg", 10, 2, 2, 3, new Thickness(0, 5, 5, 5),
            $"SichtbarEin[{(int)ViewModel.ViewModel.WpfObjects.S1}]", UIElement.VisibilityProperty, grid);

        LibWpf.LibBilder.BildViz("Bilder\\Taster_SchliesserHellgrau.jpg", 10, 2, 6, 3, new Thickness(0, 5, 5, 5),
            $"SichtbarAus[{(int)ViewModel.ViewModel.WpfObjects.S2}]", UIElement.VisibilityProperty, grid);
        LibWpf.LibBilder.BildViz("Bilder\\Taster_BetaetigtHellgrau.jpg", 10, 2, 6, 3, new Thickness(0, 5, 5, 5),
            $"SichtbarEin[{(int)ViewModel.ViewModel.WpfObjects.S2}]", UIElement.VisibilityProperty, grid);

        LibWpf.LibBilder.BildViz("Bilder\\Taster_SchliesserHellgrau.jpg", 10, 2, 10, 3, new Thickness(0, 5, 5, 5),
            $"SichtbarAus[{(int)ViewModel.ViewModel.WpfObjects.S3}]", UIElement.VisibilityProperty, grid);
        LibWpf.LibBilder.BildViz("Bilder\\Taster_BetaetigtHellgrau.jpg", 10, 2, 10, 3, new Thickness(0, 5, 5, 5),
            $"SichtbarEin[{(int)ViewModel.ViewModel.WpfObjects.S3}]", UIElement.VisibilityProperty, grid);

        LibWpf.LibBilder.BildViz("Bilder\\Taster_SchliesserHellgrau.jpg", 10, 2, 14, 3, new Thickness(0, 5, 5, 5),
            $"SichtbarAus[{(int)ViewModel.ViewModel.WpfObjects.S4}]", UIElement.VisibilityProperty, grid);
        LibWpf.LibBilder.BildViz("Bilder\\Taster_BetaetigtHellgrau.jpg", 10, 2, 14, 3, new Thickness(0, 5, 5, 5),
            $"SichtbarEin[{(int)ViewModel.ViewModel.WpfObjects.S4}]", UIElement.VisibilityProperty, grid);

        LibWpf.LibBilder.BildViz("Bilder\\Taster_SchliesserHellgrau.jpg", 10, 2, 18, 3, new Thickness(0, 5, 5, 5),
            $"SichtbarAus[{(int)ViewModel.ViewModel.WpfObjects.S5}]", UIElement.VisibilityProperty, grid);
        LibWpf.LibBilder.BildViz("Bilder\\Taster_BetaetigtHellgrau.jpg", 10, 2, 18, 3, new Thickness(0, 5, 5, 5),
            $"SichtbarEin[{(int)ViewModel.ViewModel.WpfObjects.S5}]", UIElement.VisibilityProperty, grid);

        LibWpf.LibBilder.BildViz("Bilder\\Taster_SchliesserHellgrau.jpg", 10, 2, 22, 3, new Thickness(0, 5, 5, 5),
            $"SichtbarAus[{(int)ViewModel.ViewModel.WpfObjects.S6}]", UIElement.VisibilityProperty, grid);
        LibWpf.LibBilder.BildViz("Bilder\\Taster_BetaetigtHellgrau.jpg", 10, 2, 22, 3, new Thickness(0, 5, 5, 5),
            $"SichtbarEin[{(int)ViewModel.ViewModel.WpfObjects.S6}]", UIElement.VisibilityProperty, grid);

        LibWpf.LibBilder.BildViz("Bilder\\Taster_SchliesserHellgrau.jpg", 10, 2, 26, 3, new Thickness(0, 5, 5, 5),
            $"SichtbarAus[{(int)ViewModel.ViewModel.WpfObjects.S7}]", UIElement.VisibilityProperty, grid);
        LibWpf.LibBilder.BildViz("Bilder\\Taster_BetaetigtHellgrau.jpg", 10, 2, 26, 3, new Thickness(0, 5, 5, 5),
            $"SichtbarEin[{(int)ViewModel.ViewModel.WpfObjects.S7}]", UIElement.VisibilityProperty, grid);

        LibWpf.LibBilder.BildViz("Bilder\\Taster_SchliesserHellgrau.jpg", 10, 2, 30, 3, new Thickness(0, 5, 5, 5),
            $"SichtbarAus[{(int)ViewModel.ViewModel.WpfObjects.S8}]", UIElement.VisibilityProperty, grid);
        LibWpf.LibBilder.BildViz("Bilder\\Taster_BetaetigtHellgrau.jpg", 10, 2, 30, 3, new Thickness(0, 5, 5, 5),
            $"SichtbarEin[{(int)ViewModel.ViewModel.WpfObjects.S8}]", UIElement.VisibilityProperty, grid);
    }
}