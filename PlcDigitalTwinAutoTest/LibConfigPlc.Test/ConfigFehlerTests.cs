using Xunit;

namespace LibConfigPlc.Test
{
    public class ConfigFehlerTests
    {

        [Theory]
        [InlineData("TestOrdner3", true, true, true, true)]
        [InlineData("TestOrdner3/StartBit", false, true, true, true)]
        [InlineData("TestOrdner3/StartByte", false, true, true, true)]
        [InlineData("TestOrdner3/BitDoppelt", false, true, true, true)]
        [InlineData("TestOrdner3/DoppelBelegungByte", false, true, true, true)]
        [InlineData("TestOrdner3/DoppelBelegungWord", false, true, true, true)]

        public void FehlerhafteConfigLesenTesten(string pfad, bool di, bool da, bool ai, bool aa)
        {
            var config = new LibConfigPlc.Config();
            config.SetPath(pfad);

            Assert.Equal(di, config.Di.ConfigOk);
            Assert.Equal(da, config.Da.ConfigOk);
            Assert.Equal(ai, config.Ai.ConfigOk);
            Assert.Equal(aa, config.Aa.ConfigOk);
            
        }
    }
}