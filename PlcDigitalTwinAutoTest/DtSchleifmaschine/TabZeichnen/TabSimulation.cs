using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DtSchleifmaschine.ViewModel;

namespace DtSchleifmaschine.TabZeichnen;

public partial class TabZeichnen
{
    public static void TabSimulationZeichnen(VmSchleifmaschine vmSchleifmaschine, TabItem tabItem, string hintergrund)
    {
        var libWpf = new LibWpf.LibWpf(tabItem);
        libWpf.SetBackground(new BrushConverter().ConvertFromString(hintergrund) as SolidColorBrush);
        libWpf.GridZeichnen(50, 30, 40, 30, false);


        libWpf.RipKreisFillStrokeMargin(2, 8, 1, 8, Brushes.SlateGray, Brushes.SlateGray, 0, new Thickness(2, 2, 2, 2));
        libWpf.RechteckFillMarginSetWinkel(5, 2, 1, 2, Brushes.Yellow, new Thickness(25, 0, 25, 20), WpfObjects.WinkelSchleifmaschine);

        libWpf.TextSetContendSetVisibility(2, 8, 9, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 30, Brushes.Black, WpfObjects.SchleifmaschineDrehzahl);

        libWpf.RechteckSetFillSetVisibility(2, 20, 12, 2, Brushes.Red, WpfObjects.B1);
        libWpf.TextSetContendSetVisibility(2, 20, 12, 2, HorizontalAlignment.Center, VerticalAlignment.Center, 20, Brushes.Black, WpfObjects.B1);


        libWpf.PointerGauge(12, 10, 1, 10, "Drehzahl", 0, 3000, 80, 225, "AktuelleDrehzahl");


        var buttonRand = new Thickness(2, 5, 2, 5);

        libWpf.RechteckFill(2, 5, 15, 8, Brushes.LightGray);

        libWpf.Text("-S1", 2, 2, 15, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.RipButtonContentRounded(4, 3, 15, 3, 50, 15, buttonRand, Brushes.LawnGreen, vmSchleifmaschine.BtnTaster, WpfObjects.S1);

        libWpf.Text("-S0", 2, 2, 18, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.RipButtonContentRounded(4, 3, 18, 2, 20, 5, buttonRand, Brushes.Red, vmSchleifmaschine.BtnTaster, WpfObjects.S0);

        libWpf.Text("-S2", 2, 2, 20, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.RipButtonContentRounded(4, 3, 20, 3, 50, 15, buttonRand, Brushes.LawnGreen, vmSchleifmaschine.BtnTaster, WpfObjects.S2);



        libWpf.RipKreisFillStrokeMargin(15, 4, 15, 4, Brushes.Yellow, Brushes.Red, 2, new Thickness(0, 0, 0, 0));





        var kreisRand = new Thickness(2, 2, 2, 2);
        var kreisRandFarbe = new SolidColorBrush(Colors.Black);

        libWpf.RechteckFill(30, 5, 1, 6, Brushes.LightGray);

        libWpf.Text("-F1", 30, 2, 1, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.RipButtonContentRounded(32, 3, 1, 3, 50, 5, buttonRand, Brushes.LawnGreen, vmSchleifmaschine.BtnSchalter, WpfObjects.F1);

        libWpf.Text("-F2", 30, 2, 4, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.RipButtonContentRounded(32, 3, 4, 3, 50, 5, buttonRand, Brushes.LawnGreen, vmSchleifmaschine.BtnSchalter, WpfObjects.F2);


        libWpf.RechteckFill(30, 5, 8, 11, Brushes.LightGray);

        libWpf.Text("-P1", 30, 2, 8, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.RipKreisStrokeMarginSetFilling(32, 3, 8, 3, kreisRandFarbe, kreisRand, WpfObjects.P1);
        libWpf.Text("langsam", 32, 3, 8, 3, HorizontalAlignment.Center, VerticalAlignment.Center, 10, Brushes.Black);

        libWpf.Text("-P2", 30, 2, 12, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.RipKreisStrokeMarginSetFilling(32, 3, 12, 3, kreisRandFarbe, kreisRand, WpfObjects.P2);
        libWpf.Text("schnell", 32, 3, 12, 3, HorizontalAlignment.Center, VerticalAlignment.Center, 10, Brushes.Black);

        libWpf.Text("-P3", 30, 2, 16, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.RipKreisStrokeMarginSetFilling(32, 3, 16, 3, kreisRandFarbe, kreisRand, WpfObjects.P3);
        libWpf.Text("schnell", 32, 3, 16, 3, HorizontalAlignment.Center, VerticalAlignment.Center, 10, Brushes.Black);




        libWpf.RechteckFill(30, 5, 21, 2, Brushes.LightGray);

        libWpf.Text("-S4", 30, 2, 21, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.RipButtonContentRounded(32, 3, 21, 2, 20, 5, buttonRand, Brushes.Red, vmSchleifmaschine.BtnTaster, WpfObjects.S4);

        libWpf.RipButtonZweiBilder(22, 4, 15, 4, "NotHalt.jpg", "NotHaltGedrueckt.jpg", new Thickness(0, 0, 0, 0), vmSchleifmaschine.BtnSchalter, WpfObjects.S3);
        libWpf.Text("-S3", 20, 2, 16, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);


        // libWpf.PlcError();
    }
}