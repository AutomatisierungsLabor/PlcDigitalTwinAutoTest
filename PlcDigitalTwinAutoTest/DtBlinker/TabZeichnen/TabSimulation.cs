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
        libWpf.GridZeichnen(50, 40, false, false, false);


        var scottPlot = libWpf.ScottPlot(1, 22, 6, 15);

        var kreisRand = new Thickness(2, 2, 2, 2);
        var kreisRandFarbe = new SolidColorBrush(Colors.Black);

        libWpf.EllipseMarginStrokeBindingFilling(10, 4, 1, 4, kreisRand, kreisRandFarbe, 2, nameof(vmBlinker.BrushP1));

        var buttonRand = new Thickness(2, 5, 2, 5);

        libWpf.Text("Frequenz", 25, 10, 6, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 30, Brushes.Black);
        libWpf.ButtonBackgroundContentMarginRounded("Niedriger", 25, 4, 8, 4, 25, 15, Brushes.Yellow, buttonRand, vmBlinker.ButtonTasterCommand, "S1", nameof(vmBlinker.ClickModeS1));
        libWpf.ButtonBackgroundContentMarginRounded("Höher", 31, 4, 8, 4, 25, 15, Brushes.GreenYellow, buttonRand, vmBlinker.ButtonTasterCommand, "S2", nameof(vmBlinker.ClickModeS2));


        libWpf.Text("Tastverhältnis", 25, 10, 15, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 30, Brushes.Black);
        libWpf.ButtonBackgroundContentMarginRounded("Weniger", 25, 4, 17, 4, 25, 15, Brushes.Yellow, buttonRand, vmBlinker.ButtonTasterCommand, "S3", nameof(vmBlinker.ClickModeS3));
        libWpf.ButtonBackgroundContentMarginRounded("Mehr", 31, 4, 17, 4, 25, 15, Brushes.GreenYellow, buttonRand, vmBlinker.ButtonTasterCommand, "S4", nameof(vmBlinker.ClickModeS4));
        libWpf.ButtonBackgroundContentMarginRounded("RESET", 28, 4, 1, 4, 30, 15, Brushes.Violet, buttonRand, vmBlinker.ButtonTasterCommand, "S5", nameof(vmBlinker.ClickModeS5));


        libWpf.PlcError();
        return scottPlot;
    }
}