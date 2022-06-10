using System;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows;
using LibConfigDt;
using LibDatenstruktur;
using System.Windows.Media;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Brush = System.Windows.Media.Brush;

namespace LibAlarmverwaltung.ViewModel;

public partial class VmAlarmverwaltung : ObservableObject
{
    private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);



    private readonly ConfigDt _configDt;
    private readonly Datenstruktur _datenstruktur;
    private readonly CancellationTokenSource _cancellationTokenSource;

    public VmAlarmverwaltung(Datenstruktur datenstruktur, ConfigDt configDt, CancellationTokenSource cancellationTokenSource)
    {
        Log.Debug("Konstruktor - startet");

        _datenstruktur = datenstruktur;
        _configDt = configDt;
        _cancellationTokenSource = cancellationTokenSource;


        System.Threading.Tasks.Task.Run(ViewModelTask);
    }

    private void ViewModelTask()
    {

        while (!_cancellationTokenSource.IsCancellationRequested)
        {
            switch (_configDt.DtConfig.Alarm)
            {
                case null:
                    return;
                case { Length: 0 }:
                    break;
                default:
                    foreach (var alarm in _configDt.DtConfig.Alarm)
                    {
                        switch (alarm.Id)
                        {
                            case 0: (BrushAlarm00, StringBezeichnung00, StringKommentar00, StringKommt00, StringGeht00) = GetBezeichnungKommentar(_configDt.DtConfig.Alarm[0]); break;
                            case 1: (BrushAlarm01, StringBezeichnung01, StringKommentar01, StringKommt01, StringGeht01) = GetBezeichnungKommentar(_configDt.DtConfig.Alarm[1]); break;
                            case 2: (BrushAlarm02, StringBezeichnung02, StringKommentar02, StringKommt02, StringGeht02) = GetBezeichnungKommentar(_configDt.DtConfig.Alarm[2]); break;
                            case 3: (BrushAlarm03, StringBezeichnung03, StringKommentar03, StringKommt03, StringGeht03) = GetBezeichnungKommentar(_configDt.DtConfig.Alarm[3]); break;
                            case 4: (BrushAlarm04, StringBezeichnung04, StringKommentar04, StringKommt04, StringGeht04) = GetBezeichnungKommentar(_configDt.DtConfig.Alarm[4]); break;
                            case 5: (BrushAlarm05, StringBezeichnung05, StringKommentar05, StringKommt05, StringGeht05) = GetBezeichnungKommentar(_configDt.DtConfig.Alarm[5]); break;
                            case 6: (BrushAlarm06, StringBezeichnung06, StringKommentar06, StringKommt06, StringGeht06) = GetBezeichnungKommentar(_configDt.DtConfig.Alarm[6]); break;
                            case 7: (BrushAlarm07, StringBezeichnung07, StringKommentar07, StringKommt07, StringGeht07) = GetBezeichnungKommentar(_configDt.DtConfig.Alarm[7]); break;
                            case 8: (BrushAlarm08, StringBezeichnung08, StringKommentar08, StringKommt08, StringGeht08) = GetBezeichnungKommentar(_configDt.DtConfig.Alarm[8]); break;
                            case 9: (BrushAlarm09, StringBezeichnung09, StringKommentar09, StringKommt09, StringGeht09) = GetBezeichnungKommentar(_configDt.DtConfig.Alarm[9]); break;

                        }
                    }
                    break;
            }

            Thread.Sleep(10);
        }
    }

    private (Brush brush, string bezeichnung, string kommentar, string kommt, string geht) GetBezeichnungKommentar(Alarm alarm)
    {
        DateTime localDate = DateTime.Now;
        string te =localDate.ToString("d.M.yyyy - H:mm:ss.fff");


        return (System.Windows.Media.Brushes.Blue, alarm.Bezeichnung, alarm.Kommentar, te, te);
    }
}