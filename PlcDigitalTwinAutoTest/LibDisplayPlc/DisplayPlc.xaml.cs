using LibConfigPlc;
using LibDatenstruktur;
using System.Threading;
using System.Windows.Controls;

namespace LibDisplayPlc;

public partial class DisplayPlc
{
    public bool FensterAktiv { get; set; }

    public DisplayPlc(Datenstruktur datenstruktur, ConfigPlc configPlc, CancellationTokenSource cancellationTokenSource)
    {
        var grid = new Grid();
        Content = grid;

        Width = 800;
        Height = 900;

        var viewModel = new ViewModel.ViewModel(datenstruktur, configPlc, cancellationTokenSource);

        var plcZeichnen = new PlcZeichnen.PlcZeichnen(grid);
        plcZeichnen.Zeichnen();

        DataContext = viewModel;

        Closing += (_, e) =>
        {
            e.Cancel = true;
            PlcFensterAusblenden();
        };
    }
    public void PlcFensterAusblenden()
    {
        FensterAktiv = false;
        Hide();
    }
    public void PlcFensterAnzeigen()
    {
        Show();
        Title = "PLC";
        MaxWidth = 700;
        FensterAktiv = true;
    }
}