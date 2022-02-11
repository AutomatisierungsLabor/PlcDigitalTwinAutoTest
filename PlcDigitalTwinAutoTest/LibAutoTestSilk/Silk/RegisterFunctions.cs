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
    public void Runtime_Function(object sender, FunctionEventArgs args)
    {
        switch (args.Name)
        {
            case "BitmusterBlinktTesten": BitmusterBlinktTesten(args); break;
            case "BitmusterTesten": _testAutomat.BitmusterTesten(args); break;
            case "GetDigitaleAusgaenge": _testAutomat.GetDigitaleAusgaenge(args); break;
            case "IncrementDataGridId": IncrementDataGridId(); break; // wird für Einzelschrittmodus genutzt!
            case "KommentarAnzeigen": _testAutomat.KommentarAnzeigen(args); break;
            case "PlcToDec": _testAutomat.PlcToDec(args); break;
            case "PlcColdStart": _testAutomat.PlcColdStart(); break;
            case "PlcGetStatus": _testAutomat.PlcGetStatus(); break;
            case "PlcHotStart": _testAutomat.PlcHotStart(); break;
            case "ResetStopwatch": _testAutomat.RestartStopwatch(); break;
            case "SetAnalogerEingang": _testAutomat.SetAnalogerEingang(args); break;
            case "SetDataGridBitAnzahl": _testAutomat.SetDataGridBitAnzahl(); break; // Anzeige mit 16 bit 
            case "SetDiagrammZeitbereich": _testAutomat.SetDiagrammZeitbereich(args); break;
            case "SetDigitaleEingaenge": _testAutomat.SetDigitaleEingaenge(args); break;
            case "Sleep": _testAutomat.Sleep(args); break;
            case "TestAblauf": TestAblauf(args); break;
            case "UpdateAnzeige": _testAutomat.UpdateAnzeige(args); break;
            case "VersionAnzeigen": _testAutomat.VersionAnzeigen(); break;
        }
    }
}