using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DtLinearachse.ViewModel;

namespace DtLinearachse.TabZeichnen;

public partial class TabZeichnen
{
    public static LibWpf.LibWpf TabSimulationZeichnen(VmLinearachse vmLinearachse, TabItem tabItem, string hintergrund)
    {
        var libWpf = new LibWpf.LibWpf(tabItem);
        libWpf.SetBackground(new BrushConverter().ConvertFromString(hintergrund) as SolidColorBrush);
        libWpf.GridZeichnen(50, 30, 40, 30, true);

        
        libWpf.Rechteck(3,2,1,7,Brushes.Black);
        libWpf.Rechteck(5,20,3,3,Brushes.DarkGray);
        libWpf.Rechteck(5, 20, 4, 1, Brushes.Black);
        libWpf.Rechteck(25, 2, 1, 7, Brushes.Black);

        libWpf.RechteckRand(5,20,1,7,Brushes.Yellow,WpfObjects.PositionSchlitten);

        var kontakteRand = new Thickness(2, 5, 2, 5);
        libWpf.Text("-B1", 3, 2, 8, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.BildVisAus("Taster_SchliesserHellgrau.jpg", 4, 2, 8, 2, kontakteRand, WpfObjects.B1);
        libWpf.BildVisEin("Taster_BetaetigtHellgrau.jpg", 4, 2, 8, 2, kontakteRand, WpfObjects.B1);

        libWpf.Text("-B2", 23, 2, 8, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.BildVisAus("Taster_SchliesserHellgrau.jpg", 23, 2, 8, 2, kontakteRand, WpfObjects.B2);
        libWpf.BildVisEin("Taster_BetaetigtHellgrau.jpg", 23, 2, 8, 2, kontakteRand, WpfObjects.B2);




        var buttonRand = new Thickness(2, 5, 2, 5);

        libWpf.Rechteck(1,5,11,8,Brushes.LightGray);
        libWpf.Text("-S1",1,2,11,3,HorizontalAlignment.Left, VerticalAlignment.Center,20,Brushes.Black);
        libWpf.ButtonRounded(3, 3, 11, 3, 50, 15,buttonRand, Brushes.LawnGreen, vmLinearachse.BtnTaster, WpfObjects.S1, false, false);

        libWpf.Text("-P1", 1, 2, 14, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.RechteckFarbeUmschalten(3,3,14,2,Brushes.Black, buttonRand, WpfObjects.P1);

        libWpf.Text("-S2", 1, 2, 16, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonRounded(3, 3, 16, 3, 50, 15,buttonRand, Brushes.Red, vmLinearachse.BtnTaster, WpfObjects.S2, false, false);


        libWpf.Rechteck(8, 5, 11, 8, Brushes.LightGray);
        libWpf.Text("-S3", 8, 2, 11, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonRounded(10, 3, 11, 3, 50, 15,buttonRand, Brushes.LawnGreen, vmLinearachse.BtnTaster, WpfObjects.S3, false, false);

        libWpf.Text("-S9", 8, 2, 14, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonRounded(10, 3, 14, 2, 30, 5,buttonRand, Brushes.Red, vmLinearachse.BtnTaster, WpfObjects.S9, false, false);

        libWpf.Text("-S4", 8, 2, 16, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonRounded(10, 3, 16, 3, 50, 15,buttonRand, Brushes.LawnGreen, vmLinearachse.BtnTaster, WpfObjects.S4, false, false);


        libWpf.Rechteck(15, 5, 11, 8, Brushes.LightGray);
        libWpf.Text("-S5", 15, 2, 11, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonRounded(17, 3, 11, 3, 50, 15, buttonRand, Brushes.LawnGreen, vmLinearachse.BtnTaster, WpfObjects.S5, false, false);

        libWpf.Text("-S9", 15, 2, 14, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonRounded(17, 3, 14, 2, 30, 5, buttonRand, Brushes.Red, vmLinearachse.BtnTaster, WpfObjects.S9, false, false);

        libWpf.Text("-S6", 15, 2, 16, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonRounded(17, 3, 16, 3, 50, 15, buttonRand, Brushes.LawnGreen, vmLinearachse.BtnTaster, WpfObjects.S6, false, false);


        libWpf.Rechteck(22, 5, 11, 8, Brushes.LightGray);
        libWpf.Text("-S7", 22, 2, 11, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonRounded(24, 3, 11, 3, 50, 15, buttonRand, Brushes.LawnGreen , vmLinearachse.BtnTaster, WpfObjects.S7, false, false);

        libWpf.Text("-S9", 22, 2, 14, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonRounded(24, 3, 14, 2, 30, 5, buttonRand, Brushes.Red, vmLinearachse.BtnTaster, WpfObjects.S9, false, false);

        libWpf.Text("-S8", 22, 2, 16, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonRounded(24, 3, 16, 3, 50, 15, buttonRand, Brushes.LawnGreen, vmLinearachse.BtnTaster, WpfObjects.S8, false, false);


        var kreisRand = new Thickness(2, 2, 2, 2);
        var kreisRandFarbe = new SolidColorBrush(Colors.Black);

        libWpf.Rechteck(1, 5, 20, 3, Brushes.LightGray);
        libWpf.Text("-P2", 1, 2, 20, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.KreisRandVis(3, 3, 20, 3, kreisRandFarbe, kreisRand, WpfObjects.P2);

        libWpf.Rechteck(8, 5, 20, 3, Brushes.LightGray);
        libWpf.Text("-P3", 8, 2, 20, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.KreisRandVis(10, 3, 20, 3, kreisRandFarbe, kreisRand, WpfObjects.P3);

        libWpf.Rechteck(15, 5, 20, 3, Brushes.LightGray);
        libWpf.Text("-P4", 15, 2, 20, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.KreisRandVis(17, 3, 20, 3, kreisRandFarbe, kreisRand, WpfObjects.P4);

    
        return libWpf;
    }
}