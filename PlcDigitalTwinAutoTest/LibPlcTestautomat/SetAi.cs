using LibPlcTools;
using SoftCircuits.Silk;

namespace LibPlcTestautomat;

public partial class TestAutomat
{
    public void FuncSetAnalogerEingang(FunctionEventArgs args)
    {
        var startByte = args.Parameters[0].ToInteger();
        var datenTyp = args.Parameters[2].ToString();

        if (datenTyp == "uint16")
        {
            var ai = new Uint((ulong)args.Parameters[1].ToInteger());
            _datenstruktur.Ai[0 + startByte] = Simatic.Digital_GetLowByte((uint)ai.GetDec());
            _datenstruktur.Ai[1 + startByte] = Simatic.Digital_GetHighByte((uint)ai.GetDec());
        }

        if (datenTyp != "S7 / 16 Bit / Prozent") return;

        var analogInput = args.Parameters[1].ToInteger();
        var siemens = Simatic.Analog_2_Int16(analogInput, 100);

        _datenstruktur.Ai[startByte] = Simatic.Digital_GetLowByte((uint)siemens);
        _datenstruktur.Ai[startByte + 1] = Simatic.Digital_GetHighByte((uint)siemens);
    }
}