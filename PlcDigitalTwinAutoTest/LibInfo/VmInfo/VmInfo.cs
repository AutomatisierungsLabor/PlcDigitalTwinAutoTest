using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace LibInfo.VmInfo;

public partial class VmInfo : ObservableObject
{
    private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);


    public VmInfo(Grid grid)
    {
        Log.Debug("Konstruktor - startet");

        var libWpf = new LibWpf.LibWpf(grid);

        libWpf.GridZeichnen(20, 30, 12, 30, true);
        libWpf.ButtonBackgroundContentMarginRounded("Reset", 15, 2, 1, 2, 20, 5, Brushes.LawnGreen, new Thickness(0, 0, 0, 0), ButtonTasterCommand, "-", nameof(ClickModeTasterReset));

        libWpf.Text("Kommunikation mit der PLC:", 1, 10, 2, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("Min:", 2, 4, 4, 1, HorizontalAlignment.Left, VerticalAlignment.Center, 16, Brushes.Black);
        libWpf.Text("Max:", 2, 4, 5, 1, HorizontalAlignment.Left, VerticalAlignment.Center, 16, Brushes.Black);
        libWpf.Text("Avg:", 2, 4, 6, 1, HorizontalAlignment.Left, VerticalAlignment.Center, 16, Brushes.Black);

        libWpf.TextSetContent(5, 4, 4, 1, HorizontalAlignment.Left, VerticalAlignment.Center, 16, Brushes.Black, nameof(VmInfo.StringKommunikationPlcMin));
        libWpf.TextSetContent(5, 4, 5, 1, HorizontalAlignment.Left, VerticalAlignment.Center, 16, Brushes.Black, nameof(VmInfo.StringKommunikationPlcMax));
        libWpf.TextSetContent(5, 4, 6, 1, HorizontalAlignment.Left, VerticalAlignment.Center, 16, Brushes.Black, nameof(VmInfo.StringKommunikationPlcAvg));
    }


    private static void AlleWerteZuruecksetzen()
    {
        throw new System.NotImplementedException();
    }
}