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
    public double PositionOfentuere { get; set; }

    private const double DauerOeffnen = 5.0;
    private double _laufzeitOfentuere;

    private const double AbstandEndschalter = 0.01;

    private readonly DatenRangieren _datenRangieren;

    public ModelLap2010(Datenstruktur datenstruktur, System.Threading.CancellationTokenSource cancellationTokenSource) : base(cancellationTokenSource, datenstruktur) => _datenRangieren = new DatenRangieren(this, datenstruktur);
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

        B1 = PositionOfentuere < 1 - AbstandEndschalter;    // linke Endlage - offen        (Öffner)
        B2 = PositionOfentuere > AbstandEndschalter;        // rechte Endlage - geschlossen (Öffner)
        
        _datenRangieren.Rangieren();
    }
}