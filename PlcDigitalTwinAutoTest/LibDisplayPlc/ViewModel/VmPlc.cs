using LibConfigDt;
using LibDatenstruktur;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Media;

namespace LibDisplayPlc.ViewModel;

public partial class VmPlc : ObservableObject
{
    private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);

    private readonly ConfigDt _configDt;
    private readonly Datenstruktur _datenstruktur;
    private readonly CancellationTokenSource _cancellationTokenSource;

    public VmPlc(Datenstruktur datenstruktur, ConfigDt configDt, CancellationTokenSource cancellationTokenSource)
    {
        Log.Debug("Konstruktor - startet");

        _datenstruktur = datenstruktur;
        _configDt = configDt;
        _cancellationTokenSource = cancellationTokenSource;

        AlleDpFuellen();

        System.Threading.Tasks.Task.Run(ViewModelTask);
    }
    private void ViewModelTask()
    {
        while (!_cancellationTokenSource.IsCancellationRequested)
        {
            DaZeilenBeschriften(DaCollection);
            DiZeilenBeschriften(DiCollection);
            if (_configDt != null)
            {
                if (_configDt.GetAnzahlAa() > 0) StringWertAa00 = WertAnzeigen.AnalogwertAnzeigen(_datenstruktur.Aa, _configDt.DtConfig.AnalogeAusgaenge.EaConfigs[0].Type, _configDt.DtConfig.AnalogeEingaenge.EaConfigs[0].StartByte);
                if (_configDt.GetAnzahlAa() > 1) StringWertAa01 = WertAnzeigen.AnalogwertAnzeigen(_datenstruktur.Aa, _configDt.DtConfig.AnalogeAusgaenge.EaConfigs[1].Type, _configDt.DtConfig.AnalogeAusgaenge.EaConfigs[1].StartByte);
                if (_configDt.GetAnzahlAa() > 2) StringWertAa02 = WertAnzeigen.AnalogwertAnzeigen(_datenstruktur.Aa, _configDt.DtConfig.AnalogeAusgaenge.EaConfigs[2].Type, _configDt.DtConfig.AnalogeAusgaenge.EaConfigs[2].StartByte);
                if (_configDt.GetAnzahlAa() > 3) StringWertAa03 = WertAnzeigen.AnalogwertAnzeigen(_datenstruktur.Aa, _configDt.DtConfig.AnalogeAusgaenge.EaConfigs[3].Type, _configDt.DtConfig.AnalogeAusgaenge.EaConfigs[3].StartByte);

                if (_configDt.GetAnzahlAi() > 0) StringWertAi00 = WertAnzeigen.AnalogwertAnzeigen(_datenstruktur.Ai, _configDt.DtConfig.AnalogeEingaenge.EaConfigs[0].Type, _configDt.DtConfig.AnalogeEingaenge.EaConfigs[0].StartByte);
                if (_configDt.GetAnzahlAi() > 1) StringWertAi01 = WertAnzeigen.AnalogwertAnzeigen(_datenstruktur.Ai, _configDt.DtConfig.AnalogeEingaenge.EaConfigs[1].Type, _configDt.DtConfig.AnalogeEingaenge.EaConfigs[1].StartByte);
                if (_configDt.GetAnzahlAi() > 2) StringWertAi02 = WertAnzeigen.AnalogwertAnzeigen(_datenstruktur.Ai, _configDt.DtConfig.AnalogeEingaenge.EaConfigs[2].Type, _configDt.DtConfig.AnalogeEingaenge.EaConfigs[2].StartByte);
                if (_configDt.GetAnzahlAi() > 3) StringWertAi03 = WertAnzeigen.AnalogwertAnzeigen(_datenstruktur.Ai, _configDt.DtConfig.AnalogeEingaenge.EaConfigs[3].Type, _configDt.DtConfig.AnalogeEingaenge.EaConfigs[3].StartByte);
            }


            StringWertDa0 = WertAnzeigen.AnalogwertAnzeigen(_datenstruktur.Da, EaTypen.Byte, 0);
            StringWertDa1 = WertAnzeigen.AnalogwertAnzeigen(_datenstruktur.Da, EaTypen.Byte, 1);

            StringWertDi0 = WertAnzeigen.AnalogwertAnzeigen(_datenstruktur.Di, EaTypen.Byte, 0);
            StringWertDi1 = WertAnzeigen.AnalogwertAnzeigen(_datenstruktur.Di, EaTypen.Byte, 1);

            for (var i = 0; i < 8; i++)
            {
                DiCollection[i].DpFarbe = SetBrush(LibPlcTools.Bitmuster.BitInByteArrayTesten(_datenstruktur.Di, i), Brushes.Yellow, Brushes.DarkGray);
                DiCollection[10 + i].DpFarbe = SetBrush(LibPlcTools.Bitmuster.BitInByteArrayTesten(_datenstruktur.Di, 8 + i), Brushes.Yellow, Brushes.DarkGray);

                DaCollection[i].DpFarbe = SetBrush(LibPlcTools.Bitmuster.BitInByteArrayTesten(_datenstruktur.Da, i), Brushes.LawnGreen, Brushes.DarkGray);
                DaCollection[10 + i].DpFarbe = SetBrush(LibPlcTools.Bitmuster.BitInByteArrayTesten(_datenstruktur.Da, 8 + i), Brushes.LawnGreen, Brushes.DarkGray);
            }

            AlleDpAktualisieren();

            Thread.Sleep(10);
        }
    }
    private void DaZeilenBeschriften(IReadOnlyList<VmDatenpunkte> vmDaDatenpunkte)
    {
        if (vmDaDatenpunkte == null) return;

        for (var i = 0; i < 20; i++)
        {
            if (vmDaDatenpunkte[i] != null) vmDaDatenpunkte[i].DpVisibility = Visibility.Collapsed;
        }

        if (_configDt.GetAnzahlDa() == 0) return;

        foreach (var digitaleAusgaenge in _configDt.DtConfig.DigitaleAusgaenge.EaConfigs)
        {
            var index = digitaleAusgaenge.StartBit + 10 * digitaleAusgaenge.StartByte;

            vmDaDatenpunkte[index].DpBezeichnung = digitaleAusgaenge.Bezeichnung;
            vmDaDatenpunkte[index].DpKommentar = digitaleAusgaenge.Kommentar;
            vmDaDatenpunkte[index].DpVisibility = Visibility.Visible;
        }
    }
    private void DiZeilenBeschriften(IReadOnlyList<VmDatenpunkte> vmDiDatenpunkte)
    {
        if (vmDiDatenpunkte == null) return;

        for (var i = 0; i < 20; i++)
        {
            if (vmDiDatenpunkte[i] != null) vmDiDatenpunkte[i].DpVisibility = Visibility.Collapsed;
        }

        if (_configDt.GetAnzahlDi() == 0) return;

        foreach (var digitaleEingaenge in _configDt.DtConfig.DigitaleEingaenge.EaConfigs)
        {
            var index = digitaleEingaenge.StartBit + 10 * digitaleEingaenge.StartByte;

            vmDiDatenpunkte[index].DpBezeichnung = digitaleEingaenge.Bezeichnung;
            vmDiDatenpunkte[index].DpKommentar = digitaleEingaenge.Kommentar;
            vmDiDatenpunkte[index].DpVisibility = Visibility.Visible;
        }
    }
}