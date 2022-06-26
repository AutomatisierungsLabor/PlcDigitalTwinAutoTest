using System.Windows.Media;

namespace LibWpf;

public partial class LibWpf
{
    public void SiebenSegmentAnzeigeBindingValue(int xPos, int xSpan, int yPos, int ySpan, Brush colorBackground, Brush colorSegment, string bindingValue)
    {
        var anzeige = new LibSiebenSegmentAnzeige.SiebenSegmentAnzeige
        {
            ColorBackground = colorBackground,
            ColorSegment = colorSegment,
            ShortBitmusterSegmente = 7
        };
        
        anzeige.SetBinding(LibSiebenSegmentAnzeige.SiebenSegmentAnzeige.ShortBitmusterSegmenteProperty, bindingValue);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, anzeige);
    }
}
