using System.Windows;
using System.Windows.Media;
using static BasePlcDtAt.BaseViewModel.ViewModel;

namespace LibWpf;

public partial class LibWpf
{
    public void PlcError()
    {
        RechteckVis(2, 20, 2, 10, Brushes.LightSalmon, (int)WpfBase.ErrorAnzeige);
        TextVis(5, 10, 5, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black, (int)WpfBase.ErrorVersionLokal);
        TextVis(5, 10, 10, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black, (int)WpfBase.ErrorVersionPlc);
    }
}