using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DtBehaeltersteuerung.ViewModel;

namespace DtBehaeltersteuerung.TabZeichnen;

public partial class TabZeichnen
{
    public static void TabBeschreibungZeichnen(VmBehaeltersteuerung vmBehaeltersteuerung, TabItem tabItem, string hintergrund)
    {
        _ = vmBehaeltersteuerung;
        var libWpf = new LibWpf.LibWpf(tabItem);
        libWpf.SetBackground(new BrushConverter().ConvertFromString(hintergrund) as SolidColorBrush);

        libWpf.GridZeichnen(50, 30, false, false, true);
        libWpf.Text("Beschreibung", 2, 20, 25, 3, HorizontalAlignment.Left, VerticalAlignment.Top, 30, Brushes.Black);

        libWpf.PlcError();
    }
}