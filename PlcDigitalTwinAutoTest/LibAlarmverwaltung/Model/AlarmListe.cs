using System;
using Contracts;

namespace LibAlarmverwaltung.Model;

public class AlarmListe
{
    public DateTime ZeitStempel { get; set; }
    public StatusAlarm Status { get; set; }
    public string Bezeichnung { get; set; }


    public AlarmListe(DateTime zeitStempel, StatusAlarm status, string bezeichnung)
    {
        ZeitStempel = zeitStempel;
        Status = status;
        Bezeichnung = bezeichnung;
    }
}