using System.Windows;
using System.Windows.Media;

namespace LibWpf;

public partial class LibWpf
{
    public void PlcError()
    {
        RipRechteckSetFillSetVisibility(2, 20, 2, 5, Brushes.BlueViolet, Contracts.WpfBase.ErrorAnzeige);
        RipTextSetContendSetVisibility(2, 20, 2, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black, Contracts.WpfBase.ErrorMeldung);
        RipTextSetContendSetVisibility(2, 20, 3, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black, Contracts.WpfBase.ErrorVersionLokal);
        RipTextSetContendSetVisibility(2, 20, 4, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black, Contracts.WpfBase.ErrorVersionPlc);
    }
}