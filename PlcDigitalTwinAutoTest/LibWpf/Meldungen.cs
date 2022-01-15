using System.Windows;
using System.Windows.Media;
using LibPlcKommunikation;

namespace LibWpf;

public partial class LibWpf
{
    public void PlcError(PlcDaemon plcDaemon)
    {
        if (plcDaemon == null) return;

        Rechteck(2, 20, 2, 10, Brushes.LightSalmon);

        //  libWpf.TextVis(5, 10, 5, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        //  libWpf.TextVis(5, 10, 10, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black, (int)WpfBase.ErrorVersionPlc);


    }
}