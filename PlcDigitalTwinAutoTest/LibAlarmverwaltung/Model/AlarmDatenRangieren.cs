using LibConfigDt;
using LibDatenstruktur;

namespace LibAlarmverwaltung.Model;

public class AlarmDatenRangieren
{
    private readonly Datenstruktur _datenstruktur;
    private readonly ConfigDt _configDt;

    public AlarmDatenRangieren(Datenstruktur datenstruktur, ConfigDt configDt)
    {
        _datenstruktur = datenstruktur;
        _configDt = configDt;
    }

    public void DatenRangieren()
    {
        if (_configDt.DtConfig.Alarm == null) return;
        if (_configDt.DtConfig.Alarm.Length == 0) return;

        foreach (var alarm in _configDt.DtConfig.Alarm)
        {
            (alarm.BitmusterAlarm, alarm.BitmusterQuittiert) = _datenstruktur.GetAlarmBitmuster(alarm.ByteAlarm, alarm.BitAlarm);
        }
    }
}