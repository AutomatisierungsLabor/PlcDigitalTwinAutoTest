using LibDatenstruktur;

namespace DtBlinker.Model;

public class DatenRangieren

{
    private readonly ModelBlinker _blinker;
    private readonly Datenstruktur _datenstruktur;

    public DatenRangieren(ModelBlinker kata, Datenstruktur datenstruktur)
    {
        _blinker = kata;
        _datenstruktur = datenstruktur;
    }
    internal void Rangieren()
    {
        if (_datenstruktur.SimulationAktiv())
        {
            _datenstruktur.SetBitmuster(DatenBereich.Di, 0, _blinker.S1, _blinker.S2, _blinker.S3, _blinker.S4, _blinker.S5);
        }
        else
        {
            (_blinker.S1, _blinker.S2, _blinker.S3, _blinker.S4, _blinker.S5, _, _, _) = _datenstruktur.GetBitmuster(DatenBereich.Di, 0);
        }

        (_blinker.P1, _, _, _, _, _, _, _) = _datenstruktur.GetBitmuster(DatenBereich.Da, 0);
    }
}