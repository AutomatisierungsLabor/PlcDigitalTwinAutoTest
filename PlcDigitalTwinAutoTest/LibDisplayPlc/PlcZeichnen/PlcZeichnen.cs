using LibConfigDt;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LibDisplayPlc.PlcZeichnen;

public partial class PlcZeichnen
{
    private readonly Grid _plcGrid;

    private const int SchriftGanzGross = 50;
    private const int SchriftGross = 25;
    private const int SchriftKlein = 18;
    private const int AbstandY = 30;

    public PlcZeichnen(Grid plcGrid) => _plcGrid = plcGrid;
    public void Zeichnen(ConfigDt configDt)
    {
        var libWpf = new LibWpf.LibWpf(_plcGrid);

        if (configDt.GetAnzahlAa() > 0 || configDt.GetAnzahlAi() > 0)
        {
            libWpf.GridZeichnen(30, 30, 28, 30, false, false, true);
            libWpf.RectangleFill(1, 30, 8, 12, Brushes.LightGray);
        }
        else
        {
            libWpf.GridZeichnen(21, 30, 28, 30, false, false, true);
            libWpf.RectangleFill(1, 19, 8, 12, Brushes.LightGray);
        }

        PlcRahmenZeichnen(libWpf, "DI", "a", "StringWertDi0", 2, 10, 8, new Thickness(3, 0, 3, 3));
        PlcRahmenZeichnen(libWpf, "DI", "b", "StringWertDi1", 11, 10, 8, new Thickness(3, 0, 3, 3));

        PlcAiZeichnen(libWpf, configDt, 20, 8);

        PlcLedZeichnen(libWpf, "Di0", 2, 8, 9);
        PlcLedZeichnen(libWpf, "Di1", 11, 8, 9);

        PlcBeschriftungKommentarZeichnen(libWpf, "Di0",  VerticalAlignment.Bottom, 2, 1, 6);
        PlcBeschriftungKommentarZeichnen(libWpf, "Di1", VerticalAlignment.Bottom, 11, 1, 6);


        libWpf.Text("S7-1214 DC/DC/DC", 2, 18, 12, 4, HorizontalAlignment.Center, VerticalAlignment.Center, SchriftGanzGross, Brushes.White);


        PlcRahmenZeichnen(libWpf, "DA", "a", "StringWertDa0", 2, 16, 16, new Thickness(3, 3, 3, 0));
        PlcRahmenZeichnen(libWpf, "DA", "b", "StringWertDa1", 11, 16, 16, new Thickness(3, 3, 3, 0));

        PlcAaZeichnen(libWpf, configDt, 20, 16);

        PlcLedZeichnen(libWpf, "Da0", 2, 19, 18);
        PlcLedZeichnen(libWpf, "Da1", 11, 19, 18);

        PlcBeschriftungKommentarZeichnen(libWpf, "Da0", VerticalAlignment.Top, 2, 21,20);
        PlcBeschriftungKommentarZeichnen(libWpf, "Da1", VerticalAlignment.Top, 11, 21, 20);
    }
}