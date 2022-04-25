using System;
using LibConfigPlc;
using LibPlcTools;

namespace LibDisplayPlc.ViewModel;

public class WertAnzeigen
{
    public static string AnalogwertAnzeigen(byte[] datenstruktur, ConfigPlc.EaTypen eaTypen, int startByte)
    {

        switch (eaTypen)
        {
            case ConfigPlc.EaTypen.NichtBelegt: break;
            case ConfigPlc.EaTypen.Bit: break;
            case ConfigPlc.EaTypen.Byte:
                return "16#" + Convert.ToString((long)datenstruktur[startByte], 16).PadLeft(2, '0').ToUpper();

            case ConfigPlc.EaTypen.Word: break;
            case ConfigPlc.EaTypen.DWord: break;
            case ConfigPlc.EaTypen.Ascii:
                var wertAscii = datenstruktur[startByte];
                return "16#" + Convert.ToString((long)wertAscii, 16).PadLeft(2, '0').ToUpper() + $"[{ char.ToUpper((char)wertAscii)}]";

            case ConfigPlc.EaTypen.BitmusterByte: break;
            case ConfigPlc.EaTypen.SiemensAnalogwertProzent:
                var wertWord = 256 * datenstruktur[startByte] + datenstruktur[1 + startByte];
                var wertProzent = Simatic.Analog_2_Double(wertWord, 100);
                return "16#" + Convert.ToString((long)wertWord, 16).PadLeft(4, '0').ToUpper() + $" ({wertProzent:F1}%)";

            case ConfigPlc.EaTypen.SiemensAnalogwertPromille: break;
            case ConfigPlc.EaTypen.SiemensAnalogwertSchieberegler: break;
            default: throw new ArgumentOutOfRangeException(nameof(eaTypen), eaTypen, null);
        }

        return "uups";
    }
}