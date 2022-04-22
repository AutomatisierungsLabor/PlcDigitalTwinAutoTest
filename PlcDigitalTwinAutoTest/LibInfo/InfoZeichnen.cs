using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LibInfo;

public class InfoZeichnen
{
    public InfoZeichnen(Grid grid, VmInfo.VmInfo vmInfo)
    {
        var libWpf = new LibWpf.LibWpf(grid);

        libWpf.GridZeichnen(20, 30, 12, 30, true);
        libWpf.ButtonBackgroundContentMarginRounded("Reset", 15, 2, 1, 2, 20, 5, Brushes.LawnGreen, new Thickness(0, 0, 0, 0), vmInfo.ButtonTasterCommand, "-", nameof(vmInfo.ClickModeTasterReset));

        libWpf.Text("Kommunikation mit der PLC:", 1, 10, 2, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        libWpf.Text("Status:", 2, 4, 4, 1, HorizontalAlignment.Left, VerticalAlignment.Center, 16, Brushes.Black);

        libWpf.Text("Actual:", 2, 4, 5, 1, HorizontalAlignment.Left, VerticalAlignment.Center, 16, Brushes.Black);
        libWpf.Text("Min:", 2, 4, 6, 1, HorizontalAlignment.Left, VerticalAlignment.Center, 16, Brushes.Black);
        libWpf.Text("Max:", 2, 4, 7, 1, HorizontalAlignment.Left, VerticalAlignment.Center, 16, Brushes.Black);

        libWpf.TextSetContent(5, 10, 4, 1, HorizontalAlignment.Left, VerticalAlignment.Center, 16, Brushes.Black, nameof(vmInfo.StringPlcStatus));
        libWpf.TextSetContent(5, 10, 5, 1, HorizontalAlignment.Left, VerticalAlignment.Center, 16, Brushes.Black, nameof(vmInfo.StringPlcZykluszeitAct));
        libWpf.TextSetContent(5, 10, 6, 1, HorizontalAlignment.Left, VerticalAlignment.Center, 16, Brushes.Black, nameof(vmInfo.StringPlcZykluszeitMin));
        libWpf.TextSetContent(5, 10, 7, 1, HorizontalAlignment.Left, VerticalAlignment.Center, 16, Brushes.Black, nameof(vmInfo.StringPlcZykluszeitMax));
    }
}