using System;
using System.Collections.Generic;
using Xunit;

namespace LibPlcTools.Test;

public class TestBitmuster
{
    [Theory]
    [InlineData(0, 1)]
    [InlineData(1, 2)]
    [InlineData(2, 4)]
    [InlineData(3, 8)]
    [InlineData(7, 128)]
    public void TestsBitmuster(byte bitmuster, byte ergebnis)
    {
        Assert.Equal(ergebnis, Bitmuster.BitmusterErzeugen(bitmuster));
    }

    [Theory]
    [InlineData(8)]
    public void TestsBitmusterException(byte bitmuster)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Bitmuster.BitmusterErzeugen(bitmuster));
    }


    [Theory]
    [InlineData(0, 0, false)]
    [InlineData(0b0000_0001, 0, true)]
    [InlineData(0b0100_1001, 0, true)]
    [InlineData(0b0010_0010, 1, true)]
    [InlineData(0b0000_1000, 3, true)]
    public void TestsBitmusterInByte(byte bitmuster, int bitPositon, bool ergebnis)
    {
        Assert.Equal(ergebnis, Bitmuster.BitmusterInByteTesten(bitmuster, bitPositon));
    }


    [Theory]
    [InlineData(new byte[] { 0x00, 0xff }, 0, false)]
    [InlineData(new byte[] { 0x00, 0xff }, 8, true)]
    public void TestsBitInByteArray(IReadOnlyList<byte> datenArray, int i, bool expexted)
    {
        Assert.Equal(expexted, Bitmuster.BitInByteArrayTesten(datenArray, i));
    }

    [Theory]
    [InlineData(new byte[] { 0x00, 0xff }, 0, 0, false)]
    [InlineData(new byte[] { 0x00, 0xff }, 1, 7, true)]
    public void TestsBytesUndBitInByteArray(IReadOnlyList<byte> datenArray, int bytePosition, int bitPosition, bool expexted)
    {
        Assert.Equal(expexted, Bitmuster.BitInByteArrayTesten(datenArray, bytePosition, bitPosition));
    }

    [Theory]
    [InlineData(new byte[] { 0x00, 0x00 }, 0, 0)]
    [InlineData(new byte[] { 0x00, 0x00 }, 1, 1)]
    public void TestsBytesBitArray(ref byte[] datenArray, int bytePosition, int bitPosition)
    {
        Assert.False(Bitmuster.BitInByteArrayTesten(datenArray, bytePosition, bitPosition));
        Bitmuster.SetBitmusterInArray(ref datenArray, bytePosition, bitPosition);
        Assert.True(Bitmuster.BitInByteArrayTesten(datenArray, bytePosition, bitPosition));
    }
}