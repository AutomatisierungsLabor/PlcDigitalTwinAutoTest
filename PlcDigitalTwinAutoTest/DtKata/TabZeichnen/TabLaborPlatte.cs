﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DtKata.TabZeichnen;

public partial class TabZeichnen
{
    public static LibWpf.LibWpf TabLaborPlatteZeichnen(ViewModel.VmKata vmKata, TabItem tabItem, string hintergrund)
    {
        var libWpf = new LibWpf.LibWpf(tabItem);

        libWpf.GridZeichnen(50, 30, 30, 30, true);
        libWpf.Text("Laborplatte", 2, 20, 25, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 30, Brushes.Black);
        
        return libWpf;
    }
}