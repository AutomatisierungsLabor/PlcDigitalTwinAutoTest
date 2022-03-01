using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DtLap2010_4_Abfuellanlage.ViewModel;

namespace DtLap2010_4_Abfuellanlage.TabZeichnen;

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

        libWpf.RechteckFill(20, 10, 2, 10, Brushes.LightGray);

        libWpf.Text("S1", 21, 2, 2, 2, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("S2", 25, 2, 2, 2, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("P1", 21, 2, 5, 2, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("P2", 25, 2, 5, 2, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.ButtonRounded(22, 2, 2, 2, 14, 15, buttonRand, Brushes.Red, vmLap2010.BtnTaster, WpfObjects.S1, false, false);
        libWpf.ButtonRounded(27, 2, 2, 2, 14, 15, buttonRand, Brushes.Green, vmLap2010.BtnTaster, WpfObjects.S2, false, false);

        libWpf.KreisStrokeMarginSetFilling(22, 2, 5, 2, kreisRandFarbe, kreisRand, WpfObjects.P1);
        libWpf.KreisStrokeMarginSetFilling(27, 2, 5, 2, kreisRandFarbe, kreisRand, WpfObjects.P2);


        ///////////////////////////////////////////////////////////
        //
        //  Simulation - Links
        //
        ///////////////////////////////////////////////////////////




        // libWpf.PlcError();
    }
}