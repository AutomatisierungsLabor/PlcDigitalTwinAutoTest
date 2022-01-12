using System.Runtime.CompilerServices;

namespace LibPlcTools;

public class Bitmuster
{
    public static byte BitmusterErzeugen(int bitPos)
    {
        if (bitPos > 7) throw new ArgumentOutOfRangeException(nameof(bitPos));
        return (byte)(1 << bitPos);
    }

    public static bool BitmusterInByteTesten(short Bitmuster, int bitPos)
    {
        var bitMuster = BitmusterErzeugen(bitPos % 8);

        return (Bitmuster & bitMuster) == bitMuster;
    }
}