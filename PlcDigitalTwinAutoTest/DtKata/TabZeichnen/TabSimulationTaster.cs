using System.Windows;
using System.Windows.Controls;
using DtKata.ViewModel;

namespace DtKata.TabZeichnen;

public partial class TabZeichnen
{
    private static void TabSimulationTaster(Grid grid, BasePlcDtAt.BaseViewModel.ViewModel viewmodel)
    {
        var rand = new Thickness(2, 2, 2, 2);

        LibWpf.LibButton.ButtonVis("S1", 2, 5, 2, 3, 20,  rand, viewmodel.BtnTaster, WpfObjects.S1, $"ClkMode[{(int)WpfObjects.S1}]", grid);
        LibWpf.LibButton.ButtonVis("S2", 2, 5, 6, 3, 20,  rand, viewmodel.BtnTaster, WpfObjects.S2, $"ClkMode[{(int)WpfObjects.S2}]", grid);
        LibWpf.LibButton.ButtonVis("S3", 2, 5, 10, 3, 20,  rand, viewmodel.BtnTaster, WpfObjects.S3, $"ClkMode[{(int)WpfObjects.S3}]", grid);
        LibWpf.LibButton.ButtonVis("S4", 2, 5, 14, 3, 20,  rand, viewmodel.BtnTaster, WpfObjects.S4, $"ClkMode[{(int)WpfObjects.S4}]", grid);
    }
}