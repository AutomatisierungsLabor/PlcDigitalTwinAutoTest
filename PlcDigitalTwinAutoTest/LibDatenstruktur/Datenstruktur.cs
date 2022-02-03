namespace LibDatenstruktur;

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

    public string VersionsStringLokal { get; set; }
    public string VersionsStringPlc { get; set; }

    public byte[] BefehlePlc { get; } = new byte[1024];

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
        BetriebsartProjekt = BetriebsartProjekt.LaborPlatte;
    }
    public void SetVersionLokal(string vLokal) => VersionsStringLokal = vLokal;
    public void SetBitmuster(DatenBereich datenBereich, short offset, params bool[] bits)
    {
        byte wert = 0;
        if (bits.Length > 8) throw new ArgumentOutOfRangeException($"{nameof(bits)}", $"{nameof(SetBitmuster)} zu viele bit");

        for (var i = 0; i < bits.Length; i++)
        {
            if (bits[i]) wert += LibPlcTools.Bitmuster.BitmusterErzeugen(i);
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

        var lsb = LibPlcTools.Bitmuster.BitmusterInByteTesten(wert, 0);
        var b1 = LibPlcTools.Bitmuster.BitmusterInByteTesten(wert, 1);
        var b2 = LibPlcTools.Bitmuster.BitmusterInByteTesten(wert, 2);
        var b3 = LibPlcTools.Bitmuster.BitmusterInByteTesten(wert, 3);
        var b4 = LibPlcTools.Bitmuster.BitmusterInByteTesten(wert, 4);
        var b5 = LibPlcTools.Bitmuster.BitmusterInByteTesten(wert, 5);
        var b6 = LibPlcTools.Bitmuster.BitmusterInByteTesten(wert, 6);
        var b7 = LibPlcTools.Bitmuster.BitmusterInByteTesten(wert, 7);

        return (lsb, b1, b2, b3, b4, b5, b6, b7);
    }
    public bool SimulationAktiv()
    {
        switch (BetriebsartProjekt)
        {

            case BetriebsartProjekt.Simulation:
            case BetriebsartProjekt.AutomatischerSoftwareTest:
                return true;
            case BetriebsartProjekt.BeschreibungAnzeigen:
            case BetriebsartProjekt.LaborPlatte:
            default:
                return false;
        }
    }
}