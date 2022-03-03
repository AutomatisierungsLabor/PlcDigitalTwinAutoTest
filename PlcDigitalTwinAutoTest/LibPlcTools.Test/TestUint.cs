using Xunit;

namespace LibPlcTools.Test;

public class TestUint
{
    [Theory]
    [InlineData(1, 1)]
    [InlineData(12345, 12345)]
    public void TestsKonstruktorInt(ulong zahl, uint ergebnis)
    {
        var plc = new Uint(zahl);
        Assert.Equal(ergebnis, plc.GetDec());
    }

    [Theory]
    [InlineData("12345", 12345)]
    [InlineData("2#0001_0010_0011_0100", 4660)]
    [InlineData("8#12345", 5349)]
    [InlineData("16#1234", 4660)]
    public void TestsKonstruktorString(string zahl, uint ergebnis)
    {
        var plc = new Uint(zahl);
        Assert.Equal(ergebnis, plc.GetDec());
    }


    [Theory]
    [InlineData("1", 0)]
    [InlineData("4", 2)]
    public void TestsBin(string zahl, int position)
    {
        var plc = new Uint(zahl);
        Assert.True(plc.GetBitGesetzt(position));
    }

    [Theory]
    [InlineData("16", "uuups - zu große Zahl!")]
    [InlineData("1", "2#0001")]
    [InlineData("9", "2#1001")]
    public void TestsBin_4Bit(string zahl, string ergebnis)
    {
        var plc = new Uint(zahl);
        Assert.Equal(ergebnis, plc.GetBin4Bit());
    }

    [Theory]
    [InlineData("256", "uuups - zu große Zahl!")]
    [InlineData("1", "2#0000_0001")]
    [InlineData("105", "2#0110_1001")]
    public void TestsBin_8Bit(string zahl, string ergebnis)
    {
        var plc = new Uint(zahl);
        Assert.Equal(ergebnis, plc.GetBin8Bit());
    }

    [Theory]
    [InlineData("12345", "uuups - zu große Zahl!")]
    [InlineData("1", "2#0000_0000_0001")]
    [InlineData("105", "2#0000_0110_1001")]
    public void TestsBin_12Bit(string zahl, string ergebnis)
    {
        var plc = new Uint(zahl);
        Assert.Equal(ergebnis, plc.GetBin12Bit());
    }

    [Theory]
    [InlineData("65536", "uuups - zu große Zahl!")]
    [InlineData("2", "2#0000_0000_0000_0010")]
    [InlineData("26985", "2#0110_1001_0110_1001")]
    public void TestsBin_16Bit(string zahl, string ergebnis)
    {
        var plc = new Uint(zahl);
        Assert.Equal(ergebnis, plc.GetBin16Bit());
    }

    [Theory]
    [InlineData("4294967296", "uuups - zu große Zahl!")]
    [InlineData("3", "2#0000_0000_0000_0000_0000_0000_0000_0011")]
    [InlineData("4660", "2#0000_0000_0000_0000_0001_0010_0011_0100")]
    public void TestsBin_32Bit(string zahl, string ergebnis)
    {
        var plc = new Uint(zahl);
        Assert.Equal(ergebnis, plc.GetBin32Bit());
    }


    [Theory]
    [InlineData(8, 3, "2#0000_0011")]
    [InlineData(16, 3, "2#0000_0000_0000_0011")]
    [InlineData(32, 3, "2#0000_0000_0000_0000_0000_0000_0000_0011")]
    public void TestsBin_xBit(int anzahlbit, ulong zahl, string ergebnis)
    {
        var plc = new Uint(zahl);
        Assert.Equal(ergebnis, plc.GetBinBit(anzahlbit));
    }


    [Theory]
    [InlineData(3, "2#0011")]
    [InlineData(123, "2#0111_1011")]
    [InlineData(12345, "2#0011_0000_0011_1001")]
    [InlineData(123456, "2#0000_0000_0000_0001_1110_0010_0100_0000")]
    public void TestsBin_GetBin(ulong zahl, string ergebnis)
    {
        var plc = new Uint(zahl);
        Assert.Equal(ergebnis, plc.GetBin());
    }

    [Theory]
    [InlineData("16", "uuups - zu große Zahl!")]
    [InlineData("1", "16#1")]
    [InlineData("9", "16#9")]
    public void TestsHex_4Bit(string zahl, string ergebnis)
    {
        var plc = new Uint(zahl);
        Assert.Equal(ergebnis, plc.GetHex4Bit());
    }

    [Theory]
    [InlineData("256", "uuups - zu große Zahl!")]
    [InlineData("1", "16#01")]
    [InlineData("105", "16#69")]
    public void TestsHex_8Bit(string zahl, string ergebnis)
    {
        var plc = new Uint(zahl);
        Assert.Equal(ergebnis, plc.GetHex8Bit());
    }

    [Theory]
    [InlineData("65536", "uuups - zu große Zahl!")]
    [InlineData("2", "16#002")]
    [InlineData("1234", "16#4D2")]
    public void TestsHex_12Bit(string zahl, string ergebnis)
    {
        var plc = new Uint(zahl);
        Assert.Equal(ergebnis, plc.GetHex12Bit());
    }

    [Theory]
    [InlineData("65536", "uuups - zu große Zahl!")]
    [InlineData("2", "16#0002")]
    [InlineData("26985", "16#6969")]
    public void TestsHex_16Bit(string zahl, string ergebnis)
    {
        var plc = new Uint(zahl);
        Assert.Equal(ergebnis, plc.GetHex16Bit());
    }

    [Theory]
    [InlineData("4294967296", "uuups - zu große Zahl!")]
    [InlineData("3", "16#00000003")]
    [InlineData("4660", "16#00001234")]
    public void TestsHex_32Bit(string zahl, string ergebnis)
    {
        var plc = new Uint(zahl);
        Assert.Equal(ergebnis, plc.GetHex32Bit());
    }

    [Theory]
    [InlineData(8, 3, "16#03")]
    [InlineData(16, 3, "16#0003")]
    [InlineData(32, 3, "16#00000003")]
    public void TestsHex_xBit(int anzahlBit, ulong zahl, string ergebnis)
    {
        var plc = new Uint(zahl);
        Assert.Equal(ergebnis, plc.GetHexBit(anzahlBit));
    }

    [Theory]
    [InlineData(5, "16#5")]
    [InlineData(123, "16#7B")]
    [InlineData(1234, "16#4D2")]
    public void TestsHex_Bit(ulong zahl, string ergebnis)
    {
        var plc = new Uint(zahl);
        Assert.Equal(ergebnis, plc.GetHex());
    }


    [Theory]
    [InlineData("0", 0)]
    [InlineData("2#0001", 1)]
    [InlineData("2#0010", 2)]
    [InlineData("2#0100", 3)]
    [InlineData("2#1000", 4)]
    public void TestsAnzahlBit(string zahl, uint ergebnis)
    {
        var plc = new Uint(zahl);
        Assert.Equal(ergebnis, plc.GetAnzahlBit());
    }

}