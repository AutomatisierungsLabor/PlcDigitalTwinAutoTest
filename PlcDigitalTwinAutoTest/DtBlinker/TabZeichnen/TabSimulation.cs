using DtBlinker.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DtBlinker.TabZeichnen;

public partial class TabZeichnen
{
    public static ScottPlot.WpfPlot TabSimulationZeichnen(VmBlinker vmBlinker, TabItem tabItem, string hintergrund)
    {
        var libWpf = new LibWpf.LibWpf(tabItem);
        libWpf.SetBackground(new BrushConverter().ConvertFromString(hintergrund) as SolidColorBrush);
        libWpf.GridZeichnen(50, 30, 40, 30, false);


        var scottPlot = libWpf.ScottPlot(1, 22, 6, 15);

        var kreisRand = new Thickness(2, 2, 2, 2);
        var kreisRandFarbe = new SolidColorBrush(Colors.Black);

        libWpf.KreisRandVis(10, 4, 1, 4, kreisRandFarbe, kreisRand, WpfObjects.P1);

        var buttonRand = new Thickness(2, 5, 2, 5);

        libWpf.Text("Frequenz", 25, 10, 6, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 30, Brushes.Black);
        libWpf.ButtonRounded(25, 4, 8, 4, 25, 15, buttonRand, Brushes.Yellow, vmBlinker.BtnTaster, WpfObjects.S1, false, false);
        libWpf.ButtonRounded(31, 4, 8, 4, 25, 15, buttonRand, Brushes.GreenYellow, vmBlinker.BtnTaster, WpfObjects.S2, false, false);

        libWpf.Text("Tastverhältnis", 25, 10, 15, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 30, Brushes.Black);
        libWpf.ButtonRounded(25, 4, 17, 4, 25, 15, buttonRand, Brushes.Yellow, vmBlinker.BtnTaster, WpfObjects.S3, false, false);
        libWpf.ButtonRounded(31, 4, 17, 4, 25, 15, buttonRand, Brushes.GreenYellow, vmBlinker.BtnTaster, WpfObjects.S4, false, false);

        libWpf.ButtonRounded(28, 4, 1, 4, 30, 15, buttonRand, Brushes.Violet, vmBlinker.BtnTaster, WpfObjects.S5, false, false);

        libWpf.PlcError();
        return scottPlot;
    }
}