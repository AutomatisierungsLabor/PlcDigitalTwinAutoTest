using System.Threading;
using System.Windows.Media;
using Contracts;
using LibConfigDt;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace LibAlarmverwaltung.ViewModel;

public partial class VmAlarmverwaltung : ObservableObject
{
    private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);

    private readonly ConfigDt _configDt;
    private readonly CancellationTokenSource _cancellationTokenSource;
    private readonly Alarmverwaltung _alarmverwaltung;

    public VmAlarmverwaltung(ConfigDt configDt, CancellationTokenSource cancellationTokenSource, Alarmverwaltung alarmverwaltung)
    {
        Log.Debug("Konstruktor - startet");

        _configDt = configDt;
        _cancellationTokenSource = cancellationTokenSource;
        _alarmverwaltung = alarmverwaltung;

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
    private static (Brush brush, string bezeichnung, string kommentar, string kommt, string geht) GetBezeichnungKommentar(Alarm alarm)
    {
        var kommt = alarm.AlarmKommt.ToString("d.M.yyyy - H:mm:ss.fff");
        var geht = alarm.AlarmGeht.ToString("d.M.yyyy - H:mm:ss.fff");

        switch (alarm.Status)
        {
            case StatusAlarm.AlarmKommt: return (Brushes.Red, alarm.Bezeichnung, alarm.Kommentar, kommt, "-");
            case StatusAlarm.AlarmGeht: return (Brushes.LawnGreen, alarm.Bezeichnung, alarm.Kommentar, kommt, geht);
            case StatusAlarm.AlarmQuittiert: return (Brushes.BlueViolet, alarm.Bezeichnung, alarm.Kommentar, kommt, geht);
            case StatusAlarm.AlarmKeiner:
            case StatusAlarm.Unbekannt:
            default: return (Brushes.White, alarm.Bezeichnung, alarm.Kommentar, "-", "-");
        }
    }
}