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




        ///////////////////////////////////////////////////////////
        //
        // Bedienung - Rechts
        //
        /////////////////////////////////////////////////////////// 

        libWpf.RipRechteckFill(19, 12, 1, 30, Brushes.LightGray);

        var buttonRand = new Thickness(0, 0, 0, 0);
        libWpf.RipButtonContentRounded(20, 3, 2, 2, 14, 0, buttonRand, Brushes.LawnGreen, vmLap2010.BtnTaster, WpfObjects.SchalterHand);
        libWpf.RipButtonContentRounded(23, 3, 2, 2, 14, 0, buttonRand, Brushes.Gray, vmLap2010.BtnTaster, WpfObjects.SchalterAus);
        libWpf.RipButtonContentRounded(26, 3, 2, 2, 14, 0, buttonRand, Brushes.Green, vmLap2010.BtnTaster, WpfObjects.SchalterAutomatik);

        libWpf.RipRechteckFill(20, 9, 5, 9, Brushes.Gray);
        libWpf.RipKreisFillStrokeMargin(23, 3, 8, 3, Brushes.DarkGray, Brushes.DarkGray, 0, new Thickness(0, 0, 0, 0));

        libWpf.Text("0", 20, 9, 5, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 30, Brushes.Black);
        libWpf.Text("Hand", 20, 9, 7, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 30, Brushes.Black);
        libWpf.Text("Auto ", 20, 9, 7, 2, HorizontalAlignment.Right, VerticalAlignment.Center, 30, Brushes.Black);

        libWpf.PolygonSetWinkel(21, 7, 6, 7, Brushes.Black, Brushes.Black, 0, new[] { new double[] { 105, 30 }, new double[] { 120, 60 }, new double[] { 120, 160 }, new double[] { 90, 160 }, new double[] { 90, 60 } }, WpfObjects.WinkelSchalter);



        libWpf.Text("S3", 20, 2, 15, 2, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.RipButtonContentRounded(22, 3, 15, 2, 14, 15, buttonRand, Brushes.Red, vmLap2010.BtnTaster, WpfObjects.S3);

        libWpf.Text("P1", 20, 2, 20, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("P2", 25, 2, 20, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.RipKreisStrokeMarginSetFilling(22, 3, 20, 3, Brushes.Black, new Thickness(0, 0, 0, 0), WpfObjects.P1);
        libWpf.RipKreisStrokeMarginSetFilling(27, 3, 20, 3, Brushes.Black, new Thickness(0, 0, 0, 0), WpfObjects.P2);
        libWpf.Text("Pumpe", 22, 3, 20, 3, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("Störung", 27, 3, 20, 3, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);

        ///////////////////////////////////////////////////////////
        //
        //  Simulation - Links
        //
        ///////////////////////////////////////////////////////////


        libWpf.RipButtonBackgroundContentRounded(5, 3, 1, 2, 14, 5, buttonRand, vmLap2010.BtnSchalter, WpfObjects.F1);

        libWpf.RipRechteckFillMargin(1, 4, 4, 2, Brushes.Blue, new Thickness(0, 20, 0, 20));
        libWpf.RipRechteckMarginSetFill(5, 4, 4, 2, new Thickness(0, 20, 10, 20), WpfObjects.ZuleitungWaagrecht);
        libWpf.RipRechteckMarginSetFill(8, 2, 4, 10, new Thickness(20, 20, 20, 0), WpfObjects.ZuleitungSenkrecht);

        libWpf.RipRechteckFillMargin(6, 6, 6, 10, Brushes.LightBlue, new Thickness(0, 0, 0, 0));
        libWpf.RipRechteckFillStrokeSetMargin(6, 6, 6, 10, Brushes.Blue, Brushes.Blue, 0, WpfObjects.Pegel);

        var pumpeRand = new Thickness(0, 0, 0, 0);
        libWpf.Text("Q1", 2, 2, 3, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.RipBildSetVisibilityAus("PumpeWaagrechtAus.jpg", 4, 2, 4, 2, pumpeRand, WpfObjects.Q1);
        libWpf.RipBildSetVisibilityEin("PumpeWaagrechtEin.jpg", 4, 2, 4, 2, pumpeRand, WpfObjects.Q1);


        libWpf.RipRechteckMarginSetFill(8, 2, 16, 3, new Thickness(20, 0, 20, 0), WpfObjects.AbleitungOben);
        libWpf.RipRechteckMarginSetFill(8, 2, 19, 3, new Thickness(20, 0, 20, 0), WpfObjects.AbleitungUnten);

        libWpf.Text("Y1", 5, 2, 18, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.RipButtonZweiBilder(7, 3, 18, 2, "VentilElektrischEin.jpg", "VentilElektrischAus.jpg", new Thickness(7, 0, 7, 0), vmLap2010.BtnSchalter, WpfObjects.Y1);


        var kontakteRand = new Thickness(20, 5, 0, 5);

        libWpf.Text("B1", 12, 2, 7, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.RipBildSetVisibilityAus("Schwimmerschalter.jpg", 13, 2, 7, 2, kontakteRand, WpfObjects.B1);
        libWpf.RipBildSetVisibilityEin("SchwimmerschalterBetaetigt.jpg", 13, 2, 7, 2, kontakteRand, WpfObjects.B1);


        libWpf.Text("B2", 12, 2, 14, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.RipBildSetVisibilityAus("Schwimmerschalter.jpg", 13, 2, 14, 2, kontakteRand, WpfObjects.B2);
        libWpf.RipBildSetVisibilityEin("SchwimmerschalterBetaetigt.jpg", 13, 2, 14, 2, kontakteRand, WpfObjects.B2);



        // libWpf.PlcError();
    }
}