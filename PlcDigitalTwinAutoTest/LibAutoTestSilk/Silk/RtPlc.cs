using LibAutoTestSilk.TestAutomat;

namespace LibAutoTestSilk.Silk;

public partial class Silk
{
    private  void PlcColdStart()
    {
        /*
        var status = Plc.ColdStart();
        if (status == 0) DataGridAnzeigeUpdaten(TestAnzeige.Erfolgreich, "PLC: Coldstart");
        else 
        */
        DataGridAnzeigeUpdaten(TestAnzeige.Fehler, 0, "PLC: ERROR Coldstart");
        VmAutoTesterSilk.ZeilenNummerDataGrid++;
    }
    private  void PlcHotStart()
    {
        /*
        var status = Plc.HotStart();
        if (status == 0) DataGridAnzeigeUpdaten(TestAnzeige.Erfolgreich, "PLC: Hotstart");            
        else */
        DataGridAnzeigeUpdaten(TestAnzeige.Fehler, 0, "PLC: ERROR Hotstart");
        VmAutoTesterSilk.ZeilenNummerDataGrid++;
    }
    private  void PlcGetStatus()
    {
        /*
        var (retval, status) = Plc.GetStatus();
        if (retval == 0)
        {
            switch (status)
            {
                case 0x00:
                    DataGridAnzeigeUpdaten(TestAnzeige.UnbekanntesErgebnis, "PLC: unbekannter Status");
                    break;
                case 0x08:
                    DataGridAnzeigeUpdaten(TestAnzeige.Erfolgreich, "PLC: running");
                    break;
                case 0x04:
                    DataGridAnzeigeUpdaten(TestAnzeige.Fehler, "PLC: stopped");
                    break;
            }
        }
        else
        {
            DataGridAnzeigeUpdaten(TestAnzeige.UnbekanntesErgebnis, "PLC: Statusabfrage fehlgeschlagen");
        }
        */
        DataGridAnzeigeUpdaten(TestAnzeige.UnbekanntesErgebnis, 0, "PLC: Statusabfrage fehlgeschlagen");
        VmAutoTesterSilk.ZeilenNummerDataGrid++;
    }
}