using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using LibConfigPlc;
using LibDatenstruktur;

namespace LibDisplayPlc.ViewModel;

public enum WpfObjects
{
    // ReSharper disable UnusedMember.Global
    Di00 = 0,
    Di01,
    Di02,
    Di03,
    Di04,
    Di05,
    Di06,
    Di07,
    Di10,
    Di11,
    Di12,
    Di13,
    Di14,
    Di15,
    Di16,
    Di17,

    DiBeschreibung00,
    DiBeschreibung01,
    DiBeschreibung02,
    DiBeschreibung03,
    DiBeschreibung04,
    DiBeschreibung05,
    DiBeschreibung06,
    DiBeschreibung07,
    DiBeschreibung10,
    DiBeschreibung11,
    DiBeschreibung12,
    DiBeschreibung13,
    DiBeschreibung14,
    DiBeschreibung15,
    DiBeschreibung16,
    DiBeschreibung17,

    Da00,
    Da01,
    Da02,
    Da03,
    Da04,
    Da05,
    Da06,
    Da07,
    Da10,
    Da11,
    Da12,
    Da13,
    Da14,
    Da15,
    Da16,
    Da17,

    DaBeschreibung00,
    DaBeschreibung01,
    DaBeschreibung02,
    DaBeschreibung03,
    DaBeschreibung04,
    DaBeschreibung05,
    DaBeschreibung06,
    DaBeschreibung07,
    DaBeschreibung10,
    DaBeschreibung11,
    DaBeschreibung12,
    DaBeschreibung13,
    DaBeschreibung14,
    DaBeschreibung15,
    DaBeschreibung16,
    DaBeschreibung17
    // ReSharper restore UnusedMember.Global
}

public class ViewModel : BasePlcDtAt.BaseViewModel.ViewModel
{
    private ConfigPlc _configPlc;

    public ViewModel(BasePlcDtAt.BaseModel.Model model, Datenstruktur datenstruktur) : base(model, datenstruktur) { }

    protected override void ViewModelAufrufThread()
    {
        for (var i = 0; i < 100; i++)
        {
            SichtbarEin[i] = Visibility.Collapsed;
            SichtbarAus[i] = Visibility.Collapsed;
        }

        foreach (var zeile in _configPlc.Di.Zeilen)
        {
            var bitnummer = zeile.StartBit + 8 * zeile.StartByte;
            Text[(int)WpfObjects.Di00 + bitnummer] = zeile.Bezeichnung;
            Text[(int)WpfObjects.DiBeschreibung00 + bitnummer] = zeile.Kommentar;
            SichtbarEin[(int)WpfObjects.Di00 + bitnummer] = Visibility.Visible;
            SichtbarEin[(int)WpfObjects.DiBeschreibung00 + bitnummer] = Visibility.Visible;
        }

        foreach (var zeile in _configPlc.Da.Zeilen)
        {
            var bitnummer = zeile.StartBit + 8 * zeile.StartByte;
            Text[(int)WpfObjects.Da00 + bitnummer] = zeile.Bezeichnung;
            Text[(int)WpfObjects.DaBeschreibung00 + bitnummer] = zeile.Kommentar;
            SichtbarEin[(int)WpfObjects.Da00 + bitnummer] = Visibility.Visible;
            SichtbarEin[(int)WpfObjects.DaBeschreibung00 + bitnummer] = Visibility.Visible;
        }

        for (var i = 0; i < 16; i++)
        {
            FarbeUmschalten(BitTesten(Datenstruktur.Di, i), (int)WpfObjects.Di00, Brushes.Yellow, Brushes.DarkGray);
            FarbeUmschalten(BitTesten(Datenstruktur.Da, i), (int)WpfObjects.Da00, Brushes.LawnGreen, Brushes.DarkGray);
        }

    }

    protected override void ViewModelAufrufTaster(Enum tasterId, bool gedrueckt) { }
    protected override void ViewModelAufrufSchalter(Enum schalterId) { }
    public override void BetriebsartProjektChanged(object sender, SelectionChangedEventArgs e) { }
    public override void PlcButtonClick(object sender, RoutedEventArgs e) { }
    public override void PlotterButtonClick(object sender, RoutedEventArgs e) { }


    public void SetRefConfigPlc(ConfigPlc configPlc) => _configPlc = configPlc;

    private static bool BitTesten(IReadOnlyList<byte> datenArray, int i)
    {
        var ibyte = i / 8;
        var bitMuster = (byte)(1 << i % 8);

        return (datenArray[ibyte] & bitMuster) == bitMuster;
    }
}