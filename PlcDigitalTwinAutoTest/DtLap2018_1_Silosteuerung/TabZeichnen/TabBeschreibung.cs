using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DtLap2018_1_Silosteuerung.TabZeichnen;

public partial class TabZeichnen
{
    public static void TabBeschreibungZeichnen(ViewModel.VmLap2018 vmLap2018, TabItem tabItem, string hintergrund)
    {
        _ = vmLap2018;
        var libWpf = new LibWpf.LibWpf(tabItem);
        libWpf.SetBackground(new BrushConverter().ConvertFromString(hintergrund) as SolidColorBrush);

        libWpf.GridZeichnen(50, 30, 30, 30, false, false, true);
        libWpf.Text("Beschreibung", 2, 20, 25, 3, HorizontalAlignment.Left, VerticalAlignment.Top, 30, Brushes.Black);

        libWpf.PlcError();
    }
}