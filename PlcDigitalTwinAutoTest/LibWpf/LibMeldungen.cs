using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using static BasePlcDtAt.BaseViewModel.ViewModel;

namespace LibWpf;

public  class LibMeldungen
{
    public static void PlcError(Grid grid)
    {
        LibFormen.RechteckViz(2, 20, 2, 10, Brushes.LightSalmon,  (int)WpfBase.ErrorAnzeige, UIElement.VisibilityProperty,  grid);
        LibTexte.TextViz(5,10,5,2,HorizontalAlignment.Left,VerticalAlignment.Center,20,Brushes.Black, (int)WpfBase.ErrorVersionLokal, UIElement.VisibilityProperty, grid);
        LibTexte.TextViz(5,10,10,2,HorizontalAlignment.Left,VerticalAlignment.Center,20,Brushes.Black, (int)WpfBase.ErrorVersionPlc, UIElement.VisibilityProperty,  grid);
    }
}