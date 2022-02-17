using System;
using Xunit;

namespace LibUtil.Test;

public class TestWinkel
{
    [Theory]
    [InlineData(0, 0)]
    [InlineData(180, Math.PI)]
    [InlineData(360, 2 * Math.PI)]

    public void WinkelDegToRadTest(double deg, double rad)
    {
        Assert.Equal(rad, Winkel.DegToRad(deg), 3);
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(Math.PI, 180)]
    [InlineData(2 * Math.PI, 360)]

    public void WinkelRadToDegTest(double rad, double deg)
    {
        Assert.Equal(deg, Winkel.RadToDeg(rad), 3);
    }
}