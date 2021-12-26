using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using BasePlcDtAt.BaseViewModel;
using LibAutoTest;
using LibConfigPlc;
using LibDatenstruktur;
using LibDisplayPlc;

namespace BasePlcDtAt;

public partial class BaseWindow
{

    public Datenstruktur Datenstruktur { get; set; }
    public ConfigPlc ConfigPlc { get; set; }
    public DisplayPlc DisplayPlc { get; set; }
    public AutoTest AutoTest { get; set; }

    private readonly ViewModel _viewModel;
    public BaseWindow(ViewModel viewModel, Datenstruktur datenstruktur, int startUpTabIndex)
    {
        _viewModel = viewModel;
        InitializeComponent();
        DataContext = _viewModel;

        Datenstruktur = datenstruktur;
        ConfigPlc = new ConfigPlc("/ConfigPlc");

        _viewModel.BeschreibungZeichnen(Grid0);
        _viewModel.LaborPlatteZeichnen(Grid1);
        _viewModel.SimulationZeichnen(Grid2);

        AutoTest = new AutoTest(Grid3, "/ConfigTests");
        BaseTabControl.SelectedIndex = startUpTabIndex;
        DisplayPlc = new DisplayPlc(Datenstruktur, ConfigPlc);
    }

    private void BetriebsartProjektChanged(object sender, SelectionChangedEventArgs e)
    {
        if (sender is not TabControl tc) return;

        Datenstruktur.BetriebsartProjekt = tc.SelectedIndex switch
        {
            (int)ViewModel.WpfBase.TabBeschreibung => BetriebsartProjekt.BeschreibungAnzeigen,
            (int)ViewModel.WpfBase.TabLaborplatte => BetriebsartProjekt.LaborPlatte,
            (int)ViewModel.WpfBase.TabSimulation => BetriebsartProjekt.Simulation,
            (int)ViewModel.WpfBase.TabAutoTest => BetriebsartProjekt.AutomatischerSoftwareTest,
            _ => Datenstruktur.BetriebsartProjekt
        };
    }

    private void PlcButtonClick(object sender, RoutedEventArgs e)
    {
        if (DisplayPlc.FensterAktiv) DisplayPlc.Schliessen();
        else DisplayPlc.Oeffnen();
    }

    private void PlotterButtonClick(object sender, RoutedEventArgs e) => _viewModel.PlotterButtonClick(sender, e);

    private void BaseWindow_OnClosing(object sender, CancelEventArgs e) => Application.Current.Shutdown();
}