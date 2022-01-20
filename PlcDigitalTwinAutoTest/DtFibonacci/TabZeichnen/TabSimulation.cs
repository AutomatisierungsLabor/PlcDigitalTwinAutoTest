using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DtFibonacci.ViewModel;

namespace DtFibonacci.TabZeichnen;

public partial class TabZeichnen
{
    public static (LibWpf.LibWpf libWpf, ScottPlot.WpfPlot scottPlot) TabSimulationZeichnen(VmFibonacci vmFibonacci, TabItem tabItem, string hintergrund)
    {
        var libWpf = new LibWpf.LibWpf(tabItem);
        libWpf.SetBackground(new BrushConverter().ConvertFromString(hintergrund) as SolidColorBrush);
        libWpf.GridZeichnen(50, 30, 40, 30, false);

        var scottPlot = libWpf.ScottPlot(1, 22, 6, 15);

        var kreisRand = new Thickness(2, 2, 2, 2);
        var kreisRandFarbe = new SolidColorBrush(Colors.Black);
        
        libWpf.KreisRandVis(10, 4, 1, 4, kreisRandFarbe, kreisRand, WpfObjects.P1);
        
        var buttonRand = new Thickness(2, 5, 2, 5);
        
        libWpf.Button(25, 4, 6, 4, 20, buttonRand, vmFibonacci.BtnTaster, WpfObjects.S1, false, false);

        return (libWpf, scottPlot);
    }
}