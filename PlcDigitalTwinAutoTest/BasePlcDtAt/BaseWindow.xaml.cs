using System.Windows;
using System.Windows.Controls;
using BasePlcDtAt.BaseViewModel;
using LibConfigPlc;
using LibDatenstruktur;
using LibDisplayPlc;

namespace BasePlcDtAt;

public partial class BaseWindow
{

    public Datenstruktur Datenstruktur { get; set; }
    public ConfigPlc ConfigPlc { get; set; }
    public DisplayPlc DisplayPlc { get; set; }

    private readonly ViewModel _viewModel;
    public BaseWindow(ViewModel viewModel, Datenstruktur  datenstruktur)
    {
        _viewModel = viewModel;
        InitializeComponent();
        DataContext= _viewModel;

        Datenstruktur = datenstruktur;
        ConfigPlc = new ConfigPlc("/ConfigPlc");
        
        _viewModel.BeschreibungZeichnen(Grid0);
        _viewModel.LaborPlatteZeichnen(Grid1);
        _viewModel.SimulationZeichnen(Grid2);
        _viewModel.AutotestZeichnen(Grid3);


        DisplayPlc = new DisplayPlc(Datenstruktur, ConfigPlc);

        DisplayPlc.Show();
    }

    private void BetriebsartProjektChanged(object sender, SelectionChangedEventArgs e)
    {
        if (sender is not TabControl tc) return;

        Datenstruktur.BetriebsartProjekt = tc.SelectedIndex switch
        {
            0 => BetriebsartProjekt.BeschreibungAnzeigen,
            1 => BetriebsartProjekt.LaborPlatte,
            2 => BetriebsartProjekt.Simulation,
            3 => BetriebsartProjekt.AutomatischerSoftwareTest,
            _ => Datenstruktur.BetriebsartProjekt
        };
    }

    private void PlcButtonClick(object sender, RoutedEventArgs e) => _viewModel.PlcButtonClick(sender,e);
    private void PlotterButtonClick(object sender, RoutedEventArgs e) => _viewModel.PlotterButtonClick(sender, e);
}