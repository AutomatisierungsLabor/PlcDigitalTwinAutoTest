using System;
using Xunit;

namespace LibPlcTools.Test;

public class TestBytes
{
    [Theory]
    [InlineData(0, new byte[] { })]
    [InlineData(1, new byte[] { 1, 0, 0, 0 })]
    [InlineData(2, new byte[] { 0, 1, 0, 0 })]
    [InlineData(1, new byte[] { 2 })]
    [InlineData(2, new byte[] { 1, 2 })]
    public void TestsAnzahlByteEinlesen(short anzahl, byte[] bytes)
    {
        Assert.Equal(anzahl, Bytes.MaxBytePositionBestimmen(bytes));
    }


    [Theory]
    [InlineData(new byte[] { }, 0, 0)]
    [InlineData(new byte[] { 0 }, 1, 0)]
    [InlineData(new byte[] { 0 }, 300, 0)]
    public void TestsBitmusterException(byte[] bytes, short posByte, byte bitMuster)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Bytes.BitMusterAufKollissionTesten(bytes, posByte, bitMuster));
    }

    [Theory]
    [InlineData(false, new byte[] { 0 }, 0, 0)]
    [InlineData(true, new byte[] { 1 }, 0, 1)]
    [InlineData(true, new byte[] { 0, 3 }, 1, 1)]
    [InlineData(true, new byte[] { 0, 3 }, 1, 2)]
    public void TestsBitMuster(bool ergebnis, byte[] bytes, short posByte, byte bitMuster)
    {
        Assert.Equal(ergebnis, Bytes.BitMusterAufKollissionTesten(bytes, posByte, bitMuster));
    }


    [Theory]
    [InlineData(0, false, false, false, false, false, false, false, false)]
    [InlineData(1, true, false, false, false, false, false, false, false)]
    [InlineData(2, false, true, false, false, false, false, false, false)]
    [InlineData(4, false, false, true, false, false, false, false, false)]
    [InlineData(5, true, false, true, false, false, false, false, false)]
    [InlineData(9, true, false, false, true, false, false, false, false)]
    [InlineData(11, true, true, false, true, false, false, false, false)]
    [InlineData(15, true, true, true, true, false, false, false, false)]
    [InlineData(32, false, false, false, false, false, true, false, false)]
    [InlineData(64, false, false, false, false, false, false, true, false)]
    [InlineData(128, false, false, false, false, false, false, false, true)]
    [InlineData(255, true, true, true, true, true, true, true, true)]

    public void TestsAlleBitLesen(byte b, bool bit0, bool bit1, bool bit2, bool bit3, bool bit4, bool bit5, bool bit6, bool bit7)
    {
        var (b0, b1, b2, b3, b4, b5, b6, b7) = Bytes.AlleBitLesen(b);

        Assert.Equal(b0, bit0);
        Assert.Equal(b1, bit1);
        Assert.Equal(b2, bit2);
        Assert.Equal(b3, bit3);
        Assert.Equal(b4, bit4);
        Assert.Equal(b5, bit5);
        Assert.Equal(b6, bit6);
        Assert.Equal(b7, bit7);
    }


    [Theory]
    [InlineData(0, 0, 0, 0)]
    [InlineData(1, 0, 0, 1)]
    [InlineData(2, 0, 0, 2)]
    [InlineData(3, 0, 0, 3)]
    [InlineData(8, 0, 0, 8)]
    [InlineData(9, 0, 0, 9)]
    [InlineData(10, 0, 1, 0)]
    [InlineData(11, 0, 1, 1)]
    [InlineData(18, 0, 1, 8)]
    [InlineData(19, 0, 1, 9)]
    [InlineData(110, 1, 1, 0)]
    [InlineData(111, 1, 1, 1)]
    [InlineData(118, 1, 1, 8)]
    [InlineData(119, 1, 1, 9)]

    public void TestsByteToBcdCode(byte b, byte h, byte z, byte e)
    {
        var (hunderter, zehner, einer) = Bytes.ByteToBcdCode(b);

        Assert.Equal(hunderter, h);
        Assert.Equal(zehner, z);
        Assert.Equal(einer, e);
    }

    [Theory]
    [InlineData(0, 0, new byte[] { 0, 0, 0, 0 }, new byte[] { 1, 0, 0, 0 })]
    [InlineData(0, 1, new byte[] { 0, 0, 0, 0 }, new byte[] { 2, 0, 0, 0 })]
    [InlineData(0, 2, new byte[] { 0, 0, 0, 0 }, new byte[] { 4, 0, 0, 0 })]
    [InlineData(1, 1, new byte[] { 0, 0, 0, 0 }, new byte[] { 0, 2, 0, 0 })]

    public void TestsByteBitToggeln(byte posByte, byte posBit, byte[] byteIn, byte[] byteExpected)
    {
        Bytes.BitTogglen(byteIn, posByte, posBit);

        Assert.Equal(byteIn, byteExpected);
    }
}