using System.Windows;
using System.Windows.Controls;
using LibConfigPlc;
using LibDatenstruktur;

namespace LibDisplayPlc;

public partial class DisplayPlc
{
    public  Model.Model Model { get; set; }
    public ViewModel.ViewModel ViewModel { get; set; }
    public PlcZeichnen.PlcZeichnen PlcZeichnen { get; set; }
    public Grid Grid { get; set; }
    public bool FensterAktiv { get; set; }

    public DisplayPlc(Datenstruktur datenstruktur, ConfigPlc configPlc)
    {

        Model = new Model.Model(datenstruktur);

        ViewModel = new ViewModel.ViewModel(Model, datenstruktur);
        ViewModel.SetRefConfigPlc(configPlc);

        Grid = new Grid { Name = "PlcGrid", MaxWidth = 700, MaxHeight = 1200, HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Top };
        Content = Grid;

        PlcZeichnen = new PlcZeichnen.PlcZeichnen(configPlc, Grid);

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