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

    public int AnzByteDi { get; set; }
    public int AnzByteDa { get; set; }
    public int AnzByteAi { get; set; }
    public int AnzByteAa { get; set; }
    public string TestProjektOrdner { get; set; }
    public int DiagrammZeitbereich { get; set; }


    public Datenstruktur(int anzByteDi, int anzByteDa, int anzByteAi, int anzByteAa)
    {
        TestProjektOrdner = "-";

        AnzByteDi = anzByteDi;
        AnzByteDa = anzByteDa;
        AnzByteAi = anzByteAi;
        AnzByteAa = anzByteAa;

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
}