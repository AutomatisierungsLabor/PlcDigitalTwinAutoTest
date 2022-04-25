﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using LibConfigPlc;

namespace LibDisplayPlc.PlcZeichnen;

public partial class PlcZeichnen
{
    private readonly Grid _plcGrid;

    private const int SchriftGanzGross = 50;
    private const int SchriftGross = 25;
    private const int SchriftKlein = 18;
    private const int AbstandY = 30;

    public PlcZeichnen(Grid plcGrid) => _plcGrid = plcGrid;
    public void Zeichnen(ConfigPlc configPlc)
    {
        var libWpf = new LibWpf.LibWpf(_plcGrid);

        if (configPlc.Aa.AnzZeilen > 0 || configPlc.Ai.AnzZeilen > 0)
        {
            libWpf.GridZeichnen(30, 30, 28, 30, true);
            libWpf.RectangleFill(1, 30, 8, 12, Brushes.LightGray);
        }
        else
        {
            libWpf.GridZeichnen(21, 30, 28, 30, true);
            libWpf.RectangleFill(1, 19, 8, 12, Brushes.LightGray);
        }


        PlcAiZeichnen(libWpf, configPlc, 20, 8);
        PlcDiZeichnen(libWpf, "Di0", "a", "StringWertDi0", 2, 2);
        PlcDiZeichnen(libWpf, "Di1", "b", "StringWertDi1", 11, 2);

        libWpf.Text("S7-1214 DC/DC/DC", 2, 18, 12, 4, HorizontalAlignment.Center, VerticalAlignment.Center, SchriftGanzGross, Brushes.White);

        PlcAaZeichnen(libWpf, configPlc, 20, 16);
        PlcDaZeichnen(libWpf, "Da0", "a", "StringWertDa0", 2, 16);
        PlcDaZeichnen(libWpf, "Da1", "b", "StringWertDa1", 11, 16);
    }
}