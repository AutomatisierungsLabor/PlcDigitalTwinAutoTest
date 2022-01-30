using SoftCircuits.Silk;

namespace LibAutoTestSilk.Silk;

// Register intrinsic functions - NOTE that silk internal functions are also available
// as per https://github.com/SoftCircuits/Silk/blob/master/docs/InternalFunctions.md
public partial class Silk
{
    private static void CompilerRegisterFunctions(Compiler compiler)
    {
        // ReSharper disable RedundantArgumentDefaultValue
        compiler.RegisterFunction("BitmusterBlinktTesten", 8, 8);
        compiler.RegisterFunction("BitmusterTesten", 4, 4);
        compiler.RegisterFunction("Debug", 0, Function.NoParameterLimit);
        compiler.RegisterFunction("GetDigitaleAusgaenge", 0, 0);
        compiler.RegisterFunction("IncrementDataGridId", 0, 0);
        compiler.RegisterFunction("KommentarAnzeigen", 1, 1);
        compiler.RegisterFunction("PlcToDec", 1, 1);
        compiler.RegisterFunction("PlcColdStart", 0, 0);
        compiler.RegisterFunction("PlcGetStatus", 0, 0);
        compiler.RegisterFunction("PlcHotStart", 0, 0);
        compiler.RegisterFunction("Print", 0, Function.NoParameterLimit);
        compiler.RegisterFunction("println", 0, Function.NoParameterLimit);
        compiler.RegisterFunction("ResetStopwatch", 0, 0);
        compiler.RegisterFunction("SetAnalogerEingang", 3, 3);
        compiler.RegisterFunction("SetDataGridBitAnzahl", 2, 2);
        compiler.RegisterFunction("SetDiagrammZeitbereich", 1, 1);
        compiler.RegisterFunction("SetDigitaleEingaenge", 1, 1);
        compiler.RegisterFunction("Sleep", 1, 1);
        compiler.RegisterFunction("TestAblauf", 0, 2);
        compiler.RegisterFunction("UpdateAnzeige", 2, 2);
        compiler.RegisterFunction("VersionAnzeigen", 0, 0);
        // ReSharper restore RedundantArgumentDefaultValue
    }
    public void Runtime_Function(object sender, FunctionEventArgs e)
    {
        switch (e.Name)
        {
            case "BitmusterBlinktTesten": BitmusterBlinktTesten(e); break;
            case "BitmusterTesten": BitmusterTesten(e); break;
            case "GetDigitaleAusgaenge": GetDigitaleAusgaenge(e); break;
            case "IncrementDataGridId": IncrementDataGridId(); break;
            case "KommentarAnzeigen": KommentarAnzeigen(e); break;
            case "PlcToDec": PlcToDec(e); break;
            case "PlcColdStart": TestAutomat.PlcColdStart(); break;
            case "PlcGetStatus": TestAutomat.PlcGetStatus(); break;
            case "PlcHotStart": TestAutomat.PlcHotStart(); break;
            case "ResetStopwatch": ResetStopwatch(); break;
            case "SetAnalogerEingang": SetAnalogerEingang(e); break;
            case "SetDataGridBitAnzahl": TestAutomat.SetDataGridBitAnzahl(); break; // Anzeige mit 16 bit 
            case "SetDiagrammZeitbereich": TestAutomat.SetDiagrammZeitbereich(e); break;
            case "SetDigitaleEingaenge": SetDigitaleEingaenge(e); break;
            case "Sleep": Sleep(e); break;
            case "TestAblauf": TestAblauf(e); break;
            case "UpdateAnzeige": UpdateAnzeige(e); break;
            case "VersionAnzeigen": VersionAnzeigen(); break;
        }
    }
}