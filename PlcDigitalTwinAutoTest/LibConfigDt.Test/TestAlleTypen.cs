using Contracts;
using Xunit;

namespace LibConfigDt.Test;

public class TestAlleTypen
{
    [Theory]
    [InlineData("AlleTypen", LibDatenstruktur.DatenBereich.Aa, 0, EaTypen.SiemensAnalogwertPromille)]
    [InlineData("AlleTypen", LibDatenstruktur.DatenBereich.Aa, 1, EaTypen.SiemensAnalogwertProzent)]
    [InlineData("AlleTypen", LibDatenstruktur.DatenBereich.Aa, 2, EaTypen.SiemensAnalogwertSchieberegler)]

    [InlineData("AlleTypen", LibDatenstruktur.DatenBereich.Ai, 0, EaTypen.SiemensAnalogwertPromille)]
    [InlineData("AlleTypen", LibDatenstruktur.DatenBereich.Ai, 1, EaTypen.SiemensAnalogwertProzent)]
    [InlineData("AlleTypen", LibDatenstruktur.DatenBereich.Ai, 2, EaTypen.SiemensAnalogwertSchieberegler)]
    
    [InlineData("AlleTypen", LibDatenstruktur.DatenBereich.Da, 0, EaTypen.Bit)]
    [InlineData("AlleTypen", LibDatenstruktur.DatenBereich.Da, 1, EaTypen.Ascii)]
    [InlineData("AlleTypen", LibDatenstruktur.DatenBereich.Da, 2, EaTypen.BitmusterByte)]
    [InlineData("AlleTypen", LibDatenstruktur.DatenBereich.Da, 3, EaTypen.Byte)]
    [InlineData("AlleTypen", LibDatenstruktur.DatenBereich.Da, 4, EaTypen.Word)]
    [InlineData("AlleTypen", LibDatenstruktur.DatenBereich.Da, 5, EaTypen.DWord)]

    [InlineData("AlleTypen", LibDatenstruktur.DatenBereich.Di, 0, EaTypen.Bit)]
    [InlineData("AlleTypen", LibDatenstruktur.DatenBereich.Di, 1, EaTypen.Ascii)]
    [InlineData("AlleTypen", LibDatenstruktur.DatenBereich.Di, 2, EaTypen.BitmusterByte)]
    [InlineData("AlleTypen", LibDatenstruktur.DatenBereich.Di, 3, EaTypen.Byte)]
    [InlineData("AlleTypen", LibDatenstruktur.DatenBereich.Di, 4, EaTypen.Word)]
    [InlineData("AlleTypen", LibDatenstruktur.DatenBereich.Di, 5, EaTypen.DWord)]

    public void TestTypen(string pfad, LibDatenstruktur.DatenBereich datenBereich, int pos, EaTypen eaTypen)
    {
        var config = new ConfigDt(pfad);
        Assert.Equal(config.GetEaType(datenBereich, pos), eaTypen);
    }
}