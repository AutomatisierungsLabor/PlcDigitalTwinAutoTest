using System;
using System.Windows.Controls;
using System.Windows.Media;

namespace DtKata.TabZeichnen;

public partial class TabZeichnen
{
    public static void TabSimulationZeichnen(Grid grid, bool gridSichtbar, string hintergrund)
    {
        var viewmodel = grid.DataContext as BasePlcDtAt.BaseViewModel.ViewModel ?? throw new ArgumentNullException($"{nameof(ViewModel)}", "Datacontext is not of type viewmodel");

        grid.Background = new BrushConverter().ConvertFromString(hintergrund) as SolidColorBrush;

        LibWpf.LibGrid.Zeichnen(50, 20, 40, 20, gridSichtbar, grid);

        TabSimulationTaster(grid, viewmodel);
        TabSimulationSchalter(grid, viewmodel);
        TabSimulationKontakte(grid);
        TabSimulationLampen(grid);

        LibWpf.LibMeldungen.PlcError(grid);
    }
}