using System.Windows;
using System.Windows.Controls;
using LibConfigPlc;
using LibDatenstruktur;

namespace LibDisplayPlc;

public partial class DisplayPlc
{
    public ViewModel.ViewModel ViewModel { get; set; }
    public PlcZeichnen.PlcZeichnen PlcZeichnen { get; set; }
    public Grid Grid { get; set; }
    public bool FensterAktiv { get; set; }

    public DisplayPlc(Datenstruktur datenstruktur, ConfigPlc configPlc)
    {
        ViewModel = new ViewModel.ViewModel(default, datenstruktur);
        ViewModel.SetRefConfigPlc(configPlc);

        Grid = new Grid { Name = "PlcGrid", MaxWidth = 800, MaxHeight = 1000, HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Top };
        Content = Grid;

        PlcZeichnen = new PlcZeichnen.PlcZeichnen(Grid);

        DataContext = ViewModel;

        Closing += (_, e) =>
        {
            e.Cancel = true;
            Schliessen();
        };
    }
    public void Schliessen()
    {
        FensterAktiv = false;
        Hide();
    }
    public void Oeffnen()
    {
        Show();
        Title = "PLC";
        MaxWidth = 700;
        FensterAktiv = true;
    }
}