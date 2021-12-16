namespace LibDatenstruktur;

public enum BetriebsartTestablauf
{
    Automatik = 0,
    // ReSharper disable once UnusedMember.Global
    Einzelschritt
}
public enum BetriebsartProjekt
{
    LaborPlatte = 0,
    // ReSharper disable UnusedMember.Global
    Simulation,
    AutomatischerSoftwareTest
}
public class Datenstruktur
{
    public BetriebsartProjekt BetriebsartProjekt;
    public BetriebsartTestablauf BetriebsartTestablauf;
    public bool NaechstenSchrittGehen;
    public byte[] BefehlePlc { get; set; } = new byte[1024];
    public byte[] VersionPlc { get; set; } = new byte[1024];
    public byte[] Di { get; set; } = new byte[1024];
    public byte[] Da { get; set; } = new byte[1024];
    public byte[] Ai { get; set; } = new byte[1024];
    public byte[] Aa { get; set; } = new byte[1024];

    public int SizeByteDi { get; set; }
    public int SizeByteDa { get; set; }
    public int SizeByteAi { get; set; }
    public int SizeByteAa { get; set; }
    public string TestProjektOrdner { get; set; }
    public int DiagrammZeitbereich { get; set; }

    public Datenstruktur()
    {
        TestProjektOrdner = "-";

        DiagrammZeitbereich = 20;
        BetriebsartTestablauf = BetriebsartTestablauf.Automatik;
        BetriebsartProjekt = BetriebsartProjekt.LaborPlatte;
        NaechstenSchrittGehen = false;

        Array.Clear(BefehlePlc, 0, BefehlePlc.Length);
        Array.Clear(VersionPlc, 0, VersionPlc.Length);
        Array.Clear(Di, 0, Di.Length);
        Array.Clear(Da, 0, Da.Length);
        Array.Clear(Ai, 0, Ai.Length);
        Array.Clear(Aa, 0, Aa.Length);
    }

    public void SetSizeDi(int anzByteDi) => SizeByteDi = anzByteDi;
    public void SetSizeDo(int anzByteDa) => SizeByteDa = anzByteDa;
    public void SetSizeAi(int anzByteAi) => SizeByteAi = anzByteAi;
    public void SetSizeAo(int anzByteAa) => SizeByteAa = anzByteAa;
}