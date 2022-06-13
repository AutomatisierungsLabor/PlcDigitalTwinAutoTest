using System;
using System.Threading;
using System.Windows;
using Contracts;
using LibConfigDt;
using LibDatenstruktur;

namespace LibAlarmverwaltung.Model;

public class ModelAlarmverwaltung
{
    private readonly ConfigDt _configDt;
    private readonly CancellationTokenSource _cancellationTokenSource;
    private readonly Alarmverwaltung _alarmverwaltung;
    private readonly AlarmDatenRangieren _alarmDatenRangieren;

    public ModelAlarmverwaltung(Datenstruktur datenstruktur, ConfigDt configDt, CancellationTokenSource cancellationTokenSource, Alarmverwaltung alarmverwaltung)
    {

        _configDt = configDt;
        _cancellationTokenSource = cancellationTokenSource;
        _alarmverwaltung = alarmverwaltung;

        _alarmDatenRangieren = new AlarmDatenRangieren(datenstruktur, _configDt);

        System.Threading.Tasks.Task.Run(ModelTask);
    }
    private void ModelTask()
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
                        if (alarm.BitmusterAlarm != alarm.BitmusterAlarmAlt)
                        {
                            if (alarm.BitmusterAlarm)
                            {
                                alarm.AlarmKommt = DateTime.Now;
                                alarm.Status = StatusAlarm.AlarmKommt;
                            }
                            else
                            {
                                alarm.AlarmGeht = DateTime.Now;
                                alarm.Status = StatusAlarm.AlarmGeht;
                            }
                            AlarmlisteEintragEinfuegen(alarm.Bezeichnung, alarm.Status);
                        }

                        if (alarm.BitmusterQuittiert && !alarm.BitmusterQuittiertAlt)
                        {
                            if (alarm.Status == StatusAlarm.AlarmGeht)
                            {
                                AlarmlisteEintragEinfuegen(alarm.Bezeichnung, StatusAlarm.AlarmQuittiert);
                                alarm.Status = StatusAlarm.AlarmKeiner;
                            }
                        }

                        alarm.BitmusterAlarmAlt = alarm.BitmusterAlarm;
                        alarm.BitmusterQuittiertAlt = alarm.BitmusterQuittiert;
                    }
                    break;
            }

            _alarmDatenRangieren.DatenRangieren();

            Thread.Sleep(100);
        }
    }
    private void AlarmlisteEintragEinfuegen(string bezeichnung, StatusAlarm alarmStatus)
    {
        Application.Current.Dispatcher.Invoke(() =>
                    {
                        _alarmverwaltung.AlarmListe.Add(new AlarmListe(DateTime.Now, alarmStatus, bezeichnung));
                    });
    }
}