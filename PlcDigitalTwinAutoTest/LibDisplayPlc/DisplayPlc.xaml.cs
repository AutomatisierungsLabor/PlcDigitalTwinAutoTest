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
        var maxAnzByteAaAi = 0;
        var maxAnzByteDaDi = 0;

        if (configDt.GetAnzahlAa() > 0 || configDt.GetAnzahlAi() > 0) maxAnzByteAaAi = 1;
        if (configDt.GetAnzahlByteDa() > maxAnzByteDaDi) maxAnzByteDaDi = configDt.GetAnzahlByteDa();
        if (configDt.GetAnzahlByteDi() > maxAnzByteDaDi) maxAnzByteDaDi = configDt.GetAnzahlByteDi();

        if (maxAnzByteDaDi < 2) maxAnzByteDaDi = 2;

        Height = 900;
        Width = (maxAnzByteAaAi + maxAnzByteDaDi) * 350;

        var viewModel = new ViewModel.VmPlc(datenstruktur, configDt, cancellationTokenSource);

        var plcZeichnen = new PlcZeichnen.PlcZeichnen(grid, maxAnzByteAaAi, maxAnzByteDaDi);
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