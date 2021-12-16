using Xunit;

namespace LibConfigPlc.Test
{
    public class AlleConfigAnzahlZeilenTesten
    {
        [Theory]
        [InlineData("KeinOrdner", 0, 0, 0, 0)]
        [InlineData("Alle/1", 5, 1, 0, 0)]
        [InlineData("Alle/2", 2, 2, 2, 2)]
        [InlineData("Alle/3", 2, 2, 2, 3)]
        public void ConfigAnzahlZeilenTesten(string pfad, int anzDi, int anzDa, int anzAi, int anzAa)
        {
            var config = new Config();
            config.SetPath(pfad);

            Assert.Equal(anzDi, config.Di.AnzZeilen);
            Assert.Equal(anzDa, config.Da.AnzZeilen);
            Assert.Equal(anzAi, config.Ai.AnzZeilen);
            Assert.Equal(anzAa, config.Aa.AnzZeilen);
        }
    }
}
