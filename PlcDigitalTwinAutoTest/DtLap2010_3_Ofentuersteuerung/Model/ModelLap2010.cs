using System;
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

    private const double DauerOeffnen = 5.0;
    private double _laufzeitOfentuere;

    private const double AbstandEndschalter = 0.01;

    private const double ZahnstangeLinks = -177;
    private const double ZahnstangeWeg = 220;
    private const double ZahnstangeGeschwindigkeit = 0.5;
    private const double AbstandZahnstangeOfentuere = 297;
    private const double FaktorPositionWinkel = 1.25;
    private const double OffsetWinkel = 6;

    private readonly DatenRangieren _datenRangieren;

    public ModelLap2010(Datenstruktur datenstruktur, System.Threading.CancellationTokenSource cancellationTokenSource) : base(cancellationTokenSource, datenstruktur)
    {
        _datenRangieren = new DatenRangieren(this, datenstruktur);

        PositionZahnstange = ZahnstangeLinks + ZahnstangeWeg;
        PositionOfentuere = 0;
        WinkelZahnrad = 0;
    }
    protected override void ModelSetValues()
    {
        S1 = true;
        B3 = true;
    }
    protected override void ModelThread(double dT)
    {
        if (Q1) _laufzeitOfentuere += dT;
        if (Q2) _laufzeitOfentuere -= dT;

        _laufzeitOfentuere = Math.Min(_laufzeitOfentuere, DauerOeffnen);
        PositionOfentuere = _laufzeitOfentuere / DauerOeffnen;


        /*

        if (PositionZahnstange < ZahnstangeLinks) PositionZahnstange = ZahnstangeLinks;
        if (PositionZahnstange > ZahnstangeLinks + ZahnstangeWeg) PositionZahnstange = ZahnstangeLinks + ZahnstangeWeg;

        PositionOfentuere = PositionZahnstange + AbstandZahnstangeOfentuere;
        WinkelZahnrad = OffsetWinkel + PositionOfentuere * FaktorPositionWinkel;

    
        */

        B1 = PositionOfentuere < 1 - AbstandEndschalter;    // linke Endlage - offen        (Öffner)
        B2 = PositionOfentuere > AbstandEndschalter;        // rechte Endlage - geschlossen (Öffner)


        _datenRangieren.Rangieren();
    }
}