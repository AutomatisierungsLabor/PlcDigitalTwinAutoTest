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

    public void Rangieren()
    {
        _datenstruktur.SetBitmuster(DatenBereich.Di, 0, _blinker.S1, _blinker.S2, _blinker.S3, _blinker.S4, _blinker.S5);
        (_blinker.P1, _, _, _, _, _, _, _) = _datenstruktur.GetBitmuster(DatenBereich.Da, 0);
    }
}