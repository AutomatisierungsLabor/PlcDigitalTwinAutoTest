using Xunit;

namespace LibConfigPlc.Test
{
    public class ConfigAnzahlByteTesten
    {
        [Theory]
        [InlineData("KeinOrdner", 0, 0, 0, 0)]
        [InlineData("DI/1", 5, 1, 0, 0)]
        [InlineData("DI/2", 2, 2, 2, 2)]
        [InlineData("DI/3", 2, 2, 2, 2)]
        public void ConfigLesenTesten(string pfad, int anzDi, int anzDa, int anzAi, int anzAa)
        {
            var config = new LibConfigPlc.Config();
            config.SetPath(pfad);

            Assert.Equal(anzDi, config.Di.AnzByte);
            Assert.Equal(anzDa, config.Da.AnzByte);
            Assert.Equal(anzAi, config.Ai.AnzByte);
            Assert.Equal(anzAa, config.Aa.AnzByte);
        }
    }
}
