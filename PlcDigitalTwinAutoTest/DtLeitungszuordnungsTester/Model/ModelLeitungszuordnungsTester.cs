using LibDatenstruktur;

namespace DtLeitungszuordnungsTester.Model;

public class ModelLeitungszuordnungsTester : BasePlcDtAt.BaseModel.BaseModel
{
    private readonly DatenRangieren _datenRangieren;

    public ModelLeitungszuordnungsTester(Datenstruktur datenstruktur, System.Threading.CancellationTokenSource cancellationTokenSource) : base(cancellationTokenSource) => _datenRangieren = new DatenRangieren(this, datenstruktur);
    protected override void ModelThread() => _datenRangieren.Rangieren();
}