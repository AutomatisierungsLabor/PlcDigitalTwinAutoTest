﻿using LibAutoTestSilk.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LibAutoTestSilk;

public class DiDaBeschriften
{
    public DiDaBeschriften(Grid grid)
    {
        var libWpf = new LibWpf.LibWpf(grid);

        libWpf.Rechteck(2, 1, 1, 1, Brushes.Chartreuse);
        libWpf.Rechteck(3, 1, 1, 1, Brushes.Silver);
        libWpf.Rechteck(4, 1, 1, 1, Brushes.OrangeRed);

        for (var i = 0; i < 16; i++)
        {
            var xAbstand = 10 + 10 * i / 4;

            libWpf.TextVertikalVis(2, 2, 1, 1, HorizontalAlignment.Left, VerticalAlignment.Bottom, 10, new Thickness(240 - i * xAbstand, 0, 0, 5), 100, Brushes.Black, i + (int)VmAutoTesterSilk.WpfIndex.Di01);
            libWpf.TextVertikalVis(3, 2, 1, 1, HorizontalAlignment.Left, VerticalAlignment.Bottom, 10, new Thickness(240 - i * xAbstand, 0, 0, 5), 100, Brushes.Black, i + (int)VmAutoTesterSilk.WpfIndex.Da01);
            libWpf.TextVertikalVis(4, 2, 1, 1, HorizontalAlignment.Left, VerticalAlignment.Bottom, 10, new Thickness(240 - i * xAbstand, 0, 0, 5), 100, Brushes.Black, i + (int)VmAutoTesterSilk.WpfIndex.Da01);
        }
    }
}