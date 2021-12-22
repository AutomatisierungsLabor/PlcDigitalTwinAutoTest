using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using static BasePlcDtAt.BaseViewModel.ViewModel;

namespace LibWpf;

public class LibMeldungen
{
    public static void PlcError(Grid grid)
    {
        LibFormen.RechteckVis(2, 20, 2, 10, Brushes.LightSalmon, (int)WpfBase.ErrorAnzeige, grid);
        LibTexte.TextVis(5, 10, 5, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black, (int)WpfBase.ErrorVersionLokal, grid);
        LibTexte.TextVis(5, 10, 10, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black, (int)WpfBase.ErrorVersionPlc, grid);
    }
}