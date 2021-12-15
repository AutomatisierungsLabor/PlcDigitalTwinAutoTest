using Xunit;
using LibConfigPlc;

namespace LibConfigPlc.Test
{
    public class AlleConfigKonstruktorTesten
    {

        [Fact]
        public void KonstruktorTesten()
        {
            var config = new LibConfigPlc.Config();

            Assert.True(config.Di.ConfigOk);
            Assert.True(config.Da.ConfigOk);
            Assert.True(config.Ai.ConfigOk);
            Assert.True(config.Aa.ConfigOk);

            Assert.Equal(0, config.Di.AnzZeilen);
            Assert.Equal(0, config.Da.AnzZeilen);
            Assert.Equal(0, config.Ai.AnzZeilen);
            Assert.Equal(0, config.Aa.AnzZeilen);
        }
    }
}