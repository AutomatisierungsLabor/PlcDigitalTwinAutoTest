using System;
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
    [InlineData(1, 0, true)]

    public void BitmusterInByteTesten(byte bitmuster, int bitPositon, bool ergebnis)
    {
        Assert.Equal(ergebnis, LibPlcTools.Bitmuster.BitmusterInByteTesten(bitmuster, bitPositon));
    }

}