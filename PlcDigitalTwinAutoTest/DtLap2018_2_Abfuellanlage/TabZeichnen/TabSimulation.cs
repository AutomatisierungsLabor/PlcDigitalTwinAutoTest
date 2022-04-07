using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DtLap2018_2_Abfuellanlage.ViewModel;

namespace DtLap2018_2_Abfuellanlage.TabZeichnen;

public partial class TabZeichnen
{
    public static void TabSimulationZeichnen(VmLap2018 vmLap2018, TabItem tabItem, string hintergrund)
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

        libWpf.RipRechteckFill(25, 11, 1, 19, Brushes.LightGray);

        libWpf.Text("S1", 24, 3, 2, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("S2", 29, 3, 2, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("S3", 24, 3, 6, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("S4", 29, 3, 6, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.Text("F1", 24, 3, 10, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.Text("P1", 24, 3, 16, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("P2", 29, 3, 16, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);


        libWpf.RipButtonContentRounded(27, 3, 2, 3, 20, 15, buttonRand, Brushes.Red, vmLap2018.BtnTaster, WpfObjects.S1);
        libWpf.RipButtonContentRounded(32, 3, 2, 3, 20, 15, buttonRand, Brushes.Green, vmLap2018.BtnTaster, WpfObjects.S2);
        libWpf.RipButtonContentRounded(27, 3, 6, 3, 16, 15, buttonRand, Brushes.LawnGreen, vmLap2018.BtnTaster, WpfObjects.S3);
        libWpf.RipButtonContentRounded(32, 3, 6, 3, 16, 15, buttonRand, Brushes.MediumPurple, vmLap2018.BtnTaster, WpfObjects.S4);

        libWpf.RipButtonContentRounded(27, 3, 10, 3, 14, 15, buttonRand, Brushes.Red, vmLap2018.BtnSchalter, WpfObjects.F1);


        libWpf.RipKreisStrokeMarginSetFilling(27, 3, 16, 3, kreisRandFarbe, kreisRand, WpfObjects.P1);
        libWpf.RipKreisStrokeMarginSetFilling(32, 3, 16, 3, kreisRandFarbe, kreisRand, WpfObjects.P2);

        libWpf.Text("Betrieb", 27, 3, 16, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("Störung", 32, 3, 16, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);



        ///////////////////////////////////////////////////////////
        //
        //  Simulation - Links
        //
        ///////////////////////////////////////////////////////////

        libWpf.RipButtonContentRounded(1, 3, 1, 3, 20, 15, buttonRand, Brushes.LightSkyBlue, vmLap2018.BtnTaster, WpfObjects.AllesReset);
        libWpf.RipButtonContentRounded(19, 3, 1, 3, 16, 15, buttonRand, Brushes.LightSkyBlue, vmLap2018.BtnTaster, WpfObjects.TankNachfuellen);

        libWpf.RipRechteckFillMargin(4, 1, 1, 16, Brushes.Gray, new Thickness(10, 0, 6, 0));
        libWpf.RipRechteckFillMargin(5, 1, 1, 16, Brushes.Gray, new Thickness(17, 0, 0, 0));

        libWpf.RipBildSetVisibilityEinAus("VentilElektrischEin.jpg", "VentilElektrischAus.jpg", 7, 2, 15, 2, new Thickness(0, 0, 0, 0), WpfObjects.K2);
        libWpf.Text("K2", 6, 2, 15, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.RipRechteckFill(10, 8, 1, 10, Brushes.LightBlue);
        libWpf.RipRechteckFillStrokeSetMargin(10, 8, 1, 10, Brushes.Blue, Brushes.Blue, 0, WpfObjects.Pegel);

        libWpf.Text("K1", 11, 2, 13, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.RipBildSetVisibilityEinAus("VentilElektrischEin.jpg", "VentilElektrischAus.jpg", 12, 3, 13, 2, new Thickness(0, 0, 8, 0), WpfObjects.K1);
        libWpf.RipRechteckMarginSetFill(13, 2, 11, 2, new Thickness(25, 0, 25, 0), WpfObjects.Zuleitung);
        libWpf.RipRechteckMarginSetFill(13, 2, 15, 5, new Thickness(25, 0, 25, 0), WpfObjects.Ableitung);

        libWpf.RipRechteckFillMargin(4, 14, 20, 1, Brushes.Gray, new Thickness(15, 0, 15, 20));
        libWpf.RipRechteckFillMargin(4, 14, 22, 1, Brushes.Gray, new Thickness(15, 20, 15, 0));
        libWpf.RipKreisFillStrokeMargin(3, 3, 20, 3, Brushes.Gray, Brushes.Gray, 0, new Thickness(0, 0, 0, 0));
        libWpf.RipKreisFillStrokeMargin(16, 3, 20, 3, Brushes.Gray, Brushes.Gray, 0, new Thickness(0, 0, 0, 0));
        libWpf.RipKreisStrokeMarginSetFilling(3, 3, 20, 3, Brushes.Gray, new Thickness(5, 5, 5, 5), WpfObjects.Q1);
        libWpf.Text("Q1", 3, 3, 20, 3, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.Text("B1", 11, 2, 24, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.RipBildSetVisibilityEinAus("InitiatorenSchliesser.jpg", "InitiatorenBetaetigt.jpg", 13, 2, 24, 2, new Thickness(0, 0, 0, 0), WpfObjects.B1);


        libWpf.BildSetMarginVisibilityEin("Franziskaner.jpg", 1, 20, 1, 20, WpfObjects.Flasche1);
        libWpf.BildSetMarginVisibilityEin("Kellerbier.jpg", 1, 20, 1, 20, WpfObjects.Flasche2);
        libWpf.BildSetMarginVisibilityEin("OberLänder.jpg", 1, 20, 1, 20, WpfObjects.Flasche3);
        libWpf.BildSetMarginVisibilityEin("Franziskaner.jpg", 1, 20, 1, 20, WpfObjects.Flasche4);
        libWpf.BildSetMarginVisibilityEin("Kellerbier.jpg", 1, 20, 1, 20, WpfObjects.Flasche5);
        libWpf.BildSetMarginVisibilityEin("OberLänder.jpg", 1, 20, 1, 20, WpfObjects.Flasche6);

        libWpf.RipBildSetVisibilityEin("Fohrenburger0.jpg", 18, 6, 24, 6, new Thickness(0, 0, 0, 0), WpfObjects.Fohrenburger0);
        libWpf.RipBildSetVisibilityEin("Fohrenburger1.jpg", 18, 6, 24, 6, new Thickness(0, 0, 0, 0), WpfObjects.Fohrenburger1);
        libWpf.RipBildSetVisibilityEin("Fohrenburger2.jpg", 18, 6, 24, 6, new Thickness(0, 0, 0, 0), WpfObjects.Fohrenburger2);
        libWpf.RipBildSetVisibilityEin("Fohrenburger3.jpg", 18, 6, 24, 6, new Thickness(0, 0, 0, 0), WpfObjects.Fohrenburger3);
        libWpf.RipBildSetVisibilityEin("Fohrenburger4.jpg", 18, 6, 24, 6, new Thickness(0, 0, 0, 0), WpfObjects.Fohrenburger4);
        libWpf.RipBildSetVisibilityEin("Fohrenburger5.jpg", 18, 6, 24, 6, new Thickness(0, 0, 0, 0), WpfObjects.Fohrenburger5);
        libWpf.RipBildSetVisibilityEin("Fohrenburger6.jpg", 18, 6, 24, 6, new Thickness(0, 0, 0, 0), WpfObjects.Fohrenburger6);

        libWpf.RipBildSetVisibilityEin("Mohren0.jpg", 18, 6, 24, 6, new Thickness(0, 0, 0, 0), WpfObjects.Mohren0);
        libWpf.RipBildSetVisibilityEin("Mohren1.jpg", 18, 6, 24, 6, new Thickness(0, 0, 0, 0), WpfObjects.Mohren1);
        libWpf.RipBildSetVisibilityEin("Mohren2.jpg", 18, 6, 24, 6, new Thickness(0, 0, 0, 0), WpfObjects.Mohren2);
        libWpf.RipBildSetVisibilityEin("Mohren3.jpg", 18, 6, 24, 6, new Thickness(0, 0, 0, 0), WpfObjects.Mohren3);
        libWpf.RipBildSetVisibilityEin("Mohren4.jpg", 18, 6, 24, 6, new Thickness(0, 0, 0, 0), WpfObjects.Mohren4);
        libWpf.RipBildSetVisibilityEin("Mohren5.jpg", 18, 6, 24, 6, new Thickness(0, 0, 0, 0), WpfObjects.Mohren5);
        libWpf.RipBildSetVisibilityEin("Mohren6.jpg", 18, 6, 24, 6, new Thickness(0, 0, 0, 0), WpfObjects.Mohren6);


        // libWpf.PlcError();
    }
}