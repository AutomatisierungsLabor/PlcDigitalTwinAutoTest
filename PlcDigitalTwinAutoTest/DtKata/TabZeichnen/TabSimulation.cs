using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DtKata.ViewModel;

namespace DtKata.TabZeichnen;

public partial class TabZeichnen
{
    public static void TabSimulationZeichnen(VmKata vmKata, TabItem tabItem, string hintergrund)
    {
        // var viewmodel = grid.DataContext as BasePlcDtAt.BaseViewModel.VmBase ?? throw new ArgumentNullException($"{nameof(ViewModel)}", "Datacontext is not of type viewmodel");
        var libWpf = new LibWpf.LibWpf(tabItem);
        libWpf.SetBackground(new BrushConverter().ConvertFromString(hintergrund) as SolidColorBrush);
        libWpf.GridZeichnen(50, 30, 40, 30, false);

        var buttonRand = new Thickness(2, 5, 2, 5);

        libWpf.Button(1, 3, 1, 2, 20, buttonRand, vmKata.BtnTaster, WpfObjects.S1, false, false);
        libWpf.Button(1, 3, 3, 2, 20, buttonRand, vmKata.BtnTaster, WpfObjects.S2, false, false);
        libWpf.Button(1, 3, 5, 2, 20, buttonRand, vmKata.BtnTaster, WpfObjects.S3, false, false);
        libWpf.Button(1, 3, 7, 2, 20, buttonRand, vmKata.BtnTaster, WpfObjects.S4, false, false);

        libWpf.ButtonOnOffVis(1, 3, 10, 2, 10, "SchiebeSchalterOn.JPG", "SchiebeSchalterOff.JPG", buttonRand, vmKata.BtnSchalter, WpfObjects.S5);
        libWpf.ButtonOnOffVis(1, 3, 12, 2, 10, "SchiebeSchalterOn.JPG", "SchiebeSchalterOff.JPG", buttonRand, vmKata.BtnSchalter, WpfObjects.S6);
        libWpf.ButtonOnOffVis(1, 3, 14, 2, 10, "SchiebeSchalterOn.JPG", "SchiebeSchalterOff.JPG", buttonRand, vmKata.BtnSchalter, WpfObjects.S7);
        libWpf.ButtonOnOffVis(1, 3, 16, 2, 10, "SchiebeSchalterOn.JPG", "SchiebeSchalterOff.JPG", buttonRand, vmKata.BtnSchalter, WpfObjects.S8);


        var kontakteRand = new Thickness(0, 5, 5, 5);

        libWpf.BildVisAus("Taster_SchliesserHellgrau.jpg", 5, 2, 1, 2, kontakteRand, WpfObjects.S1);
        libWpf.BildVisEin("Taster_BetaetigtHellgrau.jpg", 5, 2, 1, 2, kontakteRand, WpfObjects.S1);

        libWpf.BildVisAus("Taster_SchliesserHellgrau.jpg", 5, 2, 3, 2, kontakteRand, WpfObjects.S2);
        libWpf.BildVisEin("Taster_BetaetigtHellgrau.jpg", 5, 2, 3, 2, kontakteRand, WpfObjects.S2);

        libWpf.BildVisAus("Taster_SchliesserHellgrau.jpg", 5, 2, 5, 2, kontakteRand, WpfObjects.S3);
        libWpf.BildVisEin("Taster_BetaetigtHellgrau.jpg", 5, 2, 5, 2, kontakteRand, WpfObjects.S3);

        libWpf.BildVisAus("Taster_SchliesserHellgrau.jpg", 5, 2, 7, 2, kontakteRand, WpfObjects.S4);
        libWpf.BildVisEin("Taster_BetaetigtHellgrau.jpg", 5, 2, 7, 2, kontakteRand, WpfObjects.S4);

        libWpf.BildVisAus("Taster_SchliesserHellgrau.jpg", 5, 2, 10, 2, kontakteRand, WpfObjects.S5);
        libWpf.BildVisEin("Taster_BetaetigtHellgrau.jpg", 5, 2, 10, 2, kontakteRand, WpfObjects.S5);

        libWpf.BildVisAus("Taster_SchliesserHellgrau.jpg", 5, 2, 12, 2, kontakteRand, WpfObjects.S6);
        libWpf.BildVisEin("Taster_BetaetigtHellgrau.jpg", 5, 2, 12, 2, kontakteRand, WpfObjects.S6);

        libWpf.BildVisAus("Taster_SchliesserHellgrau.jpg", 5, 2, 14, 2, kontakteRand, WpfObjects.S7);
        libWpf.BildVisEin("Taster_BetaetigtHellgrau.jpg", 5, 2, 14, 2, kontakteRand, WpfObjects.S7);

        libWpf.BildVisAus("Taster_SchliesserHellgrau.jpg", 5, 2, 16, 2, kontakteRand, WpfObjects.S8);
        libWpf.BildVisEin("Taster_BetaetigtHellgrau.jpg", 5, 2, 16, 2, kontakteRand, WpfObjects.S8);


        var kreisRand = new Thickness(2, 2, 2, 2);
        var kreisRandFarbe = new SolidColorBrush(Colors.Black);

        libWpf.KreisRandVis(10, 2, 1, 2, kreisRandFarbe, kreisRand, WpfObjects.P1);
        libWpf.KreisRandVis(10, 2, 3, 2, kreisRandFarbe, kreisRand, WpfObjects.P2);
        libWpf.KreisRandVis(10, 2, 5, 2, kreisRandFarbe, kreisRand, WpfObjects.P3);
        libWpf.KreisRandVis(10, 2, 7, 2, kreisRandFarbe, kreisRand, WpfObjects.P4);
        libWpf.KreisRandVis(10, 2, 10, 2, kreisRandFarbe, kreisRand, WpfObjects.P5);
        libWpf.KreisRandVis(10, 2, 12, 2, kreisRandFarbe, kreisRand, WpfObjects.P6);
        libWpf.KreisRandVis(10, 2, 14, 2, kreisRandFarbe, kreisRand, WpfObjects.P7);
        libWpf.KreisRandVis(10, 2, 16, 2, kreisRandFarbe, kreisRand, WpfObjects.P8);

        libWpf.PlcError(libWpf);
    }
}