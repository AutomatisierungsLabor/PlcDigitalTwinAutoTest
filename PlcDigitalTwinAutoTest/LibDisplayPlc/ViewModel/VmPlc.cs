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
    private void DaZeilenBeschriften(IReadOnlyList<VmDatenpunkte> vmDatenpunkte)
    {
        if (vmDatenpunkte == null) return;

        for (var i = 0; i < 20; i++)
        {
            if (vmDatenpunkte[i] != null) vmDatenpunkte[i].DpVisibility = Visibility.Collapsed;
        }

        foreach (var zeile in _configPlc.Da.Zeilen)
        {
            var index = zeile.StartBit + 10 * zeile.StartByte;

            vmDatenpunkte[index].DpBezeichnung = zeile.Bezeichnung;
            vmDatenpunkte[index].DpKommentar = zeile.Kommentar;
            vmDatenpunkte[index].DpVisibility = Visibility.Visible;
        }
    }
    private void DiZeilenBeschriften(IReadOnlyList<VmDatenpunkte> vmDatenpunkte)
    {
        if (vmDatenpunkte == null) return;

        for (var i = 0; i < 20; i++)
        {
            if (vmDatenpunkte[i] != null) vmDatenpunkte[i].DpVisibility = Visibility.Collapsed;
        }

        foreach (var zeile in _configPlc.Di.Zeilen)
        {
            var index = zeile.StartBit + 10 * zeile.StartByte;

            vmDatenpunkte[index].DpBezeichnung = zeile.Bezeichnung;
            vmDatenpunkte[index].DpKommentar = zeile.Kommentar;
            vmDatenpunkte[index].DpVisibility = Visibility.Visible;
        }
    }
}