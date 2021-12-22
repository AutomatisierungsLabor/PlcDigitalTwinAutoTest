using Xunit;

namespace LibDatenstruktur.Test;

public class Bitmuster
{
    [Theory]
    [InlineData(0, false, false, false, false, false, false, false, false)]
    [InlineData(1, false, false, false, false, false, false, false, true)]
    [InlineData(2, false, false, false, false, false, false, true, false)]
    [InlineData(4, false, false, false, false, false, true, false, false)]
    [InlineData(8, false, false, false, false, true, false, false, false)]
    [InlineData(16, false, false, false, true, false, false, false, false)]
    [InlineData(32, false, false, true, false, false, false, false, false)]
    [InlineData(64, false, true, false, false, false, false, false, false)]
    [InlineData(128, true, false, false, false, false, false, false, false)]
    [InlineData(255, true, true, true, true, true, true, true, true)]

    public void BitmusterSchreibenTesten(byte expexted, bool b7, bool b6, bool b5, bool b4, bool b3, bool b2, bool b1, bool lsb)
    {
        var datenstruktur = new Datenstruktur();

        datenstruktur.SetBitmuster(DatenBereich.Di, 0, lsb, b1, b2, b3, b4, b5, b6, b7);

        Assert.Equal(expexted, datenstruktur.Di[0]);
    }

    [Theory]
    [InlineData(0, false, false, false, false, false, false, false, false)]
    [InlineData(1, false, false, false, false, false, false, false, true)]
    [InlineData(2, false, false, false, false, false, false, true, false)]
    [InlineData(4, false, false, false, false, false, true, false, false)]
    [InlineData(8, false, false, false, false, true, false, false, false)]
    [InlineData(16, false, false, false, true, false, false, false, false)]
    [InlineData(32, false, false, true, false, false, false, false, false)]
    [InlineData(64, false, true, false, false, false, false, false, false)]
    [InlineData(128, true, false, false, false, false, false, false, false)]
    [InlineData(255, true, true, true, true, true, true, true, true)]

    public void BitmusterLesenTesten(byte wert, bool eb7, bool eb6, bool eb5, bool eb4, bool eb3, bool eb2, bool eb1, bool elsb)
    {

        var datenstruktur = new Datenstruktur
        {
            Da =
            {
                [0] = wert
            }
        };

        var (lsb, b1, b2, b3, b4, b5, b6, b7) = datenstruktur.GetBitmuster(DatenBereich.Da, 0);

        Assert.Equal(elsb, lsb);
        Assert.Equal(eb1, b1);
        Assert.Equal(eb2, b2);
        Assert.Equal(eb3, b3);
        Assert.Equal(eb4, b4);
        Assert.Equal(eb5, b5);
        Assert.Equal(eb6, b6);
        Assert.Equal(eb7, b7);
    }
}