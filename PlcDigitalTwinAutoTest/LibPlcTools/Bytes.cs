namespace LibPlcTools;

public class Bytes
{
    public static int MaxBytePositionBestimmen(byte[] bytes)
    {
        var anz = 0;
        var groesse = bytes.Length;
        for (var i = 0; i < groesse; i++) if (bytes[i] > 0) anz = i + 1; // es können auch einzelne Byte nicht belegt sein
        return anz;
    }
    public static bool BitMusterAufKollissionTesten(byte[] bytes, int posByte, byte bitMuster)
    {
        var groesse = bytes.Length;

        if (groesse == 0) throw new ArgumentOutOfRangeException(groesse.ToString(), "BitMusterAufKollissionTesten: Array leer");
        if (posByte > 256) throw new ArgumentOutOfRangeException(posByte.ToString(), "BitMusterAufKollissionTesten: posByte > 256");
        if (posByte >= groesse) throw new ArgumentOutOfRangeException(posByte.ToString(), "BitMusterAufKollissionTesten: posByte > Größe Array");

        if ((bytes[posByte] & bitMuster) > 0) return true;

        bytes[posByte] |= bitMuster;
        return false;
    }
    public static (bool b0, bool b1, bool b2, bool b3, bool b4, bool b5, bool b6, bool b7) AlleBitLesen(byte parkPlaetzte)
    {
        var b0 = BitMaskierenByte(parkPlaetzte, 0);
        var b1 = BitMaskierenByte(parkPlaetzte, 1);
        var b2 = BitMaskierenByte(parkPlaetzte, 2);
        var b3 = BitMaskierenByte(parkPlaetzte, 3);
        var b4 = BitMaskierenByte(parkPlaetzte, 4);
        var b5 = BitMaskierenByte(parkPlaetzte, 5);
        var b6 = BitMaskierenByte(parkPlaetzte, 6);
        var b7 = BitMaskierenByte(parkPlaetzte, 7);

        return (b0, b1, b2, b3, b4, b5, b6, b7);
    }
    internal static bool BitMaskierenByte(byte parkPlaetzte, int i)
    {
        var bitMuster = (byte)(1 << i % 8);
        return (parkPlaetzte & bitMuster) == bitMuster;
    }
    public static (byte hunderter, byte zehner, byte einer) ByteToBcdCode(byte b)
    {
        var hunderter = b / 100;
        var rest = b % 100;
        var zehner = rest / 10;
        var einer = rest % 10;
        return ((byte)hunderter, (byte)zehner, (byte)einer);
    }
    public static void BitTogglen(byte[] byteArray, int posByte, byte posBit)
    {
        var bitMuster = Bitmuster.BitmusterErzeugen(posBit);

        if ((byte)(byteArray[posByte] & bitMuster) == bitMuster) byteArray[posByte] &= (byte)~bitMuster; else byteArray[posByte] |= bitMuster;
    }
}