using LibGaugeControl;
using System.Windows.Data;

namespace LibWpf;

public partial class LibWpf
{
    public void PointerGauge(int xPos, int xSpan, int yPos, int ySpan, string bezeichnung, int minVal, int maxVal, int colorFirstPos, int colorMittdlePos, string bindingValue)
    {
        var gaugeControl = new GaugeControl
        {
            GaugeText = bezeichnung,
            ArcMinValue = minVal,
            ArcMaxValue = maxVal,
            ArcFirstColorEndPos = colorFirstPos,
            ArcMidleColorEndPos = colorMittdlePos
        };
        BindingOperations.SetBinding(gaugeControl, GaugeControl.CurrentValueProperty, new Binding(bindingValue));
        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, gaugeControl);
    }
}