using System.Collections.Generic;
using System.Linq;
using LibDatenstruktur;

namespace DtLap2018_2_Abfuellanlage.Model;

public class ModelLap2018 : BasePlcDtAt.BaseModel.BaseModel
{
    public enum Bier
    {
        Fohrenburger = 0,
        Mohren
    }
    public Bier AktuellesBier { get; set; }
    public List<Flaschen> AlleFlaschen { get; set; }
    public bool B1 { get; set; }
    public bool F1 { get; set; }
    public bool S1 { get; set; }
    public bool S2 { get; set; }
    public bool S3 { get; set; }
    public bool S4 { get; set; }

    public bool K1 { get; set; }
    public bool K2 { get; set; }
    public bool P1 { get; set; }
    public bool P2 { get; set; }
    public bool Q1 { get; set; }

    public int FlaschenInDerKiste { get; set; }
    public double Pegel { get; set; }

    private readonly int _anzahlFlaschen;
    private int _aktuelleFlasche;

    private const double LeerGeschwindigkeit = 0.0005;

    private readonly DatenRangieren _datenRangieren;

    public ModelLap2018(Datenstruktur datenstruktur, System.Threading.CancellationTokenSource cancellationTokenSource) : base(cancellationTokenSource)
    {
        _datenRangieren = new DatenRangieren(this, datenstruktur);

        AlleFlaschen = new List<Flaschen>
        {
            new(_anzahlFlaschen++),
            new(_anzahlFlaschen++),
            new(_anzahlFlaschen++),
            new(_anzahlFlaschen++),
            new(_anzahlFlaschen++),
            new(_anzahlFlaschen++)
        };

        S2 = true;
        F1 = true;
        Pegel = 0.4;
    }
    protected override void ModelThread()
    {
        if (AlleFlaschen == null) return;


        if (K1) Pegel -= LeerGeschwindigkeit;
        if (Pegel < 0) Pegel = 0;

        if (K2) AlleFlaschen[_aktuelleFlasche].FlascheVereinzeln();

        B1 = false;
        foreach (var flasche in AlleFlaschen)
        {
            bool lichtschranke;
            (lichtschranke, _aktuelleFlasche) = flasche.FlascheBewegen(Q1, _anzahlFlaschen, _aktuelleFlasche);
            B1 |= lichtschranke;
        }

        var anzahlInDerKiste = AlleFlaschen.Count(flasche => flasche.GetBewegungSchritt() == Flaschen.BewegungSchritt.Fertig);

        FlaschenInDerKiste = anzahlInDerKiste;

        _datenRangieren?.Rangieren();
    }
    internal void TankNachfuellen() => Pegel = 1;
    internal void AllesReset()
    {
        Pegel = 0.4;
        _aktuelleFlasche = 0;
        AktuellesBier = AktuellesBier == Bier.Fohrenburger ? Bier.Mohren : Bier.Fohrenburger;

        foreach (var flasche in AlleFlaschen) { flasche.Reset(); }
    }
}