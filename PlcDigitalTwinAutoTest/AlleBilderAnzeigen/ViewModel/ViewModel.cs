using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AlleBilderAnzeigen.ViewModel;

public class ViewModel
{
    private const short AnzX = 10;
    private const short BreiteX = 150;
    private const short AnzY = 7;
    private const short BreiteY = 150;
    private readonly LibWpf.LibWpf _libWpf;
    public ViewModel(Grid grid)
    {
        _libWpf = new LibWpf.LibWpf(grid);
        _libWpf.GridZeichnen(AnzX, BreiteX, AnzY, BreiteY,false,false, true);
    }
    public void AlleBilderAnzeigen(List<string> alleBilder)
    {
        var posX = 0;
        var posY = 0;
        var bilderRand = new Thickness(0, 0, 0, 30);

        foreach (var name in alleBilder)
        {
            _libWpf.Image(name, posX, 1, posY, 1, bilderRand);
            _libWpf.Text(name, posX, 1, posY, 1, HorizontalAlignment.Left, VerticalAlignment.Bottom, 20, Brushes.Black);

            posX++;
            if (posX < AnzX) continue;
            posX = 0;
            posY++;
        }
    }
}