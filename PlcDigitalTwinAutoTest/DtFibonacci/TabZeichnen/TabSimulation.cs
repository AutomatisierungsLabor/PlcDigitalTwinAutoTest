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

        libWpf.KreisRandVis(10, 4, 1, 4, new SolidColorBrush(Colors.Black), new Thickness(2, 2, 2, 2), WpfObjects.P1);
        libWpf.ButtonRounded(25, 4, 1, 4, 30, 15, new Thickness(2, 2, 2, 2), Brushes.LawnGreen, vmFibonacci.BtnTaster, WpfObjects.S1, false, false);

        libWpf.PlcError();
        return scottPlot;
    }
}