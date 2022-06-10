using System;
using System.Threading;
using System.Windows;
using LibConfigDt;
using LibDatenstruktur;

namespace LibAlarmverwaltung.Model;

public class ModelAlarmverwaltung
{
    private readonly ConfigDt _configDt;
    private readonly Datenstruktur _datenstruktur;
    private readonly CancellationTokenSource _cancellationTokenSource;
    private readonly Alarmverwaltung _alarmverwaltung;


    public ModelAlarmverwaltung(Datenstruktur datenstruktur, ConfigDt configDt, CancellationTokenSource cancellationTokenSource, Alarmverwaltung alarmverwaltung)
    {

        _datenstruktur = datenstruktur;
        _configDt = configDt;
        _cancellationTokenSource = cancellationTokenSource;
        _alarmverwaltung = alarmverwaltung;

        System.Threading.Tasks.Task.Run(ModelTask);
    }

    private void ModelTask()
    {
        while (!_cancellationTokenSource.IsCancellationRequested)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {

                _alarmverwaltung.AlarmListe.Add(new AlarmListe(DateTime.Now, "test"));
            });



            Thread.Sleep(1000);
        }
    }
}