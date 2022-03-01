using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DtLap2010_2_Transportwagen.ViewModel;

namespace DtLap2010_2_Transportwagen.TabZeichnen;

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

        libWpf.Rechteck(25, 11, 1, 15, Brushes.LightGray);

        libWpf.Text("S1", 24, 3, 2, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("S2", 29, 3, 2, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("S3", 24, 3, 5, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.Text("P1", 24, 3, 8, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);


        libWpf.ButtonRounded(27, 3, 2, 3, 14, 15, buttonRand, Brushes.Green, vmLap2010.BtnTaster, WpfObjects.S1, false, false);
        libWpf.ButtonRounded(32, 3, 2, 3, 14, 15, buttonRand, Brushes.Red, vmLap2010.BtnSchalter, WpfObjects.S2, false, false);
        libWpf.ButtonRounded(27, 3, 5, 3, 14, 15, buttonRand, Brushes.Red, vmLap2010.BtnTaster, WpfObjects.S3, false, false);

        libWpf.KreisRandVis(27, 3, 8, 3, kreisRandFarbe, kreisRand, WpfObjects.P1);
        libWpf.Text("Störung", 27, 3, 8, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 16, Brushes.Black);


        libWpf.ButtonRounded(27, 3, 12, 3, 14, 15, buttonRand, Brushes.Red, vmLap2010.BtnSchalter, WpfObjects.F1, false, false);

        ///////////////////////////////////////////////////////////
        //
        //  Simulation - Links
        //
        ///////////////////////////////////////////////////////////


        libWpf.RechteckVis(8, 2, 2, 4, Brushes.Firebrick, WpfObjects.Fuellen);
        libWpf.Polygon(14, 5, 1, 5, Brushes.DarkOrange, Brushes.Black, 2, new[] { new double[] { 20, 10 }, new double[] { 120, 10 }, new double[] { 120, 120 }, new double[] { 100, 160 }, new double[] { 40, 160 }, new double[] { 20, 120 } });

        libWpf.RechteckRand(1, 20, 8, 4, Brushes.Gray, Brushes.Black, 3, WpfObjects.PositionWagenkasten);
        libWpf.KreisRandPosition(1, 20, 12, 1, Brushes.Red, Brushes.Black, 2, WpfObjects.PositionRadLinks);
        libWpf.KreisRandPosition(1, 20, 12, 1, Brushes.Red, Brushes.Black, 2, WpfObjects.PositionRadRechts);

        libWpf.Rechteck(1,20,13,1,Brushes.Gray);



        var kontakteRand = new Thickness(0, 5, 5, 5);

        libWpf.Text("B1", 1, 2, 15, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.BildVisAus("Initiatoren_SchliesserHellgrau.jpg", 3, 2, 15, 2, kontakteRand, WpfObjects.B1);
        libWpf.BildVisEin("Initiatoren_BetaetigtHellgrau.jpg", 3, 2, 15, 2, kontakteRand, WpfObjects.B1);

        libWpf.Text("B2", 16, 2, 15, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.BildVisAus("Initiatoren_SchliesserHellgrau.jpg", 18, 2, 15, 2, kontakteRand, WpfObjects.B2);
        libWpf.BildVisEin("Initiatoren_BetaetigtHellgrau.jpg", 18, 2, 15, 2, kontakteRand, WpfObjects.B2);


        libWpf.RechteckFarbeUmschalten(9, 2, 15, 2, Brushes.Black, new Thickness(0, 0, 0, 0), WpfObjects.Q1);
        libWpf.RechteckFarbeUmschalten(11, 2, 15, 2, Brushes.Black, new Thickness(0, 0, 0, 0), WpfObjects.Q2);
        libWpf.Text("Q1 (LL)", 9, 2, 15, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 16, Brushes.Black);
        libWpf.Text("Q2 (RL)", 11, 2, 15, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 16, Brushes.Black);


        libWpf.TextVis(9, 4, 19, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black, WpfObjects.Kurzschluss);
        libWpf.KreisRandVis(9, 4, 18, 4, Brushes.Red, new Thickness(0, 0, 0, 0), WpfObjects.Kurzschluss);


        // libWpf.PlcError();
    }
}