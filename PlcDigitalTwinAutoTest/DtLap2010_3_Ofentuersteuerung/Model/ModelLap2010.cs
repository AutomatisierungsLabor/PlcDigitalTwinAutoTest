using LibDatenstruktur;

namespace DtLap2010_3_Ofentuersteuerung.Model;

public class ModelLap2010 : BasePlcDtAt.BaseModel.BaseModel
{
    public bool P1 { get; set; }    // "Schliessen"
    public bool Q1 { get; set; }    // Motor LL (Öffnen)
    public bool Q2 { get; set; }    // Motor RL (Schliessen)
    public bool S1 { get; set; }    // Taster "Halt"
    public bool S2 { get; set; }    // Taster "Öffnen"
    public bool S3 { get; set; }    // Taster "Schliessen"
    public bool B1 { get; set; }    // Endschalter Offen
    public bool B2 { get; set; }    // Endschalter Geschlossen
    public bool B3 { get; set; }    // Lichtschranke
    public double PositionZahnstange { get; set; }
    public double PositionOfentuere { get; set; }
    public double WinkelZahnrad { get; set; }

    private const double ZahnstangeLinks = -177;
    private const double ZahnstangeWeg = 220;
    private const double ZahnstangeGeschwindigkeit = 0.5;
    private const double AbstandZahnstangeOfentuere = 297;
    private const double FaktorPositionWinkel = 1.25;
    private const double OffsetWinkel = 6;

    private readonly DatenRangieren _datenRangieren;

    public ModelLap2010(Datenstruktur datenstruktur, System.Threading.CancellationTokenSource cancellationTokenSource) : base(cancellationTokenSource)
    {
        _datenRangieren = new DatenRangieren(this, datenstruktur);

        PositionZahnstange = ZahnstangeLinks + ZahnstangeWeg;
        PositionOfentuere = ZahnstangeLinks + AbstandZahnstangeOfentuere;
        WinkelZahnrad = 0;
    }
    protected override void ModelSetValues()
    {
        S1 = true;
        B3 = true;
    }
    protected override void ModelThread()
    {
        if (Q1) { PositionZahnstange -= ZahnstangeGeschwindigkeit; }
        if (Q2) { PositionZahnstange += ZahnstangeGeschwindigkeit; }

        if (PositionZahnstange < ZahnstangeLinks) PositionZahnstange = ZahnstangeLinks;
        if (PositionZahnstange > ZahnstangeLinks + ZahnstangeWeg) PositionZahnstange = ZahnstangeLinks + ZahnstangeWeg;

        PositionOfentuere = PositionZahnstange + AbstandZahnstangeOfentuere;
        WinkelZahnrad = OffsetWinkel + PositionOfentuere * FaktorPositionWinkel;

        B1 = PositionZahnstange < ZahnstangeLinks + 5;
        B2 = PositionZahnstange > ZahnstangeLinks + ZahnstangeWeg - 5;

        _datenRangieren.Rangieren();
    }
}