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
}