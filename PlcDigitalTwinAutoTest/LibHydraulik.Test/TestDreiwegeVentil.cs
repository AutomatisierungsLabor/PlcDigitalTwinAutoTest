using Xunit;

namespace LibHydraulik.Test;

public class TestDreiwegeVentil
{

    [Theory]
    [InlineData(0, 100, 10)]
    [InlineData(-100, 100, 10)]
    public void TestsKonstruktor(double min, double max, double laufzeit)
    {
        var ventil = new DreiwegeVentil(min, max, laufzeit);
        Assert.Equal(0, ventil.GetPosition());
    }
}