using Xunit;

namespace LibConfigPlc.Test;

public class DiConfigFehlerTests
{

    [Theory]
    [InlineData("DI/StartBit", false, false, false, false)]
    [InlineData("DI/StartByte", false, false, false, false)]
    [InlineData("DI/BitDoppelt", false, false, false, false)]
    [InlineData("DI/DoppelBelegungByte", false, false, false, false)]
    [InlineData("DI/DoppelBelegungWord", false, false, false, false)]

    public void FehlerhafteConfigLesenTesten(string pfad, bool di, bool da, bool ai, bool aa)
    {
        var config = new ConfigPlc(pfad);

        Assert.Equal(di, config.Di.ConfigOk);
        Assert.Equal(da, config.Da.ConfigOk);
        Assert.Equal(ai, config.Ai.ConfigOk);
        Assert.Equal(aa, config.Aa.ConfigOk);
    }
}