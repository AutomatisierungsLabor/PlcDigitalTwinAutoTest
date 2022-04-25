using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LibDisplayPlc.PlcZeichnen;

public partial class PlcZeichnen
{
    private readonly Grid _plcGrid;

    public PlcZeichnen(Grid plcGrid) => _plcGrid = plcGrid;
    public void Zeichnen()
    {
        const int schriftGanzGross = 50;

        var libWpf = new LibWpf.LibWpf(_plcGrid);

        libWpf.GridZeichnen(25, 30, 28, 30, true);
        libWpf.RectangleFill(1, 22, 8, 12, Brushes.LightGray);

        PlcAiZeichnen(libWpf, 20, 2);

        PlcDiZeichnen(libWpf, "Di0", "a", "StringWertDi0", 3, 2);
        PlcDiZeichnen(libWpf, "Di1", "b", "StringWertDi1", 13, 2);

        libWpf.Text("S7-1214 DC/DC/DC", 3, 18, 12, 4, HorizontalAlignment.Center, VerticalAlignment.Center, schriftGanzGross, Brushes.White);

        PlcDaZeichnen(libWpf, "Da0", "a", "StringWertDa0", 3, 16);
        PlcDaZeichnen(libWpf, "Da1", "b", "StringWertDa1", 13, 16);
    }
}