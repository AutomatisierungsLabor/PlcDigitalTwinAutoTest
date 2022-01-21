using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DtLinearachse.ViewModel;

namespace DtLinearachse.TabZeichnen;

public partial class TabZeichnen
{
    public static LibWpf.LibWpf TabSimulationZeichnen(VmLinearachse vmFibonacci, TabItem tabItem, string hintergrund)
    {
        var libWpf = new LibWpf.LibWpf(tabItem);
        libWpf.SetBackground(new BrushConverter().ConvertFromString(hintergrund) as SolidColorBrush);
        libWpf.GridZeichnen(50, 30, 40, 30, true);

        
        libWpf.Rechteck(3,2,1,7,Brushes.Black);
        libWpf.Rechteck(5,20,3,3,Brushes.DarkGray);
        libWpf.Rechteck(5, 20, 4, 1, Brushes.Black);
        libWpf.Rechteck(25, 2, 1, 7, Brushes.Black);

        libWpf.RechteckRand(5,20,1,7,Brushes.Yellow,WpfObjects.PositionSchlitten);

        var buttonRand = new Thickness(2, 5, 2, 5);

        libWpf.Rechteck(3,3,9,8,Brushes.LightGray);
        libWpf.Text("-S1",1,2,9,3,HorizontalAlignment.Left, VerticalAlignment.Center,20,Brushes.Black);
        libWpf.ButtonRounded(3, 3, 9, 3, 50, 15,buttonRand, Brushes.LawnGreen, vmFibonacci.BtnTaster, WpfObjects.S1, false, false);

        libWpf.Text("-P1", 1, 2, 12, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.RechteckFarbeUmschalten(3,3,12,2,Brushes.Black, buttonRand, WpfObjects.P1);

        libWpf.Text("-S2", 1, 2, 14, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonRounded(3, 3, 14, 3, 50, 15,buttonRand, Brushes.Red, vmFibonacci.BtnTaster, WpfObjects.S2, false, false);


        libWpf.Rechteck(10, 3, 9, 8, Brushes.LightGray);
        libWpf.Text("-S3", 8, 2, 9, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonRounded(10, 3, 9, 3, 50, 15,buttonRand, Brushes.LawnGreen, vmFibonacci.BtnTaster, WpfObjects.S3, false, false);

        libWpf.Text("-S9", 8, 2, 12, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonRounded(10, 3, 12, 2, 30, 5,buttonRand, Brushes.Red, vmFibonacci.BtnTaster, WpfObjects.S9, false, false);

        libWpf.Text("-S4", 8, 2, 14, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonRounded(10, 3, 14, 3, 50, 15,buttonRand, Brushes.LawnGreen, vmFibonacci.BtnTaster, WpfObjects.S4, false, false);


        libWpf.Rechteck(17, 3, 9, 8, Brushes.LightGray);
        libWpf.Text("-S5", 15, 2, 9, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonRounded(17, 3, 9, 3, 50, 15, buttonRand, Brushes.LawnGreen, vmFibonacci.BtnTaster, WpfObjects.S5, false, false);

        libWpf.Text("-S9", 15, 2, 12, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonRounded(17, 3, 12, 2, 30, 5, buttonRand, Brushes.Red, vmFibonacci.BtnTaster, WpfObjects.S9, false, false);

        libWpf.Text("-S6", 15, 2, 14, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonRounded(17, 3, 14, 3, 50, 15, buttonRand, Brushes.LawnGreen, vmFibonacci.BtnTaster, WpfObjects.S6, false, false);


        libWpf.Rechteck(24, 3, 9, 8, Brushes.LightGray);
        libWpf.Text("-S7", 22, 2, 9, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonRounded(24, 3, 9, 3, 50, 15, buttonRand, Brushes.LawnGreen ,vmFibonacci.BtnTaster, WpfObjects.S7, false, false);

        libWpf.Text("-S9", 22, 2, 12, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonRounded(24, 3, 12, 2, 30, 5, buttonRand, Brushes.Red, vmFibonacci.BtnTaster, WpfObjects.S9, false, false);

        libWpf.Text("-S8", 22, 2, 14, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.ButtonRounded(24, 3, 14, 3, 50, 15, buttonRand, Brushes.LawnGreen, vmFibonacci.BtnTaster, WpfObjects.S8, false, false);


        var kreisRand = new Thickness(2, 2, 2, 2);
        var kreisRandFarbe = new SolidColorBrush(Colors.Black);

        libWpf.Text("-P2", 1, 2, 19, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.KreisRandVis(3, 3, 19, 3, kreisRandFarbe, kreisRand, WpfObjects.P2);

        libWpf.Text("-P3", 8, 2, 19, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.KreisRandVis(10, 3, 19, 3, kreisRandFarbe, kreisRand, WpfObjects.P3);

        libWpf.Text("-P4", 15, 2, 19, 3, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.KreisRandVis(17, 3, 19, 3, kreisRandFarbe, kreisRand, WpfObjects.P4);

    
        return libWpf;
    }
}