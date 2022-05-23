using System.IO;
using Xunit;

namespace LibConfigDt.Test;

public class TestKonstruktor
{
    [Theory]
    [InlineData("Konstruktor", 0, 0, 0, 0, 0)]
    [InlineData("JeEinEintrag", 1, 1, 1, 1, 1)]

    public void TestKonstruktorOk(string pfad, short aa, short ai, short da, short di, short texte)
    {
        var config = new ConfigDt(pfad);

        Assert.Equal(config.GetAnzahlAa(), aa);
        Assert.Equal(config.GetAnzahlAi(), ai);
        Assert.Equal(config.GetAnzahlDa(), da);
        Assert.Equal(config.GetAnzahlDi(), di);
        Assert.Equal(config.GetAnzahlTextbausteine(), texte);
    }

}