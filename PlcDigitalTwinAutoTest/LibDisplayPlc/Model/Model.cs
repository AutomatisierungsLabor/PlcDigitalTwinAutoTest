using LibDatenstruktur;

namespace LibDisplayPlc.Model;

public class Model : BasePlcDtAt.BaseModel.Model
{
    private readonly Datenstruktur _datenstruktur;

    public Model(Datenstruktur datenstruktur)
    {
        _datenstruktur = datenstruktur;
    }
    protected override void ModelThread()
    {

    }
}