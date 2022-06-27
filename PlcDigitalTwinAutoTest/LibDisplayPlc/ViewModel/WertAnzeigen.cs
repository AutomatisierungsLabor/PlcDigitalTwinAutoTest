using LibPlcTools;
using System;
using Contracts;

namespace LibDisplayPlc.ViewModel;

public class WertAnzeigen
{
    public static string AnalogwertAnzeigen(byte[] datenstruktur, EaTypen eaTypen, int startByte)
    {
        var wertWord = 256 * datenstruktur[startByte] + datenstruktur[1 + startByte];

        switch (eaTypen)
        {
            case EaTypen.NichtBelegt: break;

            case EaTypen.Bit: break;

            case EaTypen.Byte: return "16#" + Convert.ToString((long)datenstruktur[startByte], 16).PadLeft(2, '0').ToUpper();

            case EaTypen.Word:
                return "16#" + Convert.ToString((long)wertWord, 16).PadLeft(4, '0').ToUpper();
            case EaTypen.DWord: break;

            case EaTypen.Ascii:
                var wertAscii = datenstruktur[startByte];
                return "16#" + Convert.ToString((long)wertAscii, 16).PadLeft(2, '0').ToUpper() + $"[{char.ToUpper((char)wertAscii)}]";

            case EaTypen.BitmusterByte: break;

            case EaTypen.SiemensAnalogwertProzent:
                var wertProzent = Simatic.Analog_2_Double(wertWord, 100);
                return "16#" + Convert.ToString((long)wertWord, 16).PadLeft(4, '0').ToUpper() + $" ({wertProzent:F1}%)";

            case EaTypen.SiemensAnalogwertPromille: break;

            case EaTypen.SiemensAnalogwertSchieberegler: break;

            case EaTypen.TestErrorAusgeben:

            default: throw new ArgumentOutOfRangeException(nameof(eaTypen), eaTypen, null);
        }

        return "uups";
    }
}