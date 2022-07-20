using LibDatenstruktur;

namespace DtParkhaus.Model;

public class DatenRangieren

{
    private readonly ModelParkhaus _parkhaus;
    private readonly Datenstruktur _datenstruktur;

    public DatenRangieren(ModelParkhaus parkhaus, Datenstruktur datenstruktur)
    {
        _parkhaus = parkhaus;
        _datenstruktur = datenstruktur;
    }
    internal void Rangieren()
    {
        if (_datenstruktur.BetriebsartProjekt == BetriebsartProjekt.Simulation)
            _datenstruktur.SetBitmuster(DatenBereich.Di, 0,
                _parkhaus.ParkhausSpalte1, _parkhaus.ParkhausSpalte2,
                _parkhaus.ParkhausSpalte3, _parkhaus.ParkhausSpalte4, _parkhaus.ParkhausSpalte5,
                _parkhaus.ParkhausSpalte6, _parkhaus.ParkhausSpalte7, _parkhaus.ParkhausSpalte8);
        
        (_parkhaus.ParkhausReihe1, _parkhaus.ParkhausReihe2, _parkhaus.ParkhausReihe3, _parkhaus.ParkhausReihe4, _, _, _, _) = _datenstruktur.GetBitmuster(DatenBereich.Da, 0);
    }
}