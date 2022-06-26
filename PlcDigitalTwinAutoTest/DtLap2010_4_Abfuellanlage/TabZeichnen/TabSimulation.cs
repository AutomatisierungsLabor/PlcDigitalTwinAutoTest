﻿using DtLap2010_4_Abfuellanlage.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DtLap2010_4_Abfuellanlage.TabZeichnen;

public partial class TabZeichnen
{
    public static void TabSimulationZeichnen(VmLap2010 vmLap2010, TabItem tabItem, string hintergrund)
    {
        var libWpf = new LibWpf.LibWpf(tabItem);
        libWpf.SetBackground(new BrushConverter().ConvertFromString(hintergrund) as SolidColorBrush);
        libWpf.GridZeichnen(50, 40, false, false, true);

        var buttonRand = new Thickness(2, 5, 2, 5);
        var kreisRand = new Thickness(2, 2, 2, 2);
        var kreisRandFarbe = new SolidColorBrush(Colors.Black);

        ///////////////////////////////////////////////////////////
        //
        // Bedienung - Rechts
        //
        /////////////////////////////////////////////////////////// 

        libWpf.RectangleFill(20, 10, 2, 10, Brushes.LightGray);

        libWpf.Text("S1", 20, 2, 2, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("S2", 25, 2, 2, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("P1", 20, 2, 6, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.ButtonBackgroundContentMarginRounded("Aus", 22, 3, 2, 3, 14, 15, Brushes.Red, buttonRand, vmLap2010.ButtonTasterCommand, "S1", nameof(vmLap2010.ClickModeS1));
        libWpf.ButtonBackgroundContentMarginRounded("Ein", 27, 3, 2, 3, 14, 15, Brushes.Green, buttonRand, vmLap2010.ButtonTasterCommand, "S2", nameof(vmLap2010.ClickModeS2));

        libWpf.EllipseMarginStrokeBindingFilling(22, 3, 6, 3, kreisRand, kreisRandFarbe, 2, nameof(vmLap2010.BrushP1));
        libWpf.Text("Füllstand", 22, 3, 6, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);

        ///////////////////////////////////////////////////////////
        //
        //  Simulation - Links
        //
        ///////////////////////////////////////////////////////////

        libWpf.RectangleFillMargin(2, 2, 3, 12, Brushes.DarkGray, new Thickness(10, 0, 10, 0));
        libWpf.RectangleFillMargin(4, 2, 3, 12, Brushes.DarkGray, new Thickness(10, 0, 10, 0));

        var ventilRand = new Thickness(0, 0, 0, 0);
        libWpf.Text("K1", 4, 2, 12, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.ImageMarginBindingVisibility("VentilElektrischEin.jpg", 4, 2, 12, 2, ventilRand, nameof(vmLap2010.VisibilityEinK1));
        libWpf.ImageMarginBindingVisibility("VentilElektrischAus.jpg", 4, 2, 12, 2, ventilRand, nameof(vmLap2010.VisibilityAusK1));


        libWpf.RectangleFill(10, 6, 2, 6, Brushes.Coral);
        libWpf.RectangleFillBindingMargin(10, 6, 2, 6, Brushes.BurlyWood, nameof(vmLap2010.Fuellstand));

        libWpf.RectangleBindingFill(12, 2, 8, 2, nameof(vmLap2010.BrushZuleitung));

        libWpf.Text("K2", 8, 2, 12, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.ImageMarginBindingVisibility("VentilElektrischEin.jpg", 10, 2, 12, 2, ventilRand, nameof(vmLap2010.VisibilityEinK2));
        libWpf.ImageMarginBindingVisibility("VentilElektrischAus.jpg", 10, 2, 12, 2, ventilRand, nameof(vmLap2010.VisibilityAusK2));


        // libWpf.PlcError();
    }
}