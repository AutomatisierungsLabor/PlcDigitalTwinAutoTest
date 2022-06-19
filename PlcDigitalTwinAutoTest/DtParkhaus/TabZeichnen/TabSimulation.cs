using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DtParkhaus.ViewModel;

namespace DtParkhaus.TabZeichnen;

public partial class TabZeichnen
{
    public static void TabSimulationZeichnen(VmParkhaus vmParkhaus, TabItem tabItem, string hintergrund)
    {
        var libWpf = new LibWpf.LibWpf(tabItem);
        libWpf.SetBackground(new BrushConverter().ConvertFromString(hintergrund) as SolidColorBrush);
        libWpf.GridZeichnen(50, 40, false, false, false);


        ///////////////////////////////////////////////////////////
        //
        // Bedienung - Rechts
        //
        /////////////////////////////////////////////////////////// 

        libWpf.RectangleFill(29, 12, 1, 30, Brushes.LightGray);

        var buttonRand = new Thickness(0, 0, 0, 0);


        libWpf.Text("Freie Parkplätze:", 30, 10, 2, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.TextSetContent(30, 10, 4, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black, nameof(vmParkhaus.StringFreieParkplaetze));
        libWpf.TextSetContent(30, 10, 6, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black, nameof(vmParkhaus.StringFreieParkplaetzeSoll));

        libWpf.ButtonBackgroundContentMarginRounded("Zufall", 30, 3, 10, 2, 14, 15, Brushes.LawnGreen, buttonRand, vmParkhaus.ButtonTasterCommand, "Zufall", nameof(vmParkhaus.ClickModeZufall));


        ///////////////////////////////////////////////////////////
        //
        // Simulation - Links
        //
        /////////////////////////////////////////////////////////// 

        var randAuto = new Thickness(0, 0, 0, 0);
        libWpf.ButtonImageDrehenMarginSetVisibility(2, 2, 5, 2, "LkwGelb.png", 0, randAuto, vmParkhaus.ButtonTasterCommand, "0", vmParkhaus.ClickModePkw00);






        libWpf.PlcError();
    }
}