using BasePlcDtAt.BaseViewModel;
using LibAutoTest;
using LibConfigPlc;
using LibDatenstruktur;
using LibDisplayPlc;
using LibPlcTestautomat;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using LibInfo;

namespace BasePlcDtAt;

public partial class BaseWindow
{
    public Datenstruktur Datenstruktur { get; set; }
    public ConfigPlc ConfigPlc { get; set; }
    public DisplayPlc DisplayPlc { get; set; }
    public AutoTest AutoTest { get; set; }
    public TestAutomat TestAutomat { get; set; }
    public  DisplayInfo DisplayInfo { get; set; }

    private readonly VmBase _vmBase;
    private readonly CancellationTokenSource _baseCancellationToken;
    private const string PfadConfigTests = "ConfigTests";
    private const string PfadConfigPlc = "ConfigPlc";

    public BaseWindow(VmBase vmBase, Datenstruktur datenstruktur, int startUpTabIndex, CancellationTokenSource baseCancellationToken)
    {
        _vmBase = vmBase;
        Datenstruktur = datenstruktur;
        _baseCancellationToken = baseCancellationToken;

        DisplayInfo = new DisplayInfo();

        InitializeComponent();
        DataContext = _vmBase;

        _vmBase.PlcDaemon.SetInfoCallback(DisplayInfo.SetKommunikationPlcValues);
        DisplayInfo.SetResetInfoCallback(_vmBase.PlcDaemon.ResetPlcInfo);

        ConfigPlc = new ConfigPlc(PfadConfigPlc);

        _vmBase.BeschreibungZeichnen(TabBeschreibung);
        _vmBase.LaborPlatteZeichnen(TabLaborPlatte);
        _vmBase.SimulationZeichnen(TabSimulation);

        TestAutomat = new TestAutomat(Datenstruktur, _baseCancellationToken);

        AutoTest = new AutoTest(Datenstruktur, ConfigPlc, TabAutoTest, TestAutomat, PfadConfigTests, _baseCancellationToken);
        AutoTest.SetCallback(ConfigPlc.SetPath);

        BaseTabControl.SelectedIndex = startUpTabIndex;
        DisplayPlc = new DisplayPlc(Datenstruktur, ConfigPlc, _baseCancellationToken);
    }
    private void BetriebsartProjektChanged(object sender, SelectionChangedEventArgs e)
    {
        if (sender is not TabControl tc) return;

        switch (tc.SelectedIndex)
        {
            case (int)Contracts.WpfBase.TabBeschreibung:
                ConfigPlc.SetPathRelativ(PfadConfigPlc);
                Datenstruktur.BetriebsartProjekt = BetriebsartProjekt.BeschreibungAnzeigen;
                break;
            case (int)Contracts.WpfBase.TabLaborplatte:
                ConfigPlc.SetPathRelativ(PfadConfigPlc);
                Datenstruktur.BetriebsartProjekt = BetriebsartProjekt.LaborPlatte;
                break;
            case (int)Contracts.WpfBase.TabSimulation:
                ConfigPlc.SetPathRelativ(PfadConfigPlc);
                Datenstruktur.BetriebsartProjekt = BetriebsartProjekt.Simulation;
                break;
            case (int)Contracts.WpfBase.TabAutoTest:
                AutoTest.ResetSelectedProject();
                Datenstruktur.BetriebsartProjekt = BetriebsartProjekt.AutomatischerSoftwareTest;
                break;
            default:
                Datenstruktur.BetriebsartProjekt = Datenstruktur.BetriebsartProjekt;
                break;
        }
    }
    private void BaseWindow_OnClosing(object sender, CancelEventArgs e)
    {
        _baseCancellationToken.Cancel();
        Application.Current.Shutdown();
    }
    private void PlcButtonClick(object sender, RoutedEventArgs e)
    {
        if (DisplayPlc.FensterAktiv) DisplayPlc.PlcFensterAusblenden();
        else DisplayPlc.PlcFensterAnzeigen();
    }
    private void PlotterButtonClick(object sender, RoutedEventArgs e) => _vmBase.PlotterButtonClick(sender, e);
    private void LinkHomepageClick(object sender, RoutedEventArgs e)
    {
        var idListe = Datenstruktur.VorbereitungId.Split(",");

        foreach (var id in idListe)
        {
            try
            {
                Process.Start(new ProcessStartInfo($"https://linderonline.at/fk/plc_beschreibung.php?ID={id}") { UseShellExecute = true });
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }
    }
    private void AlarmVerwaltungClick(object sender, RoutedEventArgs e) { }
    private void InfoClick(object sender, RoutedEventArgs e)
    {
        if (DisplayInfo.FensterAktiv) DisplayInfo.FensterAusblenden();
        else DisplayInfo.FensterAnzeigen();
    }
}