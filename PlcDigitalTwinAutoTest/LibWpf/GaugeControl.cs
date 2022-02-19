using System.Windows.Data;

namespace LibWpf;

public partial class LibWpf
{
    public void GaugeControl(int xPos, int xSpan, int yPos, int ySpan, string bezeichnung, int minVal, int maxVal, int colorFirstPos, int colorMittdlePos, string wpfObject)
    {
        var gaugeControl = new GaugeControl.GaugeControl()
        {
            GaugeText = bezeichnung,
            ArcMinValue = minVal,
            ArcMaxValue = maxVal,
            ArcFirstColorEndPos = colorFirstPos,
            ArcMidleColorEndPos = colorMittdlePos
        };

        var b = new Binding(wpfObject)
        {
            Source = gaugeControl
        };

        //BindingOperations.SetBinding(gaugeControl,"CurrentValue", b );

        AddToGrid(xPos, xSpan, yPos, ySpan, Grid, gaugeControl);
    }
}