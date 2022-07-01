using LibDatenstruktur;

namespace DtDuengerMischanlage.Model;

public class ModelMischanlage : BasePlcDtAt.BaseModel.BaseModel
{
    public bool S1 { get; set; }
    public bool P1 { get; set; }
 

    private readonly DatenRangieren _datenRangieren;

    public ModelMischanlage(Datenstruktur datenstruktur, System.Threading.CancellationTokenSource cancellationTokenSource) : base(cancellationTokenSource) => _datenRangieren = new DatenRangieren(this, datenstruktur);
    protected override void ModelThread() => _datenRangieren?.Rangieren();
}