namespace LibPlcTools;

public class Bitmuster
{
    public static byte BitmusterErzeugen(int bitPos)
    {
        if (bitPos > 7) throw new ArgumentOutOfRangeException(nameof(bitPos));
        return (byte)(1 << bitPos);
    }
    public static bool BitmusterInByteTesten(short bitmuster, int bitPos)
    {
        var bitMuster = BitmusterErzeugen(bitPos % 8);
        return (bitmuster & bitMuster) == bitMuster;
    }
    public static bool BitInByteArrayTesten(IReadOnlyList<byte> datenArray, int i)
    {
        var ibyte = i / 8;
        var bitMuster = (byte)(1 << (i % 8));
        return (datenArray[ibyte] & bitMuster) == bitMuster;
    }
}