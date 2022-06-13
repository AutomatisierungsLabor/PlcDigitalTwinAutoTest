using System;
using Xunit;

namespace LibDatenstruktur.Test;

public class TestByte
{
    [Theory]
    [InlineData(DatenBereich.Aa, 0, 0)]
    [InlineData(DatenBereich.Ai, 0, 0)]
    [InlineData(DatenBereich.Da, 0, 0)]
    [InlineData(DatenBereich.Di, 0, 0)]

    [InlineData(DatenBereich.Aa, 1, 2)]
    [InlineData(DatenBereich.Ai, 2, 3)]
    [InlineData(DatenBereich.Da, 3, 4)]
    [InlineData(DatenBereich.Di, 4, 5)]

    [InlineData(DatenBereich.Aa, 2, 5)]
    [InlineData(DatenBereich.Ai, 3, 6)]
    [InlineData(DatenBereich.Da, 4, 7)]
    [InlineData(DatenBereich.Di, 5, 8)]

    public void TestsByteSchreiben(DatenBereich datenBereich, byte offset, byte b)
    {
        var datenstruktur = new Datenstruktur();

        datenstruktur.SetByte(datenBereich, offset, b);

        switch (datenBereich)
        {
            case DatenBereich.Aa:
                Assert.Equal(b, datenstruktur.Aa[offset]);
                Assert.Equal(0, datenstruktur.Ai[offset]);
                Assert.Equal(0, datenstruktur.Da[offset]);
                Assert.Equal(0, datenstruktur.Di[offset]);
                break;
            case DatenBereich.Ai:
                Assert.Equal(0, datenstruktur.Aa[offset]);
                Assert.Equal(b, datenstruktur.Ai[offset]);
                Assert.Equal(0, datenstruktur.Da[offset]);
                Assert.Equal(0, datenstruktur.Di[offset]);
                break;
            case DatenBereich.Da:
                Assert.Equal(0, datenstruktur.Aa[offset]);
                Assert.Equal(0, datenstruktur.Ai[offset]);
                Assert.Equal(b, datenstruktur.Da[offset]);
                Assert.Equal(0, datenstruktur.Di[offset]);
                break;
            case DatenBereich.Di:
                Assert.Equal(0, datenstruktur.Aa[offset]);
                Assert.Equal(0, datenstruktur.Ai[offset]);
                Assert.Equal(0, datenstruktur.Da[offset]);
                Assert.Equal(b, datenstruktur.Di[offset]);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(datenBereich), datenBereich, null);
        }


    }


    [Theory]
    [InlineData(DatenBereich.Aa, 0, 0)]
    [InlineData(DatenBereich.Ai, 0, 0)]
    [InlineData(DatenBereich.Da, 0, 0)]
    [InlineData(DatenBereich.Di, 0, 0)]

    [InlineData(DatenBereich.Aa, 1, 2)]
    [InlineData(DatenBereich.Ai, 2, 3)]
    [InlineData(DatenBereich.Da, 3, 4)]
    [InlineData(DatenBereich.Di, 4, 5)]

    [InlineData(DatenBereich.Aa, 2, 5)]
    [InlineData(DatenBereich.Ai, 3, 6)]
    [InlineData(DatenBereich.Da, 4, 7)]
    [InlineData(DatenBereich.Di, 5, 8)]
    public void TestsByteSchreibenUndLesen(DatenBereich datenBereich, byte offset, byte b)
    {
        var datenstruktur = new Datenstruktur();

        datenstruktur.SetByte(datenBereich, offset, b);

        switch (datenBereich)
        {
            case DatenBereich.Aa:
                Assert.Equal(b, datenstruktur.GetByte(DatenBereich.Aa, offset));
                Assert.Equal(0, datenstruktur.GetByte(DatenBereich.Ai, offset));
                Assert.Equal(0, datenstruktur.GetByte(DatenBereich.Da, offset));
                Assert.Equal(0, datenstruktur.GetByte(DatenBereich.Di, offset));
                break;
            case DatenBereich.Ai:
                Assert.Equal(0, datenstruktur.GetByte(DatenBereich.Aa, offset));
                Assert.Equal(b, datenstruktur.GetByte(DatenBereich.Ai, offset));
                Assert.Equal(0, datenstruktur.GetByte(DatenBereich.Da, offset));
                Assert.Equal(0, datenstruktur.GetByte(DatenBereich.Di, offset));
                break;
            case DatenBereich.Da:
                Assert.Equal(0, datenstruktur.GetByte(DatenBereich.Aa, offset));
                Assert.Equal(0, datenstruktur.GetByte(DatenBereich.Ai, offset));
                Assert.Equal(b, datenstruktur.GetByte(DatenBereich.Da, offset));
                Assert.Equal(0, datenstruktur.GetByte(DatenBereich.Di, offset));
                break;
            case DatenBereich.Di:
                Assert.Equal(0, datenstruktur.GetByte(DatenBereich.Aa, offset));
                Assert.Equal(0, datenstruktur.GetByte(DatenBereich.Ai, offset));
                Assert.Equal(0, datenstruktur.GetByte(DatenBereich.Da, offset));
                Assert.Equal(b, datenstruktur.GetByte(DatenBereich.Di, offset));
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(datenBereich), datenBereich, null);
        }


    }

}
