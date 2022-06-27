using LibDatenstruktur;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using Contracts;
using LibConfigDt;

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
        if (configDt.GetAnzahlByteDa() > 5) Log.Debug("ACHTUNG: es gibt zu vielen DA!");
        if (configDt.GetAnzahlByteDi() > 5) Log.Debug("ACHTUNG: es gibt zu vielen DI!");

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
                if (_configDt.GetAnzahlAa() > 0) StringWertAa00 = WertAnzeigen.AnalogwertAnzeigen(_datenstruktur.Aa, _configDt.DtConfig.AnalogeAusgaenge.EaConfig[0].Type, _configDt.DtConfig.AnalogeAusgaenge.EaConfig[0].StartByte);
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
            StringWertDa3 = WertAnzeigen.AnalogwertAnzeigen(_datenstruktur.Da, EaTypen.Byte, 3);
            StringWertDa4 = WertAnzeigen.AnalogwertAnzeigen(_datenstruktur.Da, EaTypen.Byte, 4);

            StringWertDi0 = WertAnzeigen.AnalogwertAnzeigen(_datenstruktur.Di, EaTypen.Byte, 0);
            StringWertDi1 = WertAnzeigen.AnalogwertAnzeigen(_datenstruktur.Di, EaTypen.Byte, 1);
            StringWertDi2 = WertAnzeigen.AnalogwertAnzeigen(_datenstruktur.Di, EaTypen.Byte, 2);
            StringWertDi3 = WertAnzeigen.AnalogwertAnzeigen(_datenstruktur.Di, EaTypen.Byte, 3);
            StringWertDi4 = WertAnzeigen.AnalogwertAnzeigen(_datenstruktur.Di, EaTypen.Byte, 4);

            const short byte0 = 0 * 8;
            const short byte1 = 1 * 8;
            const short byte2 = 2 * 8;
            const short byte3 = 3 * 8;
            const short byte4 = 4 * 8;

            for (var i = 0; i < 8; i++)
            {
                DiCollection[i].DpFarbe = BaseFunctions.SetBrush(LibPlcTools.Bitmuster.BitInByteArrayTesten(_datenstruktur.Di, byte0 + i), Brushes.Yellow, Brushes.DarkGray);
                DiCollection[10 + i].DpFarbe = BaseFunctions.SetBrush(LibPlcTools.Bitmuster.BitInByteArrayTesten(_datenstruktur.Di, byte1 + i), Brushes.Yellow, Brushes.DarkGray);
                DiCollection[20 + i].DpFarbe = BaseFunctions.SetBrush(LibPlcTools.Bitmuster.BitInByteArrayTesten(_datenstruktur.Di, byte2 + i), Brushes.Yellow, Brushes.DarkGray);
                DiCollection[30 + i].DpFarbe = BaseFunctions.SetBrush(LibPlcTools.Bitmuster.BitInByteArrayTesten(_datenstruktur.Di, byte3 + i), Brushes.Yellow, Brushes.DarkGray);
                DiCollection[40 + i].DpFarbe = BaseFunctions.SetBrush(LibPlcTools.Bitmuster.BitInByteArrayTesten(_datenstruktur.Di, byte4 + i), Brushes.Yellow, Brushes.DarkGray);

                DaCollection[i].DpFarbe = BaseFunctions.SetBrush(LibPlcTools.Bitmuster.BitInByteArrayTesten(_datenstruktur.Da, byte0 + i), Brushes.LawnGreen, Brushes.DarkGray);
                DaCollection[10 + i].DpFarbe = BaseFunctions.SetBrush(LibPlcTools.Bitmuster.BitInByteArrayTesten(_datenstruktur.Da, byte1 + i), Brushes.LawnGreen, Brushes.DarkGray);
                DaCollection[20 + i].DpFarbe = BaseFunctions.SetBrush(LibPlcTools.Bitmuster.BitInByteArrayTesten(_datenstruktur.Da, byte2 + i), Brushes.LawnGreen, Brushes.DarkGray);
                DaCollection[30 + i].DpFarbe = BaseFunctions.SetBrush(LibPlcTools.Bitmuster.BitInByteArrayTesten(_datenstruktur.Da, byte3 + i), Brushes.LawnGreen, Brushes.DarkGray);
                DaCollection[40 + i].DpFarbe = BaseFunctions.SetBrush(LibPlcTools.Bitmuster.BitInByteArrayTesten(_datenstruktur.Da, byte4 + i), Brushes.LawnGreen, Brushes.DarkGray);
            }


            AlleDpAktualisieren();

            Thread.Sleep(10);
        }
    }
    private static void DigitaleEaBeschriftungEinlesen(IReadOnlyList<VmDatenpunkte> vmDatenpunkte, DtEaConfig dtConfigEa)
    {
        if (vmDatenpunkte == null) return;

        for (var i = 0; i < 50; i++)
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