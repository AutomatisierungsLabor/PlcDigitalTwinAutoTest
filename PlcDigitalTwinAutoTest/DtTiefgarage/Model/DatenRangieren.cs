using LibDatenstruktur;

namespace DtTiefgarage.Model;

public class DatenRangieren

{
    private readonly ModelTiefgarage _tiefgarage;
    private readonly Datenstruktur _datenstruktur;

    public DatenRangieren(ModelTiefgarage tiefgarage, Datenstruktur datenstruktur)
    {
        _tiefgarage = tiefgarage;
        _datenstruktur = datenstruktur;
    }
    internal void Rangieren()
    {
        if (!_datenstruktur.SimulationAktiv()) return;

        _datenstruktur.SetBitmuster(DatenBereich.Di, 0, _tiefgarage.B1, _tiefgarage.B2);
        _tiefgarage.AnzahlAutos = _datenstruktur.GetByte(DatenBereich.Aa, 0);
        _tiefgarage.AnzahlPersonen = _datenstruktur.GetByte(DatenBereich.Aa, 1);
    }
}