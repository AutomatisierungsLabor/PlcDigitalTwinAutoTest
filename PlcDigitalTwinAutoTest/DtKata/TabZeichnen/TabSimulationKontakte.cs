using System.Windows;
using System.Windows.Controls;
using DtKata.ViewModel;

namespace DtKata.TabZeichnen;

public partial class TabZeichnen
{
    private static void TabSimulationKontakte(Grid grid)
    {
        var rand = new Thickness(0, 5, 5, 5);

        LibWpf.LibBilder.BildVisAus("Taster_SchliesserHellgrau.jpg", 10, 2, 2, 3, rand, (int)WpfObjects.S1, grid);
        LibWpf.LibBilder.BildVisEin("Taster_BetaetigtHellgrau.jpg", 10, 2, 2, 3, rand, (int)WpfObjects.S1, grid);

        LibWpf.LibBilder.BildVisAus("Taster_SchliesserHellgrau.jpg", 10, 2, 6, 3, rand, (int)WpfObjects.S2, grid);
        LibWpf.LibBilder.BildVisEin("Taster_BetaetigtHellgrau.jpg", 10, 2, 6, 3, rand, (int)WpfObjects.S2, grid);

        LibWpf.LibBilder.BildVisAus("Taster_SchliesserHellgrau.jpg", 10, 2, 10, 3, rand, (int)WpfObjects.S3, grid);
        LibWpf.LibBilder.BildVisEin("Taster_BetaetigtHellgrau.jpg", 10, 2, 10, 3, rand, (int)WpfObjects.S3, grid);

        LibWpf.LibBilder.BildVisAus("Taster_SchliesserHellgrau.jpg", 10, 2, 14, 3, rand, (int)WpfObjects.S4, grid);
        LibWpf.LibBilder.BildVisEin("Taster_BetaetigtHellgrau.jpg", 10, 2, 14, 3, rand, (int)WpfObjects.S4, grid);

        LibWpf.LibBilder.BildVisAus("Taster_SchliesserHellgrau.jpg", 10, 2, 18, 3, rand, (int)WpfObjects.S5, grid);
        LibWpf.LibBilder.BildVisEin("Taster_BetaetigtHellgrau.jpg", 10, 2, 18, 3, rand, (int)WpfObjects.S5, grid);

        LibWpf.LibBilder.BildVisAus("Taster_SchliesserHellgrau.jpg", 10, 2, 22, 3, rand, (int)WpfObjects.S6, grid);
        LibWpf.LibBilder.BildVisEin("Taster_BetaetigtHellgrau.jpg", 10, 2, 22, 3, rand, (int)WpfObjects.S6, grid);

        LibWpf.LibBilder.BildVisAus("Taster_SchliesserHellgrau.jpg", 10, 2, 26, 3, rand, (int)WpfObjects.S7, grid);
        LibWpf.LibBilder.BildVisEin("Taster_BetaetigtHellgrau.jpg", 10, 2, 26, 3, rand, (int)WpfObjects.S7, grid);

        LibWpf.LibBilder.BildVisAus("Taster_SchliesserHellgrau.jpg", 10, 2, 30, 3, rand, (int)WpfObjects.S8, grid);
        LibWpf.LibBilder.BildVisEin("Taster_BetaetigtHellgrau.jpg", 10, 2, 30, 3, rand, (int)WpfObjects.S8, grid);
    }
}