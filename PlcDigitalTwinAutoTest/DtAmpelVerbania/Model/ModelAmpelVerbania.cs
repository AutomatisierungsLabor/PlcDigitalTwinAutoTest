using System.Diagnostics;
using LibDatenstruktur;

namespace DtAmpelVerbania.Model;

public class ModelAmpelVarbania : BasePlcDtAt.BaseModel.BaseModel
{
 

    private readonly DatenRangieren _datenRangieren;
    
    public ModelAmpelVarbania(Datenstruktur datenstruktur, System.Threading.CancellationTokenSource cancellationTokenSource) : base(cancellationTokenSource)
    {
        _datenRangieren = new DatenRangieren(this, datenstruktur);

    }
    protected override void ModelThread()
    {
       

        _datenRangieren?.Rangieren();
    }
}