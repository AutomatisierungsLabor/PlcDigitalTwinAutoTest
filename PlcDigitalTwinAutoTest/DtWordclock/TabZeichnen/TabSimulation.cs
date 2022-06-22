using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DtWordclock.ViewModel;

namespace DtWordclock.TabZeichnen;

public partial class TabZeichnen
{
    public static void TabSimulationZeichnen(VmWordclock vmWordclock, TabItem tabItem, string hintergrund)
    {
        var libWpf = new LibWpf.LibWpf(tabItem);
        libWpf.SetBackground(new BrushConverter().ConvertFromString(hintergrund) as SolidColorBrush);
        libWpf.GridZeichnen(50, 40, false, false, true);



        ///////////////////////////////////////////////////////////
        //
        // Bedienung - Rechts
        //
        ///////////////////////////////////////////////////////////

        libWpf.RectangleFill(20, 20, 1, 20, Brushes.LightGray);

        libWpf.Text("Geschwindigkeit", 21, 10, 1, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.SliderMargin(21, 10, 3, 1, Brushes.Cyan, new Thickness(0, 0, 0, 0), 1, 10000, nameof(vmWordclock.DoubleGeschwindigkeit));

        libWpf.ButtonBackgroundContentMarginRounded("Aktuelle Zeit übernehmen", 32, 8, 2, 2, 20, 15, Brushes.Violet, new Thickness(0, 0, 0, 0), vmWordclock.ButtonTasterCommand, "AktuelleZeitUebernehmen", nameof(vmWordclock.ClickAktuelleZeitUebernehmen));

        const int posUhrX = 21;
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

        libWpf.PolygonSetWinkel(posUhrX, breiteUhr, posUhrY, hoeheUhr, Brushes.Black, Brushes.Black, 0, formStundenZeiger, nameof(vmWordclock.DoubleWinkelStundenZeiger));
        libWpf.PolygonSetWinkel(posUhrX, breiteUhr, posUhrY, hoeheUhr, Brushes.Black, Brushes.Black, 0, formMinutenZeiger, nameof(vmWordclock.DoubleWinkelMinutenZeiger));
        libWpf.PolygonSetWinkel(posUhrX, breiteUhr, posUhrY, hoeheUhr, Brushes.Red, Brushes.Red, 0, formSekundenZeiger, nameof(vmWordclock.DoubleWinkelSekundenZeiger));

        libWpf.EllipseFillRadiusSetWinkel(posUhrX, breiteUhr, posUhrY, hoeheUhr, Brushes.Red, 5, nameof(vmWordclock.DoubleWinkelSekundenZeiger));



        ///////////////////////////////////////////////////////////
        //
        //  Simulation - Links
        //
        ///////////////////////////////////////////////////////////


        libWpf.RectangleFill(1, 18, 1, 20, Brushes.LightGray);
        const int schriftGroesse = 30;
        var zeilenNummer = 1;
        const int zeileLinks = 1;
        const int zeilenBreite = 20;
        const int zeilenHoehe = 2;

        // Zeile 1
        libWpf.TextMarginMonospacedSetForeground("ES", zeileLinks, zeilenBreite, zeilenNummer, zeilenHoehe, HorizontalAlignment.Left, VerticalAlignment.Top, schriftGroesse, new Thickness(0, 0, 0, 0), nameof(vmWordclock.BrushEs));
        libWpf.TextMarginMonospaced("L", zeileLinks, zeilenBreite, zeilenNummer, zeilenHoehe, HorizontalAlignment.Left, VerticalAlignment.Top, schriftGroesse, Brushes.Violet, new Thickness(30, 0, 0, 0));

        libWpf.TextMarginMonospacedSetForeground("IST", zeileLinks, zeilenBreite, zeilenNummer, zeilenHoehe, HorizontalAlignment.Left, VerticalAlignment.Top, schriftGroesse, new Thickness(50, 0, 0, 0), nameof(vmWordclock.BrushIst));
        libWpf.TextMarginMonospaced("A", zeileLinks, zeilenBreite, zeilenNummer, zeilenHoehe, HorizontalAlignment.Left, VerticalAlignment.Top, schriftGroesse, Brushes.Violet, new Thickness(80, 0, 0, 0));

        libWpf.TextMarginMonospacedSetForeground("BALD", zeileLinks, zeilenBreite, zeilenNummer, zeilenHoehe, HorizontalAlignment.Left, VerticalAlignment.Top, schriftGroesse, new Thickness(100, 0, 0, 0), nameof(vmWordclock.BrushBald));
        libWpf.TextMarginMonospaced("N", zeileLinks, zeilenBreite, zeilenNummer, zeilenHoehe, HorizontalAlignment.Left, VerticalAlignment.Top, schriftGroesse, Brushes.Violet, new Thickness(130, 0, 0, 0));

        libWpf.TextMarginMonospacedSetForeground("GLEICH", zeileLinks, zeilenBreite, zeilenNummer, zeilenHoehe, HorizontalAlignment.Left, VerticalAlignment.Top, schriftGroesse, new Thickness(200, 0, 0, 0), nameof(vmWordclock.BrushGleich));
        libWpf.TextMarginMonospaced("DE", zeileLinks, zeilenBreite, zeilenNummer, zeilenHoehe, HorizontalAlignment.Left, VerticalAlignment.Top, schriftGroesse, Brushes.Violet, new Thickness(230, 0, 0, 0));


        // Zeile 2
        zeilenNummer++;
        libWpf.TextMarginMonospacedSetForeground("VIERTEL", zeileLinks, zeilenBreite, zeilenNummer, zeilenHoehe, HorizontalAlignment.Left, VerticalAlignment.Top, schriftGroesse, new Thickness(0, 0, 0, 0), nameof(vmWordclock.BrushViertel));
        libWpf.TextMarginMonospaced("S", zeileLinks, zeilenBreite, zeilenNummer, zeilenHoehe, HorizontalAlignment.Left, VerticalAlignment.Top, schriftGroesse, Brushes.Violet, new Thickness(30, 0, 0, 0));

        libWpf.TextMarginMonospacedSetForeground("ZWANZIG", zeileLinks, zeilenBreite, zeilenNummer, zeilenHoehe, HorizontalAlignment.Left, VerticalAlignment.Top, schriftGroesse, new Thickness(100, 0, 0, 0), nameof(vmWordclock.BrushZwanzig));
        libWpf.TextMarginMonospaced("BERUFSSC", zeileLinks, zeilenBreite, zeilenNummer, zeilenHoehe, HorizontalAlignment.Left, VerticalAlignment.Top, schriftGroesse, Brushes.Violet, new Thickness(230, 0, 0, 0));

        // Zeile 3
        zeilenNummer++;
        libWpf.TextMarginMonospacedSetForeground("ZEHN", zeileLinks, zeilenBreite, zeilenNummer, zeilenHoehe, HorizontalAlignment.Left, VerticalAlignment.Top, schriftGroesse, new Thickness(0, 0, 0, 0), nameof(vmWordclock.BrushZehnMinute));
        libWpf.TextMarginMonospaced("S", zeileLinks, zeilenBreite, zeilenNummer, zeilenHoehe, HorizontalAlignment.Left, VerticalAlignment.Top, schriftGroesse, Brushes.Violet, new Thickness(30, 0, 0, 0));

        libWpf.TextMarginMonospacedSetForeground("FÜNF", zeileLinks, zeilenBreite, zeilenNummer, zeilenHoehe, HorizontalAlignment.Left, VerticalAlignment.Top, schriftGroesse, new Thickness(100, 0, 0, 0), nameof(vmWordclock.BrushFuenfMinute));
        libWpf.TextMarginMonospaced("C", zeileLinks, zeilenBreite, zeilenNummer, zeilenHoehe, HorizontalAlignment.Left, VerticalAlignment.Top, schriftGroesse, Brushes.Violet, new Thickness(230, 0, 0, 0));

        libWpf.TextMarginMonospacedSetForeground("VOR", zeileLinks, zeilenBreite, zeilenNummer, zeilenHoehe, HorizontalAlignment.Left, VerticalAlignment.Top, schriftGroesse, new Thickness(0, 0, 0, 0), nameof(vmWordclock.BrushVor));
        libWpf.TextMarginMonospaced("H", zeileLinks, zeilenBreite, zeilenNummer, zeilenHoehe, HorizontalAlignment.Left, VerticalAlignment.Top, schriftGroesse, Brushes.Violet, new Thickness(30, 0, 0, 0));

        libWpf.TextMarginMonospacedSetForeground("NACH", zeileLinks, zeilenBreite, zeilenNummer, zeilenHoehe, HorizontalAlignment.Left, VerticalAlignment.Top, schriftGroesse, new Thickness(100, 0, 0, 0), nameof(vmWordclock.BrushNach));
        libWpf.TextMarginMonospaced("UL", zeileLinks, zeilenBreite, zeilenNummer, zeilenHoehe, HorizontalAlignment.Left, VerticalAlignment.Top, schriftGroesse, Brushes.Violet, new Thickness(230, 0, 0, 0));


        // Zeile 4
        zeilenNummer++;
        libWpf.TextMarginMonospacedSetForeground("HALB", zeileLinks, zeilenBreite, zeilenNummer, zeilenHoehe, HorizontalAlignment.Left, VerticalAlignment.Top, schriftGroesse, new Thickness(0, 0, 0, 0), nameof(vmWordclock.BrushHalb));
        libWpf.TextMarginMonospaced("E", zeileLinks, zeilenBreite, zeilenNummer, zeilenHoehe, HorizontalAlignment.Left, VerticalAlignment.Top, schriftGroesse, Brushes.Violet, new Thickness(30, 0, 0, 0));

        libWpf.TextMarginMonospacedSetForeground("ZWÖLF", zeileLinks, zeilenBreite, zeilenNummer, zeilenHoehe, HorizontalAlignment.Left, VerticalAlignment.Top, schriftGroesse, new Thickness(100, 0, 0, 0), nameof(vmWordclock.BrushZwoelf));
        libWpf.TextMarginMonospaced("F", zeileLinks, zeilenBreite, zeilenNummer, zeilenHoehe, HorizontalAlignment.Left, VerticalAlignment.Top, schriftGroesse, Brushes.Violet, new Thickness(230, 0, 0, 0));

        libWpf.TextMarginMonospacedSetForeground("ELF", zeileLinks, zeilenBreite, zeilenNummer, zeilenHoehe, HorizontalAlignment.Left, VerticalAlignment.Top, schriftGroesse, new Thickness(0, 0, 0, 0), nameof(vmWordclock.BrushElf));
        libWpf.TextMarginMonospaced("E", zeileLinks, zeilenBreite, zeilenNummer, zeilenHoehe, HorizontalAlignment.Left, VerticalAlignment.Top, schriftGroesse, Brushes.Violet, new Thickness(30, 0, 0, 0));

        libWpf.TextMarginMonospacedSetForeground("ZEHN", zeileLinks, zeilenBreite, zeilenNummer, zeilenHoehe, HorizontalAlignment.Left, VerticalAlignment.Top, schriftGroesse, new Thickness(100, 0, 0, 0), nameof(vmWordclock.BrushZehnStunde));
        libWpf.TextMarginMonospaced("L", zeileLinks, zeilenBreite, zeilenNummer, zeilenHoehe, HorizontalAlignment.Left, VerticalAlignment.Top, schriftGroesse, Brushes.Violet, new Thickness(230, 0, 0, 0));

        // Zeile 5
        zeilenNummer++;
        libWpf.TextMarginMonospacedSetForeground("NEUN", zeileLinks, zeilenBreite, zeilenNummer, zeilenHoehe, HorizontalAlignment.Left, VerticalAlignment.Top, schriftGroesse, new Thickness(0, 0, 0, 0), nameof(vmWordclock.BrushNeun));
        libWpf.TextMarginMonospaced("D", zeileLinks, zeilenBreite, zeilenNummer, zeilenHoehe, HorizontalAlignment.Left, VerticalAlignment.Top, schriftGroesse, Brushes.Violet, new Thickness(30, 0, 0, 0));

        libWpf.TextMarginMonospacedSetForeground("ACHT", zeileLinks, zeilenBreite, zeilenNummer, zeilenHoehe, HorizontalAlignment.Left, VerticalAlignment.Top, schriftGroesse, new Thickness(100, 0, 0, 0), nameof(vmWordclock.BrushAcht));
        libWpf.TextMarginMonospaced("K", zeileLinks, zeilenBreite, zeilenNummer, zeilenHoehe, HorizontalAlignment.Left, VerticalAlignment.Top, schriftGroesse, Brushes.Violet, new Thickness(230, 0, 0, 0));

        libWpf.TextMarginMonospacedSetForeground("SIEBEN", zeileLinks, zeilenBreite, zeilenNummer, zeilenHoehe, HorizontalAlignment.Left, VerticalAlignment.Top, schriftGroesse, new Thickness(0, 0, 0, 0), nameof(vmWordclock.BrushSieben));
        libWpf.TextMarginMonospaced("IRCH", zeileLinks, zeilenBreite, zeilenNummer, zeilenHoehe, HorizontalAlignment.Left, VerticalAlignment.Top, schriftGroesse, Brushes.Violet, new Thickness(30, 0, 0, 0));

        // Zeile 6
        zeilenNummer++;
        libWpf.TextMarginMonospacedSetForeground("SECHS", zeileLinks, zeilenBreite, zeilenNummer, zeilenHoehe, HorizontalAlignment.Left, VerticalAlignment.Top, schriftGroesse, new Thickness(0, 0, 0, 0), nameof(vmWordclock.BrushSechs));
        libWpf.TextMarginMonospaced("E", zeileLinks, zeilenBreite, zeilenNummer, zeilenHoehe, HorizontalAlignment.Left, VerticalAlignment.Top, schriftGroesse, Brushes.Violet, new Thickness(30, 0, 0, 0));

        libWpf.TextMarginMonospacedSetForeground("FÜNF", zeileLinks, zeilenBreite, zeilenNummer, zeilenHoehe, HorizontalAlignment.Left, VerticalAlignment.Top, schriftGroesse, new Thickness(100, 0, 0, 0), nameof(vmWordclock.BrushFuenfStunde));
        libWpf.TextMarginMonospaced("L", zeileLinks, zeilenBreite, zeilenNummer, zeilenHoehe, HorizontalAlignment.Left, VerticalAlignment.Top, schriftGroesse, Brushes.Violet, new Thickness(230, 0, 0, 0));

        libWpf.TextMarginMonospacedSetForeground("VIER", zeileLinks, zeilenBreite, zeilenNummer, zeilenHoehe, HorizontalAlignment.Left, VerticalAlignment.Top, schriftGroesse, new Thickness(0, 0, 0, 0), nameof(vmWordclock.BrushVier));
        libWpf.TextMarginMonospaced("E", zeileLinks, zeilenBreite, zeilenNummer, zeilenHoehe, HorizontalAlignment.Left, VerticalAlignment.Top, schriftGroesse, Brushes.Violet, new Thickness(30, 0, 0, 0));

        libWpf.TextMarginMonospacedSetForeground("DREI", zeileLinks, zeilenBreite, zeilenNummer, zeilenHoehe, HorizontalAlignment.Left, VerticalAlignment.Top, schriftGroesse, new Thickness(100, 0, 0, 0), nameof(vmWordclock.BrushDrei));

        // Zeile 7
        zeilenNummer++;
        libWpf.TextMarginMonospacedSetForeground("ZWEI", zeileLinks, zeilenBreite, zeilenNummer, zeilenHoehe, HorizontalAlignment.Left, VerticalAlignment.Top, schriftGroesse, new Thickness(0, 0, 0, 0), nameof(vmWordclock.BrushZwei));
        libWpf.TextMarginMonospaced("K", zeileLinks, zeilenBreite, zeilenNummer, zeilenHoehe, HorizontalAlignment.Left, VerticalAlignment.Top, schriftGroesse, Brushes.Violet, new Thickness(30, 0, 0, 0));

        libWpf.TextMarginMonospacedSetForeground("EINS", zeileLinks, zeilenBreite, zeilenNummer, zeilenHoehe, HorizontalAlignment.Left, VerticalAlignment.Top, schriftGroesse, new Thickness(100, 0, 0, 0), nameof(vmWordclock.BrushEins));
        libWpf.TextMarginMonospaced("T", zeileLinks, zeilenBreite, zeilenNummer, zeilenHoehe, HorizontalAlignment.Left, VerticalAlignment.Top, schriftGroesse, Brushes.Violet, new Thickness(230, 0, 0, 0));

        libWpf.TextMarginMonospacedSetForeground("UHR", zeileLinks, zeilenBreite, zeilenNummer, zeilenHoehe, HorizontalAlignment.Left, VerticalAlignment.Top, schriftGroesse, new Thickness(0, 0, 0, 0), nameof(vmWordclock.BrushUhr));
        libWpf.TextMarginMonospaced("TECHNIK", zeileLinks, zeilenBreite, zeilenNummer, zeilenHoehe, HorizontalAlignment.Left, VerticalAlignment.Top, schriftGroesse, Brushes.Violet, new Thickness(30, 0, 0, 0));


        libWpf.PlcError();
    }

}