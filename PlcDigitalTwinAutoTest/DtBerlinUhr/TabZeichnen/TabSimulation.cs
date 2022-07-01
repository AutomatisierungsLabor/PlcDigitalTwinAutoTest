using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DtBerlinUhr.ViewModel;

namespace DtBerlinUhr.TabZeichnen;

public partial class TabZeichnen
{
    public static void TabSimulationZeichnen(VmBerlinUhr vmBerlinUhr, TabItem tabItem, string hintergrund)
    {
        var libWpf = new LibWpf.LibWpf(tabItem);
        libWpf.SetBackground(new BrushConverter().ConvertFromString(hintergrund) as SolidColorBrush);
        libWpf.GridZeichnen(50, 40, false, false, false);



        ///////////////////////////////////////////////////////////
        //
        // Bedienung - Rechts
        //
        ///////////////////////////////////////////////////////////

        libWpf.RectangleFill(16, 20, 1, 20, Brushes.LightGray);

        libWpf.Text("Geschwindigkeit", 17, 10, 1, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.SliderMarginBindingValue(17, 10, 3, 1, Brushes.DarkGray, new Thickness(0, 0, 0, 0), 1, 10000, nameof(vmBerlinUhr.DoubleGeschwindigkeit));

        libWpf.ButtonBackgroundContentMarginRounded("Aktuelle Zeit übernehmen", 28, 8, 2, 2, 20, 15, Brushes.Violet, new Thickness(0, 0, 0, 0), vmBerlinUhr.ButtonTasterCommand, "AktuelleZeitUebernehmen", nameof(vmBerlinUhr.ClickAktuelleZeitUebernehmen));

        const int posUhrX = 17;
        const int posUhrY = 5;
        const int breiteUhr = 14;
        const int hoeheUhr = 14;

        libWpf.EllipseFill(posUhrX, breiteUhr, posUhrY, hoeheUhr, Brushes.White);


        const double halbeBreiteUhrPixel = breiteUhr * 15;
        const double halbeHoeheUhrPixel = hoeheUhr * 15;

        const double halbeBreiteMinutenStrich = 1;
        const double hoeheMinuntenStrich = 10;
        var formMinutenStrich = new[]
        {
            new [] { halbeBreiteUhrPixel - halbeBreiteMinutenStrich, 0},
            new [] { halbeBreiteUhrPixel + halbeBreiteMinutenStrich, 0},
            new [] { halbeBreiteUhrPixel + halbeBreiteMinutenStrich, hoeheMinuntenStrich},
            new [] { halbeBreiteUhrPixel - halbeBreiteMinutenStrich, hoeheMinuntenStrich}
        };

        const double halbeBreiteStundenStrich = 4;
        const double hoeheStundenStrich = 30;
        var formStundenStrich = new[]
        {
            new [] { halbeBreiteUhrPixel - halbeBreiteStundenStrich ,0  },
            new [] { halbeBreiteUhrPixel + halbeBreiteStundenStrich, 0},
            new [] { halbeBreiteUhrPixel + halbeBreiteStundenStrich, hoeheStundenStrich },
            new [] { halbeBreiteUhrPixel - halbeBreiteStundenStrich, hoeheStundenStrich}
        };

        for (double i = 0; i < 360; i += 30) libWpf.PolygonWinkel(posUhrX, breiteUhr, posUhrY, hoeheUhr, Brushes.Black, Brushes.Black, 0, formStundenStrich, i);
        for (double i = 0; i < 360; i += 6) libWpf.PolygonWinkel(posUhrX, breiteUhr, posUhrY, hoeheUhr, Brushes.Black, Brushes.Black, 0, formMinutenStrich, i);

        const double halbeBreiteMinutenzeigerOben = 3;
        const double halbeBreiteMinutenzeigerMitte = 4;
        const double untenMinutenZeiger = 20;
        const double obenMinutenZeiger = 8 * 30;
        var formMinutenZeiger = new[]
        {
            new [] { halbeBreiteUhrPixel - halbeBreiteMinutenzeigerOben, obenMinutenZeiger},
            new [] { halbeBreiteUhrPixel + halbeBreiteMinutenzeigerOben, obenMinutenZeiger},
            new [] { halbeBreiteUhrPixel + halbeBreiteMinutenzeigerMitte,halbeHoeheUhrPixel},
            new [] { halbeBreiteUhrPixel + halbeBreiteMinutenzeigerOben, untenMinutenZeiger},
            new [] { halbeBreiteUhrPixel - halbeBreiteMinutenzeigerOben, untenMinutenZeiger},
            new [] { halbeBreiteUhrPixel - halbeBreiteMinutenzeigerMitte,halbeHoeheUhrPixel}
        };

        const double halbeBreiteStundenzeigerOben = 5;
        const double halbeBreiteStundenzeigerMitte = 7;
        const double untenStundenZeiger = 35;
        const double obenStundenZeiger = 8 * 30;
        var formStundenZeiger = new[]
        {
            new [] { halbeBreiteUhrPixel - halbeBreiteStundenzeigerOben, obenStundenZeiger},
            new [] { halbeBreiteUhrPixel + halbeBreiteStundenzeigerOben, obenStundenZeiger},
            new [] { halbeBreiteUhrPixel + halbeBreiteStundenzeigerMitte, halbeHoeheUhrPixel},
            new [] { halbeBreiteUhrPixel + halbeBreiteStundenzeigerOben, untenStundenZeiger},
            new [] { halbeBreiteUhrPixel - halbeBreiteStundenzeigerOben, untenStundenZeiger},
            new [] { halbeBreiteUhrPixel - halbeBreiteStundenzeigerMitte, halbeHoeheUhrPixel}
        };

        const double halbeBreiteSekundenzeiger = 2;
        const double obenSekundenzeiger = 20;
        const double untenSekundenzeiger = 8 * 30;
        var formSekundenZeiger = new[]
        {
            new[] { halbeBreiteUhrPixel - halbeBreiteSekundenzeiger, obenSekundenzeiger },
            new[] { halbeBreiteUhrPixel + halbeBreiteSekundenzeiger, obenSekundenzeiger },
            new[] { halbeBreiteUhrPixel + halbeBreiteSekundenzeiger, untenSekundenzeiger },
            new[] { halbeBreiteUhrPixel - halbeBreiteSekundenzeiger, untenSekundenzeiger }
        };

        libWpf.PolygonBindingWinkel(posUhrX, breiteUhr, posUhrY, hoeheUhr, Brushes.Black, Brushes.Black, 0, formStundenZeiger, nameof(vmBerlinUhr.DoubleWinkelStundenZeiger));
        libWpf.PolygonBindingWinkel(posUhrX, breiteUhr, posUhrY, hoeheUhr, Brushes.Black, Brushes.Black, 0, formMinutenZeiger, nameof(vmBerlinUhr.DoubleWinkelMinutenZeiger));
        libWpf.PolygonBindingWinkel(posUhrX, breiteUhr, posUhrY, hoeheUhr, Brushes.Red, Brushes.Red, 0, formSekundenZeiger, nameof(vmBerlinUhr.DoubleWinkelSekundenZeiger));

        libWpf.EllipseFillRadiusBindingWinkel(posUhrX, breiteUhr, posUhrY, hoeheUhr, Brushes.Red, 15, 23, nameof(vmBerlinUhr.DoubleWinkelSekundenZeigerKreisOderSo));



        ///////////////////////////////////////////////////////////
        //
        //  Simulation - Links
        //
        ///////////////////////////////////////////////////////////


        libWpf.RectangleFill(1, 13, 1, 17, Brushes.LightGray);


        var farbeRand = Brushes.Black;
        var randSegment = new Thickness(2, 2, 2, 2);

        var randSegment1 = new Thickness(2, 2, 250, 2);
        var randSegment2 = new Thickness(84, 2, 168, 2);
        var randSegment3 = new Thickness(166, 2, 86, 2);
        var randSegment4 = new Thickness(248, 2, 2, 2);

        libWpf.EllipseStrokeBindingFilling(6, 3, 2, 3, farbeRand, 2, nameof(vmBerlinUhr.BrushSegmentSekunde));

        libWpf.RectangleMarginStrokeBindingFill(2, 11, 6, 2, randSegment1, farbeRand, 2, nameof(vmBerlinUhr.BrushSegment5Stunden1));
        libWpf.RectangleMarginStrokeBindingFill(2, 11, 6, 2, randSegment2, farbeRand, 2, nameof(vmBerlinUhr.BrushSegment5Stunden2));
        libWpf.RectangleMarginStrokeBindingFill(2, 11, 6, 2, randSegment3, farbeRand, 2, nameof(vmBerlinUhr.BrushSegment5Stunden3));
        libWpf.RectangleMarginStrokeBindingFill(2, 11, 6, 2, randSegment4, farbeRand, 2, nameof(vmBerlinUhr.BrushSegment5Stunden4));

        libWpf.RectangleMarginStrokeBindingFill(2, 11, 9, 2, randSegment1, farbeRand, 2, nameof(vmBerlinUhr.BrushSegment1Stunde1));
        libWpf.RectangleMarginStrokeBindingFill(2, 11, 9, 2, randSegment2, farbeRand, 2, nameof(vmBerlinUhr.BrushSegment1Stunde2));
        libWpf.RectangleMarginStrokeBindingFill(2, 11, 9, 2, randSegment3, farbeRand, 2, nameof(vmBerlinUhr.BrushSegment1Stunde3));
        libWpf.RectangleMarginStrokeBindingFill(2, 11, 9, 2, randSegment4, farbeRand, 2, nameof(vmBerlinUhr.BrushSegment1Stunde4));


        libWpf.RectangleMarginStrokeBindingFill(2, 1, 12, 2, randSegment, farbeRand, 2, nameof(vmBerlinUhr.BrushSegment5Minuten1));
        libWpf.RectangleMarginStrokeBindingFill(3, 1, 12, 2, randSegment, farbeRand, 2, nameof(vmBerlinUhr.BrushSegment5Minuten2));
        libWpf.RectangleMarginStrokeBindingFill(4, 1, 12, 2, randSegment, farbeRand, 2, nameof(vmBerlinUhr.BrushSegment5Minuten3));
        libWpf.RectangleMarginStrokeBindingFill(5, 1, 12, 2, randSegment, farbeRand, 2, nameof(vmBerlinUhr.BrushSegment5Minuten4));
        libWpf.RectangleMarginStrokeBindingFill(6, 1, 12, 2, randSegment, farbeRand, 2, nameof(vmBerlinUhr.BrushSegment5Minuten5));
        libWpf.RectangleMarginStrokeBindingFill(7, 1, 12, 2, randSegment, farbeRand, 2, nameof(vmBerlinUhr.BrushSegment5Minuten6));
        libWpf.RectangleMarginStrokeBindingFill(8, 1, 12, 2, randSegment, farbeRand, 2, nameof(vmBerlinUhr.BrushSegment5Minuten7));
        libWpf.RectangleMarginStrokeBindingFill(9, 1, 12, 2, randSegment, farbeRand, 2, nameof(vmBerlinUhr.BrushSegment5Minuten8));
        libWpf.RectangleMarginStrokeBindingFill(10, 1, 12, 2, randSegment, farbeRand, 2, nameof(vmBerlinUhr.BrushSegment5Minuten9));
        libWpf.RectangleMarginStrokeBindingFill(11, 1, 12, 2, randSegment, farbeRand, 2, nameof(vmBerlinUhr.BrushSegment5Minuten10));
        libWpf.RectangleMarginStrokeBindingFill(12, 1, 12, 2, randSegment, farbeRand, 2, nameof(vmBerlinUhr.BrushSegment5Minuten11));

        libWpf.RectangleMarginStrokeBindingFill(2, 11, 15, 2, randSegment1, farbeRand, 2, nameof(vmBerlinUhr.BrushSegment1Minute1));
        libWpf.RectangleMarginStrokeBindingFill(2, 11, 15, 2, randSegment2, farbeRand, 2, nameof(vmBerlinUhr.BrushSegment1Minute2));
        libWpf.RectangleMarginStrokeBindingFill(2, 11, 15, 2, randSegment3, farbeRand, 2, nameof(vmBerlinUhr.BrushSegment1Minute3));
        libWpf.RectangleMarginStrokeBindingFill(2, 11, 15, 2, randSegment4, farbeRand, 2, nameof(vmBerlinUhr.BrushSegment1Minute4));

        libWpf.PlcError();
    }
}