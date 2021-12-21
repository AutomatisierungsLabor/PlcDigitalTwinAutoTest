using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DtKata.TabZeichnen;

public partial class TabZeichnen
{
    private static void TabSimulationLampen(Grid grid)
    {
        LibWpf.LibFormen.KreisRandViz(20, 3, 2, 3, new SolidColorBrush(Colors.Black), new Thickness(2, 2, 2, 2),
            $"Farbe[{(int)ViewModel.ViewModel.WpfObjects.P1}]", System.Windows.Shapes.Shape.FillProperty, grid);
        LibWpf.LibFormen.KreisRandViz(20, 3, 6, 3, new SolidColorBrush(Colors.Black), new Thickness(2, 2, 2, 2),
            $"Farbe[{(int)ViewModel.ViewModel.WpfObjects.P2}]", System.Windows.Shapes.Shape.FillProperty, grid);
        LibWpf.LibFormen.KreisRandViz(20, 3, 10, 3, new SolidColorBrush(Colors.Black), new Thickness(2, 2, 2, 2),
            $"Farbe[{(int)ViewModel.ViewModel.WpfObjects.P3}]", System.Windows.Shapes.Shape.FillProperty, grid);
        LibWpf.LibFormen.KreisRandViz(20, 3, 14, 3, new SolidColorBrush(Colors.Black), new Thickness(2, 2, 2, 2),
            $"Farbe[{(int)ViewModel.ViewModel.WpfObjects.P4}]", System.Windows.Shapes.Shape.FillProperty, grid);
        LibWpf.LibFormen.KreisRandViz(20, 3, 18, 3, new SolidColorBrush(Colors.Black), new Thickness(2, 2, 2, 2),
            $"Farbe[{(int)ViewModel.ViewModel.WpfObjects.P5}]", System.Windows.Shapes.Shape.FillProperty, grid);
        LibWpf.LibFormen.KreisRandViz(20, 3, 22, 3, new SolidColorBrush(Colors.Black), new Thickness(2, 2, 2, 2),
            $"Farbe[{(int)ViewModel.ViewModel.WpfObjects.P6}]", System.Windows.Shapes.Shape.FillProperty, grid);
        LibWpf.LibFormen.KreisRandViz(20, 3, 26, 3, new SolidColorBrush(Colors.Black), new Thickness(2, 2, 2, 2),
            $"Farbe[{(int)ViewModel.ViewModel.WpfObjects.P7}]", System.Windows.Shapes.Shape.FillProperty, grid);
        LibWpf.LibFormen.KreisRandViz(20, 3, 30, 3, new SolidColorBrush(Colors.Black), new Thickness(2, 2, 2, 2),
            $"Farbe[{(int)ViewModel.ViewModel.WpfObjects.P8}]", System.Windows.Shapes.Shape.FillProperty, grid);
    }
}