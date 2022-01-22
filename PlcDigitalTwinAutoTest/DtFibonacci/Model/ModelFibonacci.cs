using LibDatenstruktur;

namespace DtFibonacci.Model;

public class ModelFibonacci : BasePlcDtAt.BaseModel.BaseModel
{
    public bool P1 { get; set; }
    public bool S1 { get; set; }

    private readonly Datenstruktur _datenstruktur;
    private readonly DatenRangieren _datenRangieren;

    public ModelFibonacci(Datenstruktur datenstruktur, System.Threading.CancellationTokenSource cancellationTokenSource) : base(cancellationTokenSource)
    {
        _datenstruktur = datenstruktur;
        _datenRangieren = new DatenRangieren(this, _datenstruktur);
    }
    protected override void ModelThread()
    {   
        _datenRangieren.Rangieren();
    }
    public void SetVersionLokal(string vLokal) => _datenstruktur.VersionsStringLokal = vLokal;
}