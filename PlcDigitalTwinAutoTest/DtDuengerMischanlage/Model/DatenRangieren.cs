using LibDatenstruktur;

namespace DtDuengerMischanlage.Model;

public class DatenRangieren

{
    private readonly ModelMischanlage _modelMischanlage;
    private readonly Datenstruktur _datenstruktur;

    public DatenRangieren(ModelMischanlage modelMischanlage, Datenstruktur datenstruktur)
    {
        _modelMischanlage = modelMischanlage;
        _datenstruktur = datenstruktur;
    }
    internal void Rangieren()
    {
        if (_datenstruktur.BetriebsartProjekt == BetriebsartProjekt.Simulation) _datenstruktur.SetBitmuster(DatenBereich.Di, 0, _modelMischanlage.S1);

        (_modelMischanlage.P1, _, _, _, _, _, _, _) = _datenstruktur.GetBitmuster(DatenBereich.Da, 0);
    }
}