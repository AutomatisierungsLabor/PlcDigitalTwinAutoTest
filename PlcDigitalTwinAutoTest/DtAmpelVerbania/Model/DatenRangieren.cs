using LibDatenstruktur;

namespace DtAmpelVerbania.Model;

public class DatenRangieren

{
    private readonly ModelAmpelVarbania _ampelVarbania;
    private readonly Datenstruktur _datenstruktur;

    public DatenRangieren(ModelAmpelVarbania ampelVarbania, Datenstruktur datenstruktur)
    {
        _ampelVarbania = ampelVarbania;
        _datenstruktur = datenstruktur;
    }
    internal void Rangieren()
    {
        if (_datenstruktur.SimulationAktiv())
        {
            _datenstruktur.SetBitmuster(DatenBereich.Di, 0, _ampelVarbania.S1, _ampelVarbania.S2);
        }

        (_ampelVarbania.P11, _ampelVarbania.P12, _ampelVarbania.P13, _, _, _, _, _) = _datenstruktur.GetBitmuster(DatenBereich.Da, 0);
        (_ampelVarbania.P21, _ampelVarbania.P22, _ampelVarbania.P23, _ampelVarbania.P31, _ampelVarbania.P32, _ampelVarbania.P33, _, _) = _datenstruktur.GetBitmuster(DatenBereich.Da, 1);
        _ampelVarbania.AlleSegmente = _datenstruktur.GetByte(DatenBereich.Da, 2);

        _ampelVarbania.Anzeige = _datenstruktur.GetByte(DatenBereich.Aa, 0);
    }
}