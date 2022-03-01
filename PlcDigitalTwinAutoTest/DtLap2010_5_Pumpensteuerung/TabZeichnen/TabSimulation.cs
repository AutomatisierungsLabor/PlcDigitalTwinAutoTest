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


        var kreisRand = new Thickness(2, 2, 2, 2);
        var kreisRandFarbe = new SolidColorBrush(Colors.Black);

        ///////////////////////////////////////////////////////////
        //
        // Bedienung - Rechts
        //
        /////////////////////////////////////////////////////////// 

        libWpf.RechteckFill(19, 12, 1, 30, Brushes.LightGray);

        var buttonRand = new Thickness(0, 0, 0, 0);
        libWpf.ButtonRounded(20, 3, 2, 2, 14, 0, buttonRand, Brushes.LawnGreen, vmLap2010.BtnTaster, WpfObjects.SchalterHand, false, false);
        libWpf.ButtonRounded(23, 3, 2, 2, 14, 0, buttonRand, Brushes.Gray, vmLap2010.BtnTaster, WpfObjects.SchalterAus, false, false);
        libWpf.ButtonRounded(26, 3, 2, 2, 14, 0, buttonRand, Brushes.Green, vmLap2010.BtnTaster, WpfObjects.SchalterAutomatik, false, false);

        libWpf.RechteckFill(20, 9, 5, 9, Brushes.Gray);
        libWpf.KreisFillStrokeMargin(23, 3, 8, 3, Brushes.DarkGray, Brushes.DarkGray, 0, new Thickness(0, 0, 0, 0));

        libWpf.Text("0", 20, 9, 5, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 30, Brushes.Black);
        libWpf.Text("Hand", 20, 9, 7, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 30, Brushes.Black);
        libWpf.Text("Auto ", 20, 9, 7, 2, HorizontalAlignment.Right, VerticalAlignment.Center, 30, Brushes.Black);

        libWpf.PolygonSetWinkel(20, 9, 5, 9, Brushes.Black, Brushes.Black, 0, new[] { new double[] { 105, 30 }, new double[] { 120, 60 }, new double[] { 120, 160 }, new double[] { 90, 160 }, new double[] { 90, 60 } }, WpfObjects.WinkelSchalter);



        libWpf.Text("S3", 21, 2, 15, 2, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.Text("P1", 21, 2, 20, 2, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("P2", 25, 2, 20, 2, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.ButtonRounded(20, 3, 15, 2, 14, 15, buttonRand, Brushes.Red, vmLap2010.BtnTaster, WpfObjects.S3, false, false);

        libWpf.KreisStrokeMarginSetFilling(22, 3, 20, 3, kreisRandFarbe, kreisRand, WpfObjects.P1);
        libWpf.KreisStrokeMarginSetFilling(27, 3, 20, 3, kreisRandFarbe, kreisRand, WpfObjects.P2);


        ///////////////////////////////////////////////////////////
        //
        //  Simulation - Links
        //
        ///////////////////////////////////////////////////////////
        

        var kontakteRand = new Thickness(0, 5, 5, 5);

        libWpf.ButtonRounded(5, 3, 1, 2, 14, 5, buttonRand, Brushes.Red, vmLap2010.BtnSchalter, WpfObjects.F1, false, false);


        libWpf.RechteckFillMargin(1, 5, 4, 1, Brushes.Blue, new Thickness(0, 10, 0, 10));
        libWpf.RechteckMarginSetFill(6, 5, 4, 1, new Thickness(0, 10, 0, 10), WpfObjects.ZuleitungWaagrecht);
        libWpf.RechteckMarginSetFill(11, 1, 4, 10, new Thickness(10, 10, 10, 0), WpfObjects.ZuleitungSenkrecht);

        libWpf.RechteckFillMargin(5, 5, 6, 10, Brushes.LightBlue, new Thickness(0, 10, 0, 10));
        libWpf.RechteckFillStrokeSetMargin(5, 5, 6, 10, Brushes.Blue, Brushes.Blue, 0, WpfObjects.Pegel);

        libWpf.Text("Q1", 4, 2, 2, 1, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.BildSichtbarkeitAus("PumpeWaagrechtAusWeiss.jpg", 6, 3, 5, 3, kontakteRand, WpfObjects.Q1);
        libWpf.BildSichtbarkeitEin("PumpeWaagrechtEinWeiss.jpg", 6, 3, 5, 3, kontakteRand, WpfObjects.Q1);

        libWpf.ButtonZweiBilder(1, 3, 10, 2, 10, "VentilElektrischEinWeiss.jpg", "VentilElektrischAusWeiss.jpg", buttonRand, vmLap2010.BtnSchalter, WpfObjects.Y1);





        

        libWpf.Text("B1", 9, 2, 5, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.BildSichtbarkeitAus("SchwimmerschalterWeiss.jpg", 11, 2, 5, 2, kontakteRand, WpfObjects.B1);
        libWpf.BildSichtbarkeitEin("SchwimmerschalterBetaetigtWeiss.jpg", 11, 2, 5, 2, kontakteRand, WpfObjects.B1);


        libWpf.Text("B2", 9, 2, 15, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.BildSichtbarkeitAus("SchwimmerschalterWeiss.jpg", 11, 2, 15, 2, kontakteRand, WpfObjects.B2);
        libWpf.BildSichtbarkeitEin("SchwimmerschalterBetaetigtWeiss.jpg", 11, 2, 15, 2, kontakteRand, WpfObjects.B2);



        // libWpf.PlcError();
    }
}