using DtGetriebemotor.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DtGetriebemotor.TabZeichnen;

public partial class TabZeichnen
{
    public static void TabSimulationZeichnen(VmGetriebemotor vmGetriebemotor, TabItem tabItem, string hintergrund)
    {
        var libWpf = new LibWpf.LibWpf(tabItem);
        libWpf.SetBackground(new BrushConverter().ConvertFromString(hintergrund) as SolidColorBrush);
        libWpf.GridZeichnen(50, 30, 40, 30, true);



        libWpf.KreisFillStrokeMargin(7, 8, 2, 8, Brushes.SlateGray, Brushes.SlateGray, 0, new Thickness(2, 2, 2, 2));
        libWpf.RechteckFillMarginSetWinkel(10, 2, 3, 2, Brushes.Yellow, new Thickness(25, 0, 25, 20), WpfObjects.WinkelGetriebemotor);


        var kontakteRand = new Thickness(2, 5, 2, 5);

        libWpf.RipBildSetVisibilityAus("TasterSchliesser.jpg", 10, 2, 0, 2, kontakteRand, WpfObjects.B1);
        libWpf.RipBildSetVisibilityEin("TasterBetaetigt.jpg", 10, 2, 0, 2, kontakteRand, WpfObjects.B1);
        libWpf.Text("-B1", 9, 2, 0, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.RipBildSetVisibilityAus("TasterSchliesser.jpg", 15, 2, 2, 2, kontakteRand, WpfObjects.B2);
        libWpf.RipBildSetVisibilityEin("TasterBetaetigt.jpg", 15, 2, 2, 2, kontakteRand, WpfObjects.B2);
        libWpf.Text("-B2", 14, 2, 2, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);

        var buttonRand = new Thickness(2, 5, 2, 5);

        libWpf.RechteckFill(1, 5, 11, 8, Brushes.LightGray);
        libWpf.Text("-S1", 1, 2, 11, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonContentRounded(3, 3, 11, 3, 50, 15, buttonRand, Brushes.LawnGreen, vmGetriebemotor.BtnTaster, WpfObjects.S1);

        libWpf.Text("-S2", 1, 2, 16, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonContentRounded(3, 3, 16, 3, 50, 15, buttonRand, Brushes.Red, vmGetriebemotor.BtnTaster, WpfObjects.S2);


        libWpf.RechteckFill(8, 5, 11, 8, Brushes.LightGray);
        libWpf.Text("-S3", 8, 2, 11, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonContentRounded(10, 3, 11, 3, 50, 15, buttonRand, Brushes.LawnGreen, vmGetriebemotor.BtnTaster, WpfObjects.S3);

        libWpf.Text("-S4", 8, 2, 14, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonContentRounded(10, 3, 14, 2, 30, 5, buttonRand, Brushes.Red, vmGetriebemotor.BtnTaster, WpfObjects.S4);

        libWpf.Text("-S5", 8, 2, 16, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonContentRounded(10, 3, 16, 3, 50, 15, buttonRand, Brushes.LawnGreen, vmGetriebemotor.BtnTaster, WpfObjects.S5);


        libWpf.RechteckFill(15, 5, 11, 8, Brushes.LightGray);
        libWpf.Text("-S6", 15, 2, 11, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonContentRounded(17, 3, 11, 3, 50, 15, buttonRand, Brushes.LawnGreen, vmGetriebemotor.BtnTaster, WpfObjects.S6);

        libWpf.Text("-S7", 15, 2, 14, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonContentRounded(17, 3, 14, 2, 30, 5, buttonRand, Brushes.Red, vmGetriebemotor.BtnTaster, WpfObjects.S7);

        libWpf.Text("-S8", 15, 2, 16, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonContentRounded(17, 3, 16, 3, 50, 15, buttonRand, Brushes.LawnGreen, vmGetriebemotor.BtnTaster, WpfObjects.S8);

        var kreisRand = new Thickness(2, 2, 2, 2);
        var kreisRandFarbe = new SolidColorBrush(Colors.Black);

        libWpf.RechteckFill(1, 5, 20, 3, Brushes.LightGray);
        libWpf.Text("-P1", 1, 2, 20, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.KreisStrokeMarginSetFilling(3, 3, 20, 3, kreisRandFarbe, kreisRand, WpfObjects.P1);

        libWpf.RechteckFill(8, 5, 20, 3, Brushes.LightGray);
        libWpf.Text("-P2", 8, 2, 20, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.KreisStrokeMarginSetFilling(10, 3, 20, 3, kreisRandFarbe, kreisRand, WpfObjects.P2);

        libWpf.RechteckFill(15, 5, 20, 3, Brushes.LightGray);
        libWpf.Text("-P3", 15, 2, 20, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.KreisStrokeMarginSetFilling(17, 3, 20, 3, kreisRandFarbe, kreisRand, WpfObjects.P3);


        libWpf.ButtonZweiBilder(20, 4, 4, 4, "NotHalt.jpg", "NotHaltGedrueckt.jpg", buttonRand, vmGetriebemotor.BtnSchalter, WpfObjects.S91);
        libWpf.Text("-S9.1", 18, 2, 4, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("-S9.2", 18, 2, 5, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.PlcError();
    }
}