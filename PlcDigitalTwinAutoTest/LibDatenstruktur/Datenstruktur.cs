namespace LibDatenstruktur;

public enum BetriebsartTestablauf
{
    Automatik = 0,
    // ReSharper disable once UnusedMember.Global
    Einzelschritt
}
public enum BetriebsartProjekt
{
    BeschreibungAnzeigen = 0,
    LaborPlatte = 1,
    Simulation = 2,
    AutomatischerSoftwareTest = 3
}

public enum DatenBereich
{
    Di = 0,
    Da = 1,
    Ai = 2,
    Aa = 3
}
public class Datenstruktur
{
    public BetriebsartProjekt BetriebsartProjekt;
    public BetriebsartTestablauf BetriebsartTestablauf;
    public bool NaechstenSchrittGehen;

    public string LokaleVersion;
    public string PlcVersion;

    public byte[] BefehlePlc { get; } = new byte[1024];
    public byte[] VersionPlc { get; } = new byte[1024];
    public byte[] Di { get; } = new byte[1024];
    public byte[] Da { get; } = new byte[1024];
    public byte[] Ai { get; } = new byte[1024];
    public byte[] Aa { get; } = new byte[1024];

    public string TestProjektOrdner { get; set; }
    public int DiagrammZeitbereich { get; set; }

    public Datenstruktur()
    {
        TestProjektOrdner = "-";

        DiagrammZeitbereich = 20;
        BetriebsartTestablauf = BetriebsartTestablauf.Automatik;
        BetriebsartProjekt = BetriebsartProjekt.LaborPlatte;
        NaechstenSchrittGehen = false;
    }

    public void SetBitmuster(DatenBereich datenBereich, short offset, params bool[] bits)
    {
        byte wert = 0;
        if (bits.Length > 8)
            throw new ArgumentOutOfRangeException($"{nameof(bits)}", $"{nameof(SetBitmuster)} zu viele bit");

        for (var i = 0; i < bits.Length; i++)
        {
            if (bits[i]) wert += (byte)(1 << i);
        }

        switch (datenBereich)
        {
            case DatenBereich.Di: Di[offset] = wert; break;
            case DatenBereich.Da: Da[offset] = wert; break;
            case DatenBereich.Ai: Ai[offset] = wert; break;
            case DatenBereich.Aa: Aa[offset] = wert; break;
            default: throw new ArgumentOutOfRangeException(nameof(datenBereich), datenBereich, null);
        }
    }
    public (bool lsb, bool b1, bool b2, bool b3, bool b4, bool b5, bool b6, bool b7) GetBitmuster(DatenBereich datenBereich, short offset)
    {
        var wert = datenBereich switch
        {
            DatenBereich.Di => Di[offset],
            DatenBereich.Da => Da[offset],
            DatenBereich.Ai => Ai[offset],
            DatenBereich.Aa => Aa[offset],
            _ => throw new ArgumentOutOfRangeException(nameof(datenBereich), datenBereich, null)
        };

        var lsb = (wert & (1 << 0)) > 0;
        var b1 = (wert & (1 << 1)) > 0;
        var b2 = (wert & (1 << 2)) > 0;
        var b3 = (wert & (1 << 3)) > 0;
        var b4 = (wert & (1 << 4)) > 0;
        var b5 = (wert & (1 << 5)) > 0;
        var b6 = (wert & (1 << 6)) > 0;
        var b7 = (wert & (1 << 7)) > 0;

        return (lsb, b1, b2, b3, b4, b5, b6, b7);
    }
}