using System.Windows.Media;

namespace LibWpf;

public partial class LibWpf
{
    public void SiebenSegmentAnzeige(int xPos, int xSpan, int yPos, int ySpan, string bindingValue)
    {
        var anzeige = new LibSiebenSegmentAnzeige.SiebenSegmentAnzeige
        {
            ColorBackground = Brushes.Yellow,
            ShortValue = 7
        };

        anzeige.SetBinding(LibSiebenSegmentAnzeige.SiebenSegmentAnzeige.ShortValueProperty, bindingValue);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, anzeige);
    }
}
