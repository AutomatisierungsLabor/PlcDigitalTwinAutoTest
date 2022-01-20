namespace LibWpf;

public partial class LibWpf
{
    public ScottPlot.WpfPlot ScottPlot(int xPos, int xSpan, int yPos, int ySpan)
    {
        var scotPlot = new ScottPlot.WpfPlot();

        AddToGrid(xPos,xSpan,yPos,ySpan,Grid, scotPlot);

        return scotPlot;
    }
}