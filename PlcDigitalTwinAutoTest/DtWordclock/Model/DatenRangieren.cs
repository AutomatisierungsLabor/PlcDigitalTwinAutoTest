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
            _datenstruktur.SetBitmuster(DatenBereich.Di, 0, false);
        }

        (_wordclock.TextEins, _wordclock.TextZwei, _wordclock.TextDrei, _wordclock.TextVier, _wordclock.TextFuenfMinute, _wordclock.TextFuenfStunde, _wordclock.TextSechs, _wordclock.TextSieben) = _datenstruktur.GetBitmuster(DatenBereich.Da, 0);
        (_wordclock.TextAcht, _wordclock.TextNeun, _wordclock.TextZehnMinute, _wordclock.TextZehnStunde, _wordclock.TextElf, _wordclock.TextZwoelf, _wordclock.TextZwanzig, _wordclock.TextUhr) = _datenstruktur.GetBitmuster(DatenBereich.Da, 1);
        (_wordclock.TextEs, _wordclock.TextIst, _wordclock.TextBald, _wordclock.TextGleich, _wordclock.TextVor, _wordclock.TextNach, _wordclock.TextHalb, _wordclock.TextViertel) = _datenstruktur.GetBitmuster(DatenBereich.Da, 2);
    }
}