using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DtLap2010_3_Ofentuersteuerung.ViewModel;

namespace DtLap2010_3_Ofentuersteuerung.TabZeichnen;

public partial class TabZeichnen
{
    public static void TabSimulationZeichnen(VmLap2010 vmLap2010, TabItem tabItem, string hintergrund)
    {
        var libWpf = new LibWpf.LibWpf(tabItem);
        libWpf.SetBackground(new BrushConverter().ConvertFromString(hintergrund) as SolidColorBrush);
        libWpf.GridZeichnen(50, 30, 40, 30, true);

        var buttonRand = new Thickness(2, 5, 2, 5);
        var kreisRand = new Thickness(2, 2, 2, 2);
        var kreisRandFarbe = new SolidColorBrush(Colors.Black);

        ///////////////////////////////////////////////////////////
        //
        // Bedienung - Rechts
        //
        /////////////////////////////////////////////////////////// 

        libWpf.RechteckFill(20, 10, 2, 10, Brushes.LightGray);

        libWpf.Text("S1", 19, 3, 2, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("S2", 19, 3, 5, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("S3", 24, 3, 5, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.Text("P1", 19, 3, 8, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);


        libWpf.ButtonRounded(22, 3, 2, 3, 14, 15, buttonRand, Brushes.Red, vmLap2010.BtnTaster, WpfObjects.S1, false, false);
        libWpf.ButtonRounded(22, 3, 5, 3, 14, 15, buttonRand, Brushes.Green, vmLap2010.BtnTaster, WpfObjects.S2, false, false);
        libWpf.ButtonRounded(27, 3, 5, 3, 14, 15, buttonRand, Brushes.Green, vmLap2010.BtnTaster, WpfObjects.S3, false, false);

        libWpf.KreisStrokeMarginSetFilling(22, 3, 8, 3, kreisRandFarbe, kreisRand, WpfObjects.P1);
        libWpf.Text("Schliessen", 22, 3, 8, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 16, Brushes.Black);


        ///////////////////////////////////////////////////////////
        //
        //  Simulation - Links
        //
        ///////////////////////////////////////////////////////////

        libWpf.VideoAutoPlay("Flammen.mp4", 7, 3, 5, 3);

        libWpf.BildDrehen("Zahnrad.png", 2, 3, 10, 3, new Thickness(0, 0, 0, 0),  WpfObjects.ZahnradWinkel);
        libWpf.BildRand("Zahnstange.png", 2, 20, 8, 3, WpfObjects.ZahnstangePosition);

        libWpf.RechteckFillStrokeSetMargin(2,4,5,4,Brushes.Gray, Brushes.Black,2, WpfObjects.OfentuerePosition);

        libWpf.ButtonRounded(22, 3, 2, 3, 14, 15, buttonRand, Brushes.Red, vmLap2010.BtnTaster, WpfObjects.B2, false, false);

        var kontakteRand = new Thickness(0, 5, 5, 5);

        libWpf.Text("B1", 8, 2, 15, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.BildSichtbarkeitAus("InitiatorenSchliesserHellgrau.jpg", 11, 2, 15, 2, kontakteRand, WpfObjects.B1);
        libWpf.BildSichtbarkeitEin("InitiatorenBetaetigtHellgrau.jpg", 11, 2, 15, 2, kontakteRand, WpfObjects.B1);

        libWpf.Text("B2", 12, 2, 15, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.BildSichtbarkeitAus("InitiatorenSchliesserHellgrau.jpg", 15, 2, 15, 2, kontakteRand, WpfObjects.B2);
        libWpf.BildSichtbarkeitEin("InitiatorenBetaetigtHellgrau.jpg", 15, 2, 15, 2, kontakteRand, WpfObjects.B2);

        libWpf.Text("B3", 16, 2, 15, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.BildSichtbarkeitAus("InitiatorenSchliesserHellgrau.jpg", 19, 2, 15, 2, kontakteRand, WpfObjects.B3);
        libWpf.BildSichtbarkeitEin("InitiatorenBetaetigtHellgrau.jpg", 19, 2, 15, 2, kontakteRand, WpfObjects.B3);


        libWpf.RechteckSetFill(2, 2, 15, 2, Brushes.Black, new Thickness(0, 0, 0, 0), WpfObjects.Q1);
        libWpf.RechteckSetFill(4, 2, 15, 2, Brushes.Black, new Thickness(0, 0, 0, 0), WpfObjects.Q2);
        libWpf.Text("Q1 (LL)", 2, 2, 15, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 16, Brushes.Black);
        libWpf.Text("Q2 (RL)", 4, 2, 15, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 16, Brushes.Black);

        // libWpf.PlcError();
    }
}