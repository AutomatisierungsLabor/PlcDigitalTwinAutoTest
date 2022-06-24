﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DtAmpelVerbania.ViewModel;

namespace DtAmpelVerbania.TabZeichnen;

public partial class TabZeichnen
{
    public static void TabSimulationZeichnen(VmAmpelVerbania vmAmpelVarbania, TabItem tabItem, string hintergrund)
    {
        var libWpf = new LibWpf.LibWpf(tabItem);
        libWpf.SetBackground(new BrushConverter().ConvertFromString(hintergrund) as SolidColorBrush);
        libWpf.GridZeichnen(50, 40, false, false, false);

      
        libWpf.PlcError();
    }
}