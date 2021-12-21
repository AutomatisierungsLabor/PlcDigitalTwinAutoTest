using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace DtKata.TabZeichnen;

public partial class TabZeichnen
{
    private static void TabSimulationSchalter(Grid grid, BasePlcDtAt.BaseViewModel.ViewModel viewmodel)
    {
        LibWpf.LibButton.ButtonOnOffViz(2, 5, 18, 3, 10, "Bilder/SchiebeSchalterOn.JPG", "Bilder/SchiebeSchalterOff.JPG", $"SichtbarEin[{(int)ViewModel.ViewModel.WpfObjects.S5}]", $"SichtbarAus[{(int)ViewModel.ViewModel.WpfObjects.S5}]",
            new Thickness(2, 2, 2, 2), viewmodel.BtnSchalter, ViewModel.ViewModel.WpfObjects.S5, $"ClkMode[{(int)ViewModel.ViewModel.WpfObjects.S5}]", ButtonBase.ClickModeProperty, UIElement.VisibilityProperty, grid);

        LibWpf.LibButton.ButtonOnOffViz(2, 5, 22, 3, 10, "Bilder/SchiebeSchalterOn.JPG", "Bilder/SchiebeSchalterOff.JPG", $"SichtbarEin[{(int)ViewModel.ViewModel.WpfObjects.S6}]", $"SichtbarAus[{(int)ViewModel.ViewModel.WpfObjects.S6}]",
            new Thickness(2, 2, 2, 2), viewmodel.BtnSchalter, ViewModel.ViewModel.WpfObjects.S6, $"ClkMode[{(int)ViewModel.ViewModel.WpfObjects.S6}]", ButtonBase.ClickModeProperty, UIElement.VisibilityProperty, grid);

        LibWpf.LibButton.ButtonOnOffViz(2, 5, 26, 3, 10, "Bilder/SchiebeSchalterOn.JPG", "Bilder/SchiebeSchalterOff.JPG", $"SichtbarEin[{(int)ViewModel.ViewModel.WpfObjects.S7}]", $"SichtbarAus[{(int)ViewModel.ViewModel.WpfObjects.S7}]",
            new Thickness(2, 2, 2, 2), viewmodel.BtnSchalter, ViewModel.ViewModel.WpfObjects.S7, $"ClkMode[{(int)ViewModel.ViewModel.WpfObjects.S7}]", ButtonBase.ClickModeProperty, UIElement.VisibilityProperty, grid);

        LibWpf.LibButton.ButtonOnOffViz(2, 5, 30, 3, 10, "Bilder/SchiebeSchalterOn.JPG", "Bilder/SchiebeSchalterOff.JPG", $"SichtbarEin[{(int)ViewModel.ViewModel.WpfObjects.S8}]", $"SichtbarAus[{(int)ViewModel.ViewModel.WpfObjects.S8}]",
            new Thickness(2, 2, 2, 2), viewmodel.BtnSchalter, ViewModel.ViewModel.WpfObjects.S8, $"ClkMode[{(int)ViewModel.ViewModel.WpfObjects.S8}]", ButtonBase.ClickModeProperty, UIElement.VisibilityProperty, grid);
    }
}