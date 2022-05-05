using System.IO;
using Xunit;

namespace LibConfigDt.Test;

public class TestKonstruktor
{
    [Theory]
    [InlineData("Konstruktor", "DtLeer.json", 0,0,0,0)]

    public void TestKonstruktorOk(string pfad, string name, short aa, short ai, short da, short di)
    {
        var pfadName = Path.Combine(pfad, name);

        var config = new ConfigDt("Konstruktor");
        config.JsonEinlesen(pfadName);

        Assert.Equal(config.GetAnzahlAa(), aa);
        Assert.Equal(config.GetAnzahlAi(), ai);
        Assert.Equal(config.GetAnzahlDa(), da);
        Assert.Equal(config.GetAnzahlDi(), di);
       
    }
}