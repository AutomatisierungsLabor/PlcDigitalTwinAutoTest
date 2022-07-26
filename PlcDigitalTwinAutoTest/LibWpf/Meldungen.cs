using System.Windows;
using System.Windows.Media;

namespace LibWpf;

public partial class LibWpf
{
    public void PlcError()
    {
        RectangleFillBindingVisibility(2, 20, 2, 5, Brushes.BlueViolet, "VisibilityErrorAnzeige");

        TextBindingContentVisibility(2, 10, 2, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black, "StringErrorMeldung", "VisibilityErrorMeldung");

        TextBindingContentVisibility(2, 20, 3, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black, "StringErrorVersionLokal", "VisibilityErrorVersionLokal");
        TextBindingContentVisibility(2, 20, 4, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black, "StringErrorVersionPlc", "VisibilityErrorVersionPlc");
    }
}