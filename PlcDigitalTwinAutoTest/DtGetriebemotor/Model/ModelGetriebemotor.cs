using LibDatenstruktur;
using System.Threading;

namespace DtGetriebemotor.Model;

public class ModelGetriebemotor : BasePlcDtAt.BaseModel.BaseModel
{
    public bool B1 { get; set; }    // Lichtschranke 0° 
    public bool B2 { get; set; }    // Lichtschranke 45° CCW
    public bool S1 { get; set; }    // Taster ( ① ) → Schliesser
    public bool S2 { get; set; }    // Taster ( ⓪ ) → Öffner
    public bool S4 { get; set; }    // Taster ( STOP ) → Öffner 
    public bool S3 { get; set; }    // Taster ( Ⅰ ) → Schliesser 
    public bool S5 { get; set; }    // Taster ( Ⅱ ) → Schliesser 
    public bool S7 { get; set; }    // Taster (STOP) → Öffner
    public bool S6 { get; set; }    // Taster (←) → Schliesser
    public bool S8 { get; set; }    // Taster (→) → Schliesser
    public bool S91 { get; set; }   // Not-Halt → Schliesser 
    public bool S92 { get; set; }   // Not-Halt → Öffner
    public bool P1 { get; set; }    // Meldeleuchte weiß
    public bool P2 { get; set; }    // Meldeleuchte rot
    public bool P3 { get; set; }    // Meldeleuchte grün
    public bool Q1 { get; set; }    // Getriebemotor Schnell Rechtslauf
    public bool Q2 { get; set; }    // Getriebemotor Linkslauf
    public bool Q3 { get; set; }    // Getriebemotor Langsam Rechtslauf

    public double WinkelGetriebemotor { get; set; }

    private const double GeschwindigkeitGetriebemotorLangsam = 1;
    private const double GeschwindigkeitGetriebemotorSchnell = 2 * GeschwindigkeitGetriebemotorLangsam;

    private readonly Datenstruktur _datenstruktur;
    private readonly DatenRangieren _datenRangieren;

    public ModelGetriebemotor(Datenstruktur datenstruktur, CancellationTokenSource cancellationTokenSource) : base(cancellationTokenSource)
    {
        _datenstruktur = datenstruktur;
        _datenRangieren = new DatenRangieren(this, _datenstruktur);

        S2 = true;
        S4 = true;
        S7 = true;
        S92 = true;
    }
    protected override void ModelThread()
    {
        if (Q2)
        {
            // Linkslauf
            if (Q1) WinkelGetriebemotor -= GeschwindigkeitGetriebemotorSchnell;
            if (Q3) WinkelGetriebemotor -= GeschwindigkeitGetriebemotorLangsam;
        }
        else
        {
            // Rechtslauf
            if (Q1) WinkelGetriebemotor += GeschwindigkeitGetriebemotorSchnell;
            if (Q3) WinkelGetriebemotor += GeschwindigkeitGetriebemotorLangsam;
        }


        if (WinkelGetriebemotor > 360) WinkelGetriebemotor -= 360;
        if (WinkelGetriebemotor < 0) WinkelGetriebemotor += 360;

        B1 = WinkelGetriebemotor is > 80 and < 100;
        B2 = WinkelGetriebemotor is > 35 and < 55;

        _datenRangieren?.Rangieren();
    }
    public void SetVersionLokal(string vLokal) => _datenstruktur.VersionsStringLokal = vLokal;
}