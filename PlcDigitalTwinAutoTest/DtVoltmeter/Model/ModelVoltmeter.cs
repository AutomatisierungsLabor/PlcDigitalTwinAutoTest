using LibDatenstruktur;

namespace DtVoltmeter.Model;

public class ModelVoltmeter : BasePlcDtAt.BaseModel.BaseModel
{
    public int AnalogSignal { get; set; }
    public short BitmusterEinerStelle { get; set; }
    public short BitmusterZehnerStelle { get; set; }
    public short BitmusterHunderterStelle { get; set; }
    public short BitmusterTausenderStelle { get; set; }
    public bool HintergrundGruen { get; set; }
    public bool HintergrundGelb { get; set; }
    public bool HintergrundRot { get; set; }
    
    private readonly DatenRangieren _datenRangieren;


    public ModelVoltmeter(Datenstruktur datenstruktur, System.Threading.CancellationTokenSource cancellationTokenSource) : base(cancellationTokenSource, datenstruktur) => _datenRangieren = new DatenRangieren(this, datenstruktur);
    protected override void ModelSetValues() { }
    protected override void ModelThread(double dT) => _datenRangieren?.Rangieren();
}