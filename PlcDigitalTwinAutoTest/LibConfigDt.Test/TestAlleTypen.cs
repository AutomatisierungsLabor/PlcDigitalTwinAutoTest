using System.IO;
using Xunit;
using LibDatenstruktur;

namespace LibConfigDt.Test;

public class TestAlleTypen
{
    [Theory]
    [InlineData("AlleTypen", LibDatenstruktur.DatenBereich.Ai, 0, EaTypen.SiemensAnalogwertPromille)]

    public void TestTypen(string pfad, LibDatenstruktur.DatenBereich datenBereich, int pos, EaTypen eaTypen)
    {
        var config = new ConfigDt(pfad);

        Assert.Equal(config.GetEaType(datenBereich, pos), eaTypen);




    }

}