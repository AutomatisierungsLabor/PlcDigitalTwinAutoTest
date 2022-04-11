using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using DtNadeltelegraph.ViewModel;

namespace DtNadeltelegraph.TabZeichnen;

public partial class TabZeichnen
{
    private enum RichtungLinie
    {
        RechtsOben = 0,
        RechtsUnten = 1,
        LinksOben = 2,
        LinksUnten = 3
    }

    private const double AbstandRaster = 30;
    private const double ObererRandRaute = 1 * AbstandRaster;
    private const double LinkerRandRaute = 1 * AbstandRaster;
    private const double BreiteRaute = 26 * AbstandRaster;
    private const double HoeheRaute = 30 * AbstandRaster;

    private const double ObererRandZeiger = 20;
    private const double LinkerRandZeiger = 20;
    private const double BreiteZeiger = 20;
    private const double HoeheZeiger = 80;

    private const double LaengeLinie1 = 525;
    private const double LaengeLinie2 = 410;
    private const double LaengeLinie3 = 295;
    private const double LaengeLinie4 = 180;
    public static void TabSimulationZeichnen(VmNadeltelegraph vmNadeltelegraph, TabItem tabItem, string hintergrund)
    {
        var libWpf = new LibWpf.LibWpf(tabItem);
        libWpf.SetBackground(new BrushConverter().ConvertFromString(hintergrund) as SolidColorBrush);
        libWpf.GridZeichnen(35, AbstandRaster, 32, AbstandRaster, true);

        libWpf.Polygon(0, 30, 0, 35, Brushes.Gray, Brushes.Black, 5, new[] {
            new[] { LinkerRandRaute, ObererRandRaute + HoeheRaute / 2},
            new[] { LinkerRandRaute + BreiteRaute / 2, ObererRandRaute},
            new[] { LinkerRandRaute + BreiteRaute, ObererRandRaute + HoeheRaute / 2},
            new[] { LinkerRandRaute + BreiteRaute / 2, ObererRandRaute + HoeheRaute} });

        var formZeiger = new[]
        {
            new[] { LinkerRandZeiger, ObererRandZeiger + HoeheZeiger / 2 },
            new[] { LinkerRandZeiger + BreiteZeiger / 2, ObererRandZeiger + HoeheZeiger },
            new[] { LinkerRandZeiger + BreiteZeiger, ObererRandZeiger + HoeheZeiger / 2 },
            new[] { LinkerRandZeiger + BreiteZeiger / 2, ObererRandZeiger  }
        };

        libWpf.PolygonSetWinkel(3, 2, 14, 4, Brushes.Yellow, Brushes.Black, 2, formZeiger, nameof(vmNadeltelegraph.WinkelZeiger1));
        libWpf.PolygonSetWinkel(8, 2, 14, 4, Brushes.Yellow, Brushes.Black, 2, formZeiger, nameof(vmNadeltelegraph.WinkelZeiger2));
        libWpf.PolygonSetWinkel(13, 2, 14, 4, Brushes.Yellow, Brushes.Black, 2, formZeiger, nameof(vmNadeltelegraph.WinkelZeiger3));
        libWpf.PolygonSetWinkel(18, 2, 14, 4, Brushes.Yellow, Brushes.Black, 2, formZeiger, nameof(vmNadeltelegraph.WinkelZeiger4));
        libWpf.PolygonSetWinkel(23, 2, 14, 4, Brushes.Yellow, Brushes.Black, 2, formZeiger, nameof(vmNadeltelegraph.WinkelZeiger5));

        // Linien nach rechts oben
        libWpf.LinieSetVisibility(1, 30, 1, 30, 3 * AbstandRaster, HoeheRaute / 2, 3 * AbstandRaster + LinieX(LaengeLinie1, RichtungLinie.RechtsOben), LinieY(LaengeLinie1, RichtungLinie.RechtsOben), 5, Brushes.Orange, nameof(vmNadeltelegraph.VisibilityLinieRechtsOben1));
        libWpf.LinieSetVisibility(1, 30, 1, 30, 8 * AbstandRaster, HoeheRaute / 2, 8 * AbstandRaster + LinieX(LaengeLinie2, RichtungLinie.RechtsOben), LinieY(LaengeLinie2, RichtungLinie.RechtsOben), 5, Brushes.OrangeRed, nameof(vmNadeltelegraph.VisibilityLinieRechtsOben2));
        libWpf.LinieSetVisibility(1, 30, 1, 30, 13 * AbstandRaster, HoeheRaute / 2, 13 * AbstandRaster + LinieX(LaengeLinie3, RichtungLinie.RechtsOben), LinieY(LaengeLinie3, RichtungLinie.RechtsOben), 5, Brushes.Red, nameof(vmNadeltelegraph.VisibilityLinieRechtsOben3));
        libWpf.LinieSetVisibility(1, 30, 1, 30, 18 * AbstandRaster, HoeheRaute / 2, 18 * AbstandRaster + LinieX(LaengeLinie4, RichtungLinie.RechtsOben), LinieY(LaengeLinie4, RichtungLinie.RechtsOben), 5, Brushes.OrangeRed, nameof(vmNadeltelegraph.VisibilityLinieRechtsOben4));

        libWpf.LinieSetVisibility(1, 30, 1, 30, 3 * AbstandRaster, HoeheRaute / 2, 3 * AbstandRaster + LinieX(LaengeLinie1, RichtungLinie.RechtsUnten), LinieY(LaengeLinie1, RichtungLinie.RechtsUnten), 5, Brushes.Orange, nameof(vmNadeltelegraph.VisibilityLinieRechtsUnten1));
        libWpf.LinieSetVisibility(1, 30, 1, 30, 8 * AbstandRaster, HoeheRaute / 2, 8 * AbstandRaster + LinieX(LaengeLinie2, RichtungLinie.RechtsUnten), LinieY(LaengeLinie2, RichtungLinie.RechtsUnten), 5, Brushes.OrangeRed, nameof(vmNadeltelegraph.VisibilityLinieRechtsUnten2));
        libWpf.LinieSetVisibility(1, 30, 1, 30, 13 * AbstandRaster, HoeheRaute / 2, 13 * AbstandRaster + LinieX(LaengeLinie3, RichtungLinie.RechtsUnten), LinieY(LaengeLinie3, RichtungLinie.RechtsUnten), 5, Brushes.Red, nameof(vmNadeltelegraph.VisibilityLinieRechtsUnten3));
        libWpf.LinieSetVisibility(1, 30, 1, 30, 18 * AbstandRaster, HoeheRaute / 2, 18 * AbstandRaster + LinieX(LaengeLinie4, RichtungLinie.RechtsUnten), LinieY(LaengeLinie4, RichtungLinie.RechtsUnten), 5, Brushes.OrangeRed, nameof(vmNadeltelegraph.VisibilityLinieRechtsUnten4));

        libWpf.LinieSetVisibility(1, 30, 1, 30, 8 * AbstandRaster, HoeheRaute / 2, 8 * AbstandRaster + LinieX(LaengeLinie4, RichtungLinie.LinksOben), LinieY(LaengeLinie4, RichtungLinie.LinksOben), 5, Brushes.OrangeRed, nameof(vmNadeltelegraph.VisibilityLinieLinksOben1));
        libWpf.LinieSetVisibility(1, 30, 1, 30, 13 * AbstandRaster, HoeheRaute / 2, 13 * AbstandRaster + LinieX(LaengeLinie3, RichtungLinie.LinksOben), LinieY(LaengeLinie3, RichtungLinie.LinksOben), 5, Brushes.Red, nameof(vmNadeltelegraph.VisibilityLinieLinksOben2));
        libWpf.LinieSetVisibility(1, 30, 1, 30, 18 * AbstandRaster, HoeheRaute / 2, 18 * AbstandRaster + LinieX(LaengeLinie2, RichtungLinie.LinksOben), LinieY(LaengeLinie2, RichtungLinie.LinksOben), 5, Brushes.OrangeRed, nameof(vmNadeltelegraph.VisibilityLinieLinksOben3));
        libWpf.LinieSetVisibility(1, 30, 1, 30, 23 * AbstandRaster, HoeheRaute / 2, 23 * AbstandRaster + LinieX(LaengeLinie1, RichtungLinie.LinksOben), LinieY(LaengeLinie1, RichtungLinie.LinksOben), 5, Brushes.Orange, nameof(vmNadeltelegraph.VisibilityLinieLinksOben4));

        libWpf.LinieSetVisibility(1, 30, 1, 30, 8 * AbstandRaster, HoeheRaute / 2, 8 * AbstandRaster + LinieX(LaengeLinie4, RichtungLinie.LinksUnten), LinieY(LaengeLinie4, RichtungLinie.LinksUnten), 5, Brushes.OrangeRed, nameof(vmNadeltelegraph.VisibilityLinieLinksUnten1));
        libWpf.LinieSetVisibility(1, 30, 1, 30, 13 * AbstandRaster, HoeheRaute / 2, 13 * AbstandRaster + LinieX(LaengeLinie3, RichtungLinie.LinksUnten), LinieY(LaengeLinie3, RichtungLinie.LinksUnten), 5, Brushes.Red, nameof(vmNadeltelegraph.VisibilityLinieLinksUnten2));
        libWpf.LinieSetVisibility(1, 30, 1, 30, 18 * AbstandRaster, HoeheRaute / 2, 18 * AbstandRaster + LinieX(LaengeLinie2, RichtungLinie.LinksUnten), LinieY(LaengeLinie2, RichtungLinie.LinksUnten), 5, Brushes.OrangeRed, nameof(vmNadeltelegraph.VisibilityLinieLinksUnten3));
        libWpf.LinieSetVisibility(1, 30, 1, 30, 23 * AbstandRaster, HoeheRaute / 2, 23 * AbstandRaster + LinieX(LaengeLinie1, RichtungLinie.LinksUnten), LinieY(LaengeLinie1, RichtungLinie.LinksUnten), 5, Brushes.Orange, nameof(vmNadeltelegraph.VisibilityLinieLinksUnten4));

        BuchstabeZeichnen(13, 3.5, libWpf, vmNadeltelegraph.ButtonTasterCommand, "A");
        BuchstabeZeichnen(10.4, 6.5, libWpf, vmNadeltelegraph.ButtonTasterCommand, "B");
        BuchstabeZeichnen(15.4, 6.5, libWpf, vmNadeltelegraph.ButtonTasterCommand, "D");
        BuchstabeZeichnen(8, 9.3, libWpf, vmNadeltelegraph.ButtonTasterCommand, "E");
        BuchstabeZeichnen(13, 9.3, libWpf, vmNadeltelegraph.ButtonTasterCommand, "F");
        BuchstabeZeichnen(17.9, 9.3, libWpf, vmNadeltelegraph.ButtonTasterCommand, "G");
        BuchstabeZeichnen(5.5, 12.1, libWpf, vmNadeltelegraph.ButtonTasterCommand, "H");
        BuchstabeZeichnen(10.4, 12.1, libWpf, vmNadeltelegraph.ButtonTasterCommand, "I");
        BuchstabeZeichnen(15.4, 12.1, libWpf, vmNadeltelegraph.ButtonTasterCommand, "K");
        BuchstabeZeichnen(20.5, 12.1, libWpf, vmNadeltelegraph.ButtonTasterCommand, "L");
        BuchstabeZeichnen(5.5, 18, libWpf, vmNadeltelegraph.ButtonTasterCommand, "M");
        BuchstabeZeichnen(10.4, 18, libWpf, vmNadeltelegraph.ButtonTasterCommand, "N");
        BuchstabeZeichnen(15.4, 18, libWpf, vmNadeltelegraph.ButtonTasterCommand, "O");
        BuchstabeZeichnen(20.5, 18, libWpf, vmNadeltelegraph.ButtonTasterCommand, "P");
        BuchstabeZeichnen(8, 21, libWpf, vmNadeltelegraph.ButtonTasterCommand, "R");
        BuchstabeZeichnen(13, 21, libWpf, vmNadeltelegraph.ButtonTasterCommand, "S");
        BuchstabeZeichnen(17.9, 21, libWpf, vmNadeltelegraph.ButtonTasterCommand, "T");
        BuchstabeZeichnen(10.4, 23.9, libWpf, vmNadeltelegraph.ButtonTasterCommand, "V");
        BuchstabeZeichnen(15.4, 23.9, libWpf, vmNadeltelegraph.ButtonTasterCommand, "W");
        BuchstabeZeichnen(13, 26.5, libWpf, vmNadeltelegraph.ButtonTasterCommand, "Y");

        libWpf.TextSetContent(20, 15, 2, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 30, Brushes.BlueViolet, nameof(vmNadeltelegraph.AsciiCode));

        //  libWpf.PlcError();
    }
    private static double LinieX(double laenge, RichtungLinie richtung)
    {
        var winkel = Math.Atan(HoeheRaute / BreiteRaute);
        var x = laenge * Math.Cos(winkel);

        return richtung switch
        {
            RichtungLinie.RechtsOben => x,
            RichtungLinie.RechtsUnten => x,
            RichtungLinie.LinksOben => -x,
            RichtungLinie.LinksUnten => -x,
            _ => throw new ArgumentOutOfRangeException(nameof(richtung), richtung, null)
        };
    }
    private static double LinieY(double laenge, RichtungLinie richtung)
    {
        var winkel = Math.Atan(HoeheRaute / BreiteRaute);
        var y = laenge * Math.Sin(winkel);

        return richtung switch
        {
            RichtungLinie.RechtsOben => HoeheRaute / 2 - y,
            RichtungLinie.RechtsUnten => HoeheRaute / 2 + y,
            RichtungLinie.LinksOben => HoeheRaute / 2 - y,
            RichtungLinie.LinksUnten => HoeheRaute / 2 + y,
            _ => throw new ArgumentOutOfRangeException(nameof(richtung), richtung, null)
        };
    }
    private static void BuchstabeZeichnen(double x, double y, LibWpf.LibWpf libWpf, ICommand vmCommand, string stringBuchstabe)
    {
        const double gesamteBreite = 30 * AbstandRaster;
        const double gesamteHoehe = 30 * AbstandRaster;
        const double width = 2 * AbstandRaster;
        const double height = 2 * AbstandRaster;
        var linkerRand = x * AbstandRaster;
        var obererRand = y * AbstandRaster;

        var thickness = new Thickness(
            linkerRand,
            obererRand,
            gesamteBreite - linkerRand - width,
            gesamteHoehe - obererRand - height
        );

        libWpf.ButtonBackgroundContentMarginRounded(stringBuchstabe, 0, 30, 0, 30, 20, 10, Brushes.LightGray, thickness, vmCommand, stringBuchstabe, $"ClickModeBuchstabe{stringBuchstabe}");
    }
}