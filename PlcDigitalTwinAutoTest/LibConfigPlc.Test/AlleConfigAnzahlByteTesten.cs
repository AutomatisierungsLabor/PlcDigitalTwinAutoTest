using Xunit;

namespace LibConfigPlc.Test;

public class AlleConfigAnzahlByteTesten
{
    [Theory]
    [InlineData("KeinOrdner", 0, 0, 0, 0)]
    [InlineData("Alle/1", 1, 1, 0, 0)]
    [InlineData("Alle/2", 1, 1, 2, 4)]
    [InlineData("Alle/3", 3, 2, 4, 6)]

    public void AnzahlByteTesten(string pfad, int anzDi, int anzDa, int anzAi, int anzAa)
    {
        var config = new Config();
        config.SetPath(pfad);

        Assert.Equal(anzDi, config.Di.AnzByte);
        Assert.Equal(anzDa, config.Da.AnzByte);
        Assert.Equal(anzAi, config.Ai.AnzByte);
        Assert.Equal(anzAa, config.Aa.AnzByte);
    }
}