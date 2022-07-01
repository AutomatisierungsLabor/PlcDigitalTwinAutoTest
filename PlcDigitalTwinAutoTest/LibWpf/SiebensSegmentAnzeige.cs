using System.Windows;
using System.Windows.Media;
using LibSiebenSegmentAnzeige;

namespace LibWpf;

public partial class LibWpf
{
    public void SiebenSegmentAnzeigeBackgroundBindingColorValueVisibility(int xPos, int xSpan, int yPos, int ySpan, Thickness margin,  Brush colorBackground,string bindingColorSegment , string bindingValue, string bindingVisibility)
    {
        var anzeige = new SiebenSegmentAnzeige
        {
            Margin = margin,
            Background = colorBackground
        };

        anzeige.SetBinding(SiebenSegmentAnzeige.VisbilityAnzeigeProperty, bindingVisibility);
        anzeige.SetBinding(SiebenSegmentAnzeige.ColorSegmentProperty, bindingColorSegment);
        anzeige.SetBinding(SiebenSegmentAnzeige.ShortBitmusterSegmenteProperty, bindingValue);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, anzeige);
    }
    public void SiebenSegmentAnzeigeBindingBackgroundValue(int xPos, int xSpan, int yPos, int ySpan, Brush colorSegment, string bindingBackground, string bindingValue)
    {
        var anzeige = new SiebenSegmentAnzeige
        {
            ColorSegment = colorSegment
        };

        anzeige.SetBinding(SiebenSegmentAnzeige.ColorBackgroundProperty, bindingBackground);
        anzeige.SetBinding(SiebenSegmentAnzeige.ShortBitmusterSegmenteProperty, bindingValue);

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, anzeige);
    }
}
