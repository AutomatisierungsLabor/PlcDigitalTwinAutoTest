using System;
using Xunit;

namespace LibPlcTools.Test
{
    public class Bytes
    {
        [Theory]
        [InlineData(0, new byte[] { })]
        [InlineData(1, new byte[] { 1, 0, 0, 0 })]
        [InlineData(2, new byte[] { 0, 1, 0, 0 })]
        [InlineData(1, new byte[] { 2 })]
        [InlineData(2, new byte[] { 1, 2 })]
        public void AnzahlByteEinlesenTesten(short anzahl, byte[] bytes)
        {
            Assert.Equal(anzahl, LibPlcTools.Bytes.MaxBytePositionBestimmen(bytes));
        }


        [Theory]
        [InlineData(new byte[] { }, 0, 0)]
        [InlineData(new byte[] { 0 }, 1, 0)]
        [InlineData(new byte[] { 0 }, 300, 0)]
        public void BitmusterException(byte[] bytes, short posByte, byte bitMuster)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => LibPlcTools.Bytes.BitMusterAufKollissionTesten(bytes, posByte, bitMuster));
        }

        [Theory]
        [InlineData(false, new byte[] { 0 }, 0, 0)]
        [InlineData(true, new byte[] { 1 }, 0, 1)]
        [InlineData(true, new byte[] { 0, 3 }, 1, 1)]
        [InlineData(true, new byte[] { 0, 3 }, 1, 2)]
        public void BitMusterTesten(bool ergebnis, byte[] bytes, short posByte, byte bitMuster)
        {
            Assert.Equal(ergebnis, LibPlcTools.Bytes.BitMusterAufKollissionTesten(bytes, posByte, bitMuster));
        }
    }
}
