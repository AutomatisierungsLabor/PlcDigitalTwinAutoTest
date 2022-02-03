using System;
using System.Collections.Generic;
using Xunit;

namespace LibPlcTools.Test;

public class Bitmuster
{
    [Theory]
    [InlineData(0, 1)]
    [InlineData(1, 2)]
    [InlineData(2, 4)]
    [InlineData(3, 8)]
    [InlineData(7, 128)]
    public void BitmusterTest(byte bitmuster, byte ergebnis)
    {
        Assert.Equal(ergebnis, LibPlcTools.Bitmuster.BitmusterErzeugen(bitmuster));
    }

    [Theory]
    [InlineData(8)]
    public void BitmusterException(byte bitmuster)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => LibPlcTools.Bitmuster.BitmusterErzeugen(bitmuster));
    }


    [Theory]
    [InlineData(0, 0, false)]
    [InlineData(0b0000_0001, 0, true)]
    [InlineData(0b0100_1001, 0, true)]
    [InlineData(0b0010_0010, 1, true)]
    [InlineData(0b0000_1000, 3, true)]
    public void BitmusterInByteTesten(byte bitmuster, int bitPositon, bool ergebnis)
    {
        Assert.Equal(ergebnis, LibPlcTools.Bitmuster.BitmusterInByteTesten(bitmuster, bitPositon));
    }


    [Theory]
    [InlineData(new byte[] { 0x00, 0xff }, 0, false)]
    [InlineData(new byte[] { 0x00, 0xff }, 8, true)]
    public void BitInByteArrayTesten(IReadOnlyList<byte> datenArray, int i, bool expexted)
    {
        Assert.Equal(expexted, LibPlcTools.Bitmuster.BitInByteArrayTesten(datenArray, i));
    }
}