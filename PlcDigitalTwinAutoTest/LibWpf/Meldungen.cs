using System.Windows;
using System.Windows.Media;
using LibDatenstruktur;
using LibPlcKommunikation;

namespace LibWpf;

public partial class LibWpf
{
    public void PlcError(PlcDaemon plcDaemon, Datenstruktur datenstruktur)
    {
        if (plcDaemon == null) return;
        if (!plcDaemon.PlcState.PlcError) return;

        Application.Current.Dispatcher.Invoke(() =>
        {
            Rechteck(2, 20, 2, 5, Brushes.OrangeRed);
            Text(plcDaemon.PlcState.PlcErrorMessage, 2, 20, 2, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
            Text($"PC: {datenstruktur.VersionsStringLokal}", 2, 20, 3, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
            Text($"PLC: {datenstruktur.VersionsStringPlc}", 2, 20, 4, 2, HorizontalAlignment.Left, VerticalAlignment.Center, 20, Brushes.Black);
        });
    }
}