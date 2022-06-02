using Contracts;
using Xunit;

namespace LibConfigDt.Test;

public class TestDoppelbelegungen
{
    [Theory]
    [InlineData("Doppelbelegungen", LibDatenstruktur.DatenBereich.Aa, 0, EaConfigError.None)]
    [InlineData("Doppelbelegungen", LibDatenstruktur.DatenBereich.Aa, 1, EaConfigError.ByteKollision)]
    [InlineData("Doppelbelegungen", LibDatenstruktur.DatenBereich.Aa, 2, EaConfigError.BezeichnungFehlt)]

    [InlineData("Doppelbelegungen", LibDatenstruktur.DatenBereich.Ai, 0, EaConfigError.None)]
    [InlineData("Doppelbelegungen", LibDatenstruktur.DatenBereich.Ai, 1, EaConfigError.ByteKollision)]
    [InlineData("Doppelbelegungen", LibDatenstruktur.DatenBereich.Ai, 2, EaConfigError.KommentarFehlt)]

    [InlineData("Doppelbelegungen", LibDatenstruktur.DatenBereich.Da, 0, EaConfigError.None)]
    [InlineData("Doppelbelegungen", LibDatenstruktur.DatenBereich.Da, 1, EaConfigError.None)]
    [InlineData("Doppelbelegungen", LibDatenstruktur.DatenBereich.Da, 2, EaConfigError.ByteKollision)]
    [InlineData("Doppelbelegungen", LibDatenstruktur.DatenBereich.Da, 3, EaConfigError.ByteKollision)]
    [InlineData("Doppelbelegungen", LibDatenstruktur.DatenBereich.Da, 4, EaConfigError.None)]
    [InlineData("Doppelbelegungen", LibDatenstruktur.DatenBereich.Da, 5, EaConfigError.ByteKollision)]

    [InlineData("Doppelbelegungen", LibDatenstruktur.DatenBereich.Di, 0, EaConfigError.None)]
    [InlineData("Doppelbelegungen", LibDatenstruktur.DatenBereich.Di, 1, EaConfigError.ByteKollision)]
    [InlineData("Doppelbelegungen", LibDatenstruktur.DatenBereich.Di, 2, EaConfigError.ByteKollision)]
    [InlineData("Doppelbelegungen", LibDatenstruktur.DatenBereich.Di, 3, EaConfigError.None)]
    [InlineData("Doppelbelegungen", LibDatenstruktur.DatenBereich.Di, 4, EaConfigError.UngueltigesStartBit)]
    [InlineData("Doppelbelegungen", LibDatenstruktur.DatenBereich.Di, 5, EaConfigError.UngueltigesStartByte)]

    public void TestBelegungen(string pfad, LibDatenstruktur.DatenBereich datenBereich, int pos, EaConfigError error)
    {
        var config = new ConfigDt(pfad);

        Assert.Equal(config.GetEaConfigError(datenBereich, pos), error);
    }
}