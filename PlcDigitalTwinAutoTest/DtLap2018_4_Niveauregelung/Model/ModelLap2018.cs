using LibDatenstruktur;

namespace DtLap2018_4_Niveauregelung.Model;

public class ModelLap2018 : BasePlcDtAt.BaseModel.BaseModel
{
    public bool B1 { get; set; }
    public bool B2 { get; set; }
    public bool B3 { get; set; }
    public bool F1 { get; set; }
    public bool F2 { get; set; }
    public bool S1 { get; set; }
    public bool S2 { get; set; }
    public bool S3 { get; set; }
    public bool Q1 { get; set; }
    public bool Q2 { get; set; }
    public bool P1 { get; set; }
    public bool P2 { get; set; }
    public bool P3 { get; set; }
    public bool Y1 { get; set; }
    public double Pegel { get; set; }

    private readonly DatenRangieren _datenRangieren;

    private const double FuellGeschwindigkeit = 0.0008;
    private const double LeerGeschwindigkeit = 0.001;

    public ModelLap2018(Datenstruktur datenstruktur, System.Threading.CancellationTokenSource cancellationTokenSource) : base(cancellationTokenSource)
    {
        _datenRangieren = new DatenRangieren(this, datenstruktur);

        Pegel = 0.95;
    }
    protected override void ModelSetValues()
    {
        S2 = true;
        F1 = true;
        F2 = true;
    }
    protected override void ModelThread()
    {
        if (Q1) Pegel += FuellGeschwindigkeit;
        if (Q2) Pegel += FuellGeschwindigkeit;
        if (Y1) Pegel -= LeerGeschwindigkeit;

        if (Pegel > 1) Pegel = 1;
        if (Pegel < 0) Pegel = 0;

        B1 = Pegel > 0.1;   // Schliesser
        B2 = Pegel > 0.5;   // Schliesser
        B3 = Pegel < 0.9;   // Öffner

        _datenRangieren.Rangieren();
    }
}