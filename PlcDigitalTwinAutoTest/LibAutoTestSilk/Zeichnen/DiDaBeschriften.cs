using LibAutoTestSilk.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LibAutoTestSilk.Zeichnen;

public class DiDaBeschriften
{
    public DiDaBeschriften(Grid grid)
    {
        var libWpf = new LibWpf.LibWpf(grid);

        libWpf.RipRechteckFill(2, 1, 1, 1, Brushes.Chartreuse);
        libWpf.RipRechteckFill(3, 1, 1, 1, Brushes.Silver);
        libWpf.RipRechteckFill(4, 1, 1, 1, Brushes.OrangeRed);

        for (var i = 0; i < 16; i++)
        {
            var xAbstand = 10 + 12 * (i + i / 4);

            libWpf.RipTextVerticalSetTextSetVisibility(2, 2, 1, 1, HorizontalAlignment.Left, VerticalAlignment.Bottom, 12, new Thickness(240 - xAbstand, 0, 0, 5), 100, Brushes.Black, i + (int)VmAutoTesterSilk.WpfIndex.Di01);
            libWpf.RipTextVerticalSetTextSetVisibility(3, 2, 1, 1, HorizontalAlignment.Left, VerticalAlignment.Bottom, 12, new Thickness(240 - xAbstand, 0, 0, 5), 100, Brushes.Black, i + (int)VmAutoTesterSilk.WpfIndex.Da01);
            libWpf.RipTextVerticalSetTextSetVisibility(4, 2, 1, 1, HorizontalAlignment.Left, VerticalAlignment.Bottom, 12, new Thickness(240 - xAbstand, 0, 0, 5), 100, Brushes.Black, i + (int)VmAutoTesterSilk.WpfIndex.Da01);
        }
    }
}