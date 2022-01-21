using LibDatenstruktur;

namespace DtLinearachse.Model;

public class ModelLinearachse : BasePlcDtAt.BaseModel.BaseModel
{
    public bool B1 { get; set; }    // Linearachse Endlage links → Öffner
    public bool B2 { get; set; }    // Linearachse Endlage rechts → Öffner
    public bool S2 { get; set; }    // Taster ( ⓪ ) → Öffner 
    public bool S1 { get; set; }    // Taster ( ① ) → Schliesser 
    public bool S4 { get; set; }    // Taster ( Ⅱ ) → Schliesser 
    public bool S3 { get; set; }    // Taster ( Ⅰ ) → Schliesser
    public bool S6 { get; set; }    // Taster ( ↓ ) → Schliesser
    public bool S5 { get; set; }    // Taster ( ↑ ) → Schliesser 

    public bool S8 { get; set; }    // Taster ( － ) → Schliesser 
    public bool S7 { get; set; }    // Taster ( + ) → Schliesser 
    public bool S9 { get; set; }    // Taster ( STOP ) → Öffner 
    public bool S10 { get; set; }   // Not-Halt → Öffner
    public bool S11 { get; set; }   // Not-Halt → Schliesser 

    public bool P1 { get; set; }    // Meldeleuchte im Taster S1/S2 (weiß) 
    public bool P2 { get; set; }    // Meldeleuchte weiß
    public bool P3 { get; set; }    // Meldeleuchte rot
    public bool P4 { get; set; }    // Meldeleuchte grün
    public bool Q1 { get; set; }    // Linearachse Rechtslauf
    public bool Q2 { get; set; }    // Linearachse Linkslauf

    public double PositionSchlitten { get; set; }

    private const double GeschwindigkeitSchlitten = 0.4;
    private const double SchlittenBreite = 525;
    private const double SchlittenEndschalterBreite = 10;
    private const double SchlittenLinkerRand = SchlittenEndschalterBreite;
    private const double SchlittenRechterRand = SchlittenBreite - SchlittenEndschalterBreite;

    private readonly Datenstruktur _datenstruktur;
    private readonly DatenRangieren _datenRangieren;

    public ModelLinearachse(Datenstruktur datenstruktur)
    {
        _datenstruktur = datenstruktur;
        _datenRangieren = new DatenRangieren(this, _datenstruktur);

        S2 = true;
        S9 = true;
        S10 = true;
    }
    protected override void ModelThread()
    {

        if (Q1) PositionSchlitten += GeschwindigkeitSchlitten;
        if (Q2) PositionSchlitten -= GeschwindigkeitSchlitten;

        if (PositionSchlitten > SchlittenBreite) PositionSchlitten = SchlittenBreite;
        if (PositionSchlitten < 0) PositionSchlitten = 0;

        B1 = PositionSchlitten > SchlittenLinkerRand;   // Öffner
        B2 = PositionSchlitten < SchlittenRechterRand;  //Öffner

        _datenRangieren.Rangieren();
    }
    public void SetVersionLokal(string vLokal) => _datenstruktur.VersionsStringLokal = vLokal;
}