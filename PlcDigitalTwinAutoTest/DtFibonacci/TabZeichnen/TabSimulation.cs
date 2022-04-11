using DtFibonacci.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DtFibonacci.TabZeichnen;

public partial class TabZeichnen
{
    public static ScottPlot.WpfPlot TabSimulationZeichnen(VmFibonacci vmFibonacci, TabItem tabItem, string hintergrund)
    {
        var libWpf = new LibWpf.LibWpf(tabItem);
        libWpf.SetBackground(new BrushConverter().ConvertFromString(hintergrund) as SolidColorBrush);
        libWpf.GridZeichnen(50, 30, 40, 30, false);

        var scottPlot = libWpf.ScottPlot(1, 37, 6, 17);

        libWpf.EllipseMarginStrokeSetFilling(10, 4, 1, 4, new Thickness(2, 2, 2, 2), new SolidColorBrush(Colors.Black), 2, nameof(vmFibonacci.BrushP1));
        libWpf.ButtonBackgroundContentMarginRounded("Start", 25, 4, 1, 4, 30, 15, Brushes.LawnGreen, new Thickness(2, 2, 2, 2), vmFibonacci.ButtonTasterCommand, "S1", nameof(vmFibonacci.ClickModeS1));

        libWpf.PlcError();
        return scottPlot;
    }
}