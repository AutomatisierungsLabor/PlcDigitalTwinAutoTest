using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LibInfo;

public class InfoZeichnen
{
    public InfoZeichnen(Grid grid, VmInfo.VmInfo vmInfo)
    {
        var libWpf = new LibWpf.LibWpf(grid);

        libWpf.GridZeichnen(20, 12, false, false, true);
        libWpf.ButtonBackgroundContentMarginRounded("Reset", 15, 2, 1, 2, 20, 5, Brushes.LawnGreen, new Thickness(0, 0, 0, 0), vmInfo.ButtonTasterCommand, "-", nameof(vmInfo.ClickModeTasterReset));

        libWpf.Text("Lokale Projektbezeichnung:", 1, 10, 1, 1, HorizontalAlignment.Left, VerticalAlignment.Center, 16, Brushes.Black);
        libWpf.Text("PLC Projektbezeichnung:", 1, 10, 2, 1, HorizontalAlignment.Left, VerticalAlignment.Center, 16, Brushes.Black);

        libWpf.TextSetContent(9, 10, 1, 1, HorizontalAlignment.Left, VerticalAlignment.Center, 16, Brushes.Black, nameof(vmInfo.StringProjektbezeichnungLokal));
        libWpf.TextSetContent(9, 10, 2, 1, HorizontalAlignment.Left, VerticalAlignment.Center, 16, Brushes.Black, nameof(vmInfo.StringProjektbezeichnungPlc));


        libWpf.Text("Kommunikation mit der PLC:", 1, 10, 3, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);

        libWpf.Text("Status:", 2, 4, 4, 1, HorizontalAlignment.Left, VerticalAlignment.Center, 16, Brushes.Black);
        libWpf.Text("Actual:", 2, 4, 5, 1, HorizontalAlignment.Left, VerticalAlignment.Center, 16, Brushes.Black);
        libWpf.Text("Min:", 2, 4, 6, 1, HorizontalAlignment.Left, VerticalAlignment.Center, 16, Brushes.Black);
        libWpf.Text("Max:", 2, 4, 7, 1, HorizontalAlignment.Left, VerticalAlignment.Center, 16, Brushes.Black);

        libWpf.TextSetContent(5, 10, 4, 1, HorizontalAlignment.Left, VerticalAlignment.Center, 16, Brushes.Black, nameof(vmInfo.StringPlcStatus));
        libWpf.TextSetContent(5, 10, 5, 1, HorizontalAlignment.Left, VerticalAlignment.Center, 16, Brushes.Black, nameof(vmInfo.StringPlcZykluszeitAct));
        libWpf.TextSetContent(5, 10, 6, 1, HorizontalAlignment.Left, VerticalAlignment.Center, 16, Brushes.Black, nameof(vmInfo.StringPlcZykluszeitMin));
        libWpf.TextSetContent(5, 10, 7, 1, HorizontalAlignment.Left, VerticalAlignment.Center, 16, Brushes.Black, nameof(vmInfo.StringPlcZykluszeitMax));

        libWpf.Text("Di:", 2, 4, 10, 1, HorizontalAlignment.Left, VerticalAlignment.Center, 16, Brushes.Black);
        libWpf.Text("Da:", 2, 4, 11, 1, HorizontalAlignment.Left, VerticalAlignment.Center, 16, Brushes.Black);

        libWpf.TextSetContent(5, 10, 10, 1, HorizontalAlignment.Left, VerticalAlignment.Center, 16, Brushes.Black, nameof(vmInfo.StringDi0));
        libWpf.TextSetContent(8, 10, 10, 1, HorizontalAlignment.Left, VerticalAlignment.Center, 16, Brushes.Black, nameof(vmInfo.StringDi1));

        libWpf.TextSetContent(5, 10, 11, 1, HorizontalAlignment.Left, VerticalAlignment.Center, 16, Brushes.Black, nameof(vmInfo.StringDa0));
        libWpf.TextSetContent(8, 10, 11, 1, HorizontalAlignment.Left, VerticalAlignment.Center, 16, Brushes.Black, nameof(vmInfo.StringDa1));
    }
}