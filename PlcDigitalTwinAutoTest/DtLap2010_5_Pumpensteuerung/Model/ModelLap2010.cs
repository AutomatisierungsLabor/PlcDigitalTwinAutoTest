using LibDatenstruktur;

namespace DtLap2010_5_Pumpensteuerung.Model;

public class ModelLap2010 : BasePlcDtAt.BaseModel.BaseModel
{
    public bool S1 { get; set; } // Wahlschalter Hand
    public bool S2 { get; set; } // Wahlschalter Automatik
    public bool S3 { get; set; } // Störung quittieren
    public bool F1 { get; set; } // Thermorelais
    public bool B1 { get; set; } // Schwimmerschalter oben
    public bool B2 { get; set; } // Schwimmerschalter unten
    public bool Q1 { get; set; } // Motor Pumpe
    public bool P1 { get; set; } // "Pumpe Ein"
    public bool P2 { get; set; } // "Störung"
    public bool Y1 { get; set; } // Entleerungsventil
    public double Pegel { get; set; }

    private const double FuellGeschwindigkeit = 0.002;
    private const double LeerGeschwindigkeit = 0.001;

    private readonly DatenRangieren _datenRangieren;

    public ModelLap2010(Datenstruktur datenstruktur, System.Threading.CancellationTokenSource cancellationTokenSource) : base(cancellationTokenSource, datenstruktur)
    {
        _datenRangieren = new DatenRangieren(this, datenstruktur);

        Pegel = 0.95;
    }
    protected override void ModelSetValues()
    {
        F1 = true;
        S3 = true;
    }
    protected override void ModelThread(double dT)
    {
        if (Q1) Pegel += FuellGeschwindigkeit;
        if (Y1) Pegel -= LeerGeschwindigkeit;

        if (Pegel > 1) Pegel = 1;
        if (Pegel < 0) Pegel = 0;

        B1 = Pegel > 0.9;
        B2 = Pegel > 0.1;

        _datenRangieren.Rangieren();
    }
}