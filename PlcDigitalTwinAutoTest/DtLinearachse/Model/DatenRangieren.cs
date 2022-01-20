using LibDatenstruktur;

namespace DtLinearachse.Model;

public class DatenRangieren

{
    private readonly ModelLinearachse _modelLinearachse;
    private readonly Datenstruktur _datenstruktur;

    public DatenRangieren(ModelLinearachse fibonacci, Datenstruktur datenstruktur)
    {
        _modelLinearachse = fibonacci;
        _datenstruktur = datenstruktur;
    }

    public void Rangieren()
    {
        _datenstruktur.SetBitmuster(DatenBereich.Di, 0, _modelLinearachse.S1);
        (_modelLinearachse.P1, _, _, _, _, _, _, _) = _datenstruktur.GetBitmuster(DatenBereich.Da, 0);
    }
}