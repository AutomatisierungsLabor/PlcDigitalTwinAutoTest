using System.Threading;
using BasePlcDtAt.BaseModel;
using LibDatenstruktur;

namespace DtAmpelVerbania.Model;

public class ModelAmpelVarbania : BaseModel
{
    public bool S1 { get; set; }        // Taster "Fußgänger" 
    public bool S2 { get; set; }        // Modus 7-Segment Anzeige aktiv
    public bool P11 { get; set; }       // Autoampel - rot
    public bool P12 { get; set; }       // Autoampel - gelb
    public bool P13 { get; set; }       // Autoampel - grün
    public bool P21 { get; set; }       // Fußgängerampel - rot 
    public bool P22 { get; set; }       // Fußgängerampel - gelb 
    public bool P23 { get; set; }       // Fußgängerampel - grün
    public bool P31 { get; set; }       // Fußgängerampel - Anzeige rot 
    public bool P32 { get; set; }       // Fußgängerampel - Anzeige gelb
    public bool P33 { get; set; }       // Fußgängerampel - Anzeige grün
    public byte AlleSegmente { get; set; }
    public byte Anzeige { get; set; }   // Fußgängerampel - Anzeige (Wert)

    private readonly DatenRangieren _datenRangieren;

    public ModelAmpelVarbania(Datenstruktur datenstruktur, CancellationTokenSource cancellationTokenSource) : base(cancellationTokenSource) => _datenRangieren = new DatenRangieren(this, datenstruktur);
    protected override void ModelSetValues() { }
    protected override void ModelThread() => _datenRangieren?.Rangieren();
}