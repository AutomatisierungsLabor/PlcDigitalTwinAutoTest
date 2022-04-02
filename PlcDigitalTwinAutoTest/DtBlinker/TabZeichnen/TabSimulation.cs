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

        libWpf.EllipseMarginStrokeSetFilling(10, 4, 1, 4, kreisRand, kreisRandFarbe, 2, nameof(vmBlinker.BrushP1));

        var buttonRand = new Thickness(2, 5, 2, 5);

        libWpf.Text("Frequenz", 25, 10, 6, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 30, Brushes.Black);
        libWpf.ButtonBackgroundMarginRoundedSetContend(25, 4, 8, 4, 25, 15, Brushes.Yellow, buttonRand, vmBlinker.ButtonTasterCommand, "S1", nameof(vmBlinker.ClickModeS1), nameof(vmBlinker.StringS1));
        libWpf.ButtonBackgroundMarginRoundedSetContend(31, 4, 8, 4, 25, 15, Brushes.GreenYellow, buttonRand, vmBlinker.ButtonTasterCommand, "S2", nameof(vmBlinker.ClickModeS2), nameof(vmBlinker.StringS2));


        libWpf.Text("Tastverhältnis", 25, 10, 15, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 30, Brushes.Black);
        libWpf.ButtonBackgroundMarginRoundedSetContend(25, 4, 17, 4, 25, 15, Brushes.Yellow, buttonRand, vmBlinker.ButtonTasterCommand, "S3", nameof(vmBlinker.ClickModeS3), nameof(vmBlinker.StringS3));
        libWpf.ButtonBackgroundMarginRoundedSetContend(31, 4, 17, 4, 25, 15, Brushes.GreenYellow, buttonRand, vmBlinker.ButtonTasterCommand, "S4", nameof(vmBlinker.ClickModeS4), nameof(vmBlinker.StringS4));
        libWpf.ButtonBackgroundMarginRoundedSetContend(28, 4, 1, 4, 30, 15, Brushes.Violet, buttonRand, vmBlinker.ButtonTasterCommand, "S5", nameof(vmBlinker.ClickModeS5), nameof(vmBlinker.StringS5));


        libWpf.PlcError();
        return scottPlot;
    }
}