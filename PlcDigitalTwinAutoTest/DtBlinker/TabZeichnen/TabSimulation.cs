using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DtBlinker.ViewModel;

namespace DtBlinker.TabZeichnen;

public partial class TabZeichnen
{
    public static void TabSimulationZeichnen(Grid grid, bool gridSichtbar, string hintergrund)
    {
        var viewmodel = grid.DataContext as BasePlcDtAt.BaseViewModel.ViewModel ?? throw new ArgumentNullException($"{nameof(ViewModel)}", "Datacontext is not of type viewmodel");
        var libWpf = new LibWpf.LibWpf(grid);

        grid.Background = new BrushConverter().ConvertFromString(hintergrund) as SolidColorBrush;
        
        libWpf.Zeichnen(50, 20, 40, 20, gridSichtbar);

        var bilderRand = new Thickness(2, 2, 2, 2);

        libWpf.ButtonVis("S1", 2, 5, 2, 3, 20, bilderRand, viewmodel.BtnTaster, WpfObjects.S1, $"ClkMode[{(int)WpfObjects.S1}]");
        libWpf.ButtonVis("S2", 2, 5, 6, 3, 20, bilderRand, viewmodel.BtnTaster, WpfObjects.S2, $"ClkMode[{(int)WpfObjects.S2}]");
        libWpf.ButtonVis("S3", 2, 5, 10, 3, 20, bilderRand, viewmodel.BtnTaster, WpfObjects.S3, $"ClkMode[{(int)WpfObjects.S3}]");
        libWpf.ButtonVis("S4", 2, 5, 14, 3, 20, bilderRand, viewmodel.BtnTaster, WpfObjects.S4, $"ClkMode[{(int)WpfObjects.S4}]");


        libWpf.ButtonOnOffVis(2, 5, 18, 3, 10, "SchiebeSchalterOn.JPG", "SchiebeSchalterOff.JPG", new Thickness(2, 2, 2, 2), viewmodel.BtnSchalter, WpfObjects.S5);
        libWpf.ButtonOnOffVis(2, 5, 22, 3, 10, "SchiebeSchalterOn.JPG", "SchiebeSchalterOff.JPG", new Thickness(2, 2, 2, 2), viewmodel.BtnSchalter, WpfObjects.S6);
        libWpf.ButtonOnOffVis(2, 5, 26, 3, 10, "SchiebeSchalterOn.JPG", "SchiebeSchalterOff.JPG", new Thickness(2, 2, 2, 2), viewmodel.BtnSchalter, WpfObjects.S7);
        libWpf.ButtonOnOffVis(2, 5, 30, 3, 10, "SchiebeSchalterOn.JPG", "SchiebeSchalterOff.JPG", new Thickness(2, 2, 2, 2), viewmodel.BtnSchalter, WpfObjects.S8);

        var kontakteRand = new Thickness(0, 5, 5, 5);

        libWpf.BildVisAus("Taster_SchliesserHellgrau.jpg", 10, 2, 2, 3, kontakteRand, (int)WpfObjects.S1);
        libWpf.BildVisEin("Taster_BetaetigtHellgrau.jpg", 10, 2, 2, 3, kontakteRand, (int)WpfObjects.S1);

        libWpf.BildVisAus("Taster_SchliesserHellgrau.jpg", 10, 2, 6, 3, kontakteRand, (int)WpfObjects.S2);
        libWpf.BildVisEin("Taster_BetaetigtHellgrau.jpg", 10, 2, 6, 3, kontakteRand, (int)WpfObjects.S2);

        libWpf.BildVisAus("Taster_SchliesserHellgrau.jpg", 10, 2, 10, 3, kontakteRand, (int)WpfObjects.S3);
        libWpf.BildVisEin("Taster_BetaetigtHellgrau.jpg", 10, 2, 10, 3, kontakteRand, (int)WpfObjects.S3);

        libWpf.BildVisAus("Taster_SchliesserHellgrau.jpg", 10, 2, 14, 3, kontakteRand, (int)WpfObjects.S4);
        libWpf.BildVisEin("Taster_BetaetigtHellgrau.jpg", 10, 2, 14, 3, kontakteRand, (int)WpfObjects.S4);

        libWpf.BildVisAus("Taster_SchliesserHellgrau.jpg", 10, 2, 18, 3, kontakteRand, (int)WpfObjects.S5);
        libWpf.BildVisEin("Taster_BetaetigtHellgrau.jpg", 10, 2, 18, 3, kontakteRand, (int)WpfObjects.S5);

        libWpf.BildVisAus("Taster_SchliesserHellgrau.jpg", 10, 2, 22, 3, kontakteRand, (int)WpfObjects.S6);
        libWpf.BildVisEin("Taster_BetaetigtHellgrau.jpg", 10, 2, 22, 3, kontakteRand, (int)WpfObjects.S6);

        libWpf.BildVisAus("Taster_SchliesserHellgrau.jpg", 10, 2, 26, 3, kontakteRand, (int)WpfObjects.S7);
        libWpf.BildVisEin("Taster_BetaetigtHellgrau.jpg", 10, 2, 26, 3, kontakteRand, (int)WpfObjects.S7);

        libWpf.BildVisAus("Taster_SchliesserHellgrau.jpg", 10, 2, 30, 3, kontakteRand, (int)WpfObjects.S8);
        libWpf.BildVisEin("Taster_BetaetigtHellgrau.jpg", 10, 2, 30, 3, kontakteRand, (int)WpfObjects.S8);


        var kreisRand = new Thickness(2, 2, 2, 2);
        var kreisRandFarbe = new SolidColorBrush(Colors.Black);

        libWpf.KreisRandVis(20, 3, 2, 3, kreisRandFarbe, kreisRand, (int)WpfObjects.P1);
        libWpf.KreisRandVis(20, 3, 6, 3, kreisRandFarbe, kreisRand, (int)WpfObjects.P2);
        libWpf.KreisRandVis(20, 3, 10, 3, kreisRandFarbe, kreisRand, (int)WpfObjects.P3);
        libWpf.KreisRandVis(20, 3, 14, 3, kreisRandFarbe, kreisRand, (int)WpfObjects.P4);
        libWpf.KreisRandVis(20, 3, 18, 3, kreisRandFarbe, kreisRand, (int)WpfObjects.P5);
        libWpf.KreisRandVis(20, 3, 22, 3, kreisRandFarbe, kreisRand, (int)WpfObjects.P6);
        libWpf.KreisRandVis(20, 3, 26, 3, kreisRandFarbe, kreisRand, (int)WpfObjects.P7);
        libWpf.KreisRandVis(20, 3, 30, 3, kreisRandFarbe, kreisRand, (int)WpfObjects.P8);

        libWpf.PlcError();
    }
}