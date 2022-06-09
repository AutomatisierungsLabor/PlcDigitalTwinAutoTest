using Xunit;

namespace LibConfigDt.Test;

public class TestKonstruktor
{
    [Theory]
    [InlineData("AlleTypen", 3, 3, 6, 6, 1,2)]
    [InlineData("Doppelbelegungen", 3, 3, 6, 6, 1,2)]
    [InlineData("JeEinEintrag", 1, 1, 1, 1, 1,1)]
    [InlineData("Konstruktor", 0, 0, 0, 0, 0,0)]


    public void TestKonstruktorOk(string pfad, short aa, short ai, short da, short di, short texte, short alarme)
    {
        var config = new ConfigDt(pfad);

        Assert.Equal(config.GetAnzahlAa(), aa);
        Assert.Equal(config.GetAnzahlAi(), ai);
        Assert.Equal(config.GetAnzahlDa(), da);
        Assert.Equal(config.GetAnzahlDi(), di);
        Assert.Equal(config.GetAnzahlTextbausteine(), texte);
        Assert.Equal(config.GetAnzahlAlarme(), alarme);
    }
}