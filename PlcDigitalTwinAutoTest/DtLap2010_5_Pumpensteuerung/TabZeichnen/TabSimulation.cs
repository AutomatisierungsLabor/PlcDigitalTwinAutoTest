using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DtLap2010_5_Pumpensteuerung.ViewModel;

namespace DtLap2010_5_Pumpensteuerung.TabZeichnen;

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

        libWpf.Rechteck(20, 10, 2, 10, Brushes.LightGray);

        libWpf.Text("S1", 21, 2, 2, 2, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("S2", 25, 2, 2, 2, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("P1", 21, 2, 5, 2, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("P2", 25, 2, 5, 2, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.ButtonRounded(22, 2, 2, 2, 14, 15, buttonRand, Brushes.Red, vmLap2010.BtnTaster, WpfObjects.S1, false, false);
        libWpf.ButtonRounded(27, 2, 2, 2, 14, 15, buttonRand, Brushes.Green, vmLap2010.BtnTaster, WpfObjects.S2, false, false);

        libWpf.KreisRandVis(22, 2, 5, 2, kreisRandFarbe, kreisRand, WpfObjects.P1);
        libWpf.KreisRandVis(27, 2, 5, 2, kreisRandFarbe, kreisRand, WpfObjects.P2);


        ///////////////////////////////////////////////////////////
        //
        //  Simulation - Links
        //
        ///////////////////////////////////////////////////////////






        var kontakteRand = new Thickness(0, 5, 5, 5);

        libWpf.Text("B1", 5, 4, 15, 1, HorizontalAlignment.Center, VerticalAlignment.Center, 10, Brushes.Black);
        libWpf.BildVisAus("Initiatoren_SchliesserHellgrau.jpg", 7, 2, 15, 2, kontakteRand, WpfObjects.B1);
        libWpf.BildVisEin("Initiatoren_BetaetigtHellgrau.jpg", 7, 2, 15, 2, kontakteRand, WpfObjects.B1);






        libWpf.RechteckFarbeUmschalten(10, 4, 15, 1, Brushes.Black, new Thickness(0, 0, 0, 0), WpfObjects.Q1);
        libWpf.RechteckFarbeUmschalten(10, 2, 16, 1, Brushes.Black, new Thickness(0, 0, 0, 0), WpfObjects.Q2);
        libWpf.RechteckFarbeUmschalten(12, 2, 16, 1, Brushes.Black, new Thickness(0, 0, 0, 0), WpfObjects.Q3);
        libWpf.Text("Q1 (Netz)", 10, 4, 15, 1, HorizontalAlignment.Center, VerticalAlignment.Center, 10, Brushes.Black);
        libWpf.Text("Q2 ( Y )", 10, 2, 16, 1, HorizontalAlignment.Center, VerticalAlignment.Center, 10, Brushes.Black);
        libWpf.Text("Q3 ( D )", 12, 2, 16, 1, HorizontalAlignment.Center, VerticalAlignment.Center, 10, Brushes.Black);


        libWpf.ButtonRounded(10, 4, 18, 2, 14, 15, buttonRand, Brushes.Red, vmLap2010.BtnSchalter, WpfObjects.F1, false, false);
        libWpf.TextVis(10, 4, 18, 2, HorizontalAlignment.Center, VerticalAlignment.Center,20, Brushes.Black,WpfObjects.Kurzschluss);

        libWpf.KreisRandVis(15, 4, 15, 4, Brushes.Red, new Thickness(0, 0, 0, 0), WpfObjects.Kurzschluss);


        // libWpf.PlcError();
    }
}