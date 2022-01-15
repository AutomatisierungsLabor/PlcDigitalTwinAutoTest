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

    private readonly VmBase _vmBase;

    public BaseWindow(VmBase vmBase, Datenstruktur datenstruktur, int startUpTabIndex)
    {
        Datenstruktur = datenstruktur;

        _vmBase = vmBase;
        InitializeComponent();
        DataContext = _vmBase;

        ConfigPlc = new ConfigPlc("/ConfigPlc");

        _vmBase.BeschreibungZeichnen(TabBeschreibung);
        _vmBase.LaborPlatteZeichnen(TabLaborPlatte);
        _vmBase.SimulationZeichnen(TabSimulation);

        AutoTest = new AutoTest(Datenstruktur, ConfigPlc, TabAutoTest, "/ConfigTests");
        AutoTest.SetCallback(ConfigPlc.SetPath);
        _vmBase.SetAutoTestRef(AutoTest);

        BaseTabControl.SelectedIndex = startUpTabIndex;
        DisplayPlc = new DisplayPlc(Datenstruktur, ConfigPlc);
    }
    private void BetriebsartProjektChanged(object sender, SelectionChangedEventArgs e)
    {
        if (sender is not TabControl tc) return;

        switch (tc.SelectedIndex)
        {
            case (int)VmBase.WpfBase.TabBeschreibung:
                ConfigPlc.SetPathRelativ("/ConfigPlc");
                Datenstruktur.BetriebsartProjekt = BetriebsartProjekt.BeschreibungAnzeigen;
                break;
            case (int)VmBase.WpfBase.TabLaborplatte:
                ConfigPlc.SetPathRelativ("/ConfigPlc");
                Datenstruktur.BetriebsartProjekt = BetriebsartProjekt.LaborPlatte;
                break;
            case (int)VmBase.WpfBase.TabSimulation:
                ConfigPlc.SetPathRelativ("/ConfigPlc");
                Datenstruktur.BetriebsartProjekt = BetriebsartProjekt.Simulation;
                break;
            case (int)VmBase.WpfBase.TabAutoTest:
                AutoTest.ResetSelectedProject();
                Datenstruktur.BetriebsartProjekt = BetriebsartProjekt.AutomatischerSoftwareTest;
                break;
            default:
                Datenstruktur.BetriebsartProjekt = Datenstruktur.BetriebsartProjekt;
                break;
        }
    }
    private void PlcButtonClick(object sender, RoutedEventArgs e)
    {
        if (DisplayPlc.FensterAktiv) DisplayPlc.Schliessen();
        else DisplayPlc.Oeffnen();
    }
    private void PlotterButtonClick(object sender, RoutedEventArgs e) => _vmBase.PlotterButtonClick(sender, e);
    private void BaseWindow_OnClosing(object sender, CancelEventArgs e) => Application.Current.Shutdown();
}