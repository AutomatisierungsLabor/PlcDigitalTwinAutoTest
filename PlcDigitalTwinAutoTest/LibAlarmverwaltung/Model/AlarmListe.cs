using System;

namespace LibAlarmverwaltung.Model;

public class AlarmListe
{
    public DateTime ZeitStempel { get; set; }
    public string Bezeichnung { get; set; }


    public AlarmListe(DateTime zeitStempel, string bezeichnung)
    {
        ZeitStempel = zeitStempel;
        Bezeichnung = bezeichnung;
    }
}