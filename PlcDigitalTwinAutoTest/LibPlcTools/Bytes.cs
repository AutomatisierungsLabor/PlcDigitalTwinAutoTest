using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibPlcTools
{
    public class Bytes
    {
        public static int AnzByteEinlesen(byte[] speicherAbbild)
        {
            var anz = 0;
            for (var i = 0; i < 256; i++) if (speicherAbbild[i] > 0) anz = i + 1; // es können auch einzelne Byte nicht belegt sein
            return anz;
        }
        public static bool BitMusterAufKollissionTesten(byte[] speicherAbbild, int posByte, byte bitMuster)
        {
            if (posByte > 256) return true;
            if ((speicherAbbild[posByte] & bitMuster) > 0) return true;

            speicherAbbild[posByte] |= bitMuster;
            return false;
        }

    }
}
