using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AlleBilderAnzeigen.ViewModel;

public class ViewModel
{
    private const int SpanXy = 5;
    private const short AnzX = 50;
    private const short AnzY = 60;
    private readonly LibWpf.LibWpf _libWpf;
    public ViewModel(Grid grid)
    {
        _libWpf = new LibWpf.LibWpf(grid);
        _libWpf.GridZeichnen(AnzX, AnzY, false, false, true);
    }
    public void AlleBilderAnzeigen(List<string> alleBilder)
    {

        var posX = 0;
        var posY = 0;
        var bilderRand = new Thickness(0, 0, 0, 30);

        foreach (var name in alleBilder)
        {
            _libWpf.Image(name, posX, SpanXy, posY, SpanXy, bilderRand);
            _libWpf.Text(name, posX, SpanXy, posY, SpanXy, HorizontalAlignment.Left, VerticalAlignment.Bottom, 12, Brushes.Black);

            posX += SpanXy;
            if (posX < AnzX) continue;
            posX = 0;
            posY += SpanXy;
        }
    }
}