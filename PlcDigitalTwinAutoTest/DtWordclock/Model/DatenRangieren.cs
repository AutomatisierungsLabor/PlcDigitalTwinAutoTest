using LibDatenstruktur;

namespace DtWordclock.Model;

public class DatenRangieren

{
    private readonly ModelWordclock _wordclock;
    private readonly Datenstruktur _datenstruktur;

    public DatenRangieren(ModelWordclock wordclock, Datenstruktur datenstruktur)
    {
        _wordclock = wordclock;
        _datenstruktur = datenstruktur;
    }
    internal void Rangieren()
    {
        if (_datenstruktur.SimulationAktiv())
        {
            _datenstruktur.SetBitmuster(DatenBereich.Di, 0, false );
        }

        (_, _, _, _, _, _, _, _) = _datenstruktur.GetBitmuster(DatenBereich.Da, 0);
    }
}