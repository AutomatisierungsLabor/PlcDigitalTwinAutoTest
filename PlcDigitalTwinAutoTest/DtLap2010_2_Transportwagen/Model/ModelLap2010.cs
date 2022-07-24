using System;
using System.Diagnostics;
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

    private const double FahrwegZeit = 5.0;
    private const double FuellenZeit = 5.0;

    private const double BereichSensor = 0.1; // Zykluszeit ist 10ms --> 5 oder 7"
    private double _laufzeitFuellen;
    private double _laufzeitPosition;

    private readonly DatenRangieren _datenRangieren;

    public ModelLap2010(Datenstruktur datenstruktur, System.Threading.CancellationTokenSource cancellationTokenSource) : base(cancellationTokenSource)
    {
        _datenRangieren = new DatenRangieren(this, datenstruktur);

        _laufzeitFuellen = 0;
        _laufzeitPosition = 0;
    }
    protected override void ModelSetValues()
    {
        F1 = true;
        S2 = true;
    }
    protected override void ModelThread()
    {
        if (B1) _laufzeitFuellen = 0;
        if (B2) _laufzeitFuellen += Contracts.BaseFunctions.ThreadZyklusZeit;
        _laufzeitFuellen = Math.Min(_laufzeitFuellen, FuellenZeit);
        _laufzeitFuellen = Math.Max(_laufzeitFuellen, 0);

        Fuellen = _laufzeitFuellen > 0.1;

        if (Q1) _laufzeitPosition -= Contracts.BaseFunctions.ThreadZyklusZeit;
        if (Q2) _laufzeitPosition += Contracts.BaseFunctions.ThreadZyklusZeit;
        _laufzeitPosition = Math.Min(_laufzeitPosition, FahrwegZeit);
        _laufzeitPosition = Math.Max(_laufzeitPosition, 0);

        PositionWagen = _laufzeitPosition / FahrwegZeit;

        B1 = PositionWagen < BereichSensor;
        B2 = PositionWagen > 1 - BereichSensor;

        _datenRangieren.Rangieren();
    }
}