using Xunit;

namespace LibHydraulik.Test;

public class TestHeizkurve
{
    [Theory]
    [InlineData(0, 0, 0, 100, 20, 0, 20)]
    [InlineData(0, 20, 0, 100, 20, 0, 40)]
    [InlineData(1, 20, 0, 100, 20, 0, 62.28)]

    public void TestsHeizkurve(double neigung, double niveau, double vorlaufMin, double vorlaufMax, double raumtempteratur, double witterungstemperatur, double vorlaufSolltemperatur)
    {
        var heizkurve = new Heizkurve(neigung, niveau, vorlaufMin, vorlaufMax);

        Assert.Equal(vorlaufSolltemperatur, heizkurve.GetVorlaufSollTemperatur(raumtempteratur, witterungstemperatur), 1);
    }
}