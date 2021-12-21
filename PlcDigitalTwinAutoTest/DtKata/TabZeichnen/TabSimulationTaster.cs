using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace DtKata.TabZeichnen;

public partial class TabZeichnen
{
    private static void TabSimulationTaster(Grid grid, BasePlcDtAt.BaseViewModel.ViewModel viewmodel)
    {
        LibWpf.LibButton.ButtonViz("S1", 2, 5, 2, 3, 20, new Thickness(2, 2, 2, 2), viewmodel.BtnTaster, ViewModel.ViewModel.WpfObjects.S1, $"ClkMode[{(int)ViewModel.ViewModel.WpfObjects.S1}]", ButtonBase.ClickModeProperty, grid);
        LibWpf.LibButton.ButtonViz("S2", 2, 5, 6, 3, 20, new Thickness(2, 2, 2, 2), viewmodel.BtnTaster, ViewModel.ViewModel.WpfObjects.S2, $"ClkMode[{(int)ViewModel.ViewModel.WpfObjects.S2}]", ButtonBase.ClickModeProperty, grid);
        LibWpf.LibButton.ButtonViz("S3", 2, 5, 10, 3, 20, new Thickness(2, 2, 2, 2), viewmodel.BtnTaster, ViewModel.ViewModel.WpfObjects.S3, $"ClkMode[{(int)ViewModel.ViewModel.WpfObjects.S3}]",ButtonBase.ClickModeProperty, grid);
        LibWpf.LibButton.ButtonViz("S4", 2, 5, 14, 3, 20, new Thickness(2, 2, 2, 2), viewmodel.BtnTaster, ViewModel.ViewModel.WpfObjects.S4, $"ClkMode[{(int)ViewModel.ViewModel.WpfObjects.S4}]",ButtonBase.ClickModeProperty, grid);
    }
}