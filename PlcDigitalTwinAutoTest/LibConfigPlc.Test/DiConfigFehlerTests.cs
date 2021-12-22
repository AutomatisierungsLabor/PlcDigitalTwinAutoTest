using Xunit;

namespace LibConfigPlc.Test;

public class DiConfigFehlerTests
{

    [Theory]
    [InlineData("DI/StartBit", false, true, true, true)]
    [InlineData("DI/StartByte", false, true, true, true)]
    [InlineData("DI/BitDoppelt", false, true, true, true)]
    [InlineData("DI/DoppelBelegungByte", false, true, true, true)]
    [InlineData("DI/DoppelBelegungWord", false, true, true, true)]

    public void FehlerhafteConfigLesenTesten(string pfad, bool di, bool da, bool ai, bool aa)
    {
        var config = new Config(pfad);

        Assert.Equal(di, config.Di.ConfigOk);
        Assert.Equal(da, config.Da.ConfigOk);
        Assert.Equal(ai, config.Ai.ConfigOk);
        Assert.Equal(aa, config.Aa.ConfigOk);
            
    }
}