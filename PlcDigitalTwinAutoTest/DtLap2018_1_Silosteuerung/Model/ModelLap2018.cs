using System.Diagnostics.CodeAnalysis;
using LibDatenstruktur;

namespace DtLap2018_1_Silosteuerung.Model;

public class ModelLap2018 : BasePlcDtAt.BaseModel.BaseModel
{
    public Wagen Wagen { get; set; }
    public Silo Silo { get; set; }

    public bool B1 { get; set; }        // Wagen Position rechts
    public bool B2 { get; set; }        // Wagen voll
    public bool F1 { get; set; }        // Motorschutzschalter Förderband
    public bool F2 { get; set; }        // Motorschutzschalter Schneckenförderer
    public bool S0 { get; set; }        // Taster Aus
    public bool S1 { get; set; }        // Taster Ein
    public bool S2 { get; set; }        // Not-Halt
    public bool S3 { get; set; }        // Taster Störungen quittieren

    public bool P1 { get; set; }        // Anlage Ein
    public bool P2 { get; set; }        // Sammelstörung
    public bool Q1 { get; set; }        // Förderband 
    public bool Q2 { get; set; }        // Freigabe FU Schneckenförderer
    public bool Y1 { get; set; }        // Magnetventil Silo

    public bool RutscheVoll { get; set; }

    private readonly DatenRangieren _datenRangieren;

    public ModelLap2018(Datenstruktur datenstruktur, System.Threading.CancellationTokenSource cancellationTokenSource) : base(cancellationTokenSource)
    {
        _datenRangieren = new DatenRangieren(this, datenstruktur);

        Wagen = new Wagen();
        Silo = new Silo();

        RutscheVoll = true;

        F1 = true;
        F2 = true;

        S0 = true;
        S2 = true;
    }

    [SuppressMessage("ReSharper", "ConditionIsAlwaysTrueOrFalse")]
    protected override void ModelThread()
    {
        if (Wagen != null && Silo != null)  // Reihenfolge der Aufrufe ist nicht immer definiert!
        {
            Wagen.WagenTask();
            B1 = Wagen.IstWagenRechts();
            B2 = Wagen.IstWagenVoll();

            if (Y1) Silo.Leeren();

            if (Q2) Silo.Fuellen(RutscheVoll);

            if (Silo.GetFuellstand() > 0 && Q1 && Y1) Wagen.Fuellen();
        }
        _datenRangieren.Rangieren();
    }

    internal void WagenNachLinks() => Wagen.NachLinks();
    internal void WagenNachRechts() => Wagen.NachRechts();
}