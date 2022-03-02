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

        libWpf.Text("S1", 20, 2, 2, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("S2", 25, 2, 2, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("P1", 20, 2, 6, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.ButtonRounded(22, 3, 2, 3, 14, 15, buttonRand, Brushes.Red, vmLap2010.BtnTaster, WpfObjects.S1);
        libWpf.ButtonRounded(27, 3, 2, 3, 14, 15, buttonRand, Brushes.Green, vmLap2010.BtnTaster, WpfObjects.S2);

        libWpf.KreisStrokeMarginSetFilling(22, 3, 6, 3, kreisRandFarbe, kreisRand, WpfObjects.P1);
        libWpf.Text("Füllstand", 22, 3, 6, 3, HorizontalAlignment.Right, VerticalAlignment.Center, 20, Brushes.Black);

        ///////////////////////////////////////////////////////////
        //
        //  Simulation - Links
        //
        ///////////////////////////////////////////////////////////

        libWpf.RechteckFillMargin(2, 2, 3, 12, Brushes.DarkGray, new Thickness(10, 0, 10, 0));
        libWpf.RechteckFillMargin(4, 2, 3, 12, Brushes.DarkGray, new Thickness(10, 0, 10, 0));

        var ventilRand = new Thickness(0, 0, 0, 0);
        libWpf.Text("K1", 4, 2, 12, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.BildSichtbarkeitEin("VentilElektrischEin.jpg", 4, 2, 12, 2, ventilRand, WpfObjects.K1);
        libWpf.BildSichtbarkeitAus("VentilElektrischAus.jpg", 4, 2, 12, 2, ventilRand, WpfObjects.K1);


        libWpf.RechteckFill(10, 6, 2, 6, Brushes.Coral);
        libWpf.RechteckFillStrokeSetMargin(10, 6, 2, 6, Brushes.BurlyWood, Brushes.BurlyWood, 0, WpfObjects.Fuellstand);

        libWpf.RechteckSetFill(12,2,8,2, Brushes.BurlyWood,0, WpfObjects.Zuleitung);


        libWpf.Text("K2", 8, 2, 12, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.BildSichtbarkeitEin("VentilElektrischEin.jpg", 10, 2, 12, 2, ventilRand, WpfObjects.K2);
        libWpf.BildSichtbarkeitAus("VentilElektrischAus.jpg", 10, 2, 12, 2, ventilRand, WpfObjects.K2);


        // libWpf.PlcError();
    }
}