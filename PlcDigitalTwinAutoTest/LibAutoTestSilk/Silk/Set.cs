using LibPlc;
using SoftCircuits.Silk;
using System.Threading;

namespace LibAutoTestSilk.Silk;

public partial class Silk
{
    internal void SetDiWord(Uint eingaenge)
    {
        Datenstruktur.Di[0] = Simatic.Digital_GetLowByte((uint)eingaenge.GetDec());
        Datenstruktur.Di[1] = Simatic.Digital_GetHighByte((uint)eingaenge.GetDec());
    }
    private void SetDi(FunctionEventArgs e)
    {
        SetDiWord(new Uint((ulong)e.Parameters[0].ToInteger()));
        Thread.Sleep(100);
    }
    private void SetAi(FunctionEventArgs e)
    {
        var startByte = e.Parameters[0].ToInteger();
        var analogInput = e.Parameters[1].ToInteger();
        var datenTyp = e.Parameters[2].ToString();

        if (datenTyp != "S7 / 16 Bit / Prozent") return;

        var siemens = Simatic.Analog_2_Int16(analogInput, 100);
        Datenstruktur.Ai[startByte] = Simatic.Digital_GetLowByte((uint)siemens);
        Datenstruktur.Ai[startByte + 1] = Simatic.Digital_GetHighByte((uint)siemens);
    }
    public void SetDiagrammZeitbereich(FunctionEventArgs e)
    {
        Datenstruktur.DiagrammZeitbereich = e.Parameters[0].ToInteger();
    }
    private void SetDataGridBitAnzahl()
    {
        _anzahlBitEingaenge = 16;   // e.Parameters[0].ToInteger();
        _anzahlBitAusgaenge = 16;   // e.Parameters[1].ToInteger();
    }
}