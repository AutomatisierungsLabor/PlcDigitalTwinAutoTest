namespace LibSilkAutoTester.Silk;

public partial class Silk
{
    private static void PlcColdStart()
    {
        /*
        var status = Plc.ColdStart();
        if (status == 0) DataGridAnzeigeUpdaten(TestAutomat.TestAnzeige.Erfolgreich, "PLC: Coldstart");
        else 
        */
        //  DataGridAnzeigeUpdaten(TestAutomat.TestAnzeige.Fehler, 0, "PLC: ERROR Coldstart");
        //  AutoTesterWindow.DataGridId++;
    }
    private static void PlcHotStart()
    {
        /*
        var status = Plc.HotStart();
        if (status == 0) DataGridAnzeigeUpdaten(TestAutomat.TestAnzeige.Erfolgreich, "PLC: Hotstart");            
        else */
        //   DataGridAnzeigeUpdaten(TestAutomat.TestAnzeige.Fehler, 0, "PLC: ERROR Hotstart");
        //   AutoTesterWindow.DataGridId++;
    }
    private static void PlcGetStatus()
    {
        /*
        var (retval, status) = Plc.GetStatus();
        if (retval == 0)
        {
            switch (status)
            {
                case 0x00:
                    DataGridAnzeigeUpdaten(TestAutomat.TestAnzeige.UnbekanntesErgebnis, "PLC: unbekannter Status");
                    break;
                case 0x08:
                    DataGridAnzeigeUpdaten(TestAutomat.TestAnzeige.Erfolgreich, "PLC: running");
                    break;
                case 0x04:
                    DataGridAnzeigeUpdaten(TestAutomat.TestAnzeige.Fehler, "PLC: stopped");
                    break;
            }
        }
        else
        {
            DataGridAnzeigeUpdaten(TestAutomat.TestAnzeige.UnbekanntesErgebnis, "PLC: Statusabfrage fehlgeschlagen");
        }
        */
        //  DataGridAnzeigeUpdaten(TestAutomat.TestAnzeige.UnbekanntesErgebnis, 0, "PLC: Statusabfrage fehlgeschlagen");
        //  AutoTesterWindow.DataGridId++;
    }
}