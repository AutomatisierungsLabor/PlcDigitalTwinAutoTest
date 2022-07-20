﻿using Contracts;
using SoftCircuits.Silk;
using System.Threading;

namespace LibAutoTestSilk.Silk;

public partial class Silk
{
    // Register intrinsic functions - NOTE that silk internal functions are also available
    // as per https://github.com/SoftCircuits/Silk/blob/master/docs/InternalFunctions.md

    public void RunProgram(CompiledProgram program, CancellationToken cancellationToken)
    {
        var runtime = new Runtime(program, cancellationToken);

        runtime.Begin += Runtime_Begin;
        runtime.Function += Runtime_Function;
        runtime.End += Runtime_End;

        runtime.Execute();
    }
    public void Runtime_Begin(object sender, BeginEventArgs e) => _testAutomat.InfoAnzeigen($"{_testAutomat.StopwatchGetElapsedMilliseconds()}ms", TestAnzeige.TestStart, " ");
    private void Runtime_End(object sender, EndEventArgs e) => _testAutomat.InfoAnzeigen($"{_testAutomat.StopwatchGetElapsedMilliseconds()}ms", TestAnzeige.TestEnde, " ");
    private static void CompilerRegisterFunctions(Compiler compiler)
    {
        // ReSharper disable RedundantArgumentDefaultValue
        compiler.RegisterFunction("BitmusterBlinktTesten", 8, 8);
        compiler.RegisterFunction("BitmusterTesten", 4, 4);
        compiler.RegisterFunction("Debug", 0, Function.NoParameterLimit);
        compiler.RegisterFunction("IncrementDataGridId", 0, 0);
        compiler.RegisterFunction("KommentarAnzeigen", 1, 1);
        compiler.RegisterFunction("PlcToDec", 1, 1);
        compiler.RegisterFunction("PlcColdStart", 0, 0);
        compiler.RegisterFunction("PlcGetStatus", 0, 0);
        compiler.RegisterFunction("PlcHotStart", 0, 0);
        compiler.RegisterFunction("Print", 0, Function.NoParameterLimit);
        compiler.RegisterFunction("println", 0, Function.NoParameterLimit);
        compiler.RegisterFunction("StopwatchRestart", 0, 0);
        compiler.RegisterFunction("SetAnalogerEingang", 3, 3);
        compiler.RegisterFunction("SetDataGridBitAnzahl", 2, 2);
        compiler.RegisterFunction("SetDiagrammZeitbereich", 1, 1);
        compiler.RegisterFunction("SetDigitaleEingaenge", 1, 1);
        compiler.RegisterFunction("Sleep", 1, 1);
        compiler.RegisterFunction("TestAblauf", 0, 2);
        compiler.RegisterFunction("TestabschnittAnzeigen",1,1);
        compiler.RegisterFunction("VersionAnzeigen", 0, 0);
        // ReSharper restore RedundantArgumentDefaultValue
    }
    public void Runtime_Function(object sender, FunctionEventArgs args)
    {
        switch (args.Name)
        {
            case "BitmusterBlinktTesten": _testAutomat.FuncBitmusterBlinktTesten(args); break;
            case "BitmusterTesten": _testAutomat.FuncBitmusterTesten(args); break;
            case "IncrementDataGridId": // wird für Einzelschrittmodus genutzt!
                FuncIncrementDataGridId();
                _testAutomat.IncrementZeilenNummer();
                break;
            case "KommentarAnzeigen": _testAutomat.FuncKommentarAnzeigen(args); break;
            case "PlcToDec": _testAutomat.FuncPlcToDec(args); break;
            case "PlcColdStart": _testAutomat.FuncPlcColdStart(); break;
            case "PlcGetStatus": _testAutomat.FuncPlcGetStatus(); break;
            case "PlcHotStart": _testAutomat.FuncPlcHotStart(); break;
            case "StopwatchRestart": _testAutomat.StopwatchRestart(); break;
            case "SetAnalogerEingang": _testAutomat.FuncSetAnalogerEingang(args); break;
            case "SetDataGridBitAnzahl": _testAutomat.FuncSetDataGridBitAnzahl(); break; // Anzeige mit 16 bit 
            case "SetDiagrammZeitbereich": _testAutomat.FuncSetDiagrammZeitbereich(args); break;
            case "SetDigitaleEingaenge": _testAutomat.FuncSetDigitaleEingaenge(args); break;
            case "Sleep": _testAutomat.FuncSleep(args); break;
            case "TestAblauf": FuncTestAblauf(args); break;
            case "TestabschnittAnzeigen": _testAutomat.FuncTestabschnittAnzeigen(args); break;
            case "VersionAnzeigen": _testAutomat.FuncVersionAnzeigen(); break;
        }
    }
}