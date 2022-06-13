using LibConfigDt;
using Xunit;

namespace LibAutoTest.Test;

public class TestKonstruktor
{
    [Theory]
    [InlineData("Konstruktor", 0)]
    [InlineData("Alarme", 3)]

    public void TestKonstruktorOk(string pfad, short alarme)
    {
        var config = new ConfigDt(pfad);

        Assert.Equal(config.GetAnzahlAlarme(), alarme);
    }
}