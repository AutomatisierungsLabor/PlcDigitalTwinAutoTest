using Xunit;

namespace LibPlcTools.Test;

public class TestZeitDauer
{
    [Theory]
    [InlineData("1234567890", 1234567890)]
    [InlineData("T#1d2h3m4s567ms", 93784567)]
    [InlineData("T#5s500ms", 5500)]
    [InlineData("T#5s123ms", 5123)]
    [InlineData("T#123ms", 123)]

    public void TestsKonstruktorLong(string zahl, long ergebnis)
    {
        var zeitMs = new ZeitDauer(zahl);
        Assert.Equal(ergebnis, zeitMs.DauerMs);
    }

    [Theory]
    [InlineData("1234567890", 1234567890)]
    [InlineData("T#1d2h3m4s567ms", 93784567)]
    [InlineData("T#5s500ms", 5500)]
    [InlineData("T#5s123ms", 5123)]
    [InlineData("T#123ms", 123)]

    public void TestsKonstruktorDouble(string zahl, long ergebnis)
    {
        var zeitMs = new ZeitDauer(zahl);
        Assert.Equal(ergebnis, zeitMs.DauerMs);
    }

    [Theory]
    [InlineData(1, "1ms")]
    [InlineData(999, "999ms")]
    [InlineData(1000, "1s 0ms")]
    [InlineData(60000, "1min 0s 0ms")]
    [InlineData(6101100, "1h 41min 41s 100ms")]

    public void TestsFormatiertAusgeben(long dauer, string ergebnis)
    {
        Assert.Equal(ergebnis, ZeitDauer.ConvertLongToMs(dauer));
    }
}