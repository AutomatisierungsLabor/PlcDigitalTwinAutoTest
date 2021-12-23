using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DtBlinker.TabZeichnen;

public partial class TabZeichnen
{
    public static void TabSimulationZeichnen(Grid grid, bool gridSichtbar, string hintergrund)
    {
        //var viewmodel = grid.DataContext as BasePlcDtAt.BaseViewModel.ViewModel ?? throw new ArgumentNullException($"{nameof(ViewModel)}", "Datacontext is not of type viewmodel");
        var libWpf = new LibWpf.LibWpf(grid);

        grid.Background = new BrushConverter().ConvertFromString(hintergrund) as SolidColorBrush;
        
        libWpf.Zeichnen(50, 20, 40, 20, gridSichtbar);

        libWpf.Text("Simulation", 2, 20, 25, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 30, Brushes.Black);

        libWpf.PlcError();
    }
}