﻿using BasePlcDtAt.BaseViewModel;
using LibAutoTest;
using LibDatenstruktur;
using LibDisplayPlc;
using LibInfo;
using LibPlcTestautomat;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using LibAlarmverwaltung;
using LibConfigDt;

namespace BasePlcDtAt;

public partial class BaseWindow
{
    public Datenstruktur Datenstruktur { get; set; }
    public ConfigDt ConfigDt { get; set; }
    public DisplayPlc DisplayPlc { get; set; }
    public AutoTest AutoTest { get; set; }
    public TestAutomat TestAutomat { get; set; }
    public DisplayInfo DisplayInfo { get; set; }
    public Alarmverwaltung Alarmverwaltung { get; set; }

    private readonly VmBase _vmBase;
    private readonly CancellationTokenSource _baseCancellationToken;
    private const string PfadConfigTests = "ConfigTests";
    private const string PfadJsonDt = "ConfigDt";

    public BaseWindow(VmBase vmBase, Datenstruktur datenstruktur, int startUpTabIndex, CancellationTokenSource baseCancellationToken)
    {
        _vmBase = vmBase;
        Datenstruktur = datenstruktur;
        _baseCancellationToken = baseCancellationToken;

        DisplayInfo = new DisplayInfo(Datenstruktur);

        InitializeComponent();
        DataContext = _vmBase;

        _vmBase.PlcDaemon.SetInfoCallback(DisplayInfo.SetKommunikationPlcValues);
        DisplayInfo.SetResetInfoCallback(_vmBase.PlcDaemon.ResetPlcInfo);

        ConfigDt = new ConfigDt(PfadJsonDt);
        ConfigDt.SetCallbackNeuerTest(NeuerTestAusgewaehlt);

        _vmBase.BeschreibungZeichnen(TabBeschreibung);
        _vmBase.LaborPlatteZeichnen(TabLaborPlatte);
        _vmBase.SimulationZeichnen(TabSimulation);

        TestAutomat = new TestAutomat(Datenstruktur, _baseCancellationToken);

        AutoTest = new AutoTest(Datenstruktur, ConfigDt, TabAutoTest, TestAutomat, PfadConfigTests, _baseCancellationToken);
        AutoTest.SetCallback(ConfigDt.SetPath);

        DisplayPlc = new DisplayPlc(Datenstruktur, ConfigDt, _baseCancellationToken);

        Alarmverwaltung = new Alarmverwaltung(Datenstruktur, ConfigDt, _baseCancellationToken);

        BaseTabControl.SelectedIndex = startUpTabIndex;
    }
    private void BetriebsartProjektChanged(object sender, SelectionChangedEventArgs e)
    {
        if (sender is not TabControl tc) return;

        switch (tc.SelectedIndex)
        {
            case (int)Contracts.WpfBase.TabBeschreibung:
                ConfigDt.SetPathRelativ(PfadJsonDt);
                Datenstruktur.BetriebsartProjekt = BetriebsartProjekt.BeschreibungAnzeigen;
                break;
            case (int)Contracts.WpfBase.TabLaborplatte:
                ConfigDt.SetPathRelativ(PfadJsonDt);
                Datenstruktur.BetriebsartProjekt = BetriebsartProjekt.LaborPlatte;
                break;
            case (int)Contracts.WpfBase.TabSimulation:
                ConfigDt.SetPathRelativ(PfadJsonDt);
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

    private void AlarmVerwaltungClick(object sender, RoutedEventArgs e)
    {
        if (Alarmverwaltung.FensterAktiv) Alarmverwaltung.FensterAusblenden();
        else Alarmverwaltung.FensterAnzeigen();
    }
    private void InfoClick(object sender, RoutedEventArgs e)
    {
        if (DisplayInfo.FensterAktiv) DisplayInfo.FensterAusblenden();
        else DisplayInfo.FensterAnzeigen();
    }

    private void NeuerTestAusgewaehlt()
    {
        Alarmverwaltung.ConfigNeuLaden();
    }
}