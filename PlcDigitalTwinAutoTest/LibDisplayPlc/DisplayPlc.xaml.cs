using LibDatenstruktur;
using System.Threading;
using System.Windows.Controls;

namespace LibDisplayPlc;

public partial class DisplayPlc
{
    public bool FensterAktiv { get; set; }

    public DisplayPlc(Datenstruktur datenstruktur, LibConfigDt.ConfigDt configDt, CancellationTokenSource cancellationTokenSource)
    {
        var grid = new Grid();
        Content = grid;

        Height = 900;

        if (configDt.GetAnzahlAa() > 0 || configDt.GetAnzahlAi() > 0) Width = 1000; else Width = 650;

        var viewModel = new ViewModel.VmPlc(datenstruktur, configDt, cancellationTokenSource);

        var plcZeichnen = new PlcZeichnen.PlcZeichnen(grid);
        plcZeichnen.Zeichnen(configDt);

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
        FensterAktiv = true;
    }
}