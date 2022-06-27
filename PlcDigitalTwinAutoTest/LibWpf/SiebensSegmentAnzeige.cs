using System.Windows.Media;

namespace LibWpf;

public partial class LibWpf
{
    public void SiebenSegmentAnzeigeBindingBackgroundValue(int xPos, int xSpan, int yPos, int ySpan,  Brush colorSegment, string bindingBackground,string bindingValue)
    {
        var anzeige = new LibSiebenSegmentAnzeige.SiebenSegmentAnzeige
        {
            ColorSegment = colorSegment,
            ShortBitmusterSegmente = 7
        };

        anzeige.SetBinding(LibSiebenSegmentAnzeige.SiebenSegmentAnzeige.ColorBackgroundProperty, bindingBackground);
        anzeige.SetBinding(LibSiebenSegmentAnzeige.SiebenSegmentAnzeige.ShortBitmusterSegmenteProperty, bindingValue);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, anzeige);
    }
}
