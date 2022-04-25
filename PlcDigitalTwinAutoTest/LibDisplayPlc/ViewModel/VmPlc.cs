using System;
using System.Collections.Generic;
using LibConfigPlc;
using LibDatenstruktur;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace LibDisplayPlc.ViewModel;

public partial class VmPlc : ObservableObject
{
    private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);

    private readonly ConfigPlc _configPlc;
    private readonly Datenstruktur _datenstruktur;
    private readonly CancellationTokenSource _cancellationTokenSource;

    public VmPlc(Datenstruktur datenstruktur, ConfigPlc configPlc, CancellationTokenSource cancellationTokenSource)
    {
        Log.Debug("Konstruktor - startet");

        _datenstruktur = datenstruktur;
        _configPlc = configPlc;
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

            StringWertAi00 = "16#" + Convert.ToString((long)_datenstruktur.Ai[0], 16).PadLeft(2, '0').ToUpper();

            StringWertDa0 = "16#" + Convert.ToString((long)_datenstruktur.Da[0], 16).PadLeft(2, '0').ToUpper();
            StringWertDa1 = "16#" + Convert.ToString((long)_datenstruktur.Da[1], 16).PadLeft(2, '0').ToUpper();
            StringWertDi0 = "16#" + Convert.ToString((long)_datenstruktur.Di[0], 16).PadLeft(2, '0').ToUpper();
            StringWertDi1 = "16#" + Convert.ToString((long)_datenstruktur.Di[1], 16).PadLeft(2, '0').ToUpper();

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

        if (_configPlc.Da.AnzZeilen == 0) return;

        foreach (var zeile in _configPlc.Da.Zeilen)
        {
            var index = zeile.StartBit + 10 * zeile.StartByte;

            vmDaDatenpunkte[index].DpBezeichnung = zeile.Bezeichnung;
            vmDaDatenpunkte[index].DpKommentar = zeile.Kommentar;
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

        if (_configPlc.Di.AnzZeilen == 0) return;

        foreach (var zeile in _configPlc.Di.Zeilen)
        {
            var index = zeile.StartBit + 10 * zeile.StartByte;

            vmDiDatenpunkte[index].DpBezeichnung = zeile.Bezeichnung;
            vmDiDatenpunkte[index].DpKommentar = zeile.Kommentar;
            vmDiDatenpunkte[index].DpVisibility = Visibility.Visible;
        }
    }
}