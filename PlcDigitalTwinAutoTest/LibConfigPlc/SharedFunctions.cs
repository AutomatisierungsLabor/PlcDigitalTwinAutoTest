namespace LibConfigPlc;

internal class SharedFunctions
{
    internal  int AnzByteEinlesen(byte[] speicherAbbild)
    {
        var anz = 0;
        for (var i = 0; i < 256; i++) if (speicherAbbild[i] > 0) anz = i + 1; // es können auch einzelne Byte nicht belegt sein
        return anz;
    }
    internal  bool BitMusterAufKollissionTesten(byte[] speicherAbbild, int posByte, byte bitMuster)
    {
        if (posByte > 256) return true;
        if ((speicherAbbild[posByte] & bitMuster) > 0) return true;

        speicherAbbild[posByte] |= bitMuster;
        return false;
    }
}