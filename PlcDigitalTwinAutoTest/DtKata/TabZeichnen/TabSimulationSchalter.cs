using System.Windows;
using System.Windows.Controls;
using DtKata.ViewModel;

namespace DtKata.TabZeichnen;

public partial class TabZeichnen
{
    private static void TabSimulationSchalter(Grid grid, BasePlcDtAt.BaseViewModel.ViewModel viewmodel)
    {
        LibWpf.LibButton.ButtonOnOffVis(2, 5, 18, 3, 10, "SchiebeSchalterOn.JPG", "SchiebeSchalterOff.JPG",  new Thickness(2, 2, 2, 2), viewmodel.BtnSchalter, WpfObjects.S5,  grid);

        LibWpf.LibButton.ButtonOnOffVis(2, 5, 22, 3, 10, "SchiebeSchalterOn.JPG", "SchiebeSchalterOff.JPG", new Thickness(2, 2, 2, 2), viewmodel.BtnSchalter, WpfObjects.S6,  grid);

        LibWpf.LibButton.ButtonOnOffVis(2, 5, 26, 3, 10, "SchiebeSchalterOn.JPG", "SchiebeSchalterOff.JPG",  new Thickness(2, 2, 2, 2), viewmodel.BtnSchalter,WpfObjects.S7,  grid);

        LibWpf.LibButton.ButtonOnOffVis(2, 5, 30, 3, 10, "SchiebeSchalterOn.JPG", "SchiebeSchalterOff.JPG", new Thickness(2, 2, 2, 2), viewmodel.BtnSchalter, WpfObjects.S8,  grid);
    }
}