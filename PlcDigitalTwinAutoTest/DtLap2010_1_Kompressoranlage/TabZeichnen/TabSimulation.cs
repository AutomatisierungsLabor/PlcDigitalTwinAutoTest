using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DtLap2010_1_Kompressoranlage.ViewModel;

namespace DtLap2010_1_Kompressoranlage.TabZeichnen;

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

        libWpf.Rechteck(20, 11, 1, 9, Brushes.LightGray);

        libWpf.Text("S1", 19, 3, 2, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("S2", 24, 3, 2, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("P1", 19, 3, 6, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("P2", 24, 3, 6, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.ButtonRounded(22, 3, 2, 3, 20, 15, buttonRand, Brushes.Red, vmLap2010.BtnTaster, WpfObjects.S1, false, false);
        libWpf.ButtonRounded(27, 3, 2, 3, 20, 15, buttonRand, Brushes.Green, vmLap2010.BtnTaster, WpfObjects.S2, false, false);

        libWpf.KreisRandVis(22, 3, 6, 3, kreisRandFarbe, kreisRand, WpfObjects.P1);
        libWpf.KreisRandVis(27, 3, 6, 3, kreisRandFarbe, kreisRand, WpfObjects.P2);


        ///////////////////////////////////////////////////////////
        //
        //  Simulation - Links
        //
        ///////////////////////////////////////////////////////////

        libWpf.RechteckRundung(2, 20, 1, 15, 25, 15, Brushes.LightBlue, Brushes.Black, 2, new Rect(0, 0, 210, 300));
        libWpf.RechteckFillStroke(4, 3, 11, 3, Brushes.LightBlue, Brushes.Black, 2, new Thickness(10, 0, 10, 0));
        libWpf.RechteckFill(4, 3, 10, 2, Brushes.LightBlue, new Thickness(12, 0, 12, 0));

        libWpf.Polygon(0, 7, 15, 6, Brushes.LightBlue, Brushes.Black, 2, new double[][] { new double[] { 130, 20 }, new double[] { 200, 20 }, new double[] { 200, 150 }, new double[] { 20, 150 }, new double[] { 20, 90 }, new double[] { 130, 90 } });

        libWpf.KreisFillStroke(3, 5, 12, 5, Brushes.Blue, Brushes.Black, 2, new Thickness(10, 10, 10, 10));
        libWpf.Polygon(3, 5, 13, 5, Brushes.Blue, Brushes.Black, 2, new double[][] { new double[] { 70, 2 }, new double[] { 90, 30 }, new double[] { 50, 30 } });


        var kontakteRand = new Thickness(0, 5, 5, 5);

        libWpf.Text("B1", 9, 2, 5, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.BildVisAus("Initiatoren_SchliesserHellgrau.jpg", 11, 2, 5, 2, kontakteRand, WpfObjects.B1);
        libWpf.BildVisEin("Initiatoren_BetaetigtHellgrau.jpg", 11, 2, 5, 2, kontakteRand, WpfObjects.B1);



        libWpf.RechteckFarbeUmschalten(10, 4, 15, 1, Brushes.Black, new Thickness(0, 0, 0, 0), WpfObjects.Q1);
        libWpf.RechteckFarbeUmschalten(10, 2, 16, 1, Brushes.Black, new Thickness(0, 0, 0, 0), WpfObjects.Q2);
        libWpf.RechteckFarbeUmschalten(12, 2, 16, 1, Brushes.Black, new Thickness(0, 0, 0, 0), WpfObjects.Q3);
        libWpf.Text("Q1 (Netz)", 10, 4, 15, 1, HorizontalAlignment.Center, VerticalAlignment.Center, 15, Brushes.Black);
        libWpf.Text("Q2 ( Y )", 10, 2, 16, 1, HorizontalAlignment.Center, VerticalAlignment.Center, 15, Brushes.Black);
        libWpf.Text("Q3 ( △ )", 12, 2, 16, 1, HorizontalAlignment.Center, VerticalAlignment.Center, 15, Brushes.Black);


        libWpf.ButtonRounded(10, 4, 18, 2, 14, 15, buttonRand, Brushes.Red, vmLap2010.BtnSchalter, WpfObjects.F1, false, false);
        libWpf.TextVis(10, 4, 18, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black, WpfObjects.Kurzschluss);

        libWpf.KreisRandVis(15, 4, 15, 4, Brushes.Red, new Thickness(0, 0, 0, 0), WpfObjects.Kurzschluss);


        libWpf.GaugeControl(20, 10, 12, 10, "Druck", 0, 10, 165, 188, "AktuellerDruck");

        // libWpf.PlcError();
    }
}