using System;
using LibDatenstruktur;

namespace DtLap2010_2_Transportwagen.Model;

public class ModelLap2010 : BasePlcDtAt.BaseModel.BaseModel
{
    public bool Q1 { get; set; }    // Motor LL
    public bool Q2 { get; set; }    // Motor RL
    public bool P1 { get; set; }    // Störung
    public bool S1 { get; set; }    // Taster "Start"
    public bool S2 { get; set; }    // NotHalt
    public bool S3 { get; set; }    // Taster Reset
    public bool F1 { get; set; }    // Thermorelais
    public bool B1 { get; set; }    // Endschalter Links
    public bool B2 { get; set; }    // Endschalter Rechts
    public double PositionWagen { get; set; }
    public bool Fuellen { get; internal set; }
    public double LaufzeitFuellen { get; set; }

    private const double FahrwegZeit = 5.0;
    private const double FuellenZeit = 5.0; // Wartezeit SPS Beispiel: 7"

    private const double BereichSensor = 0.01;

    private double _laufzeitPosition;

    private readonly DatenRangieren _datenRangieren;

    public ModelLap2010(Datenstruktur datenstruktur, System.Threading.CancellationTokenSource cancellationTokenSource) : base(cancellationTokenSource, datenstruktur)
    {
        _datenRangieren = new DatenRangieren(this, datenstruktur);

        LaufzeitFuellen = 0;
        _laufzeitPosition = 0;
    }
    protected override void ModelSetValues()
    {
        F1 = true;
        S2 = true;
    }
    protected override void ModelThread(double dT)
    {
        if (B2) LaufzeitFuellen += dT; else  LaufzeitFuellen = 0;
        Fuellen = LaufzeitFuellen is > 0.01 and < FuellenZeit;

        if (Q1) _laufzeitPosition -= dT;
        if (Q2) _laufzeitPosition += dT;
        _laufzeitPosition = Math.Min(_laufzeitPosition, FahrwegZeit);
        _laufzeitPosition = Math.Max(_laufzeitPosition, 0);

        PositionWagen = _laufzeitPosition / FahrwegZeit;

        B1 = PositionWagen < BereichSensor;
        B2 = PositionWagen > 1 - BereichSensor;

        _datenRangieren.Rangieren();
    }
}