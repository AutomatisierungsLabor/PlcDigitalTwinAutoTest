using LibConfigDt;
using LibDatenstruktur;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using Contracts;

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

        AlleDpInitialisieren();

        if (configDt.GetAnzahlAa() > 3) Log.Debug("ACHTUNG: es gibt zu vielen AA!");
        if (configDt.GetAnzahlAi() > 3) Log.Debug("ACHTUNG: es gibt zu vielen AI!");
        if (configDt.GetAnzahlDa() > 24) Log.Debug("ACHTUNG: es gibt zu vielen DA!");
        if (configDt.GetAnzahlDi() > 24) Log.Debug("ACHTUNG: es gibt zu vielen DI!");

        System.Threading.Tasks.Task.Run(ViewModelTask);
    }
    private void ViewModelTask()
    {
        while (!_cancellationTokenSource.IsCancellationRequested)
        {
            DigitaleEaBeschriftungEinlesen(DaCollection, _configDt.DtConfig.DigitaleAusgaenge);
            DigitaleEaBeschriftungEinlesen(DiCollection, _configDt.DtConfig.DigitaleEingaenge);

            if (_configDt != null)
            {
                if (_configDt.GetAnzahlAa() > 0) StringWertAa00 = WertAnzeigen.AnalogwertAnzeigen(_datenstruktur.Aa, _configDt.DtConfig.AnalogeAusgaenge.EaConfig[0].Type, _configDt.DtConfig.AnalogeEingaenge.EaConfig[0].StartByte);
                if (_configDt.GetAnzahlAa() > 1) StringWertAa01 = WertAnzeigen.AnalogwertAnzeigen(_datenstruktur.Aa, _configDt.DtConfig.AnalogeAusgaenge.EaConfig[1].Type, _configDt.DtConfig.AnalogeAusgaenge.EaConfig[1].StartByte);
                if (_configDt.GetAnzahlAa() > 2) StringWertAa02 = WertAnzeigen.AnalogwertAnzeigen(_datenstruktur.Aa, _configDt.DtConfig.AnalogeAusgaenge.EaConfig[2].Type, _configDt.DtConfig.AnalogeAusgaenge.EaConfig[2].StartByte);
                if (_configDt.GetAnzahlAa() > 3) StringWertAa03 = WertAnzeigen.AnalogwertAnzeigen(_datenstruktur.Aa, _configDt.DtConfig.AnalogeAusgaenge.EaConfig[3].Type, _configDt.DtConfig.AnalogeAusgaenge.EaConfig[3].StartByte);

                if (_configDt.GetAnzahlAi() > 0) StringWertAi00 = WertAnzeigen.AnalogwertAnzeigen(_datenstruktur.Ai, _configDt.DtConfig.AnalogeEingaenge.EaConfig[0].Type, _configDt.DtConfig.AnalogeEingaenge.EaConfig[0].StartByte);
                if (_configDt.GetAnzahlAi() > 1) StringWertAi01 = WertAnzeigen.AnalogwertAnzeigen(_datenstruktur.Ai, _configDt.DtConfig.AnalogeEingaenge.EaConfig[1].Type, _configDt.DtConfig.AnalogeEingaenge.EaConfig[1].StartByte);
                if (_configDt.GetAnzahlAi() > 2) StringWertAi02 = WertAnzeigen.AnalogwertAnzeigen(_datenstruktur.Ai, _configDt.DtConfig.AnalogeEingaenge.EaConfig[2].Type, _configDt.DtConfig.AnalogeEingaenge.EaConfig[2].StartByte);
                if (_configDt.GetAnzahlAi() > 3) StringWertAi03 = WertAnzeigen.AnalogwertAnzeigen(_datenstruktur.Ai, _configDt.DtConfig.AnalogeEingaenge.EaConfig[3].Type, _configDt.DtConfig.AnalogeEingaenge.EaConfig[3].StartByte);
            }


            StringWertDa0 = WertAnzeigen.AnalogwertAnzeigen(_datenstruktur.Da, EaTypen.Byte, 0);
            StringWertDa1 = WertAnzeigen.AnalogwertAnzeigen(_datenstruktur.Da, EaTypen.Byte, 1);
            StringWertDa2 = WertAnzeigen.AnalogwertAnzeigen(_datenstruktur.Da, EaTypen.Byte, 2);

            StringWertDi0 = WertAnzeigen.AnalogwertAnzeigen(_datenstruktur.Di, EaTypen.Byte, 0);
            StringWertDi1 = WertAnzeigen.AnalogwertAnzeigen(_datenstruktur.Di, EaTypen.Byte, 1);
            StringWertDi2 = WertAnzeigen.AnalogwertAnzeigen(_datenstruktur.Di, EaTypen.Byte, 2);


            for (var i = 0; i < 8; i++)
            {
                DiCollection[i].DpFarbe = SetBrush(LibPlcTools.Bitmuster.BitInByteArrayTesten(_datenstruktur.Di, i), Brushes.Yellow, Brushes.DarkGray);
                DiCollection[10 + i].DpFarbe = SetBrush(LibPlcTools.Bitmuster.BitInByteArrayTesten(_datenstruktur.Di, 8 + i), Brushes.Yellow, Brushes.DarkGray);
                DiCollection[20 + i].DpFarbe = SetBrush(LibPlcTools.Bitmuster.BitInByteArrayTesten(_datenstruktur.Di, 16 + i), Brushes.Yellow, Brushes.DarkGray);

                DaCollection[i].DpFarbe = SetBrush(LibPlcTools.Bitmuster.BitInByteArrayTesten(_datenstruktur.Da, i), Brushes.LawnGreen, Brushes.DarkGray);
                DaCollection[10 + i].DpFarbe = SetBrush(LibPlcTools.Bitmuster.BitInByteArrayTesten(_datenstruktur.Da, 8 + i), Brushes.LawnGreen, Brushes.DarkGray);
                DaCollection[20 + i].DpFarbe = SetBrush(LibPlcTools.Bitmuster.BitInByteArrayTesten(_datenstruktur.Da, 16 + i), Brushes.LawnGreen, Brushes.DarkGray);
            }


            AlleDpAktualisieren();

            Thread.Sleep(10);
        }
    }
    private static void DigitaleEaBeschriftungEinlesen(IReadOnlyList<VmDatenpunkte> vmDatenpunkte, DtEaConfig dtConfigEa)
    {
        if (vmDatenpunkte == null) return;

        for (var i = 0; i < 30; i++)
        {
            vmDatenpunkte[i].DpVisibility = Visibility.Hidden;
            vmDatenpunkte[i].DpKommentar = "";
            vmDatenpunkte[i].DpBezeichnung = "";
        }

        if (dtConfigEa.EaConfig == null || dtConfigEa.EaConfig.Length == 0) return;

        foreach (var digitaleEa in dtConfigEa.EaConfig)
        {
            var index = digitaleEa.StartBit + 10 * digitaleEa.StartByte;

            vmDatenpunkte[index].DpBezeichnung = digitaleEa.Bezeichnung;
            vmDatenpunkte[index].DpKommentar = digitaleEa.Kommentar;
            vmDatenpunkte[index].DpVisibility = Visibility.Visible;
        }
    }
}