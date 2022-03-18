using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DtLap2018_1_Silosteuerung.ViewModel;
using WpfAnimatedGif;

namespace DtLap2018_1_Silosteuerung.TabZeichnen;

public partial class TabZeichnen
{
    public static void TabSimulationZeichnen(VmLap2018 vmLap2018, TabItem tabItem, string hintergrund)
    {
        var libWpf = new LibWpf.LibWpf(tabItem);
        libWpf.SetBackground(new BrushConverter().ConvertFromString(hintergrund) as SolidColorBrush);
        libWpf.GridZeichnen(50, 30, 40, 30, true);




        ///////////////////////////////////////////////////////////
        //
        // Bedienung - Rechts
        //
        /////////////////////////////////////////////////////////// 

        var buttonRand = new Thickness(2, 5, 2, 5);
        var kreisRand = new Thickness(2, 2, 2, 2);
        var kreisRandFarbe = new SolidColorBrush(Colors.Black);

        libWpf.RechteckFill(20, 11, 1, 12, Brushes.LightGray);

        libWpf.Text("P1", 19, 3, 2, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("P2", 24, 3, 2, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.KreisStrokeMarginSetFilling(22, 3, 2, 3, kreisRandFarbe, kreisRand, WpfObjects.P1);
        libWpf.KreisStrokeMarginSetFilling(27, 3, 2, 3, kreisRandFarbe, kreisRand, WpfObjects.P2);


        libWpf.Text("S0", 19, 3, 6, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("S1", 24, 3, 6, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonRounded(22, 3, 6, 3, 20, 15, buttonRand, Brushes.Red, vmLap2018.BtnTaster, WpfObjects.S0);
        libWpf.ButtonRounded(27, 3, 6, 3, 20, 15, buttonRand, Brushes.Green, vmLap2018.BtnTaster, WpfObjects.S1);


        libWpf.Text("S2", 19, 3, 10, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("S3", 24, 3, 10, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonZweiBilder(22, 3, 10, 3, 10, "NotHalt.jpg", "NotHaltGedrueckt.jpg", buttonRand, vmLap2018.BtnSchalter, WpfObjects.S2);
        libWpf.ButtonRounded(27, 3, 10, 3, 20, 15, buttonRand, Brushes.Green, vmLap2018.BtnTaster, WpfObjects.S3);






        ///////////////////////////////////////////////////////////
        //
        //  Simulation - Links
        //
        ///////////////////////////////////////////////////////////


        







       libWpf.BildAnimiert("Schneckenfoerderer.gif", 4, 6, 2, 7, vmLap2018.AnimatedLoaded);

    }
}