using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using LibConfigDt;

namespace LibDisplayPlc.PlcZeichnen;

public partial class PlcZeichnen
{
    private readonly Grid _plcGrid;
    private readonly int _maxAnzByteAaAi;
    private readonly int _maxAnzByteDaDi;

    private const int SchriftGanzGross = 50;
    private const int SchriftGross = 25;
    private const int SchriftKlein = 18;

    public PlcZeichnen(Grid plcGrid, int maxAnzByteAaAi, int maxAnzByteDaDi)
    {
        _plcGrid = plcGrid;
        _maxAnzByteAaAi = maxAnzByteAaAi;
        _maxAnzByteDaDi = maxAnzByteDaDi;
    }
    public void Zeichnen(ConfigDt configDt)
    {
        const int xPos0 = 2;
        const int xPos1 = xPos0 + 9;
        const int xPos2 = xPos1 + 9;
        const int xPos3 = xPos2 + 9;
        const int xPos4 = xPos3 + 9;

        var libWpf = new LibWpf.LibWpf(_plcGrid);

        var breiteGrid = (int)(2 + (_maxAnzByteDaDi + 1.3 * _maxAnzByteAaAi) * 9);
        var breiteRechteck = (int)(1 + (_maxAnzByteDaDi + 1.3 * _maxAnzByteAaAi) * 9);
        var posAaAi = 2 + _maxAnzByteDaDi * 9;

        libWpf.GridZeichnen(breiteGrid, 28, false, false, true);
        libWpf.RectangleFill(1, breiteRechteck, 8, 12, Brushes.LightGray);



        PlcRahmenZeichnen(libWpf, "DI", "a", "StringWertDi0", xPos0, 10, 8, new Thickness(3, 0, 3, 3));
        PlcRahmenZeichnen(libWpf, "DI", "b", "StringWertDi1", xPos1, 10, 8, new Thickness(3, 0, 3, 3));
        if (_maxAnzByteDaDi > 2) PlcRahmenZeichnen(libWpf, "DI", "c", "StringWertDi2", xPos2, 10, 8, new Thickness(3, 0, 3, 3));
        if (_maxAnzByteDaDi > 3) PlcRahmenZeichnen(libWpf, "DI", "d", "StringWertDi3", xPos3, 10, 8, new Thickness(3, 0, 3, 3));
        if (_maxAnzByteDaDi > 4) PlcRahmenZeichnen(libWpf, "DI", "e", "StringWertDi4", xPos4, 10, 8, new Thickness(3, 0, 3, 3));

        PlcAiZeichnen(libWpf, configDt, posAaAi, 8);

        PlcLedZeichnen(libWpf, "Di0", xPos0, 8, 9);
        PlcLedZeichnen(libWpf, "Di1", xPos1, 8, 9);
        if (_maxAnzByteDaDi > 2) PlcLedZeichnen(libWpf, "Di2", xPos2, 8, 9);
        if (_maxAnzByteDaDi > 3) PlcLedZeichnen(libWpf, "Di3", xPos3, 8, 9);
        if (_maxAnzByteDaDi > 4) PlcLedZeichnen(libWpf, "Di4", xPos4, 8, 9);

        PlcBeschriftungKommentarZeichnen(libWpf, "Di0", VerticalAlignment.Bottom, xPos0, 1, 6);
        PlcBeschriftungKommentarZeichnen(libWpf, "Di1", VerticalAlignment.Bottom, xPos1, 1, 6);
        if (_maxAnzByteDaDi > 2) PlcBeschriftungKommentarZeichnen(libWpf, "Di2", VerticalAlignment.Bottom, xPos2, 1, 6);
        if (_maxAnzByteDaDi > 3) PlcBeschriftungKommentarZeichnen(libWpf, "Di3", VerticalAlignment.Bottom, xPos3, 1, 6);
        if (_maxAnzByteDaDi > 4) PlcBeschriftungKommentarZeichnen(libWpf, "Di4", VerticalAlignment.Bottom, xPos4, 1, 6);

        libWpf.Text("S7-1214 DC/DC/DC", 2, 18, 12, 4, HorizontalAlignment.Center, VerticalAlignment.Center, SchriftGanzGross, Brushes.White);


        PlcRahmenZeichnen(libWpf, "DA", "a", "StringWertDa0", xPos0, 16, 16, new Thickness(3, 3, 3, 0));
        PlcRahmenZeichnen(libWpf, "DA", "b", "StringWertDa1", xPos1, 16, 16, new Thickness(3, 3, 3, 0));
        if (_maxAnzByteDaDi > 2) PlcRahmenZeichnen(libWpf, "DA", "c", "StringWertDa2", xPos2, 16, 16, new Thickness(3, 3, 3, 0));
        if (_maxAnzByteDaDi > 3) PlcRahmenZeichnen(libWpf, "DA", "d", "StringWertDa3", xPos3, 16, 16, new Thickness(3, 3, 3, 0));
        if (_maxAnzByteDaDi > 4) PlcRahmenZeichnen(libWpf, "DA", "e", "StringWertDa4", xPos4, 16, 16, new Thickness(3, 3, 3, 0));

        PlcAaZeichnen(libWpf, configDt, posAaAi, 16);

        PlcLedZeichnen(libWpf, "Da0", xPos0, 19, 18);
        PlcLedZeichnen(libWpf, "Da1", xPos1, 19, 18);
        if (_maxAnzByteDaDi > 2) PlcLedZeichnen(libWpf, "Da2", xPos2, 19, 18);
        if (_maxAnzByteDaDi > 3) PlcLedZeichnen(libWpf, "Da3", xPos3, 19, 18);
        if (_maxAnzByteDaDi > 4) PlcLedZeichnen(libWpf, "Da4", xPos4, 19, 18);

        PlcBeschriftungKommentarZeichnen(libWpf, "Da0", VerticalAlignment.Top, xPos0, 21, 20);
        PlcBeschriftungKommentarZeichnen(libWpf, "Da1", VerticalAlignment.Top, xPos1, 21, 20);
        if (_maxAnzByteDaDi > 2) PlcBeschriftungKommentarZeichnen(libWpf, "Da2", VerticalAlignment.Top, xPos2, 21, 20);
        if (_maxAnzByteDaDi > 3) PlcBeschriftungKommentarZeichnen(libWpf, "Da3", VerticalAlignment.Top, xPos3, 21, 20);
        if (_maxAnzByteDaDi > 4) PlcBeschriftungKommentarZeichnen(libWpf, "Da4", VerticalAlignment.Top, xPos4, 21, 20);
    }
}